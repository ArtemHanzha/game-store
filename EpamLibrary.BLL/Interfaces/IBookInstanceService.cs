using EpamLibrary.Contracts.Models;

namespace EpamLibrary.BLL.Interfaces
{
    public interface IBookInstanceService
    {
        void AddBookInstance(int bookId, BookInstance instance);

        BookInstance GetBookInstance(int bookId);

        void RemoveBookInstance(int instanceId);
    }
}