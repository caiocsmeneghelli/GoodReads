using AutoMapper;
using GoodReads.Application.ViewModels;
using GoodReads.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Queries.Books.GetBookDetailsById
{
    public class GetBookDetailsByIdQueryHandler : IRequestHandler<GetBookDetailsByIdQuery, BookReviewViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookDetailsByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookReviewViewModel> Handle(GetBookDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.GetByIdDetailsAsync(request.IdBook);
            if(book is null) { return null; }

            var bookDetail = _mapper.Map<BookReviewViewModel>(book);
            return bookDetail;
        }
    }
}
