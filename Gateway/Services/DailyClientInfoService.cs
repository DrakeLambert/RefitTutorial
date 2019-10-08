using System.Threading.Tasks;
using DrakeLambert.RefitTutorial.Gateway.ApiServices.ClientsApi;
using DrakeLambert.RefitTutorial.Gateway.Dtos;

namespace DrakeLambert.RefitTutorial.Gateway.Services
{
    public class DailyClientInfoService : IDailyClientInfoService
    {
        private readonly IClientJokeService _companyJokeService;
        private readonly IClientsApi _clientsApi;

        public DailyClientInfoService(IClientJokeService companyJokeService, IClientsApi clientsApi)
        {
            _companyJokeService = companyJokeService;
            _clientsApi = clientsApi;
        }

        public async Task<DailyClientInfo> GetDailyClientInfoAsync(string companyName)
        {
            var joke = await _companyJokeService.GetJokeForClientAsync(companyName);

            var client = await _clientsApi.GetClientByNameAsync(companyName);
            return new DailyClientInfo
            {
                JokeOfTheDay = joke,
                Weather = null //TODO: fill this in with weather data for company.
            };
        }
    }
}
