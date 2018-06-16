using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using EmapLibrary.UserInterface.ViewModels;
using EpamLibrary.BLL.Interfaces;
using Microsoft.Ajax.Utilities;

namespace EmapLibrary.UserInterface.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        public ActionResult Catalog(int start = 0, int count = 10)
        {
            //TODO:get books from DB
            var books = _bookService.GetBooks(null, start, count);
            var model = new CatalogViewModel()
            {
                Books = _mapper.Map<IEnumerable<EpamLibrary.Contracts.Models.Book>, IEnumerable<BookViewModel>>(books)
            };
            return View(model);
        }

        public ActionResult Top()
        {
            var books = _bookService.GetBooks().OrderBy(
                c =>
                {
                    return c.BookReviews.Sum(s => ((int) s.Rating )/ c.BookReviews.Count);
                }).Take(100); 
                
                //TODO: add predicate to sort books by rating

            var model = new CatalogViewModel()
            {
                Books = _mapper.Map<IEnumerable<EpamLibrary.Contracts.Models.Book>, IEnumerable<BookViewModel>>(books)
            };

            return View(model);
        }
    }
}