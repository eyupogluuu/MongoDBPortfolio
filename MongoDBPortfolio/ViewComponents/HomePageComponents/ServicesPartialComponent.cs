using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities;
using MongoDBPortfolio.DAL.Entities.Settings;

namespace MongoDBPortfolio.ViewComponents.HomePageComponents
{
    public class ServicesPartialComponent:ViewComponent
    {
        private readonly IMongoCollection<Services> _servicesCollection;
        public ServicesPartialComponent(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _servicesCollection = database.GetCollection<Services>(databaseSettings.servicesCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _servicesCollection.Find(x => true).ToListAsync();
            return View(values);    
        }
    }
}
