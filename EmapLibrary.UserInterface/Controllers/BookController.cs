using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using EmapLibrary.UserInterface.ViewModels;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.Contracts.Models;
using Microsoft.Ajax.Utilities;

namespace EmapLibrary.UserInterface.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICommentService _commentService;

        public BookController(
            IBookService bookService, 
            ICommentService commentService)
        {
            _bookService = bookService;
            _commentService = commentService;
        }

        public ActionResult Catalog(int start = 0, int count = 10)
        {
            //TODO:get books from DB
            var books = _bookService.GetBooks(null, start, count);
            var model = new CatalogViewModel()
            {
                Books = Mapper.Map<IEnumerable<EpamLibrary.Contracts.Models.Book>, IEnumerable<BookViewModel>>(books)
            };
            return View(model);
        }

        public ActionResult Top()
        {
            var books = _bookService.GetTopBooks(100);
                
            var model = new CatalogViewModel()
            {
                Books = Mapper.Map<IEnumerable<EpamLibrary.Contracts.Models.Book>, IEnumerable<BookViewModel>>(books)
            };

            return View(model);
        }

        public ActionResult BookInfo(int bookId = -1)
        {
            var book = _bookService.GetBook(bookId);
            var book1 = Mapper.Map<Book, BookViewModel>(book);
            if(book1!=null)
                return View(book1);
            return HttpNotFound();
        }

        public ActionResult SetComment(
            int mark,
            string text)
        {
            var com = new CommentViewModel() //TODO: auth -> userID + bookId
            {
                Rating = mark,
                ReviewerFullName = "",
                Review = text,
                BookId = 0,
                ReviewerId = 0
            };
            _commentService.AddComment(0, Mapper.Map<CommentViewModel, Comment>(com)); //TODO: this mapper

            return BookInfo(0); //TODO: bookID
        }

        public ActionResult BookSetup(int id = -1)
        {
            //TODO: book setup
            return View();
        }

        [HttpPost]
        public ActionResult ChangeInstancesCount(int newCount, int bookId =-1)
        {
           var book =  _bookService.GetBook(bookId);
            if (book.ConcreteBooks.Count > newCount)
            {
                //TODO: this
            }
            else if (book.ConcreteBooks.Count < newCount)
            {

            }
            else
            {

            }

            return Redirect("~/Home/Index");
        }

    }
}