using System;
using System.Linq;
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
        private readonly IRepository<Consumer> _consumeRepository;
        private readonly IRepository<Worker> _workerRepository;

        public UserService(
            IRepository<Worker> workerRepository, 
            IRepository<Consumer> consumeRepository, 
            IUnitOfWork unitOfWork)
        {
            _workerRepository = workerRepository;
            _consumeRepository = consumeRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddUser(Consumer consumer)
        {
            if(UserExist(consumer.Login))
                throw new UserExistsException();

            _consumeRepository.Create(consumer);
        }

        public void DeleteConsumer(int userId)
        {
            _consumeRepository.Delete(userId);
        }

        public void DeleteWorker(int userId)
        {
            if(_workerRepository.Get().Count() <= 1)
                _workerRepository.Delete(userId);
        }

        public bool Login(string login, string password)
        {
            if (_consumeRepository.Get(c => c.Login == login).Any())
            {
                //TODO: login
            }
            else if (_workerRepository.Get(w => w.Login == login).Any())
            {

            }
            else
            {
                return false;
            }

            return false;
        }

        public bool UserExist(string login)
        {
            return WorkerExists(login) || ConsumerExists(login);
        }

        public void SetAsWorker(int id, string workerNumber, WorkerType type)
        {
            var user = _consumeRepository.GetById(id);
            _consumeRepository.Delete(id);
            Worker worker = new Worker()
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
                WorkerType = type
            };
            _workerRepository.Create(worker);
        }

        public void SetWorkerType(int id, WorkerType type)
        {
            var worker = _workerRepository.GetById(id);
            worker.WorkerType = type;
            _workerRepository.Update(worker);
        }

        private bool ConsumerExists(string login)
        {
           var users= _consumeRepository.Get(c => c.Login == login);
            var enumerable = users as Consumer[] ?? users.ToArray();
            if (!enumerable.Any())
                return false;
            else if (enumerable.Count() > 1)
                //TODO:write log
                return true;
            else
                return true;
        }

        private bool WorkerExists(string login)
        {
            var users = _workerRepository.Get(c => c.Login == login);
            var enumerable = users as Worker[] ?? users.ToArray();
            if (!enumerable.Any())
                return false;
            else if (enumerable.Count() > 1)
                //TODO:write log
                return true;
            else
                return true;
        }
    }
}