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
        public DataLayer(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _postsCollection = mongoDatabase.GetCollection<PostEntity>(databaseSettings.Value.CollectionName);
        }

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
        
    }
}
