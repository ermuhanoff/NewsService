using Epam.NewsService.BLL.Interfaces;
using Epam.NewsService.DAL.Interfaces;
using Epam.NewsService.Entities;
using System.Collections.Generic;

namespace Epam.NewsService.BLL
{
    public class CategoryLogic : ICategoryLogic
    {
        private ICategoryDAO _categoryDAO;

        public CategoryLogic(ICategoryDAO categoryDAO)
        {
            _categoryDAO = categoryDAO;
        }

        public bool AddCategory(Category category)
        {
            return _categoryDAO.AddCategory(category);
        }

        public void EditCategory(int id, string newTitle, string newDesc)
        {
            _categoryDAO.EditCategory(id, newTitle, newTitle);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryDAO.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return _categoryDAO.GetCategoryById(id);
        }

        public IEnumerable<Category> GetFollowCategoriesOfUser(int userId)
        {
            return _categoryDAO.GetFollowCategoriesOfUser(userId);
        }

        public bool RemoveCategory(int id)
        {
            return _categoryDAO.RemoveCategory(id);
        }
    }
}
