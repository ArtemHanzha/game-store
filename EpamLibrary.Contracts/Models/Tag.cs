﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamLibrary.Contracts.Models.Abstracts;

namespace EpamLibrary.Contracts.Models
{
    public class Tag : AbstractDbObject
    {
        public string TagName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
