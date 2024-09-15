using GoodReads.Application.Queries.Users.GetUserById;
using GoodReads.Core.Entities;
using GoodReads.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(request.IdUser);
            if (user == null) { return Result.NotFound($"Usuário de Id: {request.IdUser} não foi encontrado."); }

            return Result.Success(user);
        }
    }
}
