using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities;
using MongoDBPortfolio.DAL.Entities.Settings;

namespace MongoDBPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IMongoCollection<Experience> _experienceCollection;
        public ExperienceController(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _experienceCollection = database.GetCollection<Experience>(databaseSettings.experienceCollectionName);
        }
        public async Task< IActionResult> experienceList()
        {
            var values = await _experienceCollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public  IActionResult addExperience()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addExperience(Experience exp)
        {
            await _experienceCollection.InsertOneAsync(exp);
            return RedirectToAction("experienceList");
        }
        public async Task<IActionResult> deleteExperience(string id)
        {
            await _experienceCollection.DeleteOneAsync(x=>x.experienceID== id);
            return RedirectToAction("experienceList");
        }
        [HttpGet]
        public async Task<IActionResult> updateExperience(string id)
        {
            var values = await _experienceCollection.Find<Experience>(x => x.experienceID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<ActionResult> updateExperience(Experience exp)
        {
            var values = await _experienceCollection.FindOneAndReplaceAsync(x => x.experienceID == exp.experienceID, exp);
            return RedirectToAction("experienceList");
        }
    }
}
