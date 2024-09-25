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
            var listError = new List<string>();
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                listError = validationResult.Errors
                     .Select(reg => reg.ErrorMessage).ToList();
                return Result.BadRequest(request, listError);
            }

            // Validator?
            var userEmail = await _unitOfWork.Users.GetByEmailAsync(request.Email);
            if (userEmail != null)
            {
                string error = $"E-mail {request.Email} já cadastrado.";
                listError.Add(error);

                return Result.BadRequest(request, listError);
            }

            User user = new User(request.Name, request.Email);

            await _unitOfWork.Users.CreateAsync(user);
            await _unitOfWork.CompleteAsync();

            return Result.Success(user.Id);
        }
    }
}
