using Paragraff.Data.Models;
using Paragraff.ViewModels.BookViewModels;
using Paragraff.ViewModels.DataTransferObjects;
using Paragraff.ViewModels.ReviewDTOs;
using Paragraff.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paragraff.DataServices.Contracts
{
    public interface IUserService
    {
        ProfilePictureDto GetUserProfilePicture(string username);
        EditUserViewModel FindUserByUsername(string id);
        void EditUser(string username, EditUserViewModel data);
        IEnumerable<BookReviewDto> GetWishlist(string username);
        void AddToWishlist(NewBookViewModel model, string id);
    }
}
