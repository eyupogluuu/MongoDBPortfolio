using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities;
using MongoDBPortfolio.DAL.Entities.Settings;

namespace MongoDBPortfolio.Controllers
{
    public class TMessageController : Controller
    {
        private readonly IMongoCollection<TMessage> _tMessageCollection;
        public TMessageController(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _tMessageCollection = database.GetCollection<TMessage>(databaseSettings.tMessageCollectionName);
                
        }
        public async Task< IActionResult> messageInbox()
        {
            var values = await _tMessageCollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult addMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addMessage(TMessage tmes)
        {
            await _tMessageCollection.InsertOneAsync(tmes);
            return RedirectToAction("Index","Default");
        }

        public async Task<IActionResult> deleteMessage(string id)
        {
            await _tMessageCollection.DeleteOneAsync(x=>x.messageID == id);
            return RedirectToAction("messageInbox");
        }
        public async Task<IActionResult> messageDetail(string id)
        {
            var values = await _tMessageCollection.Find(x => x.messageID == id).FirstOrDefaultAsync();
            return View(values);
        }
    }
}
