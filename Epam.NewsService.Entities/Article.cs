using System;
using System.Collections.Generic;

namespace Epam.NewsService.Entities
{
    public class Article
    {
        public Article(int id, string title, string text, User moderator, string introImageLink, Category category, string[] tags)
        {
            Title = title;
            Text = text;
            Moderator = moderator;
            IntroImageLink = introImageLink;
            Category = category;
            Tags = tags;

            Id = id;
            CreationTime = DateTime.Now;
            Comments = new List<Comment>();
            Likes = 0;
        }
        public Article(int id, string title, string text, User moderator, string introImageLink, Category category, string[] tags, DateTime creationTime, IEnumerable<Comment> comments, int likes)
        {
            Title = title;
            Text = text;
            Moderator = moderator;
            IntroImageLink = introImageLink;
            Category = category;
            Tags = tags;
            Id = id;
            CreationTime = creationTime;
            Comments = comments;
            Likes = likes;
        }

        public int Id { get; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime CreationTime { get; }

        public User Moderator { get; set; }

        public string IntroImageLink { get; set; }

        public Category Category { get; set; }

        public string[] Tags { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public int Likes { get; set; }
    }
}
