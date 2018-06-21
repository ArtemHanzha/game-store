using System.Collections.Generic;
using EmapLibrary.UserInterface.ViewModels.Enums;

namespace EmapLibrary.UserInterface.ViewModels
{
    public class CatalogViewModel
    {
        public IEnumerable<BookViewModel> Books { get; set; } 
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public ActiveSortFilter Filter { get; set; }
    }
}