using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MongoDBPortfolio.DAL.Entities
{
	public class Services
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string serviceID { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string descreption { get; set; }
    }
}
