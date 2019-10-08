using System.Threading.Tasks;
using Refit;

namespace DrakeLambert.RefitTutorial.Gateway.ApiServices.ClientsApi
{
    public interface IClientsApi
    {
        [Get("/clients/{name}")]
        Task<ClientDto> GetClientByNameAsync(string name);

        [Post("/clients")]
        Task AddClient([Body] ClientDto client);
    }
}