using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmapLibrary.UserInterface.ViewModels
{
    public class UserListViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}