using Epam.NewsService.Entities;
using System.Collections.Generic;

namespace Epam.NewsService.DAL.Interfaces
{
    public interface IArticleDAO
    {
        bool AddArticle(Article article);
        bool RemoveArticle(int id);
        void EditArticle(int id, User moderator, string newText = null, string newTitle = null, string newIntroImageLink = null);
        Article GetArticleById(int id);
        IEnumerable<Article> GetAllArticles();
        IEnumerable<Article> GetArticlesByCategory(Category category);
        IEnumerable<Article> GetFollowArticles();
        IEnumerable<Article> GetArticlesByTitle(string title);
    }
}
