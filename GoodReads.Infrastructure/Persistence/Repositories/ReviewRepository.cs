using GoodReads.Core.Entities;
using GoodReads.Core.Repositories;
using GoodReads.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Infrastructure.Persistence.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly GoodReadsContext _context;

        public ReviewRepository(GoodReadsContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
            return review.Id;
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
