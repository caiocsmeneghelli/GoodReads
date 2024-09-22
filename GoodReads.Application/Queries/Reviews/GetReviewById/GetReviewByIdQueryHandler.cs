using GoodReads.Application.ViewModels;
using GoodReads.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Queries.Reviews.GetReviewById
{
    public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, ReviewViewModel?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetReviewByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReviewViewModel?> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.Reviews.GetByIdAsync(request.IdReview);
            if(review is null) { return null;}

            var reviewViewModel = new ReviewViewModel();
            reviewViewModel.FromModel(review);

            return reviewViewModel;
        }
    }
}
