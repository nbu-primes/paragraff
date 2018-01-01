using Paragraff.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paragraff.ViewModels.ReviewDTOs;
using Bytes2you.Validation;
using Paragraff.Data;

namespace Paragraff.DataServices
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext context;

        public ReviewService(ApplicationDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }

        public PostReviewDto GetPostReview(Guid postId)
        {
            Guard.WhenArgument(postId, "postId").IsEqual(Guid.Empty).Throw();

            var review = context.Posts.Where(p => p.Id == postId)
                .Select(p => new PostReviewDto()
                {
                    PublisherId = p.PublisherId,
                    Description = p.Description,
                    CreatedOn = p.CreatedOn,
                    Ratings = p.PostRatings.Select(r => r.Rating),
                    IsRead = p.IsRead,
                    IsOwned = p.IsOwned,
                    IsTradable = p.IsTradable,
                    Comments = p.Comments.Select(c => new CommentReviewDto()
                    {
                        CreatorId = c.CreatorId,
                        Content = c.Content,
                        CreatedOn = c.CreatedOn
                    }),
                    Book = new BookReviewDto()
                    {
                        Id = p.Book.Id,
                        Author = p.Book.Author,
                        Category = p.Book.Category.CategoryName,
                        Title = p.Book.Title
                    },
                    Price = p.Price
                })
                .First();

            return review;
        }
    }
}
