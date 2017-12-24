using Bytes2you.Validation;
using Paragraff.DataServices.Contracts;
using Paragraff.ViewModels.BookViewModels;
using Paragraff.ViewModels.PostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paragraff.Controllers
{
    public class PostController : Controller
    {
        private readonly ICategoryService categoryService;

        public PostController(ICategoryService categoryService)
        {
            Guard.WhenArgument(categoryService, "categoryServuce").IsNull().Throw();

            this.categoryService = categoryService;
        }


        public ActionResult NewPost()
        {
            var allCategories = this.categoryService.GetAllCategories();
            var statesAsStr = allCategories.Select(c => c.CategoryName);

            var states = this.GetSelectListItems(statesAsStr);

            var bookVm = new NewBookViewModel()
            {
                Categories = states
            };

            var postVm = new NewPostViewModel()
            {
                Book = bookVm
            };

            return this.View(postVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(NewPostViewModel postVm)
        {
            return this.RedirectToAction("Index", "Home");
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }
    }
}