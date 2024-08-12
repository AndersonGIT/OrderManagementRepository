using Domain.Entities;
using Domain.Ports.IClient;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService) => _clientService = clientService;

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientService.GetOrListClientAsync(0);

            return Ok(clients);
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetClientById(int clientId)
        {
            if (clientId <= 0) return BadRequest();

            var clients = await _clientService.GetOrListClientAsync(clientId);

            return Ok(clients);
        }

        [HttpPost]
        public async Task<IActionResult> InserClient([FromBody] Client client)
        {
            var clientInserted = await _clientService.InsertClientAsync(client);

            return Ok(clientInserted);
        }

        [HttpPut("{clientId}")]
        public async Task<IActionResult> UpdateClient(int clientId, [FromBody] Client client)
        {
            if (clientId != client?.Id) return BadRequest();

            var clientUpdated = await _clientService.UpdateClientAsync(client);

            return Ok(clientUpdated);
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteClient(int clientId)
        {
            if (clientId <= 0) return BadRequest();

            var clientDeleted = await _clientService.DeleteClientAsync(clientId);

            return Ok(clientDeleted);
        }
    }
}
