using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities;
using MongoDBPortfolio.DAL.Entities.Settings;

namespace MongoDBPortfolio.Controllers
{
    public class EducationController : Controller
    {
        private readonly IMongoCollection<Education> _educationCollection;
        public EducationController(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _educationCollection = database.GetCollection<Education>(databaseSettings.educationCollectionName);
        }
        public async Task<IActionResult> educationList()
        {
            var values = await _educationCollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult addEducation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addEducation(Education edu)
        {
            await _educationCollection.InsertOneAsync(edu);
            return RedirectToAction("educationList");
        }
        public async Task<IActionResult> deleteEducation(string id)
        {
            await _educationCollection.DeleteOneAsync(x => x.educationID == id);
            return RedirectToAction("educationList");
        }
        [HttpGet]
        public async Task<IActionResult> updateEducation(string id)
        {
            var values = await _educationCollection.Find<Education>(x => x.educationID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> updateEducation(Education edu)
        {
            var values = await _educationCollection.FindOneAndReplaceAsync(x => x.educationID == edu.educationID, edu);
            return RedirectToAction("educationList");
        }
    }
}
