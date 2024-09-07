using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<Result>
    {
        public DeleteBookCommand(int idBook)
        {
            IdBook = idBook;
        }

        public int IdBook { get; private set; }
    }
}
