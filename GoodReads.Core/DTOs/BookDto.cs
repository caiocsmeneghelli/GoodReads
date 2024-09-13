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
    }
}
