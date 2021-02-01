using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using jCoreDemoApp.Domain.Entities;


namespace jCoreDemoApp.WebUI.Controllers
{
    public interface IThrottledHttpClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri">URL Endpoint + parameters</param>
        /// <param name="requestLimit">Max number of concurrent requests</param>
        /// <param name="limitingPeriodInSeconds">per second or per n seconds</param>
        /// <returns>json data of all the Organization phones</returns>
        Task<List<T>> GetData<T>(string uri, int requestLimit = 10, int limitingPeriodInSeconds = 20);
    }    
    [ApiController]
    [Route("[controller]")]
    public class OrganizationSummaryController : ControllerBase
    {
        private int callCounter=0;
        private async Task<List<T>> GetData<T>(string uri)
        {
            Console.WriteLine(uri+" . Call# "+ callCounter.ToString() );
            var dataSet = new List<T>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        dataSet = JsonSerializer.Deserialize<List<T>>(apiResponse);              
                    }
                }
                return dataSet;
        }

        [HttpGet]        
        public async Task<IActionResult> Get()
        {                                                
            callCounter=0;
            try
            {
                var organizations = await GetData<Organization>("https://5f0ddbee704cdf0016eaea16.mockapi.io/organizations");

                var response = new List<OrganizationSummary>();
                var responseUsers = new List<UserPhoneGroup>();
                int blacklistTotal=0,totalCount=0;
    
                foreach(var o in organizations)
                {
                    var users = await GetData<User>("https://5f0ddbee704cdf0016eaea16.mockapi.io/organizations/"+o.id+"/users");
                    callCounter++;

                    var organizationUsers = users.Where(x => x.organizationId == o.id);

                    foreach(var ou in organizationUsers){
                    if(callCounter>11)//Work around, issue with AspNetCoreRateLimit 
                    {
                        System.Threading.Thread.Sleep(20000); callCounter=0;
                    }                
                        var phones = await GetData<Phone>("https://5f0ddbee704cdf0016eaea16.mockapi.io/organizations/"+o.id+"/users/"+ou.id+"/phones");
                        callCounter++;               

                        var currentUserPhoneList = phones.Where(x => x.userId == ou.id);
                        var currentUserPhonesBlacklisted = currentUserPhoneList.Where(x => x.Blacklist == true);
                        var currentUserPhone = currentUserPhoneList.FirstOrDefault();

                        if(currentUserPhone != null){
                            responseUsers.Add(new UserPhoneGroup{id=currentUserPhone.userId, email=ou.email, phoneCount=currentUserPhoneList.Count()});
                            totalCount += currentUserPhoneList.Count();
                            blacklistTotal += currentUserPhonesBlacklisted.Count();                        
                        }
                    }                
                    response.Add(new OrganizationSummary{id=o.id, name=o.name, blacklistTotal=blacklistTotal, totalCount=totalCount, users=responseUsers});

                    responseUsers = new List<UserPhoneGroup>();
                    blacklistTotal = totalCount = 0;//System.Threading.Thread.Sleep(2000);
                }
                return Ok(response);
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
                return Conflict();
            }
        }                
    }
}
