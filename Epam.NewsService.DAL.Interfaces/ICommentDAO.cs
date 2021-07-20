using Epam.NewsService.Entities;
using System.Collections.Generic;

namespace Epam.NewsService.DAL.Interfaces
{
    public interface ICommentDAO
    {
        bool AddComment(Comment comment);
        bool RemoveComment(int id);
        void EditComment(int id, string newText);
        Comment GetCommentById(int id);
        IEnumerable<Comment> GetAllComments();
        IEnumerable<Comment> GetCommentsByArticleId(int articleId);
        IEnumerable<Comment> GetCommentsFromUser(int userId);
    }
}
