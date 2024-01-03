using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities.Settings;
using MongoDBPortfolio.DAL.Entities;

namespace MongoDBPortfolio.ViewComponents.HomePageComponents
{
    public class HeaderPartialComponent:ViewComponent
    {
        private readonly IMongoCollection<AboutMe> _aboutMeCollection;
        public HeaderPartialComponent(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);//mongo db istekte bulundum
            var database = client.GetDatabase(databaseSettings.databaseName);//veri tabanına istekte bulundum
            _aboutMeCollection = database.GetCollection<AboutMe>(databaseSettings.aboutMeCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutMeCollection.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
