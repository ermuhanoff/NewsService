using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NewsService.Entities
{
    public class Comment
    {
        public Comment(int id, User author, DateTime creationTime, DateTime editedTime, string content)
        {
            Id = id;
            Author = author;
            CreationTime = creationTime;
            EditedTime = editedTime;
            Content = content;
        }

        public int Id { get; }

        public User Author { get; }

        public DateTime CreationTime { get; }

        public DateTime EditedTime { get; set; }

        public string Content { get; set; }
    }
}
