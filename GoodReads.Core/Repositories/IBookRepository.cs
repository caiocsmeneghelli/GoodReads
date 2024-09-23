using GoodReads.Core.Entities;
using GoodReads.Core.Enum;
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
        Task<IEnumerable<Book>> GetAllByGenreAsync(Genre genre);
        Task<IEnumerable<Book>> GetAllAsync(string param);
        Task<int> CreateAsync(Book book);
        Task UpdateAsync(Book book);
        void Delete(Book book);
    }
}
