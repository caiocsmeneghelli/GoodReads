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
        public UnitOfWork(IBookRepository books)
        {
            Books = books;
        }

        public IBookRepository Books { get; }

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
