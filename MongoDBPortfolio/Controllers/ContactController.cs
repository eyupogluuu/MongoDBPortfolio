using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities;
using MongoDBPortfolio.DAL.Entities.Settings;

namespace MongoDBPortfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        public ContactController(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _contactCollection = database.GetCollection<Contact>(databaseSettings.contactCollectionName);
        }
        public async Task< IActionResult> contactList()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult addContact()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> addContact(Contact contact)
        {
            await _contactCollection.InsertOneAsync(contact);
            return RedirectToAction("contactList");
        }
        public async Task<IActionResult> deleteContact(string id)
        {
            await _contactCollection.DeleteOneAsync(x=>x.contactID==id);
            return RedirectToAction("contactList");

        }
        [HttpGet]
        public async Task<IActionResult> updateContact(string id)
        {
            var values = await _contactCollection.Find(x => x.contactID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> updateContact(Contact cont)
        {
            var values = await _contactCollection.FindOneAndReplaceAsync(x => x.contactID == cont.contactID, cont);
            return RedirectToAction("contactList");
        }
    }
}
