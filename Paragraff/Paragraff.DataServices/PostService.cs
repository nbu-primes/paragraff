using Paragraff.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paragraff.ViewModels.PostViewModels;
using Paragraff.Data.Models;
using Paragraff.Services.Contracts;
using Bytes2you.Validation;
using Paragraff.Services.Providers;
using Paragraff.Data;

namespace Paragraff.DataServices
{
    public class PostService : IPostService
    {
        private readonly IUserService userService;
        private readonly IFileConverter fileConverter;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly ApplicationDbContext context;

        public PostService(IUserService userService, IFileConverter fileConverter, 
            IDateTimeProvider dateTimeProvider, ApplicationDbContext context)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(fileConverter, "fileConverter").IsNull().Throw();
            Guard.WhenArgument(dateTimeProvider, "dateTimeProvider").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.userService = userService;
            this.fileConverter = fileConverter;
            this.dateTimeProvider = dateTimeProvider;
            this.context = context;
        }

        public void CreatePost(NewPostViewModel postVm, string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var bookVm = postVm.Book;
            
            var book = new Book()
            {
                Id = Guid.NewGuid(),
                Author = bookVm.Author,
                CategoryId = Guid.Parse(bookVm.Category),   
                Image = this.fileConverter.PostedToByteArray(bookVm.Image),
                PublishedOn = bookVm.PublishedOn,
                Publisher = bookVm.Publisher,
                Title = bookVm.Title
            };

            var post = new Post()
            {
                Id = Guid.NewGuid(),
                Book = book,
                CreatedOn = this.dateTimeProvider.Now(),
                IsActive = true,
                PublisherId = userId,
                Description = postVm.Description,
                Price = postVm.Price
            };

            var publisherRating = new PostRating()
            {
                Id = Guid.NewGuid(),
                Post = post,
                Rating = postVm.Rating,
                UserId = userId
            };

            post.PostRatings.Add(publisherRating);

            this.context.Posts.Add(post);
            this.context.SaveChanges();
        }
    }
}
