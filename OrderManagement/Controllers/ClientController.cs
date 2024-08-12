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
            if (client.Validate())
            {
                var clientInserted = await _clientService.InsertClientAsync(client);

                return Ok(clientInserted);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{clientId}")]
        public async Task<IActionResult> UpdateClient(int clientId, [FromBody] Client client)
        {
            if (client.Validate())
            {
                if (clientId != client?.Id) return BadRequest();

                var clientUpdated = await _clientService.UpdateClientAsync(client);

                return Ok(clientUpdated);
            }
            else
            {
                return BadRequest();
            }
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
