using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Logic.Models.Posts
{
    public class DisplayPostModel
    {
        public string Id { get; set; } = null!;
        public string PostTitle { get; set; } = null!;
        public string PostBody { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
