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
using EpamLibrary.Contracts.Enums;
using EpamLibrary.Contracts.Models;

namespace EmapLibrary.UserInterface.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IJournalRecordService _journalService;

        public UserController(
            IUserService userService,
            IJournalRecordService journalService,
            IAuthentication auth) : base(auth)
        {
            _userService = userService;
            _journalService = journalService;
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
                Password = password1,
                Name = name,
                Surname = surname,
                LastName = lastname,
                Email = email,
                Birthday = birthday,
                Login = login,
                IsEmailError = email != null ? !emailRegex.IsMatch(email) : false,
                IsPassError = (password1 == null || password2 == null) ? false : password1 != password2,
                IsLoginError = _userService.UserExists(login)
            };

            if (!regViewModel.HaveError())
            {
                _userService.AddUser(Mapper.Map<RegistrationViewModel, User>(regViewModel));
                return RedirectToAction("Login", "Base");
            }
            else
            {
                return View(regViewModel);
            }
        }


        #region Default user

        [HttpGet]
        public ActionResult Settings(int id = -1, UserSettingsViewModel settings = null)
        {
            if (settings == null || settings.IsFirstIn)
            {
                if (_auth.User == null)
                    return HttpNotFound();
                var us = Mapper.Map<User, UserViewModel>(_userService.GetById(_auth.User.Id));
                return View(new UserSettingsViewModel() { User = us });
            }
            else
            {
                return View(settings);
            }
        }

        [HttpPost]
        public ActionResult Settings(
            string email,
            string password1,
            string password2,
            string name,
            string surname,
            string lastname,
            string birthday)
        {
            var settingsVm = new UserSettingsViewModel()
            {
                Email = email,
                Password = password1,
                Name = name,
                Surname = surname,
                LastName = lastname,
                StringBirthday = birthday,
                IsPassError = password1 != password2
            };

            if (settingsVm.HaveError())
                return RedirectToAction("Settings", settingsVm);

            var user = Mapper.Map<UserSettingsViewModel, User>(settingsVm);
            user.Id = _auth.User.Id;

            _userService.Edit(user);
            return RedirectToAction("UserInfo");
        }

        public ActionResult History()
        {
            var books = _userService.GetUserBooks(_auth.User.Id);
            var viewBooks = new Dictionary<DateTime, IEnumerable<BookViewModel>>();
            foreach (var book in books)
            {
                viewBooks[book.Key] = Mapper.Map<ICollection<Book>, ICollection<BookViewModel>>(book.Value);
            }

            //TODO: orderBy viewBooks
            return View(new UserBooksViewModel() { HistoryDictionary = viewBooks });

        }

        public ActionResult UserInfo()
        {
            var user = _userService.GetById(_auth.User.Id);
            var userView = Mapper.Map<User, UserViewModel>(user);
            return View(userView);
        }

        #endregion
        
        public ActionResult UserList(int page = 1)
        {
            var users = _userService.Get(null).Skip((page - 1) * 10).Take(page * 10);

            var model = new UserListViewModel()
            {
                Users = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users),
                CurrentPage = page
            };

            return View(model);
        }

        public ActionResult Journal(int page = 1)
        {
            var pageCount = (_journalService.RecordsCount() / RecordsOnPage) + 
                        (_journalService.RecordsCount() % RecordsOnPage != 0 ? 1 : 0);

            if (page > pageCount)
                return HttpNotFound();

            var logs = _journalService.GetRecords(null, RecordsOnPage * (page - 1), RecordsOnPage);
            var logsVm = Mapper.Map<IEnumerable<LibraryLogRecord>, IEnumerable<LibraryLogRecordViewModel>>(logs);

            var model = new LogListViewModel()
            {
                PageCount = pageCount,
                CurrentPage = page,
                Logs = logsVm
            };

            return View(model);
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
                BookInstacneNumber = instanceNumber,
                BookInstanceNameTitle = instanceTitle,
                ExpectedReturnTime = DateTime.Parse(expectedTime),
                RentalTime = DateTime.Parse(rentalTime),
                RealReturnTime = DateTime.Parse(realTime)
            };
            _journalService.Edit(Mapper.Map<LibraryLogRecordViewModel, LibraryLogRecord>(log)); //TODO: make edit method
            return Redirect("/User/Journal");
        }
        
        [HttpGet]
        public ActionResult ExpandedSettings(int id = -1, ExpandedSettingsViewModel setup = null)
        {
            if (_auth.User.UserType != UserType.Admin && _auth.User.UserType != UserType.Moderator)
                return HttpNotFound();

            if (setup == null || setup.IsFirstIn)
            {
                var user = _userService.GetById(id);
                var userVm = Mapper.Map<User, UserViewModel>(user);
                var model = new ExpandedSettingsViewModel() { User = userVm };
                model.UserId = id;

                return View(model);
            }
            else
            {
                return View(setup);
            }
        }

        [HttpPost]
        public ActionResult ExpandedSettings(
            string userid,
            int usertype,
            string workernumber,
            string librarynumber,
            string email,
            string password1,
            string password2,
            string name,
            string surname,
            string lastname,
            string birthday)
        {
            var model = new ExpandedSettingsViewModel()
            {
                Email = email,
                Password = password1,
                Name = name,
                Surname = surname,
                LastName = lastname,
                StringBirthday = birthday,
                IsPassError = password1 != password2,
                LibraryNumber = librarynumber,
                WorkerNumber = workernumber,
                UserType = (UserType)usertype,
                UserId = int.Parse(userid)
            };

            if (model.HaveError())
            {
                return ExpandedSettings(model.UserId, model);
            }

            model.Password = _userService.GetById(model.UserId).Password; // :(

            _userService.Edit(Mapper.Map<ExpandedSettingsViewModel, User>(model));

            return Redirect("/User/UserList");
        }
    }
}