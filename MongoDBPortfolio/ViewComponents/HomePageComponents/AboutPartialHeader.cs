using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities;
using MongoDBPortfolio.DAL.Entities.Settings;

namespace MongoDBPortfolio.ViewComponents.HomePageComponents
{
    public class AboutPartialHeader:ViewComponent
    {
        private readonly IMongoCollection<About> _aboutCollectiont;
        public AboutPartialHeader(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _aboutCollectiont = database.GetCollection<About>(databaseSettings.aboutCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutCollectiont.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
