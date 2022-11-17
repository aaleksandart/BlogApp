using BlogApp.Data;
using BlogApp.Data.Entities;
using BlogApp.Logic.Models.Posts;
using BlogApp.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Logic
{
    public class LogicLayer : ILogicLayer
    {
        private readonly IDataLayer _data;
        private readonly ILogicService _service;
        public LogicLayer(IDataLayer data, ILogicService service)
        {
            _data = data;
            _service = service;
        }

        public async Task<IEnumerable<DisplayPostModel>> GetPostsAsync()
        {
            try
            {
                var entityList = await _data.GetPostsAsync();
                var modelList = _service.ConvertToModelList(entityList);
                var validatedModelList = _service.ValidateList(modelList);
                return validatedModelList;
            }
            catch
            {
                return new List<DisplayPostModel>();
            }
            
        }

        public async Task<DisplayPostModel> GetPostAsync(string id)
        {
            try
            {
                var entity = await _data.GetPostAsync(id);
                var model = _service.ConvertToModel(entity);
                return model;
            }
            catch
            {
                return new DisplayPostModel();
            }
        }
        public async Task<bool> CreatePostAsync(PostModel newPost)
        {
            try
            {
                var entity = _service.ConvertToEntity(newPost);
                await _data.CreatePostAsync(entity);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdatePostAsync(string id, PostModel updatePost)
        {
            try
            {
                var exist = await GetPostAsync(id);
                if ( exist.Id == null)
                    return false;

                var updateEntity = _service.ConvertToEntity(updatePost);
                await _data.UpdatePostAsync(id, updateEntity);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeletePostAsync(string id)
        {
            try
            {
                var exist = await GetPostAsync(id);
                if (exist.Id == null)
                    return false;

                await _data.DeletePostAsync(id);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
