using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities;
using MongoDBPortfolio.DAL.Entities.Settings;

namespace MongoDBPortfolio.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IMongoCollection<Services> _servicesCollection;
        public ServiceController(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _servicesCollection = database.GetCollection<Services>(databaseSettings.servicesCollectionName);
        }
        public async Task<IActionResult> servicesList()
        {
            var values = await _servicesCollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult addServices()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addServices(Services serv)
        {
            await _servicesCollection.InsertOneAsync(serv);
            return RedirectToAction("servicesList");
        }
        public async Task<IActionResult> deleteServices(string id)
        {
            await _servicesCollection.DeleteOneAsync(x => x.serviceID == id);
            return RedirectToAction("servicesList");

        }
        [HttpGet]
        public async Task<IActionResult> updateServices(string id)
        {
            var values = await _servicesCollection.Find(x => x.serviceID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> updateServices(Services serv)
        {
            var values = await _servicesCollection.FindOneAndReplaceAsync(x => x.serviceID == serv.serviceID, serv);
            return RedirectToAction("servicesList");
        }
    }
}
