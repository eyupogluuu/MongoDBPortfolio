using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MongoDBPortfolio.DAL.Entities
{
	public class TMessage
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string messageID { get; set; }
        public string name { get; set; }
        public string mail { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
    }
}
