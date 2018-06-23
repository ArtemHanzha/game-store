using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmapLibrary.UserInterface.ViewModels.Internal
{
    public class BookInfoViewModel
    {
        public BookViewModel Book { get; set; }

        public int PageCount { get; set; }

        public int Page { get; set; }
    }
}