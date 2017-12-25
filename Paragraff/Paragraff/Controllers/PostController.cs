using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Paragraff.DataServices.Contracts;
using Paragraff.Services.Contracts;
using Paragraff.ViewModels.BookViewModels;
using Paragraff.ViewModels.CategoriesViewModels;
using Paragraff.ViewModels.PostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paragraff.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IPostService postService;
        private readonly IFileConverter fileConverter;

        public PostController(ICategoryService categoryService,IPostService postService, IFileConverter fileConverter)
        {
            Guard.WhenArgument(categoryService, "categoryServuce").IsNull().Throw();
            Guard.WhenArgument(postService, "postService").IsNull().Throw();
            Guard.WhenArgument(fileConverter, "fileConverter").IsNull().Throw();

            this.categoryService = categoryService;
            this.postService = postService;
            this.fileConverter = fileConverter;
        }
        
        public ActionResult NewPost()
        {
            var allCategories = this.categoryService.GetAllCategories();

            var states = this.GetSelectListItems(allCategories);

            var postVm = (NewPostViewModel)this.TempData["reSubmit"];
            if (postVm == null)
            {
                var bookVm = new NewBookViewModel()
                {
                    PublishedOn = DateTime.Now
                };

                postVm = new NewPostViewModel()
                {
                    Book = bookVm
                };
            }
            postVm.Book.Categories = states;
            return this.View(postVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(NewPostViewModel postVm)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var profilePicture = this.Request.Files["Book.Image"];

                    if (profilePicture.ContentLength > 0)
                    {
                        postVm.Book.Image = profilePicture;
                    }
                }
                var userId = this.User.Identity.GetUserId();
                this.postService.CreatePost(postVm, userId);

                return this.RedirectToAction("Index", "Home");
            }
            // use this view model in the redirected action
            this.TempData["reSubmit"] = postVm;
            return this.RedirectToAction("NewPost");
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<CategoryViewModel> elements)
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
                    Value = element.Id.ToString(),
                    Text = element.CategoryName
                });
            }

            return selectList;
        }
    }
}