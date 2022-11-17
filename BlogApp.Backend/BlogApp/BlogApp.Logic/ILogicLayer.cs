using BlogApp.Logic.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Logic
{
    public interface ILogicLayer
    {
        Task<IEnumerable<DisplayPostModel>> GetPostsAsync();
        Task<DisplayPostModel> GetPostAsync(string id);
        Task<bool> CreatePostAsync(PostModel newPost);
        Task<bool> UpdatePostAsync(string id, PostModel updatePost);
        Task<bool> DeletePostAsync(string id);
    }
}
