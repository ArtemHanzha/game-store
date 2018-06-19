using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmapLibrary.UserInterface.ViewModels.Abstract;
using EmapLibrary.UserInterface.ViewModels.Enums;
using EpamLibrary.Contracts.Models;

namespace EmapLibrary.UserInterface.ViewModels
{
    public class CatalogViewModel : BaseViewModel
    {
        public IEnumerable<BookViewModel> Books { get; set; } 
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public ActiveSortFilter Filter { get; set; }
    }
}