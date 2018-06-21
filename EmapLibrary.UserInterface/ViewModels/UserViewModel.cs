using System;
using System.Collections.Generic;

namespace EmapLibrary.UserInterface.ViewModels
{
    public class UserViewModel
    {
        private string _fullName;
        public int Id { get; set; }

        public string Email { get; set; }

        public int CardNumber { get; set; }

        public bool IsBlocked { get; set; }

        public string Login { get; set; }

        public DateTime Birthday { get; set; }

        /// <summary>
        /// Add like this $"{Surname} {Name} {LastName}"
        /// </summary>
        public string FullName
        {
            get => _fullName;
            set
            {
                string[] str = value.Split(' ');
                Name = str[1];
                Surname = str[0];
                LastName = str[2];
                _fullName = value;
            }
        }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string LastName { get; private set; }

        public ICollection<BookViewModel> BooksHistory { get; set; }
    }
}