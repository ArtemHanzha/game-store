using System.Collections.Generic;
using EpamLibrary.Contracts.Models;

namespace EpamLibrary.BLL.Interfaces
{
    public interface ICommentService
    {
        void AddComment(int bookId, Comment commment);

        IEnumerable<Comment> GetComments(int bookId, int from = 0, int count = 10);

        Comment Get(int commentId);

        void RemoveComment(int commentId);
    }
}