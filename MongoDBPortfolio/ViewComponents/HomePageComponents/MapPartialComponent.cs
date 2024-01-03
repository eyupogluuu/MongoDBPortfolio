using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities.Settings;
using MongoDBPortfolio.DAL.Entities;

namespace MongoDBPortfolio.ViewComponents.HomePageComponents
{
    public class MapPartialComponent:ViewComponent
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        public MapPartialComponent(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _contactCollection = database.GetCollection<Contact>(databaseSettings.contactCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
