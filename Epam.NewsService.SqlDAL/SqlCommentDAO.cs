using Epam.NewsService.DAL.Interfaces;
using Epam.NewsService.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System;

namespace Epam.NewsService.SqlDAL
{
    public class SqlCommentDAO : ICommentDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool AddComment(Comment comment)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("AddComment", _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@CreationTime", comment.GetDateTimeString(comment.CreationTime));
                command.Parameters.AddWithValue("@EditedTime", comment.GetDateTimeString(comment.EditedTime));
                command.Parameters.AddWithValue("@Content", comment.Content);
                command.Parameters.AddWithValue("@UserId", comment.Author.Id);
                command.Parameters.AddWithValue("@ArticleId", comment.ArticleId);
                command.Parameters.AddWithValue("@Likes", comment.Likes);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public void EditComment(int id, string newText)
        {
            throw new System.NotImplementedException();
        }

        public bool LikeComment(int id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Comments SET Likes = Likes + 1 WHERE Comments.Id = @Id";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool UnlikeComment(int id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Comments SET Likes = Likes - 1 WHERE Comments.Id = @Id";

                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return ExecuteStoredProcedure("GetComments");
        }

        public IEnumerable<Comment> GetCommentsByArticleId(int articleId)
        {
            return ExecuteStoredProcedure(
                            "GetCommentsByArticleId",
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
            DateTime? editedTime = (DateTime?)(reader.IsDBNull(4) ? null : reader[4]);

            return new Comment(
                (int)reader["CommentId"],
                (int)reader["ArticleId"],
                SqlUserDAO.CreateUserFromReader(reader),
                (DateTime)reader["CommentCreationTime"],
                editedTime,
                (string)reader["Content"],
                (int)reader["CommentLikes"]);
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

