using System.Threading.Tasks;
using DrakeLambert.RefitTutorial.Gateway.Dtos;

namespace DrakeLambert.RefitTutorial.Gateway.Services
{
    public class DailyClientInfoService : IDailyClientInfoService
    {
        private readonly IClientJokeService _companyJokeService;

        public DailyClientInfoService(IClientJokeService companyJokeService)
        {
            _companyJokeService = companyJokeService;
        }

        public async Task<DailyClientInfo> GetDailyClientInfoAsync(string companyName)
        {
            var joke = await _companyJokeService.GetJokeForClientAsync(companyName);

            return new DailyClientInfo
            {
                JokeOfTheDay = joke,
                Weather = null //TODO: fill this in with weather data for company.
            };
        }
    }
}
