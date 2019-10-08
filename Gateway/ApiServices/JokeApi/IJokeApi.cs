using System.Threading.Tasks;

namespace DrakeLambert.RefitTutorial.Gateway.ApiServices.JokeApi
{
    public interface IJokeApi
    {
        Task<JokeDto> GetRandomJokeAsync();
    }
}
