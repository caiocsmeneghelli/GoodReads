using FluentValidation;
using GoodReads.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.Book.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateBookCommand> _validator;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateBookCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return Result.BadRequest(request, validationResult.Errors
                    .Select(reg => reg.ErrorMessage).ToList());
            }

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
