using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonnelAccounting.Model
{
    public class Job
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
    }
}
