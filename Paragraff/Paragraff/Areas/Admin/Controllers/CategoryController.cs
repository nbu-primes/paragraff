using Bytes2you.Validation;
using Paragraff.DataServices.Contracts;
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
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            Guard.WhenArgument(categoryService, "categoryService").IsNull().Throw();

            this.categoryService = categoryService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(Guid categoryId)
        {
            try
            {
                this.categoryService.DeleteCategory(categoryId);
            }
            catch (Exception)
            {
                return Json(new
                {
                    success = false,
                    responseText = "Something went wrong on category deletion!"
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                success = true,
                responseText = "Category was successfully deleted!"
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditCategories()
        {
            var allCategories = this.categoryService.GetAllCategories();

            return this.PartialView(allCategories);
        }
    }
}