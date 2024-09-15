using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.Users.CreateUser
{
    public class CreateUserCommand : IRequest<Result>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
