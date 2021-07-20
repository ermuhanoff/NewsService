using Epam.NewsService.Entities;
using System;

namespace Epam.NewsService.BLL.Interfaces
{
    public interface IUserLogic
    {
        bool AddUser(User user);
        bool RemoveUser(int id);
        void EditUser(int id);
        User GetById(int id);
    }
}
