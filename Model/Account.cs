using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PersonnelAccounting.Model
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string? Nickname { get; set; }
        public Owner? Owner { get; set; }
    }
}
