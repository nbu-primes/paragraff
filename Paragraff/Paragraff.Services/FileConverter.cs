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
        public byte[] GetDefaultProfilePicture()
        {
            string fileName = HttpContext.Current.Server.MapPath(@"~/Content/Images/no_profile.png");

            byte[] imageData = null;

            FileInfo fileInfo = new FileInfo(fileName);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            imageData = br.ReadBytes((int)imageFileLength);

            return imageData;
        }
        
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
