using EpamLibrary.Contracts.Models;

namespace EpamLibrary.BLL.Interfaces
{
    public interface IBookInstanceService
    {
        void AddBookInstance(int bookInstanceId, BookInstance instance);

        BookInstance GetBookInstance(int bookId);

        void RemoveBookInstance(int instanceId);
    }
}