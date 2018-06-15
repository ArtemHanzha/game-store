using System;
using System.Collections.Generic;

namespace EmapLibrary.UserInterface.ViewModels
{
    public class WorkerViewModel
    {
        public int WorkerNumber { get; set; }

        public string Type { get; set; }

        public DateTime HiringDate { get; set; }

        public string Login { get; set; }

        public string FullName { get; set; }

        public DateTime Birthday { get; set; }

        public ICollection<BookViewModel> BooksHistory { get; set; }
    }
}