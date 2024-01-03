using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBPortfolio.DAL.Entities
{
	public class Skill
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string skillID { get; set; }
        public string title { get; set; }
        public string rating { get; set; }
    }
}
