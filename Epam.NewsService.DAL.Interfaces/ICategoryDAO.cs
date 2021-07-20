using Epam.NewsService.Entities;
using System.Collections.Generic;

namespace Epam.NewsService.DAL.Interfaces
{
    public interface ICategoryDAO
    {
        bool AddCategory(Category category);
        bool RemoveCategory(int id);
        void EditCategory(int id, string newTitle, string newDesc);
        Category GetCategoryById(int id);
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Category> GetFollowCategoriesOfUser(int userId);
    }
}
