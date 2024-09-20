using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommand : IRequest<Result>
    {
        public DeleteUserCommand(int idUser)
        {
            IdUser = idUser;
        }

        public int IdUser { get; set; }
    }
}
