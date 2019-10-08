using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DrakeLambert.RefitTutorial.Clients.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly List<Client> _clients;

        public ClientsController(List<Client> clients)
        {
            _clients = clients;
        }

        [HttpGet("{name}")]
        public Client Get([FromRoute] string name)
        {
            return _clients.FirstOrDefault(client => client.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }

        [HttpPost]
        public void Add([FromBody] Client client)
        {
            _clients.Add(client);
        }
    }

    public class Client
    {
        public string Name { get; set; }

        public string ZipCode { get; set; }
    }
}
