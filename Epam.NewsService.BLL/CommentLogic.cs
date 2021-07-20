using Epam.NewsService.BLL.Interfaces;
using Epam.NewsService.DAL.Interfaces;
using Epam.NewsService.Entities;
using System.Collections.Generic;

namespace Epam.NewsService.BLL
{
    public class CommentLogic : ICommentLogic
    {
        private ICommentDAO _commentDAO;

        public CommentLogic(ICommentDAO commentDAO)
        {
            _commentDAO = commentDAO;
        }

        public bool AddComment(string content, User author, int articleId)
        {
            return _commentDAO.AddComment(new Comment(articleId, author, content));
        }

        public void EditComment(int id, string newText)
        {
            _commentDAO.EditComment(id, newText);
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _commentDAO.GetAllComments();
        }

        public Comment GetCommentById(int id)
        {
            return _commentDAO.GetCommentById(id);
        }

        public IEnumerable<Comment> GetCommentsByArticleId(int articleId)
        {
            return _commentDAO.GetCommentsByArticleId(articleId);
        }

        public IEnumerable<Comment> GetCommentsFromUser(int userId)
        {
            return _commentDAO.GetCommentsFromUser(userId);
        }

        public bool LikeComment(int id)
        {
            return _commentDAO.LikeComment(id);
        }

        public bool RemoveComment(int id)
        {
            return _commentDAO.RemoveComment(id);
        }

        public bool UnlikeComment(int id)
        {
            return _commentDAO.UnlikeComment(id);
        }
    }
}
