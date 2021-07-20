using Epam.NewsService.Entities;
using System.Collections.Generic;

namespace Epam.NewsService.BLL.Interfaces
{
    public interface IArticleLogic
    {
        bool AddArticle(Article article);
        bool RemoveArticle(int id);
        void EditArticle(int id, User moderator, string newText = null, string newTitle = null, string newIntroImageLink = null);
        Article GetArticleById(int id);
        IEnumerable<Article> GetAllArticles();
        IEnumerable<Article> GetArticlesByCategory(int categoryId);
        IEnumerable<Article> GetFollowArticles(int userId);
        IEnumerable<Article> GetArticlesByTitle(string title);
    }
}
