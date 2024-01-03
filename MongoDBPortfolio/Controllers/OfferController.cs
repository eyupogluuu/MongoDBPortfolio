using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities;
using MongoDBPortfolio.DAL.Entities.Settings;

namespace MongoDBPortfolio.Controllers
{
    public class OfferController : Controller
    {
        private readonly IMongoCollection<Offer> _offerCollection;
        public OfferController(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _offerCollection = database.GetCollection<Offer>(databaseSettings.offerCollectionName);
        }
        public async Task< IActionResult> offerLis()
        {
            var values = await _offerCollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult addAOffer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addAOffer(Offer off)
        {
            await _offerCollection.InsertOneAsync(off);
            return RedirectToAction("offerLis");
        }
        public async Task<IActionResult> deleteOffer(string id)
        {
            await _offerCollection.DeleteOneAsync(x => x.offerID == id);
            return RedirectToAction("offerLis");
        }
        [HttpGet]
        public async Task<IActionResult> updateOffer(string id)
        {
            var values = await _offerCollection.Find<Offer>(x => x.offerID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> updateOffer(Offer off)
        {
            var values = await _offerCollection.FindOneAndReplaceAsync(x => x.offerID == off.offerID, off);
            return RedirectToAction("offerLis");
        }
    }
}
