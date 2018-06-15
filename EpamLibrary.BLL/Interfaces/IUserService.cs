using EpamLibrary.Contracts.Models;

namespace EpamLibrary.BLL.Interfaces
{
    public interface IUserService
    {
        void AddUser(Consumer consumer);

        void DeleteUser(int userId);

        int? Login(string login, string password);
    }
}