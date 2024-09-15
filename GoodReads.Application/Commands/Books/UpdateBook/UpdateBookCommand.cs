using GoodReads.Core.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.Books.UpdateBook
{
    public class UpdateBookCommand : IRequest<Result>
    {
        public int IdBook { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
    }
}
