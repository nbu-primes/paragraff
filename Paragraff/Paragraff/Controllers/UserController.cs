using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Paragraff.DataServices.Contracts;
using Paragraff.Services.Contracts;
using Paragraff.ViewModels.UserViewModels;
using System.IO;
using System.Web.Mvc;

namespace Paragraff.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IFileConverter fileConverter;

        public UserController(IUserService userService, IFileConverter fileConverter)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(fileConverter, "fileConverter").IsNull().Throw();

            this.userService = userService;
            this.fileConverter = fileConverter;
        }

        // Exclude the file, because it tries to parse it automatically, do i manually instead.
        // https://social.technet.microsoft.com/wiki/contents/articles/34445.mvc-asp-net-identity-customizing-for-adding-profile-image.aspx
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser([Bind(Exclude = "ProfilePicture")]EditUserViewModel userVm)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var profilePicture = this.Request.Files["ProfilePicture"];

                    // if there is no uploaded image on next editing, dont remove the previous one
                    if (profilePicture.ContentLength > 0)
                    {
                        var imgData = this.fileConverter.PostedToByteArray(profilePicture);

                        userVm.ProfilePicture = imgData;
                    }
                }
                var id = this.User.Identity.GetUserId();
                this.userService.EditUser(id, userVm);

                return RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        public ActionResult EditUser()
        {
            var username = this.HttpContext.User.Identity.Name;
            var userViewModel = this.userService.FindUserByUsername(username);

            return this.View(userViewModel);
        }

        public FileContentResult UserPhotos()
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = this.User.Identity.GetUserId();

                var username = this.User.Identity.Name;
                var userImage = this.userService.GetUserProfilePicture(username).Data;
                if (userImage == null)
                {
                    var defaultImage = this.fileConverter.GetDefaultProfilePicture();

                    return this.File(defaultImage, "image/png");
                }

                return this.File(userImage, "image/jpeg");
            }
            else
            {
                var defaultImage = this.fileConverter.GetDefaultProfilePicture();
                return this.File(defaultImage, "image/png");
            }
        }
    }
}