using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities.Settings;
using MongoDBPortfolio.DAL.Entities;

namespace MongoDBPortfolio.ViewComponents.HomePageComponents
{
    public class TestimonialPartialComponent:ViewComponent
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        public TestimonialPartialComponent(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(databaseSettings.testimonialCollectionName);

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _testimonialCollection.Find(x => true).ToListAsync();
            return View(values);
        }
    }
}
