using BlogApp.Data.Entities;
using BlogApp.Logic.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Logic.Services
{
    public class LogicService : ILogicService
    {
        public DisplayPostModel ConvertToModel(PostEntity postEntity)
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

        public PostEntity ConvertToEntity(PostModel postModel)
        {
            var entity = new PostEntity
            {
                PostTitle = postModel.PostTitle,
                PostBody = postModel.PostBody,
                ImageUrl = postModel.ImageUrl
            };
            return entity;
        }

        public IEnumerable<DisplayPostModel> ConvertToModelList(IEnumerable<PostEntity> postEntityList)
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

        public IEnumerable<PostEntity> ConvertToEntityList(IEnumerable<DisplayPostModel> postModelList)
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

        public IEnumerable<T> ValidateList<T>(IEnumerable<T> list)
        {
            if(list == null)
                return new List<T>();

            return list;
        }
    }
}
