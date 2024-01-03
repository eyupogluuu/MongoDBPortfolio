using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MongoDBPortfolio.DAL.Entities
{
	public class Testimonial
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string testimonialID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string tittle { get; set; }
        public string imageUrl { get; set; }
        public string descreption { get; set; }
    }
}
