using GoodReads.Core.Repositories;
using GoodReads.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IBookRepository books, IUserRepository users,
            IReviewRepository reviews)
        {
            Books = books;
            Users = users;
            Reviews = reviews;
        }

        public IBookRepository Books { get; }
        public IUserRepository Users { get; }
        public IReviewRepository Reviews { get; }

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
