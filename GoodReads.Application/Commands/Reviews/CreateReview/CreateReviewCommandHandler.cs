using FluentValidation;
using GoodReads.Core.Entities;
using GoodReads.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.Reviews.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateReviewCommand> _validator;

        public CreateReviewCommandHandler(IUnitOfWork unitOfWork, 
            IValidator<CreateReviewCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                errors = validationResult
                    .Errors.Select(reg => reg.ErrorMessage).ToList();
                return Result.BadRequest(request, errors);
            }

            var user = await _unitOfWork.Users.GetByIdAsync(request.IdUser);
            if(user is null) { errors.Add($"Usuário de ID {request.IdUser} não encontrado."); }

            var book = await _unitOfWork.Books.GetByIdAsync(request.IdBook);
            if (book is null) { errors.Add($"Livro de ID {request.IdBook} não foi encontado."); }

            if(errors.Count > 0)
            {
                return Result.BadRequest(request, errors);
            }

            var review = new Review(request.Score, request.Description, user.Id, book.Id);

            await _unitOfWork.BeginTransaction();
            
            var idReview = await _unitOfWork.Reviews.CreateAsync(review);
            await _unitOfWork.CompleteAsync();
            
            book.UpdateAvarageScore(request.Score);
            await _unitOfWork.CompleteAsync();

            await _unitOfWork.CommitAsync();

            return Result.Success(review.Id);
        }
    }
}
