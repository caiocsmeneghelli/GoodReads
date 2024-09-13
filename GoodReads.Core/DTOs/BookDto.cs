using GoodReads.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Core.DTOs
{
    public class BookDto
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public string? Publisher { get; set; }
        public string? ThumbnailUrl { get; set; }
        public int YearOfPublish { get; set; }
        public int QuantityOfPages { get; set; }

        public Book ToModel()
        {
            Title = Title ?? string.Empty;
            Author = Author ?? string.Empty;
            ISBN = ISBN ?? string.Empty;
            Publisher = Publisher ?? string.Empty;

            return new Book(Title, ISBN, Author, Publisher, YearOfPublish, QuantityOfPages);
        }
    }
}
