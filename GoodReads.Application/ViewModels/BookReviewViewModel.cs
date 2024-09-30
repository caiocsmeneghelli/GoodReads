using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.ViewModels
{
    public class BookReviewViewModel
    {
        public int IdBook { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ISBN { get; private set; }
        public string Author { get; private set; }
        public string Editor { get; private set; }
        public string Genre { get; private set; }
        public int YearOfPublish { get; private set; }
        public int QuantityOfPages { get; private set; }
        public decimal AvarageScore { get; private set; }
        public byte[] BookCover { get; private set; }

        public List<ReviewViewModel> Reviews { get; set; }
    }
}
