using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBPortfolio.DAL.Entities
{
	public class AboutMe
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string aboutMeID { get; set; }
        public string tittle { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }
}
