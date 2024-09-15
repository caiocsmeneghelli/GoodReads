using GoodReads.Core.Entities;
using MediatR;

namespace GoodReads.Application.Queries.Books.GetBookById
{
    public class GetBookByIdQuery : IRequest<Book?>
    {
        public GetBookByIdQuery(int idBook)
        {
            IdBook = idBook;
        }

        public int IdBook { get; private set; }
    }
}
