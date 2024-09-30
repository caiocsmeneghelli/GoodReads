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
    public class UserReviewProfile : Profile
    {
        public UserReviewProfile()
        {
            CreateMap<User, UserReviewViewModel>();

            CreateMap<Review, ReviewViewModel>()
                .ForMember(dest => dest.IdReview, opt => opt.MapFrom(src => src.IdBook)) // Supondo que IdBook seja o IdReview
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Book.Author))
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.Book.ISBN))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Book.Genre));

        }
    }
}
