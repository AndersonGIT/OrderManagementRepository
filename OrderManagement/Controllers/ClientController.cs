using Domain.Entities;
using Domain.Ports.IClient;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            if (id <= 0) return BadRequest();

            var clients = await _clientService.GetOrListClientAsync(id);

            return Ok(clients);
        }

        [HttpPost]
        public async Task<IActionResult> InserClient([FromBody] Client client)
        {
            var clientInserted = await _clientService.InsertClientAsync(client);

            return Ok(clientInserted);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] Client client)
        {
            if (id != client?.Id) return BadRequest();

            var clientUpdated = await _clientService.UpdateClientAsync(client);

            return Ok(clientUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (id <= 0) return BadRequest();

            var clientDeleted = await _clientService.DeleteClientAsync(id);

            return Ok(clientDeleted);
        }
    }
}
