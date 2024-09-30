using AutoMapper;
using GoodReads.Application.ViewModels;
using GoodReads.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.Mapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.IdBook, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.ToString()));
        }
    }
}
