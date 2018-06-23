using System.Web.Mvc;
using EmapLibrary.Auth.Interfaces;
using EmapLibrary.UserInterface.ViewModels.Internal;

namespace EmapLibrary.UserInterface.Controllers
{
    public class BaseController : Controller
    {
        protected const int RecordsOnPage = 10;

        protected readonly IAuthentication _auth;

        public BaseController(IAuthentication auth)
        {
            _auth = auth;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            var result = _auth.Login(login, password, true);

            if (result == null)
                return View(new LoginViewModel(){IsLoginIncorrect = true, Login = login, Password = password});

            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            _auth.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}