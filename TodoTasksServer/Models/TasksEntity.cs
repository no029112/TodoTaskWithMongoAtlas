using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TodoTasksServer.Models
{
    public class TasksEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _Id { get; set; }
        public string CustomerID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool IsActive { get; set; }
        public bool isDone { get; set; }

    }
}
