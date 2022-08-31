using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection.Metadata.Ecma335;

namespace TodoTasksServer.Models
{
    public class AccountsEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _Id { get; set; }
        public int account_id { get; set; }
        public int limit { get; set; }
        public string[] products { get; set; }
    }
}
