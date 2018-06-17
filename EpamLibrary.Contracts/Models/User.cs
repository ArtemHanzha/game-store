using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EpamLibrary.Contracts.Enums;
using EpamLibrary.Contracts.Models.Abstracts;

namespace EpamLibrary.Contracts.Models
{
    [Table("Users")]
    public class User : AbstractDbObject
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<BookInstance> BooksHistory { get; set; }

        public string EMail { get; set; }

        public string WorkerNumber { get; set; }

        public DateTime? HiringDate { get; set; }

        public UserType UserType { get; set; }

        public int ReaderCardNumber { get; set; }

        public bool IsBlocked { get; set; }
    }
}
