using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Paragraff.DataServices.Contracts;
using Paragraff.ViewModels.ReviewViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paragraff.Controllers
{
    public class CommentController : Controller
    {

        private readonly ICommentService commentService;
        private readonly ApplicationUserManager userManager;

        public CommentController(ICommentService commentService, ApplicationUserManager userManager)
        {
            Guard.WhenArgument(commentService, "commentService").IsNull().Throw();
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();

            this.commentService = commentService;
            this.userManager = userManager;
        }
        
        public ActionResult SubmitPostComments(Guid postId)
        {
            CommentReviewViewModel commentVm = new CommentReviewViewModel()
            {
                PostId = postId
            };
            return this.PartialView("_SubmitPostComments", commentVm);
        }

        public ActionResult ShowComments(Guid postId)
        {
            var comments = this.commentService.GetCommentsForPost(postId)
                .Select(dto => new CommentReviewViewModel()
                {
                    Content = dto.Content,
                    CreatedOn = dto.CreatedOn,
                    Username = this.userManager.FindById(dto.AuthorId).UserName
                });

            return this.PartialView("_ViewPostComments", comments);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(CommentReviewViewModel commentVm)
        {
            this.commentService.CreateComment(commentVm);

            return this.RedirectToAction("Post", "Review", new { area = "", postId = commentVm.PostId });
        }
    }
}