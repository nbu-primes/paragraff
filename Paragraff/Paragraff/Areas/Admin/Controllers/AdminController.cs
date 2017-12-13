using Paragraff.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paragraff.Areas.Admin.Controllers
{
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

            return this.View(allUsers);
        }
    }
}