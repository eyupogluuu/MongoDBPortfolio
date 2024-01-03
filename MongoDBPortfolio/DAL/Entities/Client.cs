using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MongoDBPortfolio.DAL.Entities
{
	public class Client
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string clientID { get; set; }
        public string clientName { get; set; }
        public string clientService { get; set; }
    }
}
