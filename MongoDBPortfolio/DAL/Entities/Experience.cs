using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MongoDBPortfolio.DAL.Entities
{
	public class Experience
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string experienceID { get; set; }
        public string title { get; set; }
        public string time { get; set; }
        public string company { get; set; }
    }
}
