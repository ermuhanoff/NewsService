using Epam.NewsService.Entities;
using System;

namespace Epam.NewsService.BLL.Interfaces
{
    public interface IUserLogic
    {
        bool AddUser(string login, string password, string firstname, string lastname, int role);
        bool RemoveUser(int id);
        void EditUser(int id);
        User GetUserById(int id);
        User GetUserByEmail(string email);
        User Authentication(string email, string password);
    }
}
