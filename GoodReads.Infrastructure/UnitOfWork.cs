using GoodReads.Core.Repositories;
using GoodReads.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IBookRepository books, IUserRepository users)
        {
            Books = books;
            Users = users;
        }

        public IBookRepository Books { get; }
        public IUserRepository Users { get; }

        public Task BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CompleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
