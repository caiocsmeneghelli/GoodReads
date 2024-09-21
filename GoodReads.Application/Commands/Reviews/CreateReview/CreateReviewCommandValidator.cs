using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.Reviews.CreateReview
{
    public class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewCommandValidator()
        {
            RuleFor(reg => reg.IdUser).NotEmpty().WithMessage("Id de usuário não pode ser 0.");
            RuleFor(reg => reg.IdBook).NotEmpty().WithMessage("Id de livro não pode ser 0.");

            RuleFor(reg => reg.Score)
                .GreaterThan(0).WithMessage("Nota precisa ser maior que 0.")
                .LessThanOrEqualTo(5).WithMessage("Nota precisar ser menor ou igual a 5");

            RuleFor(reg => reg.Description)
                .MaximumLength(256)
                .WithMessage("Campo descrição precisa ter no máximo 256 caracteres.");
        }
    }
}
