using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using AutoMapper;
using EmapLibrary.UserInterface.ViewModels;
using EmapLibrary.UserInterface.ViewModels.Internal;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.Contracts.Models;

namespace EmapLibrary.UserInterface.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Login(string login = "", string password = "")
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
                return View(regViewModel);
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
                Page = page
            };

            return View(model);
        }

        public ActionResult History(int id = -1)
        {
            var user = _userService.GetById(id);
            var user1 = Mapper.Map<User, UserViewModel>(user);
            if (id != -1 || user1 != null)
                return View(user1);
            else
                return HttpNotFound();

        }

        public ActionResult LogOut(int id = -1)
        {
            //TODO: logout
            return Redirect("~/Home/Index");
        }
    }
}