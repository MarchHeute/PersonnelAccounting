using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonnelAccounting.Model
{
    public class Owner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }   
        public Job? Job { get; set; }
    }
}
