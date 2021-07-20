using Epam.NewsService.Entities;
using System.Collections.Generic;

namespace Epam.NewsService.BLL.Interfaces
{
    public interface ICommentLogic
    {
        bool AddComment(string content, User author, int articleId);
        bool RemoveComment(int id);
        void EditComment(int id, string newText);
        bool LikeComment(int id);
        bool UnlikeComment(int id);
        Comment GetCommentById(int id);
        IEnumerable<Comment> GetAllComments();
        IEnumerable<Comment> GetCommentsByArticleId(int articleId);
        IEnumerable<Comment> GetCommentsFromUser(int userId);
    }
}
