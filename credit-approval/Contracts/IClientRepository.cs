using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using credit_approval.Models;

namespace credit_approval.Contracts
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientById(int clientId);
        bool ClientExist(int clientId);
        void CreateClient(Client client);
        void UpdateClient(Client client);
    }
}
