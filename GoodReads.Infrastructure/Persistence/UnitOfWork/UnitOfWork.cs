using GoodReads.Core.Repositories;
using GoodReads.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GoodReadsContext _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(IBookRepository books, IUserRepository users,
            IReviewRepository reviews, GoodReadsContext context)
        {
            Books = books;
            Users = users;
            Reviews = reviews;
            _context = context;
        }

        public IBookRepository Books { get; }
        public IUserRepository Users { get; }
        public IReviewRepository Reviews { get; }

        public async Task BeginTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                throw ex;
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
