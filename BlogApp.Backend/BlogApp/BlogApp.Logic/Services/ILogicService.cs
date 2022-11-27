using BlogApp.Data.Entities;
using BlogApp.Logic.Models.Pictures;
using BlogApp.Logic.Models.Posts;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Logic.Services
{
    public interface ILogicService
    {
        #region Posts
        DisplayPostModel ConvertToPostModel(PostEntity postEntity);
        PostEntity ConvertToPostEntity(PostModel postModel);
        IEnumerable<DisplayPostModel> ConvertToPostModels(IEnumerable<PostEntity> postEntityList);
        IEnumerable<PostEntity> ConvertToPostEntities(IEnumerable<DisplayPostModel> postModelList);
        bool ValidatePost(PostModel model);
        string EncodeBody(string messageBody);

        #endregion

        #region Pictures
        bool ValidateExtension(string extension);
        bool ValidateId(ObjectId id);
        #endregion

    }
}
