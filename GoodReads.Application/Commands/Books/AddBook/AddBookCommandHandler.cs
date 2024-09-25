using GoodReads.Core.Services;
using GoodReads.Core.UnitOfWork;
using MediatR;

namespace GoodReads.Application.Commands.Books.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Result>
    {
        private readonly IBookService _bookService;
        private readonly IUnitOfWork _unitOfWork;

        public AddBookCommandHandler(IBookService bookService, IUnitOfWork unitOfWork)
        {
            _bookService = bookService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var bookInfo = await _bookService.SearchBookByISBN(request.ISBN);
            if (bookInfo is null)
            {
                string erro = $"Livro com o identificador {request.ISBN} não encontrado.";
                List<string> errors = new List<string>();
                errors.Add(erro);
                return Result.BadRequest(request.ISBN, errors);
            }

            var book = bookInfo.ToModel();
            var bookCover = await _bookService.GetBookThumbnailImage(bookInfo.ThumbnailUrl);
            if (bookCover != null)
            {
                book.UpdateBookCover(bookCover);
            }

            // Save book.
            await _unitOfWork.Books.CreateAsync(book);
            await _unitOfWork.CompleteAsync();

            return Result.Success(bookInfo);
        }
    }
}
