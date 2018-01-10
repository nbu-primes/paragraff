using Bytes2you.Validation;
using Paragraff.Data;
using Paragraff.Data.Models;
using Paragraff.DataServices.Contracts;
using Paragraff.Services.Contracts;
using Paragraff.ViewModels.BookViewModels;
using Paragraff.ViewModels.DataTransferObjects;
using Paragraff.ViewModels.ReviewDTOs;
using Paragraff.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.DataServices
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        private readonly IFileConverter fileConverter;

        public UserService(ApplicationDbContext context, IFileConverter fileConverter)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(fileConverter, "fileConverter").IsNull().Throw();

            this.context = context;
            this.fileConverter = fileConverter;
        }

        public void EditUser(string id, EditUserViewModel data)
        {
            Guard.WhenArgument(id, "id").IsNullOrEmpty().Throw();

            var user = this.context.Users.First(u=> u.Id == id);

            user.About = data.About;
            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.Gender = data.Gender;
            user.Email = data.Email;
            user.Location = data.Location;

            // if there is no uploaded image on next editing, dont remove the previous one
            if (data.ProfilePicture != null)
            {
                user.ProfilePicture = data.ProfilePicture;
            }

            this.context.SaveChanges();
        }

        public EditUserViewModel FindUserByUsername(string username)
        {
            var viewModel = this.context.Users
                .Where(u => u.UserName == username)
                .Select(user => new EditUserViewModel()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    About = user.About,
                    Email = user.Email,
                    Gender = user.Gender,
                    Location = user.Location,
                    ProfilePicture = user.ProfilePicture
                })
                .First();


            return viewModel;
        }

        public ProfilePictureDto GetUserProfilePicture(string username)
        {
            Guard.WhenArgument(username, "username").IsNull().Throw();

            var profilePicture = this.context.Users.Where(u => u.UserName == username)
                .Select(u => new ProfilePictureDto()
                {
                    Data = u.ProfilePicture
                })
                .First();

            return profilePicture;
        }

        public IEnumerable<BookReviewDto> GetWishlist(string username)
        {
            Guard.WhenArgument(username, "username").IsNullOrEmpty().Throw();

            var wishlist = this.context.Users.First(u => u.UserName == username).Wishlist.Select(b => new BookReviewDto()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Category = b.Category.CategoryName
            });

            return wishlist;
        }

        public void AddToWishlist(string title, string username)
        {
            Guard.WhenArgument(username, "username").IsNullOrEmpty().Throw();
            Guard.WhenArgument(title, "title").IsNullOrEmpty().Throw();

            var book = this.context.Books.Where(b => b.Title == title).First();

            var user = this.context.Users.First(u => u.UserName == username);

            user.Wishlist.Add(book);
            this.context.SaveChanges();
        }
    }
}
