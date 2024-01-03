using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MongoDBPortfolio.DAL.Entities
{
	public class Education
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string educationID { get; set; }
        public string title { get; set; }
        public string time { get; set; }
    }
}
