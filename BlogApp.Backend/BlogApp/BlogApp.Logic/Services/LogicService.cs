using BlogApp.Data.Entities;
using BlogApp.Logic.Models.Pictures;
using BlogApp.Logic.Models.Posts;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BlogApp.Logic.Services
{
    public class LogicService : ILogicService
    {
        private string[] _allowed = new string[] { "<b>", "</b>", "<i>", "</i>" };

        #region Posts
        public DisplayPostModel ConvertToPostModel(PostEntity postEntity)
        {
            var model = new DisplayPostModel
            {
                Id = postEntity.Id,
                PostTitle = postEntity.PostTitle,
                PostBody = postEntity.PostBody,
                ImageUrl = postEntity.ImageUrl
            };
            return model;
        }

        public PostEntity ConvertToPostEntity(PostModel postModel)
        {
            var entity = new PostEntity
            {
                PostTitle = postModel.PostTitle,
                PostBody = postModel.PostBody,
                ImageUrl = postModel.ImageUrl
            };
            return entity;
        }

        public IEnumerable<DisplayPostModel> ConvertToPostModels(IEnumerable<PostEntity> postEntityList)
        {
            var modelList = new List<DisplayPostModel>();
            foreach (var postEntity in postEntityList)
            {
                var model = new DisplayPostModel
                {
                    Id = postEntity.Id,
                    PostTitle = postEntity.PostTitle,
                    PostBody = postEntity.PostBody,
                    ImageUrl = postEntity.ImageUrl
                };
                modelList.Add(model);
            }
            return modelList;
        }

        public IEnumerable<PostEntity> ConvertToPostEntities(IEnumerable<DisplayPostModel> postModelList)
        {
            var entityList = new List<PostEntity>();
            foreach (var postModel in postModelList)
            {
                var entity = new PostEntity
                {
                    PostTitle = postModel.PostTitle,
                    PostBody = postModel.PostBody,
                    ImageUrl = postModel.ImageUrl
                };
                entityList.Add(entity);
            }
            return entityList;
        }

        public bool ValidatePost(PostModel model)
        {
            if (model.PostTitle == null
                || model.PostBody == null
                || model.ImageUrl == null)
                return false;
            
            return true;
        }

        public string EncodeBody(string messageBody)
        {
            if (string.IsNullOrEmpty(messageBody))
                return "";

           messageBody = HttpUtility.HtmlEncode(messageBody);
           foreach(var tag in _allowed)
            {
                var encodedTag = HttpUtility.HtmlEncode(tag);
                messageBody = messageBody.Replace(encodedTag, tag);
            }
            return messageBody;
        }

        #endregion

        #region Pictures
        
        public bool ValidateExtension(string extension)
        {
            if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
                return false;
            else
                return true;
        }

        public bool ValidateId(ObjectId id)
        {
            if (string.IsNullOrEmpty(id.ToString()) || id.ToString().Length != 24 || id.Timestamp == 0)
                return false;
            else
                return true;
        }

        #endregion
    }
}
