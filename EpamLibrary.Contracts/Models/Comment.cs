using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamLibrary.Contracts.Enums;
using EpamLibrary.Contracts.Models.Abstracts;

namespace EpamLibrary.Contracts.Models
{
    public class Comment : AbstractDbObject
    {
        public AbstractUser Reviewer { get; set; }

        public Book Book { get; set; }

        public DateTime? PublicationDateTime { get; set; }

        public string Review { get; set; }

        public Rating Rating { get; set; }

        public bool Equals(Comment com)
        {
            return this.Book.Equals(com.Book) &&
                   Reviewer.Equals(com.Reviewer) && 
                   PublicationDateTime.Equals(com.PublicationDateTime);
        }
    }
}
