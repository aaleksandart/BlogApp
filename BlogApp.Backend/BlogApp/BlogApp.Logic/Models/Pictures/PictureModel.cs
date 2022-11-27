using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Logic.Models.Pictures
{
    public class PictureModel
    {
        public IFormFile File { get; set; } = null!;
        public string? UploadedBy { get; set; }
    }
}
