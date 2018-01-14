using Bytes2you.Validation;
using Paragraff.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paragraff.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IUserService userService;

        public WishlistController(IUserService userService)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.userService = userService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [ChildActionOnly]
        public ActionResult WishlistSummary()
        {
            var wishlist = this.userService.GetWishlist(this.User.Identity.Name);

            return this.PartialView("_WishlistSummary", wishlist);
        }

        public ActionResult AddToWishlist(string title)
        {
            this.userService.AddToWishlist(title, this.User.Identity.Name);

            return this.RedirectToAction("AllPosts", "Post");
        }

        public ActionResult RemoveFromWishlist(string title)
        {
            this.userService.RemoveFromWishlist(title, this.User.Identity.Name);

            return this.RedirectToAction("Index");
        }
    }
}