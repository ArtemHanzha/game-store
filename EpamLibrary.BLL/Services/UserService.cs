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
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<LibraryLogRecord> _journalRepository;

        public UserService(
            IUnitOfWork unitOfWork,
            IRepository<User> userRepository,
            IRepository<LibraryLogRecord> journalRepository)
        {

            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _journalRepository = journalRepository;
        }

        public void AddUser(User consumer)
        {
            if (UserExists(consumer.Login))
                throw new UserExistsException();

            _userRepository.Create(consumer);
        }

        public void DeleteUser(int userId)
        {
            var user = _userRepository.GetById(userId);

            if (user.UserType != UserType.Consumer)

                _userRepository.Delete(userId);
        }
        
        public bool UserExists(string login)
        {
            var users = _userRepository.Get(c => c.Login == login);
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

        public Dictionary<DateTime, ICollection<Book>> GetUserBooks(int id)
        {
            var history = new Dictionary<DateTime, ICollection<Book>>();
            var allTest = _journalRepository.Get(); //TODO: remove this
            var journal = _journalRepository.Get(j => j.Reader.Id == id && !j.IsDeleted);

            foreach (var record in journal)
            {
                if (record.RentalTime != null)
                {
                    if(!history.ContainsKey(record.RentalTime.Value.Date))
                        history.Add(record.RentalTime.Value.Date, new List<Book>());

                    history[record.RentalTime.Value.Date].Add(record.BookInstance.Book);//TODO: fix nullRefExc
                }
            }

            return history;
        }
    }
}