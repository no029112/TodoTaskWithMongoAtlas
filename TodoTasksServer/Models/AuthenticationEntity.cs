using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TodoTasksServer.Models
{
    public class AuthenticationEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _Id { get; set; }
        public string? id { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? recordStatus { get; set; }
        public string? createDate { get; set; }
        public string? createBy { get; set; }
        public string? updateDate { get; set; }
        public string? updateBy { get; set; }

    }
}
