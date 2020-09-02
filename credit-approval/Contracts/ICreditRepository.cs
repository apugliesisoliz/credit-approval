using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using credit_approval.Models;

namespace credit_approval.Contracts
{
    public interface ICreditRepository : IRepositoryBase<Credit>
    {
        IEnumerable<Credit> GetAllCredits();
        IEnumerable<Credit> GetByAuthState(int state);
        Credit GetCreditById(int creditId);
        bool ClienthasCredits(int clientId);
        void CreateCredit(Credit credit);
        void UpdateCredit(Credit credit);
    }
}
