using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace credit_approval.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IClientRepository Client { get; }
        ICreditRepository Credit { get; }
        void Save();
    }
}
