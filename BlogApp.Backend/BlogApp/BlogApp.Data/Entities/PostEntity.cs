using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Entities
{
    public class PostEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        [BsonRequired]
        public string PostTitle { get; set; } = null!;
        [BsonRequired]
        public string PostBody { get; set; } = null!;
        [BsonRequired]
        public string ImageUrl { get; set; } = null!;
    }
}
