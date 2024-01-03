using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBPortfolio.DAL.Entities
{
	public class Offer
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string offerID { get; set; }
        public string offerName { get; set; }
    }
}
