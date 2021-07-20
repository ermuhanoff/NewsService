using Epam.NewsService.DAL.Interfaces;
using Epam.NewsService.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace Epam.NewsService.SqlDAL
{
    class SqlUserDAO : IUserDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool AddUser(User user)
        {
            using (var _connection = new SqlConnection(_connectionString))
            {
                var stProc = "AddUser";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", user.Id);

                command.Parameters.AddWithValue("@Text", article.Text);
                command.Parameters.AddWithValue("@Title", article.Title);
                command.Parameters.AddWithValue("@CreationTime", article.CreationTime);
                command.Parameters.AddWithValue("@ModeratorId", article.Moderator.Id);
                command.Parameters.AddWithValue("@IntroImageLink", article.Moderator.Id);
                command.Parameters.AddWithValue("@CategoryId", article.Category.Id);
                command.Parameters.AddWithValue("@Likes", article.Likes);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public void EditUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveUser(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
