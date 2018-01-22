using Paragraff.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paragraff.ViewModels.ReviewDTOs;
using Bytes2you.Validation;
using Paragraff.Data;
using Paragraff.ViewModels.PostViewModels;
using Paragraff.Data.Models;

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

        public byte[] GetBookImage(Guid bookId)
        {
            var image = this.context.Books.Find(bookId).Image;
            return image;
        }

        public PostReviewDto GetPostReview(Guid postId, string userId)
        {
            Guard.WhenArgument(postId, "postId").IsEqual(Guid.Empty).Throw();

            var review = context.Posts.Where(p => p.Id == postId)
                .Select(p => new PostReviewDto()
                {
                    RatedFromViewer = p.PostRatings.FirstOrDefault(pr => pr.UserId == userId).Rating,
                    PostId = p.Id,
                    PublisherId = p.PublisherId,
                    Description = p.Description,
                    CreatedOn = p.CreatedOn,
                    Ratings = p.PostRatings.Select(r => r.Rating),
                    IsRead = p.IsRead,
                    IsOwned = p.IsOwned,
                    IsTradable = p.IsTradable,
                    Comments = p.Comments.Select(c => new CommentReviewDto()
                    {
                        AuthorId = c.CreatorId,
                        Content = c.Content,
                        CreatedOn = c.CreatedOn
                    }),
                    Book = new BookReviewDto()
                    {
                        Id = p.Book.Id,
                        Author = p.Book.Author,
                        Category = p.Book.Category.CategoryName,
                        Title = p.Book.Title,
                        Wishers = p.Book.Wisher.Select(u => new UserViewModel() { UserId = u.Id, Username = u.UserName })
                    },
                    Price = p.Price
                })
                .First();

            return review;
        }

        public double RatePost(Guid postId, int ratedFromViewer, string userId)
        {
            var existing = this.context.PostRatings.FirstOrDefault(p => p.UserId == userId && p.PostId == postId);
            if(existing == null)
            {
                var postRating = new PostRating()
                {
                    Id = Guid.NewGuid(),
                    PostId = postId,
                    Rating = ratedFromViewer,
                    UserId = userId
                };
                this.context.PostRatings.Add(postRating);
            }
            else
            {
                existing.Rating = ratedFromViewer;
            }
            
            this.context.SaveChanges();

            // return avarage
            var ratingsForPost = this.context.PostRatings
                .Where(p => p.PostId == postId)
                .Select(p => p.Rating);

            return ratingsForPost.Average();
        }
    }
}
