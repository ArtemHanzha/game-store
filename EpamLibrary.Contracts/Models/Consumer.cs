using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamLibrary.Contracts.Models.Abstracts;

namespace EpamLibrary.Contracts.Models
{
    public class Consumer : AbstractUser
    {
        public int ReaderCardNumber { get; set; }

        public bool IsBlocked { get; set; }
    }
}
