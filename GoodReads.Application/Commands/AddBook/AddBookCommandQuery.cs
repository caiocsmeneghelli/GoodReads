using GoodReads.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.AddBook
{
    public class AddBookCommandQuery : IRequestHandler<AddBookCommand, Result>
    {
        private readonly IBookService _bookService;

        public AddBookCommandQuery(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Result> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var bookInfo = await _bookService.SearchBookByISBN(request.ISBN);
            if(bookInfo is null)
            {
                string erro = string.Format($"Livro com o identificador {0} não encontrado.", request.ISBN);
                List<string> errors = new List<string>();
                errors.Add(erro);
                return Result.BadRequest(request.ISBN, errors);
            }

            return Result.Success(bookInfo);
        }
    }
}
