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
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(
            IRepository<Comment> commentRepository,
            IRepository<Book> bookRepository, 
            IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddComment(int bookId, Comment comment)
        {
            var book = _bookRepository.GetById(bookId);
            comment.Book = book;
            _commentRepository.Create(comment);
            _unitOfWork.Save();
        }

        public IEnumerable<Comment> GetComments(int bookId, int @from = 0, int count = 10)
        {
            var bookRewievs = _bookRepository.GetById(bookId).BookReviews;
            if (from >= bookRewievs.Count)
            {
                throw new ArgumentException();
            }

            if (bookRewievs.Count - @from < count)
                count = bookRewievs.Count - @from;
            return bookRewievs.Skip(@from).Take(count).ToList();
        }

        public Comment Get(int commentId)
        {
           return _commentRepository.GetById(commentId);
        }

        public void RemoveComment(int commentId)
        {
            if (_commentRepository.GetById(commentId) != null)
                _commentRepository.Delete(commentId);
            _unitOfWork.Save();
        }
    }
}
