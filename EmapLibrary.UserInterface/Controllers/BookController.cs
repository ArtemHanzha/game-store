using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using EmapLibrary.Auth.Interfaces;
using EmapLibrary.UserInterface.ViewModels;
using EmapLibrary.UserInterface.ViewModels.Internal;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.Contracts.Models;
using Microsoft.Ajax.Utilities;

namespace EmapLibrary.UserInterface.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        private readonly ICommentService _commentService;
        private readonly IBookInstanceService _bookInstanceService;

        public BookController(
            IBookService bookService, 
            ICommentService commentService, 
            IBookInstanceService bookInstanceService,
            IAuthentication auth) : base(auth)
        {
            _bookService = bookService;
            _commentService = commentService;
            _bookInstanceService = bookInstanceService;
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

        public ActionResult BookInfo(int id = -1)
        {
            var book = _bookService.GetBook(id);
            var book1 = Mapper.Map<Book, BookViewModel>(book);
            var model = new BookInfoViewModel()
            {
                Book = book1,
                Page = 0,
                PageCount = 0//TODO: pages
            };
            if(book1!=null)
                return View(model);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult SetComment(
            int bookId,
            int mark,
            string text)
        {
            var com = new CommentViewModel()
            {
                Rating = mark,
                Review = text,
                Book = Mapper.Map<Book, BookViewModel>(_bookService.GetBook(bookId)),
                Reviewer = new UserViewModel() {Id = 1} //TODO: this user
            };
            _commentService.AddComment(bookId, Mapper.Map<CommentViewModel, Comment>(com)); //TODO: this mapper

            return BookInfo(bookId);
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

        public ActionResult AddBookInstance(int id)
        {
            _bookInstanceService.AddBookInstance(id,new BookInstance());
            return Redirect("~/Home/Index");
        }

        public ActionResult RemoveBookInstance(int id)
        {
            _bookInstanceService.RemoveBookInstance(id);
            return Redirect("~/Home/Index");
        }

        [HttpGet]
        public ActionResult EditBook(int id = -1, BookChangeViewModel bookModel = null)
        {
            if (bookModel == null || bookModel.FirstStart())
            {
                var book = _bookService.GetBook(id);
                var bookVm = Mapper.Map<Book, BookViewModel>(book);
                var model = new BookChangeViewModel(bookVm);
                return View(model);
            }
            else
            {
                return View(bookModel);
            }
        }

        [HttpPost]
        public ActionResult EditBook(BookChangeViewModel model)
        {
            if (model.HaveError())
            {
                return EditBook(model.Id, model);
            }
            else
            {
                _bookService.UpdateBook(Mapper.Map<BookChangeViewModel, Book>(model));
                return BookInfo(model.Id);
            }
        }
    }
}