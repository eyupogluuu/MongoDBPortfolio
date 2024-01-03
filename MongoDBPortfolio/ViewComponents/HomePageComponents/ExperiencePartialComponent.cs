using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities;
using MongoDBPortfolio.DAL.Entities.Settings;

namespace MongoDBPortfolio.ViewComponents.HomePageComponents
{
    public class ExperiencePartialComponent:ViewComponent
    {
        private readonly IMongoCollection<Experience> _experienceCollection;
        public ExperiencePartialComponent(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _experienceCollection = database.GetCollection<Experience>(databaseSettings.experienceCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _experienceCollection.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
