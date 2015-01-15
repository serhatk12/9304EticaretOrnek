using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploader.Types
{
    public class ThumbSettings 
    {
        public string OldFilePath { get; set; }

        public string NewFilePath { get; set; }

        public int NewWidth { get; set; }

        public int NewHeight { get; set; }
    }
}
