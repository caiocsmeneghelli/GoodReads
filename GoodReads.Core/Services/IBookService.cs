using GoodReads.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Core.Services
{
    public interface IBookService
    {
        Task<BookDto?> SearchBookByISBN(string ISBN);
        Task<byte[]?> GetBookThumbnailImage(string url);
    }
}
