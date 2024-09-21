using GoodReads.Core.Entities;
using GoodReads.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        public Task<int> CreateAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllAsync(string param)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllByGenreAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
