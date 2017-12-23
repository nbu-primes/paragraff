using Paragraff.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Paragraff.Services
{
    public class FileConverter : IFileConverter
    {
        public byte[] PostedToByteArray(HttpPostedFileBase postedFile)
        {
            byte[] imageData = null;
            HttpPostedFileBase poImgFile = postedFile;

            using (var binary = new BinaryReader(poImgFile.InputStream))
            {
                imageData = binary.ReadBytes(poImgFile.ContentLength);
            }
            return imageData;
        }
    }
}
