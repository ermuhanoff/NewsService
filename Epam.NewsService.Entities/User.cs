using System;
using System.Collections.Generic;

namespace Epam.NewsService.Entities
{
    public class User
    {
        public User(string login, string password, string firstName, string lastName, UserRole userRole)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
            Role = userRole;

            Id = -1;
            FollowCategories = new List<Category>();
        }

        public User(int id, string login, string password, string firstName, string lastName, UserRole userRole, IEnumerable<Category> categories)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
            Role = userRole;
            Id = id;
            FollowCategories = categories;
        }

        public enum UserRole
        {
            DEFAULT,
            MODERATOR
        }

        public int Id { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UserRole Role { get; }

        public IEnumerable<Category>  FollowCategories { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }


        public string GetRoleString(UserRole role) => Enum.GetName(typeof(UserRole), role);
        
        public bool IsModerator() => Role == UserRole.MODERATOR;
        
    }
}
