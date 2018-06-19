using System.Collections.Generic;
using EmapLibrary.UserInterface.ViewModels.Abstract;

namespace EmapLibrary.UserInterface.ViewModels.Internal
{
    public class HomeViewModel : BaseViewModel
    {
        public IEnumerable<BookViewModel> LastReviewed { get; set; }

        public IEnumerable<BookViewModel> NewestBooks { get; set; }
    }
}