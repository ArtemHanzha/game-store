using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EpamLibrary.Contracts.Models;

namespace EpamLibrary.BLL.Interfaces
{
    public interface IAuthorService
    {
        void AddAuthor(Author author);

        Author GetAuthor(int authorId);

        IEnumerable<Author> GetAuthors(Expression<Func<Author, bool>> predicate = null, int from = 0, int count = 10);

        void RemoveAuthor(int authorId);
    }
}