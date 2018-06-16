using EpamLibrary.Contracts.Enums;
using EpamLibrary.Contracts.Models;

namespace EpamLibrary.BLL.Interfaces
{
    public interface IUserService
    {
        void AddUser(Consumer consumer);

        void DeleteConsumer(int userId);

        void DeleteWorker(int userId);

        bool Login(string login, string password);

        bool UserExist(string login);

        void SetAsWorker(int id, string workerNumber, WorkerType type);

        void SetWorkerType(int id, WorkerType type);
    }
}