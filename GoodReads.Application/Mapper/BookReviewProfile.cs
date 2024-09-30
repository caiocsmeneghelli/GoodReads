using AutoMapper;
using GoodReads.Application.ViewModels;
using GoodReads.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Mapper
{
    public class BookReviewProfile : Profile
    {
        public BookReviewProfile()
        {
            CreateMap<Book, BookReviewViewModel>();
        }
    }
}
