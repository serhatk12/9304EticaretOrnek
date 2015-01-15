using System;
using System.Web;
using System.IO;
using FileUploader.Types;

namespace FileUploader
{
    public class FileUploadBase :IDisposable
    {
        protected HttpPostedFileBase PostedFile { get; private set; }

        protected string FileExtension { get; private set; }

        protected string Path { get; private set; }

        protected string PhyscalPath { get; private set; }

        public FileUploadBase(HttpPostedFileBase postedFile, string path)
        {
            this.PostedFile = postedFile;
            this.FileExtension = System.IO.Path.GetExtension(postedFile.FileName);
            this.Path = path;
            this.PhyscalPath = HttpContext.Current.Server.MapPath(path);
        }


        public virtual FileUploadResult UploadFile()
        {
            return UploadFile(Guid.NewGuid().ToString());
        }

        public virtual FileUploadResult UploadFile(string fileName)
        {
            string newName = "";
            string fullpath = SetUniqFileName(fileName, out newName);
            PostedFile.SaveAs(fullpath);
            return new FileUploadResult
            {
                FileName = newName,
                Status = true,
                FileLenght = PostedFile.ContentLength,
            };
        }


        private string SetUniqFileName(string fileName, out string newName)
        {
            string fullPath = "";
            string refName = fileName + FileExtension;
            int counter = 0;
            do
            {
                if (counter == 0)
                {
                    fullPath = PhyscalPath + "\\" + fileName + FileExtension;
                }
                else
                {
                    fullPath = PhyscalPath + "\\" + fileName + "-" + counter + FileExtension;
                    refName = fileName + "-" + counter + FileExtension;

                }

                counter++;
            } while (File.Exists(fullPath));
            newName = refName;
            return fullPath;

        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
