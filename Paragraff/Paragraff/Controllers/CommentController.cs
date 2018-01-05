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

        public CommentController(ICommentService commentService)
        {
            Guard.WhenArgument(commentService, "commentService").IsNull().Throw();

            this.commentService = commentService;
        }

        public ActionResult PostCommentSection(Guid postId)
        {
            CommentReviewViewModel commentVm = new CommentReviewViewModel()
            {
                PostId = postId
            };
            return this.PartialView("_PostCommentSection", commentVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(CommentReviewViewModel commentVm)
        {
            this.commentService.CreateComment(commentVm);

            return this.RedirectToAction("Post", "Review", new { area = "", postId = commentVm.PostId });
        }
    }
}