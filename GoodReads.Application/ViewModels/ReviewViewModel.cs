using GoodReads.Core.Entities;
using GoodReads.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Application.ViewModels
{
    public class ReviewViewModel
    {
        public int IdReview { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string ISBN { get; set; }
        public Genre Genre { get; set; }

        public void FromModel(Review review)
        {
            IdReview = review.Id;
            Description = review.Description;
            Score = review.Score;

            UserName = review.User.Name;
            UserEmail = review.User.Email;

            Title = review.Book.Title;
            AuthorName = review.Book.Author;
            ISBN = review.Book.ISBN;
            Genre = review.Book.Genre;
        }
    }
}
