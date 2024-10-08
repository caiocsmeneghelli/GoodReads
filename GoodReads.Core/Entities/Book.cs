﻿using GoodReads.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book(string title, string iSBN, string author, string editor,
            int yearOfPublish, int quantityOfPages)
        {
            Title = title;
            ISBN = iSBN;
            Author = author;
            Editor = editor;
            YearOfPublish = yearOfPublish;
            QuantityOfPages = quantityOfPages;

            Description = string.Empty;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string ISBN { get; private set; }
        public string Author { get; private set; }
        public string Editor { get; private set; }
        public Genre Genre { get; private set; }
        public int YearOfPublish { get; private set; }
        public int QuantityOfPages { get; private set; }
        public decimal AvarageScore { get; private set; }
        public byte[]? BookCover { get; private set; }
        public List<Review> Reviews { get; private set; }

        public void Update(string description, Genre genre)
        {
            Description = description;
            Genre = genre;
        }

        public void UpdateBookCover(byte[] bookCover)
        {
            BookCover = bookCover;
        }

        public void UpdateAvarageScore(int score)
        {
            int countReviews = Reviews.Count + 1;
            int sumAllScores = Reviews.Sum(r => r.Score) + score;

            AvarageScore = sumAllScores / countReviews;
        }
    }
}
