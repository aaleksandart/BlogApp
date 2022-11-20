using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string PostsCollectionName { get; set; } = null!;
        public string PicturesCollectionName { get; set; } = null!;
    }
}
