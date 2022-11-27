using BlogApp.Logic.Models.Pictures;
using BlogApp.Logic.Models.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Logic
{
    public interface ILogicLayer
    {
        #region Posts
        Task<IEnumerable<DisplayPostModel>> GetPostsAsync();
        Task<DisplayPostModel> GetPostAsync(string id);
        Task<bool> CreatePostAsync(PostModel newPost);
        Task<bool> UpdatePostAsync(string id, PostModel updatePost);
        Task<bool> DeletePostAsync(string id);
        #endregion

        #region Pictures
        Task<IActionResult> UploadPictureAsync(PictureModel picture);
        Task<Byte[]> GetPictureAsync();

        #endregion
    }
}
