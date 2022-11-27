using BlogApp.Data;
using BlogApp.Data.Entities;
using BlogApp.Logic.Models.Pictures;
using BlogApp.Logic.Models.Posts;
using BlogApp.Logic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Logic
{
    public class LogicLayer : ControllerBase, ILogicLayer
    {
        private readonly IDataLayer _data;
        private readonly ILogicService _service;
        public LogicLayer(IDataLayer data, ILogicService service)
        {
            _data = data;
            _service = service;
        }

        #region Posts
        public async Task<IEnumerable<DisplayPostModel>> GetPostsAsync()
        {
            try
            {
                var entityList = await _data.GetPostsAsync();
                foreach (var entity in entityList)
                {
                    entity.PostBody = _service.EncodeBody(entity.PostBody);
                }

                if (entityList == null)
                    return new List<DisplayPostModel>();

                var modelList = _service.ConvertToPostModels(entityList);
                return modelList;
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
                if(entity == null)
                    return new DisplayPostModel();

                var model = _service.ConvertToPostModel(entity);
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
                if(!_service.ValidatePost(newPost))
                    return false;

                var entity = _service.ConvertToPostEntity(newPost);
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
                if (exist.Id == null)
                    return false;

                var updateEntity = _service.ConvertToPostEntity(updatePost);
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
        #endregion

        #region Pictures

        public async Task<IActionResult> UploadPictureAsync(PictureModel picture)
        {
            try
            {
                using var stream = picture.File.OpenReadStream();
                var fileExtension = Path.GetExtension(picture.File.FileName);
                if (_service.ValidateExtension(fileExtension) == false)
                    return BadRequest("File extension not permitted.");

                var fileName = $"BlogApp-IMG_{Guid.NewGuid()}{fileExtension}";

                var id = await _data.UploadAsync(stream, fileName);
                if (_service.ValidateId(id) == false)
                    return StatusCode(500);
                else
                    return new OkObjectResult(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return StatusCode(500);
            }
            
        }

        #endregion
    }
}
