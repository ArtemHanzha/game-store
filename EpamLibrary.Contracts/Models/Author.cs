using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamLibrary.Contracts.Models.Abstracts;

namespace EpamLibrary.Contracts.Models
{
    public class Author : AbstractDbObject
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
