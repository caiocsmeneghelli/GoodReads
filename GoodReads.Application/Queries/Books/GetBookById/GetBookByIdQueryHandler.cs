using GoodReads.Core.Entities;
using GoodReads.Core.UnitOfWork;
using MediatR;

namespace GoodReads.Application.Queries.Books.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Book?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Books.GetByIdAsync(request.IdBook);
        }
    }
}
