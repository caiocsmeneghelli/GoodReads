using GoodReads.Core.Entities;
using GoodReads.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<int> CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
