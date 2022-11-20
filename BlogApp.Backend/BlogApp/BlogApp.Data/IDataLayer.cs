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
        #region Posts
        Task<IEnumerable<PostEntity>> GetPostsAsync();
        Task<PostEntity> GetPostAsync(string id);
        Task CreatePostAsync(PostEntity newPost);
        Task UpdatePostAsync(string id, PostEntity updateEntity);
        Task DeletePostAsync(string id);
        #endregion

        #region Pictures
        Task<IEnumerable<PictureEntity>> GetPicturesAsync();
        Task<PictureEntity> GetPictureAsync(string id);
        Task CreatePictureAsync(PictureEntity newPost);
        Task UpdatePictureAsync(string id, PictureEntity updateEntity);
        Task DeletePictureAsync(string id);
        #endregion
    }
}
