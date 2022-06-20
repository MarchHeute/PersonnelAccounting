using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonnelAccounting.Model.Jobs
{
    public class Job
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public virtual string? Name { get; }
        public virtual decimal Salary { get; }
    }
}
