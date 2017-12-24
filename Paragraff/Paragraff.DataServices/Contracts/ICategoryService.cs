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
        IEnumerable<CategoryViewModel> GetAllCategories();
        void DeleteCategory(Guid categoryId);
        void AddCategory(string name);
        void ToggleActivity(Guid id);

    }
}
