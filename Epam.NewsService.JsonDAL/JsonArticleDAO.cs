using Epam.NewsService.DAL.Interfaces;
using Epam.NewsService.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Epam.NewsService.JsonDAL
{
    public class JsonArticleDAO : IArticleDAO
    {
        public const string JsonFilesPath = @"C:\Users\ermuh\Documents\epam_projects\Epam.NewsService\Epam.NewsService.JsonDAL\Files\";

        public bool AddArticle(Article article)
        {
            try
            {
                string json = JsonConvert.SerializeObject(article);

                File.WriteAllText(GetFilePathById(article.Id), json);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void EditArticle(int id, User moderator, string newText = null, string newTitle = null, string newIntroImageLink = null)
        {
            Article article = GetArticleById(id);

            if (newText != null) article.Text = newText;
            if (newTitle != null) article.Title = newTitle;
            if (newIntroImageLink != null) article.IntroImageLink = newIntroImageLink;

            article.Moderator = moderator;

            File.WriteAllText(GetFilePathById(id), JsonConvert.SerializeObject(article));
        }

        public IEnumerable<Article> GetAllArticles()
        {
            string[] files = Directory.GetFiles(JsonFilesPath);
            Article[] articles = new Article[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                articles[i] = JsonConvert.DeserializeObject<Article>(File.ReadAllText(files[i]));
            }

            return new List<Article>(articles);
        }

        public Article GetArticleById(int id)
        {
            if (!File.Exists(GetFilePathById(id)))
                throw new FileNotFoundException(
                    string.Format("File with name {0} at path {1} isn't created!",
                        id, JsonFilesPath));

            return JsonConvert.DeserializeObject<Article>(File.ReadAllText(GetFilePathById(id)));
        }

        public IEnumerable<Article> GetArticlesByCategory(int categoryId)
        {
            string[] files = Directory.GetFiles(JsonFilesPath);
            Article[] articles = new Article[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                var article = JsonConvert.DeserializeObject<Article>(File.ReadAllText(files[i]));
                if (article.Category.Id == categoryId)
                {
                    articles[i] = article;
                }
            }

            return new List<Article>(articles);
        }

        public IEnumerable<Article> GetArticlesByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetFollowArticles(int userId)
        {
            return new List<Article>();
        }

        public bool RemoveArticle(int id)
        {
            if (!File.Exists(GetFilePathById(id)))
            {
                return false;
            }

            File.Delete(GetFilePathById(id));

            return true;
        }

        private string GetFilePathById(int id) => JsonFilesPath + id + ".json";
    }
}
