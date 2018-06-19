using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmapLibrary.UserInterface.ViewModels.Internal
{
    public class UserBooksViewModel
    {
        public UserViewModel User { get; set; }

        public Dictionary<DateTime, IEnumerable<BookViewModel>> HistoryDictionary { get; set; }

        public int PageCount { get; set; }

        public int Current { get; set; }
    }
}