using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EpamLibrary.Contracts.Enums;
using EpamLibrary.Contracts.Models;

namespace EpamLibrary.BLL.Interfaces
{
    public interface IUserService
    {
        void AddUser(User consumer);

        void DeleteUser(int userId);
        
        bool UserExists(string login);

        void Edit(User user);

        IEnumerable<User> Get(Expression<Func<User, bool>> predicate);

        User GetById(int userId);

        Dictionary<DateTime, ICollection<Book>> GetUserBooks(int id);
    }
}