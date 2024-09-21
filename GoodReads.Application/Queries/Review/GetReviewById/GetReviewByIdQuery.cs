using GoodReads.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Queries.Review.GetReviewById
{
    public class GetReviewByIdQuery : IRequest<ReviewViewModel?>
    {
        public GetReviewByIdQuery(int idReview)
        {
            IdReview = idReview;
        }

        public int IdReview { get; private set; }
    }
}
