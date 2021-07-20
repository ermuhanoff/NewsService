using Epam.NewsService.BLL.Interfaces;
using Epam.NewsService.DAL.Interfaces;
using Epam.NewsService.Entities;

namespace Epam.NewsService.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDAO _userDAO;

        public UserLogic(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public bool AddUser(string login, string password, string firstname, string lastname, int role)
        {
            return _userDAO.AddUser(new User(login, password, firstname, lastname, (User.UserRole)role));
        }

        public User Authentication(string email, string password)
        {
            return _userDAO.Authentication(email, password);
        }

        public void EditUser(int id)
        {
            _userDAO.EditUser(id);
        }

        public User GetUserByEmail(string email)
        {
            return _userDAO.GetUserByEmail(email);
        }

        public User GetUserById(int id)
        {
            return _userDAO.GetUserById(id);
        }

        public bool RemoveUser(int id)
        {
            return _userDAO.RemoveUser(id);
        }
    }
}
