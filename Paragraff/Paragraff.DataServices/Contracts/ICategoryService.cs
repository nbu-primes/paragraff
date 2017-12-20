using Paragraff.ViewModels.CategoriesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.DataServices.Contracts
{
    public interface ICategoryService
    {
        List<CategoryViewModel> GetAllCategories();
        void DeleteCategory(Guid categoryId);
        void DeactivateCategory(Guid categoryId);
        void AddCategory(CategoryViewModel category);
    }
}
