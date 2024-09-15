using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.User.DeleteUser
{
    public class DeleteUserCommand : IRequest<Result>
    {
        public int IdUser { get; set; }
    }
}
