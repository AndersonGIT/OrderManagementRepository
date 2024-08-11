using Domain.Ports.IClient;

namespace Application.Services.Client
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository) => _clientRepository = clientRepository;

        public async Task<Domain.Entities.Client> DeleteClientAsync(int clientId)
        {
            var clientDeleted = await _clientRepository.Delete(clientId);
            return clientDeleted;
        }

        public async Task<IEnumerable<Domain.Entities.Client>> GetOrListClientAsync(int clientId)
        {
            var clients = await _clientRepository.GetOrList(clientId);
            return clients;
        }

        public async Task<Domain.Entities.Client> InsertClientAsync(Domain.Entities.Client client)
        {
            var clientInserted = await _clientRepository.Insert(client);
            return clientInserted;
        }

        public async Task<Domain.Entities.Client> UpdateClientAsync(Domain.Entities.Client client)
        {
            var clientUpdated = await _clientRepository.Update(client);
            return clientUpdated;
        }
    }
}
