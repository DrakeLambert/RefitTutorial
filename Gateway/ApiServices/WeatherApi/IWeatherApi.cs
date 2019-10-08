using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace DrakeLambert.RefitTutorial.Gateway.ApiServices.WeatherApi
{
    public interface IWeatherApi
    {
        [Get("/data/2.5/weather?zip={zipCode}")]
        Task<WeatherDto> GetWeatherByZipCode([Query]string zipCode);
    }

    public class WeatherDto
    {
        public IEnumerable<WeatherDescriptionsDto> Weather { get; set; }
    }

    public class WeatherDescriptionsDto
    {
        public string Description { get; set; }
    }
}

/*
URL: 

GET http://api.openweathermap.org/data/2.5/weather?zip={zipCode}&appid={appId}

Response: 

{
    weather: [
        {
            description: string
        }
    ]
}

 */
