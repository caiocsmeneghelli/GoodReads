using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodReads.Core.Entities
{
    public class Review : BaseEntity
    {
        public Review(int score, string description, int idUser, int idBook)
        {
            Score = score;
            Description = description;
            IdBook = idBook;
            IdUser = idUser;
        }

        //[Range(1, 5, ErrorMessage = "O valor deve ser maior que 0 e menor ou igual a 5.")]
        [Range(1, 5)]
        public int Score { get; private set; }
        [MaxLength(256)]
        public string Description { get; private set; }

        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }
    }
}
