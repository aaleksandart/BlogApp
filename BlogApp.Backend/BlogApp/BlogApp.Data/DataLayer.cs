using BlogApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data
{
    public class DataLayer : IDataLayer
    {
        private readonly IMongoCollection<PostEntity> _postsCollection;
        private readonly IMongoCollection<PictureEntity> _picturesCollection;
        private readonly IGridFSBucket _bucket;
        public DataLayer(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _postsCollection = mongoDatabase.GetCollection<PostEntity>(databaseSettings.Value.PostsCollectionName);
            _picturesCollection = mongoDatabase.GetCollection<PictureEntity>(databaseSettings.Value.PicturesCollectionName);
            _bucket = new GridFSBucket(mongoDatabase, new GridFSBucketOptions { BucketName = "PictureBucket" });
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
        public async Task<ObjectId> UploadAsync(Stream stream, string fileName) =>
            await _bucket.UploadFromStreamAsync(fileName, stream);

        #endregion

    }
}
