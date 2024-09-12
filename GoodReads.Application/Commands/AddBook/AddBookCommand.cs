using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.AddBook
{
    public class AddBookCommand : IRequest<Result>
    {
        public string ISBN { get; set; }
    }
}
