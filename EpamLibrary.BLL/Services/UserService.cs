using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.Contracts.Enums;
using EpamLibrary.Contracts.Exception;
using EpamLibrary.Contracts.Models;
using EpamLibrary.Contracts.Models.Abstracts;
using EpamLibrary.DAL.Interfaces;

namespace EpamLibrary.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
       // private readonly IRepository<Consumer> _consumeRepository;
       // private readonly IRepository<Worker> _workerRepository;
        private readonly IRepository<User> _userRepository;

        public UserService(
            // IRepository<Worker> workerRepository, 
            // IRepository<Consumer> consumeRepository, 
            IUnitOfWork unitOfWork, 
            IRepository<User> userRepository)
        {
            //_workerRepository = workerRepository;
            //_consumeRepository = consumeRepository;

            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public void AddUser(User consumer)
        {
            if(UserExists(consumer.Login))
                throw new UserExistsException();

            //_consumeRepository.Create(consumer);
            _userRepository.Create(consumer);
        }

        
        public void DeleteUser(int userId)
        {
            var user = _userRepository.GetById(userId);
            
             if(user.UserType != UserType.Consumer)

            _userRepository.Delete(userId);
        }

        public bool Login(string login, string password)
        {
            if (_userRepository.Get(c => c.Login == login).Any())
            {
                //TODO: login
            }
            else if (_userRepository.Get(w => w.Login == login).Any())
            {

            }
            else
            {
                return false;
            }

            return false;
        }
       
        public void SetAsWorker(int id, string workerNumber, UserType type)
        {
            var user = _userRepository.GetById(id);
            _userRepository.Delete(id);
            var worker = new User()
            {
                Birthday = user.Birthday,
                BooksHistory = user.BooksHistory,
                Comments = user.Comments,
                EMail = user.EMail,
                HiringDate = DateTime.UtcNow,
                LastName = user.LastName,
                Login = user.Login,
                Name = user.Name,
                Password = user.Password,
                Surname = user.Surname,
                WorkerNumber = workerNumber,
                UserType = type
            };
            _userRepository.Create(worker);
        }

        public bool UserExists(string login)
        {
           var users= _userRepository.Get(c => c.Login == login);
            var enumerable = users as User[] ?? users.ToArray();
            if (!enumerable.Any())
                return false;
            else if (enumerable.Count() > 1)
                //TODO:write log
                return true;
            else
                return true;
        }

        public void Edit(User user)
        {
            var us = _userRepository.GetById(user.Id);
            us.Name = user.Name;
            us.Surname = user.Surname;
            us.LastName = user.LastName;
            us.EMail = user.EMail;
            us.Birthday = user.Birthday;
            us.Password = user.Password;
            us.UserType = user.UserType;
            us.WorkerNumber = user.WorkerNumber;
            us.ReaderCardNumber = user.ReaderCardNumber;
            _userRepository.Update(us);
        }

        public IEnumerable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _userRepository.Get(predicate);
        }

        public User GetById(int userId)
        {
            return _userRepository.GetById(userId);
        }
    }
}