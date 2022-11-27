using BlogApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
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
        private readonly IGridFSBucket _bucket;
        private readonly IMongoCollection<BsonDocument> _files;
        private readonly IMongoCollection<BsonDocument> _chunks;
        public DataLayer(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _postsCollection = mongoDatabase.GetCollection<PostEntity>(databaseSettings.Value.PostsCollectionName);
            _picturesCollection = mongoDatabase.GetCollection<PictureEntity>(databaseSettings.Value.PicturesCollectionName);
            _bucket = new GridFSBucket(mongoDatabase, new GridFSBucketOptions { BucketName = "PictureBucket" });
            _files = mongoDatabase.GetCollection<BsonDocument>("PictureBucket.files");
            _chunks = mongoDatabase.GetCollection<BsonDocument>("PictureBucket.chunks");
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

        public async Task<Byte[]> GetPictureAsync(ObjectId id)
        {
            var byteArray = await _bucket.DownloadAsBytesAsync(id);
            MemoryStream memory = new MemoryStream();
            await _bucket.DownloadToStreamAsync(id, memory);

            var chunkBytes = await _chunks.Find(id => true).FirstOrDefaultAsync();
            var fileBytes = await _files.Find(id => true).FirstOrDefaultAsync();
            var data = chunkBytes.Elements.ElementAt(3);
            //var dataValue = Convert.ToByte(data.Value.ToString());
            //var dataName = Convert.ToByte(data.Name.ToString());


            return byteArray;
        }

        #endregion

    }
}
