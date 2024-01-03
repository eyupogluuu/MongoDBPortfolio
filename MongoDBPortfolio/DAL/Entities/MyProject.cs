using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MongoDBPortfolio.DAL.Entities
{
	public class MyProject
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string projectID { get; set; }
        public string title { get; set; }
        public string imageUrl { get; set; }
    }
}
