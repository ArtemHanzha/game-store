using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using EmapLibrary.Auth.Interfaces;
using EmapLibrary.UserInterface.ViewModels;
using EmapLibrary.UserInterface.ViewModels.Internal;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.Contracts.Models;

namespace EmapLibrary.UserInterface.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IBookService _bookService;

        public HomeController(
            IAuthentication auth, 
            IBookService bookService) : base(auth)
        {
            _bookService = bookService;
        }

        public ActionResult Index()
        {
            var model = new HomeViewModel()
            {
                NewestBooks = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(_bookService.GetNewestBooks()),
                LastReviewed = Mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(_bookService.GetLastReviewedBooks())
            };
            ViewBag.IsLogged = _auth.User;
            return View(model);
        }
        
        public ActionResult About()
        {
            return View();
        }

    }
}