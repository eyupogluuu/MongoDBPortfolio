using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities;
using MongoDBPortfolio.DAL.Entities.Settings;

namespace MongoDBPortfolio.Controllers
{
    public class ClientController : Controller
    {
        private readonly IMongoCollection<Client> _clientCollection;
        public ClientController(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _clientCollection = database.GetCollection<Client>(databaseSettings.clientCollectionName);
        }
        public async Task <IActionResult> clientList()
        {
			var clientCount = await _clientCollection.CountDocumentsAsync(x => true);
			ViewBag.ClientCount = clientCount;

			var values=await _clientCollection.Find(x=>true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult addClient()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addClient(Client cli)
        {
            await _clientCollection.InsertOneAsync(cli);
            return RedirectToAction("clientList");
        }
        public async Task<IActionResult> deleteClient(string id)
        {
            await _clientCollection.DeleteOneAsync(x=>x.clientID==id);
            return RedirectToAction("clientList");
        }
        [HttpGet]
        public async Task<IActionResult> updateClient(string id)
        {
            var values=await _clientCollection.Find(x=>x.clientID==id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> updateClient(Client cli)
        {
            var values = await _clientCollection.FindOneAndReplaceAsync(x => x.clientID == cli.clientID, cli);
            return RedirectToAction("clientList");
        }
		
	}
}
