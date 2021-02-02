using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace jCoreDemoApp.Application.WeatherForecasts.Queries.GetWeatherForecasts
{
    public class GetWeatherForecastsQuery : IRequest<RootObject>{}   
    public class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, RootObject>
    {
        public Task<RootObject> Handle(GetWeatherForecastsQuery request, CancellationToken cancellationToken)
        {
            //TODO, StringBuilder, and use parameters
            var uri = "https://api.openweathermap.org/data/2.5/weather?q=New%20York,us&units=metric&APPID=a382ba56864d4c04ef13a65d92261590";            
            Console.WriteLine(uri);
            var vm = GetData<RootObject>(uri);
            return vm;
        }

        private async Task<T> GetData<T>(string uri)
        {
            Console.WriteLine(uri);
            T dataSet =  default(T);
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(uri))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        dataSet = JsonSerializer.Deserialize<T>(apiResponse);              
                    }
                }
                return dataSet;
        }
    }
}
