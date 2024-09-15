using GoodReads.Application.ViewModels;
using MediatR;

namespace GoodReads.Application.Queries.Books.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BookViewModel>>
    {
    }
}
