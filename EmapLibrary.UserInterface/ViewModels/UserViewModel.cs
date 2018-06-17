﻿using System;
using System.Collections.Generic;

namespace EmapLibrary.UserInterface.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public int CardNumber { get; set; }

        public bool IsBlocked { get; set; }

        public string Login { get; set; }

        public DateTime Birthday { get; set; }

        public string FullName { get; set; }

        public ICollection<BookViewModel> BooksHistory { get; set; }
    }
}