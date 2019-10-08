using System.Threading.Tasks;
using DrakeLambert.RefitTutorial.Gateway.Services;
using DrakeLambert.RefitTutorial.Gateway.Dtos;
using Microsoft.AspNetCore.Mvc;
using DrakeLambert.RefitTutorial.Gateway.ApiServices.ClientsApi;

namespace DrakeLambert.RefitTutorial.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsApi _clientsApi;
        private readonly IDailyClientInfoService _clientInfoService;

        public ClientsController(IClientsApi clientsApi, IDailyClientInfoService clientInfoService)
        {
            _clientsApi = clientsApi;
            _clientInfoService = clientInfoService;
        }

        [HttpGet("{clientName}")]
        public async Task<ActionResult<Client>> GetClient([FromRoute] string clientName)
        {
            var client = await _clientsApi.GetClientByNameAsync(clientName);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] Client client)
        {
            await _clientsApi.AddClient(new ClientDto { Name = client.Name, ZipCode = client.ZipCode });
            return Ok();
        }

        [HttpGet("{clientName}/dailyInfo")]
        public async Task<ActionResult<DailyClientInfo>> GetDailyClientInfo([FromRoute] string clientName)
        {
            return Ok(await _clientInfoService.GetDailyClientInfoAsync(clientName));
        }
    }
}