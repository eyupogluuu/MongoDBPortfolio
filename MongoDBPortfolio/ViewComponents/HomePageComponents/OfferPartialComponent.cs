using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities.Settings;
using MongoDBPortfolio.DAL.Entities;

namespace MongoDBPortfolio.ViewComponents.HomePageComponents
{
    public class OfferPartialComponent:ViewComponent
    {
        private readonly IMongoCollection<Offer> _offerCollection;
        public OfferPartialComponent(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _offerCollection = database.GetCollection<Offer>(databaseSettings.offerCollectionName);
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _offerCollection.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
