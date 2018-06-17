using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamLibrary.Contracts.Models.Abstracts;

namespace EpamLibrary.Contracts.Models
{
    public class LibraryLogRecord : AbstractDbObject
    {
        public BookInstance BookInstance { get; set; }
        //user
        public User Reader { get; set; }
        //workers
        public User Librariant { get; set; }

        public DateTime? RentalTime { get; set; }

        public DateTime? ExpectedReturnTime { get; set; }

        public DateTime? ReturnTime { get; set; }

        public string Comment { get; set; }
    }
}
