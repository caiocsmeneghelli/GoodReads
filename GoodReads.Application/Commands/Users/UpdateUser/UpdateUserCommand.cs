using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<Result>
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
