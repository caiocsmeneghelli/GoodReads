using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.Book.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(reg => reg.IdBook)
                .NotEmpty()
                .WithMessage("IdBook não pode ser vazio.");

            RuleFor(reg => reg.Description.Length)
                .LessThanOrEqualTo(256)
                .WithMessage("Campo Descrição deve ter no máximo 256 caracteres.");

            RuleFor(reg => reg.Genre)
                .NotEmpty()
                .WithMessage("Campo Genero não pode ser vazio.")
                .IsInEnum()
                .WithMessage("Campo Genero inválido.");
        }
    }
}
