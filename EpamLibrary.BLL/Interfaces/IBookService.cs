using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EpamLibrary.Contracts.Models;

namespace EpamLibrary.BLL.Interfaces
{
    public interface IBookService
    {
        //here will be operation with books 
        //new book
        //get book
        //
        void AddBook(Book book);

        void RemoveBook(int bookId);

        Book GetBook(int bookId);

        IEnumerable<Book> GetBooks(Expression<Func<Book, bool>> predicate = null,
                                   int from = 0, 
                                   int count = 10);

        IEnumerable<Book> GetTopBooks(int count);
    }
}