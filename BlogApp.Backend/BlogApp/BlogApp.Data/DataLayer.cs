using BlogApp.Data.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data
{
    public class DataLayer : IDataLayer
    {
        private readonly IMongoCollection<PostEntity> _postsCollection;
        private readonly IMongoCollection<PictureEntity> _picturesCollection;
        public DataLayer(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _postsCollection = mongoDatabase.GetCollection<PostEntity>(databaseSettings.Value.PostsCollectionName);
            _picturesCollection = mongoDatabase.GetCollection<PictureEntity>(databaseSettings.Value.PicturesCollectionName);
        }

        #region Posts
        public async Task<IEnumerable<PostEntity>> GetPostsAsync() =>
            await _postsCollection.Find(_ => true).ToListAsync();

        public async Task<PostEntity> GetPostAsync(string id) =>
            await _postsCollection.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task CreatePostAsync(PostEntity newPost) =>
            await _postsCollection.InsertOneAsync(newPost);

        public async Task UpdatePostAsync(string id, PostEntity updateEntity) =>
            await _postsCollection.ReplaceOneAsync(p => p.Id == id, updateEntity);

        public async Task DeletePostAsync(string id) =>
            await _postsCollection.DeleteOneAsync(p => p.Id == id);
        #endregion

        #region Pictures
        public async Task<IEnumerable<PictureEntity>> GetPicturesAsync() =>
            await _picturesCollection.Find(_ => true).ToListAsync();

        public async Task<PictureEntity> GetPictureAsync(string id) =>
            await _picturesCollection.Find(pic => pic.Id == id).FirstOrDefaultAsync();

        public async Task CreatePictureAsync(PictureEntity newPicture) =>
            await _picturesCollection.InsertOneAsync(newPicture);

        public async Task UpdatePictureAsync(string id, PictureEntity updatePicture) =>
            await _picturesCollection.ReplaceOneAsync(pic => pic.Id == id, updatePicture);

        public async Task DeletePictureAsync(string id) =>
           await _picturesCollection.DeleteOneAsync(p => p.Id == id);
        #endregion

    }
}
