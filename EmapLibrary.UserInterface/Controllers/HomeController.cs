using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmapLibrary.UserInterface.ViewModels;
using EpamLibrary.Contracts.Models;

namespace EmapLibrary.UserInterface.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Catalog(int start = 0, int count = 10)
        {
            //TODO:get books from DB
            var model = new CatalogViewModel()
            {
                Books = new List<Book>()
                {
                    new Book(){Title = "Book1"},
                    new Book(){Title = "Book2"},
                    new Book(){Title = "Book3"},
                    new Book(){Title = "Book4"},
                    new Book(){Title = "Book5"},
                    new Book(){Title = "Book6"},
                    new Book(){Title = "Book7"},
                    new Book(){Title = "Book8"},
                    new Book(){Title = "Book9"},
                    new Book(){Title = "Book10"},
                    new Book(){Title = "Book11"},
                    new Book(){Title = "Book12"},
                    new Book(){Title = "Book13"},
                    new Book(){Title = "Book14"},
                    new Book(){Title = "Book15"},
                    new Book(){Title = "Book16"},
                    new Book(){Title = "Book17"},
                    new Book(){Title = "Book18"},
                    new Book(){Title = "Book19"},
                    new Book(){Title = "Book20"},
                    new Book(){Title = "Book21"},
                }
            };
            return View(model);
        }

        public ActionResult Top()
        {
            //TODO:get books from DB
            var model = new CatalogViewModel()
            {
                Books = new List<Book>()
                {
                    new Book(){Title = "Book1"},
                    new Book(){Title = "Book2"},
                    new Book(){Title = "Book3"},
                    new Book(){Title = "Book4"},
                    new Book(){Title = "Book5"},
                    new Book(){Title = "Book6"},
                    new Book(){Title = "Book7"},
                    new Book(){Title = "Book8"},
                    new Book(){Title = "Book9"},
                    new Book(){Title = "Book10"},
                    new Book(){Title = "Book11"},
                    new Book(){Title = "Book12"},
                    new Book(){Title = "Book13"},
                    new Book(){Title = "Book14"},
                    new Book(){Title = "Book15"},
                    new Book(){Title = "Book16"},
                    new Book(){Title = "Book17"},
                    new Book(){Title = "Book18"},
                    new Book(){Title = "Book19"},
                    new Book(){Title = "Book20"},
                    new Book(){Title = "Book21"},
                }
            };

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}