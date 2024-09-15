using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.Books.AddBook
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            RuleFor(reg => reg.ISBN.Length).Equal(13).WithMessage("Código ISBN deve possuir 13 caracteres.");
        }
    }
}
