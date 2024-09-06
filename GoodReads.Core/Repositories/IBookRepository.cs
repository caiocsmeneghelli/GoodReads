using GoodReads.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Core.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<IEnumerable<Book>> GetAllByGenreAsync();
        Task<IEnumerable<Book>> GetAllAsync(string param);
        Task<int> CreateAsync(Book book);
        Task UpdateAsync(Book book);
        Task Delete(int id);
    }
}
