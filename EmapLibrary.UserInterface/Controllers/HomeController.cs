using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using EmapLibrary.UserInterface.ViewModels;
using EmapLibrary.UserInterface.ViewModels.Internal;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.Contracts.Models;

namespace EmapLibrary.UserInterface.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Catalog(int start = 0, int count = 10)
        {
            //TODO:get books from DB
            var books = _bookService.GetBooks(null, start, count);
            var model = new CatalogViewModel()
            {
                Books = books as ICollection<BookViewModel>

            };
            return View(model);
        }

        public ActionResult Top()
        {
            var books = _bookService.GetBooks(null, 0, 100); //TODO: add predicate to sort books by rating
            var model = new CatalogViewModel()
            {
                Books = books as ICollection<BookViewModel>
            };

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

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
                IsEmailError = email != null? !emailRegex.IsMatch(email) : false,
                IsPassError = (password1 == null || password2 == null)? false : password1 != password2
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