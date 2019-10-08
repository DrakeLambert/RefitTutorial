using System.Linq;
using System.Threading.Tasks;
using DrakeLambert.RefitTutorial.Gateway.ApiServices.ClientsApi;
using DrakeLambert.RefitTutorial.Gateway.ApiServices.WeatherApi;
using DrakeLambert.RefitTutorial.Gateway.Dtos;

namespace DrakeLambert.RefitTutorial.Gateway.Services
{
    public class DailyClientInfoService : IDailyClientInfoService
    {
        private readonly IClientJokeService _companyJokeService;
        private readonly IClientsApi _clientsApi;
        private readonly IWeatherApi _weatherApi;

        public DailyClientInfoService(IClientJokeService companyJokeService, IClientsApi clientsApi, IWeatherApi weatherApi)
        {
            _companyJokeService = companyJokeService;
            _clientsApi = clientsApi;
            _weatherApi = weatherApi;
        }

        public async Task<DailyClientInfo> GetDailyClientInfoAsync(string companyName)
        {
            var joke = await _companyJokeService.GetJokeForClientAsync(companyName);

            var client = await _clientsApi.GetClientByNameAsync(companyName);
            var weather = (await _weatherApi.GetWeatherByZipCode(client.ZipCode)).Weather.First().Description;

            return new DailyClientInfo
            {
                JokeOfTheDay = joke,
                Weather = weather
            };
        }
    }
}
