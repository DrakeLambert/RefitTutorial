using System.Threading.Tasks;

namespace DrakeLambert.RefitTutorial.Gateway.Services
{
    public interface IClientJokeService
    {
        Task<string> GetJokeForClientAsync(string companyName);
    }
}
