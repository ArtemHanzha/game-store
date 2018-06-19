using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using AutoMapper;
using EmapLibrary.Auth.Interfaces;
using EmapLibrary.UserInterface.ViewModels;
using EmapLibrary.UserInterface.ViewModels.Internal;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.Contracts.Models;

namespace EmapLibrary.UserInterface.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IJournalRecordService _journalRecord;

        public UserController(
            IUserService userService,
            IJournalRecordService journalRecord,
            IAuthentication auth) : base(auth)
        {
            _userService = userService;
            _journalRecord = journalRecord;
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

        public ActionResult Edit(
            string email,
            string password1,
            string password2,
            string name,
            string surname,
            string lastname,
            string birthday)
        {
            Regex emailRegex = new Regex(@"\A[^@]+@([^@\.]+\.)+[^@\.]+\z");
            
            var regViewModel = new RegistrationViewModel
            {
                Name = name,
                Surname = surname,
                LastName = lastname,
                Email = email,
                Birthday = birthday,
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
                var user = _userService.GetById(0);//user id = id
                user.EMail = email;
                user.Name = name;
                user.Surname = surname;
                user.LastName = lastname;
                DateTime.TryParse(birthday, out var a);
                user.Birthday = a;
                user.Password = password1;
                _userService.Edit(user);

                return Redirect("~/User/UserInfo?id="+user.Id);
            }
        }

        public ActionResult Settings(int id = -1)
        {
            UserViewModel us = null;
            if (id != -1)
               us = Mapper.Map<User, UserViewModel>( _userService.GetById(id));
            if (us == null || id == -1)
                return HttpNotFound();
            return View();
        }

        public ActionResult UserList(int page = 1)
        {
            var users = _userService.Get(null).Skip((page-1)*10).Take(page*10);

            var model=  new UserListViewModel()
            {
                Users = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users),
                CurrentPage = page
            };

            return View(model);
        }

        public ActionResult History(int id = -1)
        {
            var books = _userService.GetUserBooks(id);
            var viewBooks = new Dictionary<DateTime, IEnumerable<BookViewModel>>();
            foreach (var book in books)
            {
                viewBooks[book.Key] = Mapper.Map<ICollection<Book>, ICollection<BookViewModel>>(book.Value);
            }

           //TODO: orderBy viewBooks
            return View(new UserBooksViewModel(){ HistoryDictionary = viewBooks});

        }
        
        public ActionResult LogEdit(
            string instanceNumber,
            string instanceTitle,
            string userId,
            string workerId,
            string rentalTime,
            string expectedTime,
            string realTime)
        {
            var user = _userService.GetById(int.Parse(userId));
            var worker = _userService.GetById(int.Parse(workerId));
            if (user == null || worker == null)
                return Redirect("~/User/LogSetup/");//TODO: id of log

            var log = new LibraryLogRecordViewModel()
            {
                BookInstacneNumber = int.Parse(instanceNumber),
                BookInstanceNameTitle = instanceTitle,
                ExpectedReturnTime = DateTime.Parse(expectedTime),
                RentalTime = DateTime.Parse(rentalTime),
                RealReturnTime = DateTime.Parse(realTime)
            };
            _journalRecord.Edit(Mapper.Map<LibraryLogRecordViewModel, LibraryLogRecord>(log)); //TODO: make edit method
            return Redirect("/User/Journal");
        }

        public ActionResult UserInfo(int id = -1)
        {
            var user = _userService.GetById(id);
            if(user != null)
             return View();
            else
            {
                return HttpNotFound();
            }
        }
        
    }
}