using GoodReads.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQuery : IRequest<Result>
    {
        public GetUserByIdQuery(int idUser)
        {
            IdUser = idUser;
        }

        public int IdUser { get; set; }
    }
}
