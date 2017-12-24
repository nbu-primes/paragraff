using Paragraff.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paragraff.ViewModels.CategoriesViewModels;
using Paragraff.Data;
using Paragraff.Data.Models;
using Bytes2you.Validation;

namespace Paragraff.DataServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddCategory(string name)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();

            var category = new Category()
            {
                Id = Guid.NewGuid(),
                CategoryName = name,
                IsActive = true
            };

            this.context.Categories.Add(category);
            this.context.SaveChanges();
        }
        
        public void DeleteCategory(Guid categoryId)
        {
            Category category = new Category() { Id = categoryId };

            this.context.Categories.Attach(category);
            this.context.Categories.Remove(category);
            this.context.SaveChanges();
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
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

        public void ToggleActivity(Guid id)
        {
            var category = this.context.Categories.Single(c => c.Id == id);

            category.IsActive = category.IsActive ? false : true;

            this.context.SaveChanges();
        }
    }
}
