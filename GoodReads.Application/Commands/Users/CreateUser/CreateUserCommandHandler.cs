using FluentValidation;
using GoodReads.Core.Entities;
using GoodReads.Core.UnitOfWork;
using MediatR;

namespace GoodReads.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IValidator<CreateUserCommand> _validator;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IValidator<CreateUserCommand> validator,
            IUnitOfWork unitOfWork)
        {
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return Result.BadRequest(request, validationResult.Errors
                    .Select(reg => reg.ErrorMessage).ToList());
            }

            User user = new User(request.Name, request.Email);

            await _unitOfWork.Users.CreateAsync(user);
            await _unitOfWork.CommitAsync();

            return Result.Success(request);
        }
    }
}
