using jCoreDemoApp.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace jCoreDemoApp.WebUI.Controllers
{
    public class WeatherForecastController : ApiControllerBase
    {
        [HttpGet]
        public async Task<RootObject> Get()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}
