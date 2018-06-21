using System.Collections.Generic;

namespace EmapLibrary.UserInterface.ViewModels.Internal
{
    public class HomeViewModel
    {
        public IEnumerable<BookViewModel> LastReviewed { get; set; }

        public IEnumerable<BookViewModel> NewestBooks { get; set; }
    }
}