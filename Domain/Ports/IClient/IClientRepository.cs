using Domain.Entities;

namespace Domain.Ports.IClient
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetOrList(int clientId);
        Task<Client> Insert(Client client);
        Task<Client> Update(Client client);
        Task<Client> Delete(int clientId);
    }
}
