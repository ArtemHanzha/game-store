using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamLibrary.Contracts.Models.Abstracts;

namespace EpamLibrary.Contracts.Models
{
    public class BookInstance : AbstractDbObject
    {
        public Book Book { get; set; }

        public string LibraryNumber { get; set; }

        public string ConditionComment { get; set; }

        public bool IsInUse { get; set; }
    }
}
