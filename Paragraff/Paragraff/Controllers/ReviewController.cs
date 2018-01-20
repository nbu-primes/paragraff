using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Paragraff.DataServices.Contracts;
using Paragraff.ViewModels.ReviewViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Paragraff.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly ApplicationUserManager userManager;

        public ReviewController(IReviewService reviewService, ApplicationUserManager userManager)
        {
            Guard.WhenArgument(reviewService, "reviewService").IsNull().Throw();
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();

            this.reviewService = reviewService;
            this.userManager = userManager;
        }

        public ActionResult Post(Guid postId)
        {
            return this.View(postId);
        }
        
        public ActionResult GetBookImage(Guid bookId)
        {
            var imageData = this.reviewService.GetBookImage(bookId);

            // TODO: add default image
            if(imageData == null)
            {
                throw new NullReferenceException("no book cover");
            }else
            {
                return this.File(imageData, "image/jpeg");
            }
        }

        [ChildActionOnly]
        //[OutputCache(Duration = 120)]
        public ActionResult PostInfo(Guid postId)
        {
            var review = this.reviewService.GetPostReview(postId);

            Guard.WhenArgument(review, "review").IsNull().Throw();

            var reviewVm = new PostReviewViewModel()
            {
                PostId = review.PostId,
                IsRated = review.Ratings.Any(),
                Comments = review.Comments.Select(c => new CommentReviewViewModel()
                {
                    Username = c.AuthorId,
                    Content = c.Content,
                    CreatedOn = c.CreatedOn
                }),
                Book = new BookReviewViewModel()
                {
                    Id = review.Book.Id,
                    Author = review.Book.Author,
                    Category = review.Book.Category,
                    Title = review.Book.Title,
                    Wishers = review.Book.Wishers
                },
                Description = review.Description,
                CreatedOn = review.CreatedOn,
                IsOwned = review.IsOwned,
                IsRead = review.IsRead,
                IsTradable = review.IsTradable,
                Price = review.Price,
                Username = this.userManager.FindById(review.PublisherId).UserName,
                Ratings = review.Ratings
            };

            return this.PartialView("_PostInfo", reviewVm);
        }
        
    }
}