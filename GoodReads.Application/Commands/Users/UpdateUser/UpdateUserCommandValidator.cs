using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(reg => reg.Name)
                .NotEmpty()
                .WithMessage("O campo Nome não pode ser vazio.")
                .MaximumLength(256)
                .WithMessage("O campo Nome não pode ter mais de 256 caracteres.");

            RuleFor(reg => reg.Email)
                .NotEmpty()
                .WithMessage("O campo E-mail não pode ser vazio.")
                .EmailAddress()
                .WithMessage("O campo E-mail inválido.");
        }
    }
}
