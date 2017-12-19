using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paragraff.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {


        public ActionResult EditCategories()
        {
            return this.PartialView();
        }
    }
}