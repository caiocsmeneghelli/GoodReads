using GoodReads.Application.ViewModels;
using GoodReads.Core.Entities;
using MediatR;

namespace GoodReads.Application.Queries.Books.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookViewModel?>
    {
        public GetBookByIdQuery(int idBook)
        {
            IdBook = idBook;
        }

        public int IdBook { get; private set; }
    }
}
