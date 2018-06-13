using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EpamLibrary.BLL.Interfaces;
using EpamLibrary.Contracts.Models;
using EpamLibrary.DAL.Interfaces;

namespace EpamLibrary.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(
            IRepository<Author> authorRepository, 
            IUnitOfWork unitOfWork)
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddAuthor(Author author)
        {
            _authorRepository.Create(author);
            _unitOfWork.Save();
        }

        public Author GetAuthor(int authorId)
        {
            return _authorRepository.GetById(authorId);
        }

        public IEnumerable<Author> GetAuthors(Expression<Func<Author, bool>> predicate = null, int @from = 0, int count = 10)
        {
           var authors = _authorRepository.Get(predicate);

            if (authors == null)
                return null;

            if(from > authors.Count())
                throw new ArgumentException();

            if (authors.Count() - from < count)
                count = authors.Count() - from;

            return authors.Skip(from).Take(count).ToList();
        }

        public void RemoveAuthor(int authorId)
        {
            _authorRepository.Delete(authorId);
            _unitOfWork.Save();
        }
    }
}
