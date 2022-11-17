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
        public string? Id { get; set; }
        public string? PostTitle { get; set; }
        public string? PostBody { get; set; }
        public string? ImageUrl { get; set; }
    }
}
