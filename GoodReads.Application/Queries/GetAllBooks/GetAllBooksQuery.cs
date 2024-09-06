﻿using GoodReads.Application.ViewModels;
using MediatR;

namespace GoodReads.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<BookViewModel>>
    {
    }
}
