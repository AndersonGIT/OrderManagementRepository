using Domain.Entities;
using Domain.Ports.IClient;
using Infraestructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Database.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _appDbContext;

        public ClientRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Client> Delete(int clientId)
        {
            var client = await _appDbContext.Client.FirstOrDefaultAsync(client => client.Id == clientId);

            if(client?.Id > 0)
            {
                _appDbContext.Client.Remove(client);
                await _appDbContext.SaveChangesAsync();
                return client;
            }
            else
            {
                throw new ArgumentNullException(nameof(client));
            }
        }

        public async Task<IEnumerable<Client>> GetOrList(int clientId)
        {
            List<Client> clients = new List<Client>();
            if(clientId > 0)
            {
                var client = await _appDbContext.Client.FirstOrDefaultAsync(client => client.Id == clientId);
                
                if(client?.Id > 0)
                {
                    clients.Add(client);
                }
            } else {
                clients = await _appDbContext.Client.ToListAsync();
            }

            return clients;
        }

        public async Task<Client> Insert(Client client)
        {
            if(client != null)
            {
                _appDbContext.Client.Add(client);
                await _appDbContext.SaveChangesAsync();
                return client;
            } else {
                throw new ArgumentNullException(nameof(client));
            }
        }

        public async Task<Client> Update(Client client)
        {
            if (client != null) { 
                _appDbContext.Client.Update(client);
                await _appDbContext.SaveChangesAsync();
                return client;
            } else { 
                throw new ArgumentNullException(nameof(client));
            }
        }
    }
}
