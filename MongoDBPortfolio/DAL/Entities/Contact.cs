using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MongoDBPortfolio.DAL.Entities
{
	public class Contact
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string contactID { get; set; }
        public string office { get; set; }
        public string phone { get; set; }
        public string mail { get; set; }
        public string linkedin { get; set; }
        public string github { get; set; }
        public string mapsLink { get; set; }
    }
}
