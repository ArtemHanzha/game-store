using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmapLibrary.UserInterface.ViewModels.Internal
{
    public class LogListViewModel
    {
        public IEnumerable<LibraryLogRecordViewModel> Logs { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }
    }
}