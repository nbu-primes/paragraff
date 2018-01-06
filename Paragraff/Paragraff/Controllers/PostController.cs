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

        public PostController(ICategoryService categoryService, IPostService postService, IFileConverter fileConverter)
        {
            Guard.WhenArgument(categoryService, "categoryServuce").IsNull().Throw();
            Guard.WhenArgument(postService, "postService").IsNull().Throw();
            Guard.WhenArgument(fileConverter, "fileConverter").IsNull().Throw();

            this.categoryService = categoryService;
            this.postService = postService;
            this.fileConverter = fileConverter;
        }

        [AllowAnonymous]
        public ActionResult AllPosts()
        {
            return this.View();
        }

        public ActionResult MyPosts()
        {
            return this.View();
        }

        public FileContentResult GetBookCover(Guid bookId)
        {
            var coverData = this.postService.GetBookCover(bookId);
            if(coverData == null)
            {
                var defaultImage = this.fileConverter.GetDefaultProfilePicture();

                return this.File(defaultImage, "image/png");
            }
            return this.File(coverData, "image/jpeg");
        }

        [ChildActionOnly]
        //[OutputCache(Duration = 60, VaryByParam = "userId")]
        public ActionResult SummaryPostsView(string userId)
        {

            var userPosts = this.postService.GetUserPosts(userId)
                .Select(p => new SummaryPostViewModel()
                {
                    PostId = p.PostId,
                    Ratings = p.Ratings,
                    IsRated = p.Ratings.Any(),
                    IsRead = p.IsRead,
                    IsTradable = p.IsTradable,
                    Price = p.Price,
                    PublisherId = p.PublisherId,
                    CreatedOn = p.CreatedOn,
                    Book = new SummaryBookViewModel()
                    {
                        Author = p.Book.Author,
                        Title = p.Book.Title,
                        BookId = p.Book.BookId
                    }
                })
                .OrderBy(p => p.CreatedOn);

            return this.PartialView("_SummaryPostsView", userPosts);
        }

        [ChildActionOnly]
        public ActionResult SummaryAllPostsView()
        {

            var userPosts = this.postService.GetAllPosts()
                .Select(p => new SummaryPostViewModel()
                {
                    PostId = p.PostId,
                    Ratings = p.Ratings,
                    IsRated = p.Ratings.Any(),
                    IsRead = p.IsRead,
                    IsTradable = p.IsTradable,
                    Price = p.Price,
                    PublisherId = p.PublisherId,
                    CreatedOn = p.CreatedOn,
                    Book = new SummaryBookViewModel()
                    {
                        Author = p.Book.Author,
                        Title = p.Book.Title,
                        BookId = p.Book.BookId
                    }
                })
                .OrderBy(p => p.CreatedOn);

            return this.PartialView("_SummaryPostsView", userPosts);
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