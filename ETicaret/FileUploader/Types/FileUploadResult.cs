using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Types
{
    public class FileUploadResult
    {
        public string FileName { get; set; }

        public bool Status { get; set; }
        /// <summary>
        /// Dosya boyutu byte olarak..
        /// </summary>
        public int FileLenght { get; set; }

        public string Message { get; set; }
    }
}
