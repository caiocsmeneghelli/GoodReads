using GoodReads.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.IdBook);
            if (book == null) { return Result.NotFound("Livro não encontrado."); }

            await _unitOfWork.Books.Delete(request.IdBook);
            await _unitOfWork.CommitAsync();

            return Result.Success(request.IdBook);
        }
    }
}
