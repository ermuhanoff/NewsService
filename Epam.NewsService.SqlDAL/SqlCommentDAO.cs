using Epam.NewsService.DAL.Interfaces;
using Epam.NewsService.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System;

namespace Epam.NewsService.SqlDAL
{
    class SqlCommentDAO : ICommentDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool AddComment(Comment comment)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                //var query = "INSERT INTO dbo.Articles(Text, Title, CreationTime, ModeratorId, IntroImageLink, CategoryId, Likes) " +
                //    "VALUES(@Text, @Title, @CreationTime, @ModeratorId, @IntroImageLink, @CategoryId, @Likes)";
                //var command = new SqlCommand(query, _connection);

                //command.Parameters.AddWithValue("@Text", article.Text);
                //command.Parameters.AddWithValue("@Title", article.Title);
                //command.Parameters.AddWithValue("@CreationTime", article.CreationTime);
                //command.Parameters.AddWithValue("@ModeratorId", article.Moderator.Id);
                //command.Parameters.AddWithValue("@IntroImageLink", article.Moderator.Id);
                //command.Parameters.AddWithValue("@CategoryId", article.Category.Id);
                //command.Parameters.AddWithValue("@Likes", article.Likes);

                //_connection.Open();

                //var result = command.ExecuteNonQuery();

                //return result > 0;
                return true;
            }
        }

        public void EditComment(int id, string newText)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return ExecuteStoredProcedure("GetComments");
        }

        public IEnumerable<Comment> GetCommentsByArticleId(int articleId)
        {
            return ExecuteStoredProcedure(
                            "GetComments",
                            new ProcedureParameter("@ArticleId", articleId));
        }

        public Comment GetCommentById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetCommentsFromUser(int userId)
        {
            return ExecuteStoredProcedure(
                 "GetCommentsFromUser",
                 new ProcedureParameter("@UserId", userId));
        }

        public bool RemoveComment(int id)
        {
            throw new NotImplementedException();
        }

        public static Comment CreateCommentFromReader(SqlDataReader reader)
        {
            return new Comment(
                (int)reader["CommentId"],
                SqlUserDAO.CreateUserFromReader(reader),
                (DateTime)reader["CreationTime"],
                (DateTime)reader["EditedTime"],
                (string)reader["Content"]);
        }

        private IEnumerable<Comment> ExecuteStoredProcedure(string procedureName, params ProcedureParameter[] parameters)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {

                var command = new SqlCommand(procedureName, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return CreateCommentFromReader(reader);
                }
            }
        }
    }


    struct ProcedureParameter
    {
        public ProcedureParameter(string key, object value)
        {
            Value = value;
            Key = key;
        }

        public object Value { get; set; }
        public string Key { get; set; }
    }
}

