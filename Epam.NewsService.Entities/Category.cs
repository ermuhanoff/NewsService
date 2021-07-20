using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NewsService.Entities
{
    public class Category
    {
        public Category(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public int Id { get; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
