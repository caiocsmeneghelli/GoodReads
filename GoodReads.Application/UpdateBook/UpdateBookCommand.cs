﻿using GoodReads.Core.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.UpdateBook
{
    public class UpdateBookCommand : IRequest<Result>
    {
        public string Description { get; set; }
        public Genre Genre { get; set; }
    }
}
