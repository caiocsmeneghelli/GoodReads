﻿using AutoMapper;
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
        }
    }
}
