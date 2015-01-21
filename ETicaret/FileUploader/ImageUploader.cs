using FileUploader.Types;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;

namespace FileUploader
{
    public class ImageUploader : FileUploadBase
    {
        List<string> allowedExtensions;

        public ImageUploader(HttpPostedFileBase postedFile, string path)
            : base(postedFile, path)
        {
            //TODO İZİN VERİLEN ÖZELLİKLERİ EKLE
            allowedExtensions = new List<string> { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };
        }

        public override FileUploadResult UploadFile(string fileName)
        {
            if (!allowedExtensions.Contains(base.FileExtension))
            {
                return new FileUploadResult
                {
                    FileName = null,
                    Status = false,
                    Message = "Bu içeriğe izin verilmiyor",
                };
            }
            return base.UploadFile(fileName);
        }

        // Hack framework için düzelt
        public string CreateThumb(ThumbSettings settings)
        {
            string oldFileName = HttpContext.Current.Server.MapPath(settings.OldFilePath);
            Image img = Image.FromFile(oldFileName);
            Bitmap bmp = new Bitmap(width: settings.NewWidth, height: settings.NewHeight);
            using (Graphics gr = Graphics.FromImage((Image)bmp))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.CompositingQuality = CompositingQuality.HighQuality;
                gr.DrawImage(img, new Rectangle(0, 0, settings.NewWidth, settings.NewHeight));

                string[] fileArray = settings.OldFilePath.Split('/');
                string fileNameWithExtensions = fileArray[fileArray.Length - 1];
                string fileExtension = System.IO.Path.GetExtension(fileNameWithExtensions);
                string pureFileName = fileNameWithExtensions.Replace(fileExtension, "");
                string savedFileName = pureFileName + settings.NewWidth + "x" + settings.NewHeight + FileExtension;
                string saveAddress = HttpContext.Current.Server.MapPath(settings.NewFilePath + "/" + savedFileName);

                bmp.Save(saveAddress, System.Drawing.Imaging.ImageFormat.Png);
                img.Dispose();
                return savedFileName;
            }
        }
    }
}
