using BlogApp.Data.Entities;
using BlogApp.Logic.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Logic.Services
{
    public interface ILogicService
    {
        DisplayPostModel ConvertToModel(PostEntity postEntity);
        PostEntity ConvertToEntity(PostModel postModel);
        IEnumerable<DisplayPostModel> ConvertToModelList(IEnumerable<PostEntity> postEntityList);
        IEnumerable<PostEntity> ConvertToEntityList(IEnumerable<DisplayPostModel> postModelList);
        IEnumerable<T> ValidateList<T>(IEnumerable<T> listToValidate);
    }
}
