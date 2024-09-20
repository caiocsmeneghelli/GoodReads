using FluentValidation;
using GoodReads.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateUserCommand> _validator;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IValidator<UpdateUserCommand> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.IdUser);
            var listError = new List<string>();
            if(user is null) { return Result.NotFound($"Usuário de ID {request.IdUser} não encontrado."); }

            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                listError = validationResult.Errors
                    .Select(reg => reg.ErrorMessage).ToList();
                return Result.BadRequest(request, listError);
            }

            // Validator?
            var userEmail = await _unitOfWork.Users.GetByEmailAsync(request.Email);
            if(userEmail != null && userEmail?.Id != user.Id)
            {
                string error = $"E-mail {request.Email} já cadastrado.";
                listError.Add(error);

                return Result.BadRequest(request, listError);
            }

            user.Update(request.Name, request.Email);
            await _unitOfWork.CommitAsync();

            return Result.Success(user);
        }
    }
}
