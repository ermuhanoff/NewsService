using Epam.NewsService.DAL.Interfaces;
using Epam.NewsService.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Epam.NewsService.SqlDAL
{
    public class SqlUserDAO : IUserDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool AddUser(User newUser)
        {
            try
            {
                GetUserByEmail(newUser.Login);

                return false;
            }
            catch
            {
                using (var _connection = new SqlConnection(_connectionString))
                {
                    var stProc = "AddUser";

                    var command = new SqlCommand(stProc, _connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@Login", newUser.Login);
                    command.Parameters.AddWithValue("@Password", newUser.Password);
                    command.Parameters.AddWithValue("@FirstName", newUser.FirstName);
                    command.Parameters.AddWithValue("@LastName", newUser.LastName);
                    command.Parameters.AddWithValue("@Role", newUser.Role);

                    _connection.Open();

                    var result = command.ExecuteNonQuery();

                    return result > 0;
                }

            }
        }

        public void EditUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(int id)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "GetUserById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return CreateUserFromReader(reader);
                }

                throw new InvalidOperationException("Cannot find user with ID = " + id);
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "GetUserByEmail";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Email", email);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return CreateUserFromReader(reader);
                }

                throw new InvalidOperationException("Cannot find user with email = " + email);
            }
        }

        public User Authentication(string email, string password)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Authentication";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return CreateUserFromReader(reader);
                }

                throw new InvalidOperationException("Cannot find user with email = " + email + " and password = " + password);
            }
        }

        public bool RemoveUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public static User CreateUserFromReader(SqlDataReader reader)
        {
            return new User(
                (int)reader["UserId"],
                (string)reader["Login"],
                (string)reader["Password"],
                (string)reader["FirstName"],
                (string)reader["LastName"],
                (User.UserRole)reader["Role"],
                new List<Category>());
        }
    }
}
