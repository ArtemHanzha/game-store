using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace EmapLibrary.UserInterface.ViewModels.Internal
{
    public class UserSettingsViewModel
    {
        private DateTime _birthday;

        public UserViewModel User
        {
            set
            {
                Name = value.Name;
                Surname = value.Surname;
                LastName = value.LastName;
                Email = value.Email;
                Birthday = value.Birthday;
            }
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime Birthday
        {
            get => _birthday.Date;
            set => _birthday = value;
        }

        public string FullName => $"{Surname} {Name} {LastName}";

        public string Password { get; set; }

        public bool IsPassError { get; set; }
        public bool IsBirthdayError { get; set; }
        public bool IsNameError { get; set; }
        public bool IsSurnameError { get; set; }
        public bool IsLastNameError { get; set; }
        public bool IsEmailError { get; set; }
        public string StringBirthday { get; set; }

        public bool IsFirstIn
        {
            get
            {

                if (string.IsNullOrWhiteSpace(Name) && string.IsNullOrWhiteSpace(Surname) && string.IsNullOrWhiteSpace(LastName) && string.IsNullOrWhiteSpace(StringBirthday))
                {
                    IsPassError = false;
                    IsBirthdayError = false;
                    IsNameError = false;
                    IsSurnameError = false;
                    IsLastNameError = false;
                    IsEmailError = false;
                    return true;
                }

                return false;
            }
        }

        public bool HaveError()
        {
            var stringReg = new Regex(@"^\w+$");
            var emailReg = new Regex(@"^.+\@.+\..+$");
            var dateReg = new Regex(@"^\d{2}/\d{2}/\d{2}(\d{2})?$");

            IsNameError |= !stringReg.IsMatch(Name);
            IsSurnameError |= !stringReg.IsMatch(Surname);
            IsLastNameError |= !stringReg.IsMatch(LastName);
            IsEmailError |= !emailReg.IsMatch(Email);
            IsBirthdayError |= !dateReg.IsMatch(StringBirthday);
            IsPassError |= !stringReg.IsMatch(Password);

            if (!IsBirthdayError)
                Birthday = DateTime.Parse(StringBirthday);

            return IsNameError || IsSurnameError || IsLastNameError || IsEmailError || IsPassError || IsBirthdayError;
        }


    }
}