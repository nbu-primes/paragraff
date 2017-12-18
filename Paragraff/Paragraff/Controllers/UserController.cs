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
        public ActionResult EditUser()
        {

            return this.View();
        }
    }
}