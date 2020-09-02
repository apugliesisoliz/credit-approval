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
        Credit GetCreditById(int creditId);
        void CreateCredit(Credit credit);
        void UpdateCredit(Credit credit);
    }
}
