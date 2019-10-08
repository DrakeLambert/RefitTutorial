using System.Threading.Tasks;
using DrakeLambert.RefitTutorial.Gateway.Dtos;

namespace DrakeLambert.RefitTutorial.Gateway.Services
{
    public interface IDailyClientInfoService
    {
        Task<DailyClientInfo> GetDailyClientInfoAsync(string companyName);
    }
}
