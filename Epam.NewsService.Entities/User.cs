using System;
using System.Collections.Generic;

namespace Epam.NewsService.Entities
{
    public class User
    {
        public User(int id, string firstName, string lastName, UserRole userRole)
        {
            FirstName = firstName;
            LastName = lastName;

            Id = id;
            Role = userRole;
            FollowCategories = new List<Category>();
        }
        public User(string firstName, string lastName, UserRole userRole)
        {
            FirstName = firstName;
            LastName = lastName;

            Id = 0;
            Role = userRole;
            FollowCategories = new List<Category>();
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

        public List<Category>  FollowCategories { get; set; }
    }
}
