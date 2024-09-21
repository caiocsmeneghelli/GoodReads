using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.Reviews.CreateReview
{
    public class CreateReviewCommand : IRequest<Result>
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
    }
}
