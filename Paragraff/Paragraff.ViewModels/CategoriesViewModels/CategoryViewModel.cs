using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.ViewModels.CategoriesViewModels
{
    // vm same as model but => https://stackoverflow.com/a/16785700/4990859
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public bool IsActive { get; set; }
    }
}
