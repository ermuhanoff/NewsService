using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NewsService.Entities
{
    public class Comment
    {
        public Comment(int id, int articleId, User author, DateTime creationTime, DateTime? editedTime, string content, int likes)
        {
            Id = id;
            Author = author;
            CreationTime = creationTime;
            EditedTime = editedTime;
            Content = content;
            ArticleId = articleId;
            Likes = likes;
        }

        public Comment(int articleId, User author, string content)
        {
            Author = author;
            Content = content;
            ArticleId = articleId;

            Id = -1;
            CreationTime = DateTime.Now;
            EditedTime = null;
            Likes = 0;
        }

        public int Id { get; }

        public User Author { get; }

        public DateTime CreationTime { get; }

        public DateTime? EditedTime { get; set; }

        public string Content { get; set; }

        public int ArticleId { get; }

        public int Likes { get; set; }

        public string GetDateTimeString(DateTime? time)
        {
            if(time == null)
            {
                return "";
            }
            else
            {
                return ((DateTime)time).ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }
        }
    }
}
