using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

//https://stackoverflow.com/questions/12008899/create-ajax-actionlink-with-html-elements-in-the-link-text
namespace Paragraff.Helpers
{
    public static class AjaxHelpers
    {
        public static MvcHtmlString RawActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var repID = Guid.NewGuid().ToString();
            var lnk = ajaxHelper.ActionLink(repID, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes);
            return MvcHtmlString.Create(lnk.ToString().Replace(repID, linkText));
        }
    }
}