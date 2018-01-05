using Bytes2you.Validation;
using Paragraff.Data;
using Paragraff.Data.Models;
using Paragraff.DataServices.Contracts;
using Paragraff.Services.Providers;
using Paragraff.ViewModels.ReviewViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.DataServices
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext context;
        private readonly IDateTimeProvider dateTimeProvider;

        public CommentService(ApplicationDbContext context, IDateTimeProvider dateTimeProvider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(dateTimeProvider, "dateTimeProvider").IsNull().Throw();

            this.context = context;
            this.dateTimeProvider = dateTimeProvider;
        }

        public void CreateComment(CommentReviewViewModel commentVm)
        {
            var comment = new Comment()
            {
                Id = Guid.NewGuid(),
                Content = commentVm.Content,
                CreatorId = commentVm.PublisherId,
                PostId = commentVm.PostId,
                CreatedOn = this.dateTimeProvider.Now()
            };

            this.context.Comments.Add(comment);
            this.context.SaveChanges();
        }
    }
}
