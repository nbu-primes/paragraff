using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Paragraff.ViewModels.CustomValidations
{
    public class ImageNotNull : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if(file == null)
            {
                this.ErrorMessage = "Image is required!";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
