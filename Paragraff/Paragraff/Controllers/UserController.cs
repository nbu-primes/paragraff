using Paragraff.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paragraff.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IAdminService adminService;

        public UserController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public ActionResult EditUser(string username)
        {
            var user = adminService.FindUserByUsername(username);

            return this.View("EditUser", user);
        }
    }
}