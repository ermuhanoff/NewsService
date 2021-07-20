using Epam.NewsService.DAL.Interfaces;
using Epam.NewsService.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Epam.NewsService.SqlDAL
{
    public class SqlArticleDAO : IArticleDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool AddArticle(Article article)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Articles(Text, Title, CreationTime, ModeratorId, IntroImageLink, CategoryId, Likes) " +
                    "VALUES(@Text, @Title, @CreationTime, @ModeratorId, @IntroImageLink, @CategoryId, @Likes)";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Text", article.Text);
                command.Parameters.AddWithValue("@Title", article.Title);
                command.Parameters.AddWithValue("@CreationTime", article.CreationTime);
                command.Parameters.AddWithValue("@ModeratorId", article.Moderator.Id);
                command.Parameters.AddWithValue("@IntroImageLink", article.IntroImageLink);
                command.Parameters.AddWithValue("@CategoryId", article.Category.Id);
                command.Parameters.AddWithValue("@Likes", article.Likes);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public Article GetArticleById(int id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "GetArticleById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return CreateArticleFromReader(reader);
                }

                throw new InvalidOperationException("Cannot find Note with ID = " + id);
            }
        }

        public IEnumerable<Article> GetAllArticles()
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "GetArticles";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return CreateArticleFromReader(reader);
                }
            }
        }

        public IEnumerable<Article> GetArticlesByCategory(int categoryId)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "GetArticlesByCategory";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@CategoryId", categoryId);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return CreateArticleFromReader(reader);
                }
            }
        }

        public IEnumerable<Article> GetFollowArticles(int userId)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "GetArticlesByTitle";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Title", "1");

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return CreateArticleFromReader(reader);
                }
            }
        }

        public IEnumerable<Article> GetArticlesByTitle(string title)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "GetArticlesByTitle";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Title", title);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return CreateArticleFromReader(reader);
                }
            }
        }

        public bool RemoveArticle(int id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Articles WHERE Articles.Id = @ArticleId";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@ArticleId", id);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public void EditArticle(int id, User moderator, string newText = null, string newTitle = null, string newIntroImageLink = null)
        {
            throw new NotImplementedException();
        }

        public static Article CreateArticleFromReader(SqlDataReader reader)
        {
            return new Article(
                        (int)reader["ArticleId"],
                        (string)reader["Title"],
                        (string)reader["Text"],
                        SqlUserDAO.CreateUserFromReader(reader),
                        (string)reader["IntroImageLink"],
                        SqlCategoryDAO.CreateCategoryFromReader(reader),
                        new string[] { },
                        (DateTime)reader["CreationTime"],
                        new Comment[] { },
                        (int)reader["Likes"]);
        }
    }
}
