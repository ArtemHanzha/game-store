using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.Contracts.Models;
using EpamLibrary.DAL.Interfaces;

namespace EpamLibrary.BLL.Services
{
    public class BookInstanceService : IBookInstanceService
    {
        private readonly IRepository<BookInstance> _bookInstanceRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookInstanceService(
            IRepository<BookInstance> bookInstanceRepository,
            IRepository<Book> bookRepository, 
            IUnitOfWork unitOfWork)
        {
            _bookInstanceRepository = bookInstanceRepository;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddBookInstance(int bookId, BookInstance instance)
        {
            var book = _bookRepository.GetById(bookId);
            instance.Book = book;
            _bookInstanceRepository.Create(instance);
            _unitOfWork.Save();
        } //TODO: bookInstanceID instead of bookID

        public BookInstance GetBookInstance(int bookId)
        {
            return _bookInstanceRepository.GetById(bookId);
        }

        public void RemoveBookInstance(int instanceId)
        {
            _bookInstanceRepository.Delete(instanceId);
            _unitOfWork.Save();
        }
    }
}
