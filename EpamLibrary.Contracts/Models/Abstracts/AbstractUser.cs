using System;
using System.Collections.Generic;

namespace EpamLibrary.Contracts.Models.Abstracts
{
    public abstract class AbstractUser : AbstractDbObject
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

        public bool Equals(AbstractUser user)
        {
            return Login.Equals(user.Login);
        }
    }
}
