namespace MongoDBPortfolio.DAL.Entities.Settings
{
	public class DatabaseSettings:IDatabaseSettings
	{
		public string connectionString { get; set; }
		public string databaseName { get; set; }
		public string aboutCollectionName { get; set; }
		public string aboutMeCollectionName { get; set; }
		public string clientCollectionName { get; set; }
		public string contactCollectionName { get; set; }
		public string educationCollectionName { get; set; }
		public string experienceCollectionName { get; set; }
		public string myProjectCollectionName { get; set; }
		public string offerCollectionName { get; set; }
		public string servicesCollectionName { get; set; }
		public string skillCollectionName { get; set; }
		public string testimonialCollectionName { get; set; }
		public string tMessageCollectionName { get; set; }
		public string newmessageCollectionName { get; set; }
	}
}
