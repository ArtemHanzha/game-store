using System.Text.RegularExpressions;
using System.Web.Mvc;
using EmapLibrary.UserInterface.ViewModels.Internal;

namespace EmapLibrary.UserInterface.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Login(string login, string password)
        {
            return View();
        }

        public ActionResult Registration(
            string login,
            string password1,
            string password2,
            string email,
            string name,
            string surname,
            string lastname,
            string birthday)
        {

            Regex emailRegex = new Regex(@"\A[^@]+@([^@\.]+\.)+[^@\.]+\z");
            //TODO: datetime regex
            var regViewModel = new RegistrationViewModel
            {
                Name = name,
                Surname = surname,
                LastName = lastname,
                Email = email,
                Birthday = birthday,
                Login = login,
                IsEmailError = email != null ? !emailRegex.IsMatch(email) : false,
                IsPassError = (password1 == null || password2 == null) ? false : password1 != password2
            };



            if (!regViewModel.HaveError())
            {
                //correct. Go next page
                //TODO: add user to database
                return Redirect("Login");
            }
            else
            {
                return View(regViewModel);
            }
        }
    }
}