using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities.Settings;
using MongoDBPortfolio.DAL.Entities;

namespace MongoDBPortfolio.ViewComponents.HomePageComponents
{
    public class ProjectPartialComponent:ViewComponent
    {
        private readonly IMongoCollection<MyProject> _projectCollection;
        public ProjectPartialComponent(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _projectCollection = database.GetCollection<MyProject>(databaseSettings.myProjectCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _projectCollection.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
