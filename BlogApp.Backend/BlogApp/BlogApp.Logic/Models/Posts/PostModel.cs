using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Logic.Models.Posts
{
    public class PostModel
    {
        public string PostTitle { get; set; } = null!;
        public string PostBody { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
