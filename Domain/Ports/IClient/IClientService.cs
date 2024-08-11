using Domain.Entities;

namespace Domain.Ports.IClient
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetOrListClientAsync(int clientId);
        Task<Client> InsertClientAsync(Client client);
        Task<Client> UpdateClientAsync(Client client);
        Task<Client> DeleteClientAsync(int clientId);
    }
}
