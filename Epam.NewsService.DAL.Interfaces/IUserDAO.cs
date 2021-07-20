﻿using Epam.NewsService.Entities;

namespace Epam.NewsService.DAL.Interfaces
{
    public interface IUserDAO
    {
        bool AddUser(User user);
        bool RemoveUser(int id);
        void EditUser(int id);
        User GetById(int id);
    }
}
