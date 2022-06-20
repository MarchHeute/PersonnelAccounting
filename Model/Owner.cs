using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PersonnelAccounting.Model.Jobs;
using System.Collections.Generic;

namespace PersonnelAccounting.Model
{
    public class Owner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }   
        public List<Job>? Jobs { get; set; }
    }
}
