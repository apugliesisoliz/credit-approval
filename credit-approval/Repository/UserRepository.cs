using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using credit_approval.Models;
using credit_approval.Contracts;

namespace credit_approval.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<User> GetAllUsers()
        {
            return FindAll()
                .OrderBy(u => u.UserId)
                .ToList();
        }
        public User GetUserById(string userId)
        {
            return FindByCondition(u => u.UserId.Equals(userId))
                    .FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            Create(user);
        }
    }
}
