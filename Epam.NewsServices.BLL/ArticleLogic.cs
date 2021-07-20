using Epam.NewsService.Entities;
using Epam.NewsService.BLL.Interfaces;
using Epam.NewsService.DAL.Interfaces;
using System.Collections.Generic;

namespace Epam.NewsService.BLL
{
    public class ArticleLogic : IArticleLogic
    {
        private IArticleDAO _articleDAO;

        public ArticleLogic(IArticleDAO articleDAO)
        {
            _articleDAO = articleDAO;
        }

        public IEnumerable<Article> GetAllArticles()
        {

            return _articleDAO.GetAllArticles();
        }

        public IEnumerable<Article> GetFollowArticles()
        {
            return _articleDAO.GetFollowArticles();
        }

        public bool AddArticle(Article article)
        {
            return _articleDAO.AddArticle(article);
        }

        public void EditArticle(int id, User moderator, string newText = null, string newTitle = null, string newIntroImageLink = null)
        {
            _articleDAO.EditArticle(id, moderator,newText , newTitle, newIntroImageLink);
        }

        public Article GetArticleById(int id)
        {
            return _articleDAO.GetArticleById(id);
        }

        public bool RemoveArticle(int id)
        {
            return _articleDAO.RemoveArticle(id);
        }

        public IEnumerable<Article> GetArticlesByCategory(Category category)
        {
            return _articleDAO.GetArticlesByCategory(category);
        }

        public IEnumerable<Article> GetArticlesByTitle(string title)
        {
            return _articleDAO.GetArticlesByTitle(title);
        }
    }
}
