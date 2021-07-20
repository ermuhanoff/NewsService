using Epam.NewsService.DAL.Interfaces;
using Epam.NewsService.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Epam.NewsService.SqlDAL
{
    public class SqlCategoryDAO : ICategoryDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool AddCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void EditCategory(int id, string newTitle, string newDesc)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "GetCategories";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return CreateCategoryFromReader(reader);
                }
            }
        }

        public Category GetCategoryById(int id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "GetCategoryById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return CreateCategoryFromReader(reader);
                }

                throw new InvalidOperationException("Cannot find Note with ID = " + id);
            }
        }

        public IEnumerable<Category> GetFollowCategoriesOfUser(int userId)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "GetFollowCategoriesOfUser";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@UserId", userId);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return CreateCategoryFromReader(reader);
                }
            }
        }

        public bool RemoveCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public static Category CreateCategoryFromReader(SqlDataReader reader)
        {
            return new Category(
                (int)reader["CategoryId"],
                (string)reader["CategoryTitle"],
                (string)reader["CategoryDesc"]);
        }
    }
}
