using GoodReads.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            var book = await _unitOfWork.Books.GetByIdAsync(request.IdBook);
            if (book is null)
            {
                errors.Add("Livro não encontrando.");
                return Result.NotFound(request.IdBook, errors);
            }

            // Validation

            book.Update(request.Description, request.Genre);
            await _unitOfWork.CompleteAsync();

            return Result.Success(book);
        }
    }
}
