using GoodReads.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Core.Repositories
{
    public interface IReviewRepository 
    {
        Task<Review?> GetByIdAsync(int id);
        Task<List<Review>> GetAllAsync();
        Task<int> CreateAsync(Review review);
        Task DeleteAsync(Review review);
    }
}
