using AutoMapper;
using GoodReads.Application.ViewModels;
using GoodReads.Core.Entities;
using GoodReads.Core.UnitOfWork;
using MediatR;

namespace GoodReads.Application.Queries.Books.GetBookById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookViewModel?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookViewModel?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdAsync(request.IdBook);
            if (book is null) { return null; }

            var bookDetail = _mapper.Map<BookViewModel>(book);
            return bookDetail;
        }
    }
}
