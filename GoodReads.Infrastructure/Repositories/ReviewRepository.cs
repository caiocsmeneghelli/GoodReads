using GoodReads.Core.Entities;
using GoodReads.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public Task<int> CreateAsync(Review review)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Review review)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
