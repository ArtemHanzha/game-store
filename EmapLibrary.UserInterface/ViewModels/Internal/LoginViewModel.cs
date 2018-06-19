using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmapLibrary.UserInterface.ViewModels.Internal
{
    public class LoginViewModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public bool IsLoginIncorrect { get; set; }
    }
}