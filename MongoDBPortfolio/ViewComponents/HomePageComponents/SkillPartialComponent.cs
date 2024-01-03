using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities.Settings;
using MongoDBPortfolio.DAL.Entities;

namespace MongoDBPortfolio.ViewComponents.HomePageComponents
{
    public class SkillPartialComponent:ViewComponent
    {
        private readonly IMongoCollection<Skill> _skillCollection;
        public SkillPartialComponent(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _skillCollection = database.GetCollection<Skill>(databaseSettings.skillCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _skillCollection.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
