using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities.Settings;
using MongoDBPortfolio.DAL.Entities;

namespace MongoDBPortfolio.ViewComponents.HomePageComponents
{
	public class EducationPartialComponent:ViewComponent
	{
		private readonly IMongoCollection<Education> _educationCollection;
		public EducationPartialComponent(IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.connectionString);
			var database = client.GetDatabase(databaseSettings.databaseName);
			_educationCollection = database.GetCollection<Education>(databaseSettings.educationCollectionName);
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _educationCollection.Find(x => true).ToListAsync();
			return View(values);
		}
	}
}
