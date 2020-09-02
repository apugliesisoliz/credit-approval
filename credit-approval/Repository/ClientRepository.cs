using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using credit_approval.Models;
using credit_approval.Contracts;

namespace credit_approval.Repository
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<Client> GetAllClients()
        {
            return FindByCondition(c => c.State == true)
                .OrderBy(c => c.Name)
                .ToList();
        }
        public Client GetClientById(int clientId)
        {
            return FindByCondition(c => c.Id == clientId & c.State == true)
                    .FirstOrDefault();
        }
        public bool ClientExist(int clientId)
        {
            return FindByCondition(c => c.Id == clientId & c.State == true)
                    .Any();
        }
        public void CreateClient(Client client)
        {
            Create(client);
        }
        public void UpdateClient(Client client)
        {
            Update(client);
        }
    }
}
