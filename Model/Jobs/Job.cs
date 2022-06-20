using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonnelAccounting.Model.Jobs
{
    public abstract class Job
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public abstract string? Name { get; }
        public abstract decimal Salary { get; }
    }
}
