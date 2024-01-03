using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBPortfolio.DAL.Entities
{
	public class About
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string aboutID { get; set; }
        public string tittle { get; set; }
        public string descreption { get; set; }
       
    }
}
