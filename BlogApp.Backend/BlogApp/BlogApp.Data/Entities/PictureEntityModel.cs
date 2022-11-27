using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Entities
{
    public class PictureEntityModel
    {
        public byte[] File { get; set; } = null!;
        public string? UploadedBy { get; set; }
    }
}
