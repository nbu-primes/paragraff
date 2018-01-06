using Paragraff.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paragraff.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult AllUsers()
        {
            var allUsers = adminService.DisplayAllUsers();
            return this.PartialView("_AllUsers", allUsers);
        }

        public ActionResult UserDetails(string username)
        {
            var userDetails = adminService.UserDetails(username);

            return this.View(userDetails);
        }

        public ActionResult ChangeStatus(string username)
        {
            adminService.ChangeStatus(username);
            
            return RedirectToAction("Index", "Admin");
        }
    }
}