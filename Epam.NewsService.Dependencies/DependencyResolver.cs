using Epam.NewsService.BLL;
using Epam.NewsService.BLL.Interfaces;
using Epam.NewsService.DAL.Interfaces;
using Epam.NewsService.SqlDAL;

namespace Epam.NewsService.Dependencies
{
    public class DependencyResolver
    {
        private static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DependencyResolver();
                }

                return _instance;
            }
        }

        public IArticleDAO ArtilceDAO => new SqlArticleDAO();

        public IArticleLogic ArticleLogic => new ArticleLogic(ArtilceDAO);
    }
}
