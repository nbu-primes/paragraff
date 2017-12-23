using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Paragraff.Services.Contracts
{
    public interface IFileConverter
    {
        byte[] PostedToByteArray(HttpPostedFileBase postedFile);
        byte[] GetDefaultProfilePicture();
    }
}
