using Paragraff.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paragraff.ViewModels.CategoriesViewModels;
using Paragraff.Data;
using Paragraff.Data.Models;

namespace Paragraff.DataServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddCategory(CategoryViewModel category)
        {
            throw new NotImplementedException();
        }

        public void DeactivateCategory(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Guid categoryId)
        {
            Category category = new Category() { Id = categoryId };

            this.context.Categories.Attach(category);
            this.context.Categories.Remove(category);
            this.context.SaveChanges();
        }

        public List<CategoryViewModel> GetAllCategories()
        {
            var allCategories = this.context.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    IsActive = c.IsActive
                })
                .ToList();

            return allCategories;
        }
    }
}
