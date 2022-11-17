using BlogApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data
{
    public interface IDataLayer
    {
        Task<IEnumerable<PostEntity>> GetPostsAsync();
        Task<PostEntity> GetPostAsync(string id);
        Task CreatePostAsync(PostEntity newPost);
        Task UpdatePostAsync(string id, PostEntity updateEntity);
        Task DeletePostAsync(string id);
    }
}
