using FluentValidation;
using MediatR;
using GoodReads.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
    {
        private readonly IValidator<CreateUserCommand> _validator;

        public CreateUserCommandHandler(IValidator<CreateUserCommand> validator)
        {
            _validator = validator;
        }

        public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return Result.BadRequest(request, validationResult.Errors
                    .Select(reg => reg.ErrorMessage).ToList());
            }
            
            throw new NotImplementedException();
        }
    }
}
