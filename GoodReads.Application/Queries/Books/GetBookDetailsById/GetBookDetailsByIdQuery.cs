using GoodReads.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Queries.Books.GetBookDetailsById
{
    public class GetBookDetailsByIdQuery : IRequest<BookReviewViewModel>
    {
        public GetBookDetailsByIdQuery(int id)
        {
            IdBook = id;
        }
        public int IdBook { get; set; }
    }
}
