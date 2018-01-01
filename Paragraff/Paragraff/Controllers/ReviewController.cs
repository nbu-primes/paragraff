using Bytes2you.Validation;
using Paragraff.DataServices.Contracts;
using Paragraff.ViewModels.ReviewViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paragraff.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            Guard.WhenArgument(reviewService, "reviewService").IsNull().Throw();

            this.reviewService = reviewService;
        }

        public ActionResult Post(Guid postId)
        {
            return this.View(postId);
        }

        [ChildActionOnly]
        //[OutputCache(Duration = 120)]
        public ActionResult PostInfo(Guid postId)
        {
            var review = this.reviewService.GetPostReview(postId);

            Guard.WhenArgument(review, "review").IsNull().Throw();

            var reviewVm = new PostReviewViewModel()
            {
                IsRated = review.Ratings.Any(),
                Comments = review.Comments.Select(c => new CommentReviewViewModel()
                {
                    CreatorId = c.CreatorId,
                    Content = c.Content,
                    CreatedOn = c.CreatedOn
                }),
                Book = new BookReviewViewModel()
                {
                    Id = review.Book.Id,
                    Author = review.Book.Author,
                    Category = review.Book.Category,
                    Title = review.Book.Title
                },
                Description = review.Description,
                CreatedOn = review.CreatedOn,
                IsOwned = review.IsOwned,
                IsRead = review.IsRead,
                IsTradable = review.IsTradable,
                Price = review.Price,
                PublisherId = review.PublisherId
            };

            return this.PartialView("_PostInfo", reviewVm);
        }
        
    }
}