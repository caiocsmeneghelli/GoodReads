using GoodReads.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<Book?>
    {
        public GetBookByIdQuery(int idBook)
        {
            IdBook = idBook;
        }

        public int IdBook { get; private set; }
    }
}
