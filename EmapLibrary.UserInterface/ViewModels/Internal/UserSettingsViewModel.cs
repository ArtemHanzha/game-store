using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmapLibrary.UserInterface.ViewModels.Internal
{
    public class UserSettingsViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public string FullName => $"{Surname} {Name} {LastName}";
        
        public bool IsPassError { get; set; }
        public bool IsBirthdayError { get; set; }
        public bool IsNameError { get; set; }
        public bool IsSurnameError { get; set; }
        public bool IsLastNameError { get; set; }
        public bool IsEmailError { get; set; }

        public bool HaveError()
        {
            IsNameError |= string.IsNullOrEmpty(Name);
            IsSurnameError |= string.IsNullOrEmpty(Surname);
            IsLastNameError |= string.IsNullOrEmpty(LastName);
            IsEmailError |= string.IsNullOrEmpty(Email);

            return IsNameError || IsSurnameError || IsLastNameError || IsEmailError || IsPassError || IsBirthdayError;
        }

        public void FirsIn()
        {
            if (Name == null && Surname == null && LastName == null && Email == null &&
                Birthday == null)
            {
                IsPassError = false;
                IsBirthdayError = false;
                IsNameError = false;
                IsSurnameError = false;
                IsLastNameError = false;
                IsEmailError = false;
            }
        }
    }
}