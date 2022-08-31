using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.RegularExpressions;
using TodoTasksServer.Models;

namespace TodoTasksServer.Services
{
    public class MongoDBService
    {
        private readonly IMongoDatabase database;
        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new (mongoDBSettings.Value.ConnectionURI);
            database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        }


        private static string GetCollectionName(string className)
        {
            try
            {
                return Regex.Replace(className, "entity", "");
            }
            catch
            {
                throw new InvalidOperationException("Cannot get collection name from classname.");
            }
        }
        public async Task<(IEnumerable<T>, string)> GetAsync<T>() 
        {
            try
            {
                var collectionName = GetCollectionName(typeof(T).Name.ToLower());
                var collection = database.GetCollection<T>(collectionName);
                var collectionData = await collection.Find(new BsonDocument()).ToListAsync();
                return await Task.FromResult((collectionData, "success"));
            }
            catch (Exception ex)
            {
                return await Task.FromResult((Enumerable.Empty<T>(), ex.Message));
            }
        }
        public async Task<(bool, string)> AddAsync<T>(T data)      
        {
            try
            {
                var collectionName = GetCollectionName(typeof(T).Name.ToLower());
                var collection = database.GetCollection<T>(collectionName);
                await collection.InsertOneAsync(data);
                return await Task.FromResult((true, "success"));
            }
            catch (Exception ex)
            {
                return await Task.FromResult((false, ex.Message));
            }
          
        }
        public async Task<(bool, string)> DeleteAsync<T>(string id) 
        {
            try
            {
                var filter = Builders<T>.Filter.Eq("id", id);

                var collectionName = GetCollectionName(typeof(T).Name.ToLower());
                var collection = database.GetCollection<T>(collectionName);
                var result = collection.DeleteMany(filter);
                return await Task.FromResult((true, result.DeletedCount.ToString()));
            }
            catch (Exception ex)
            {
                return await Task.FromResult((false, ex.Message));
            }
        }
    }
}
