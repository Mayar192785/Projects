using Microsoft.AspNetCore.Mvc.Rendering;
using NLog;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Global.Models
{
    public class ImageViewModel
    {
        public String? FullPath { get; set; }
        public String? suffix { get; set; }

        public int ImageID { get; set; }

        public String? ImageExt { get; set; }

        public int width { get; set; }

        public int height { get; set; }
    }

 


}
