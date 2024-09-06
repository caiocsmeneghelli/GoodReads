using GoodReads.Application.ViewModels;
using GoodReads.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public async Task<List<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BookRepository.GetAllAsync();
            return result.Select(reg => new BookViewModel(reg)).ToList();
        }
    }
}
