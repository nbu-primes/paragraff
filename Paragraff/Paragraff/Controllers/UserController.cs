using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Paragraff.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Paragraff.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.userService = userService;
        }

        public ActionResult EditUser()
        {
            var username = this.HttpContext.User.Identity.Name;
            var userViewModel = this.userService.FindUserByUsername(username);

            return this.View(userViewModel);
        }
    }
}