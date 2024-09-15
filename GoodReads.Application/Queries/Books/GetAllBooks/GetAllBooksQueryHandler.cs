using GoodReads.Application.ViewModels;
using GoodReads.Core.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Queries.Books.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public async Task<List<BookViewModel>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Books.GetAllAsync();
            return result.Select(reg => new BookViewModel(reg)).ToList();
        }
    }
}
