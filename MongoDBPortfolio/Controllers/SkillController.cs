using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities;
using MongoDBPortfolio.DAL.Entities.Settings;

namespace MongoDBPortfolio.Controllers
{


    public class SkillController : Controller
    {
        private readonly IMongoCollection<Skill> _skillCollection;
        public SkillController(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _skillCollection = database.GetCollection<Skill>(databaseSettings.skillCollectionName);
        }
        public async Task<IActionResult> skillList()
        {
            var values = await _skillCollection.Find(x => true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult addSkill()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addSkill(Skill ski)
        {
            await _skillCollection.InsertOneAsync(ski);
            return RedirectToAction("skillList");
        }
        public async Task<IActionResult> deleteSkill(string id)
        {
            await _skillCollection.DeleteOneAsync(x => x.skillID == id);
            return RedirectToAction("skillList");
        }
        [HttpGet]
        public async Task<IActionResult> updateSkill(string id)
        {
            var values = await _skillCollection.Find<Skill>(x => x.skillID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> updateCategory(Skill skill)
        {
            var values = await _skillCollection.FindOneAndReplaceAsync(x => x.skillID == skill.skillID, skill);//2 . paramatre güncellenecek veriyi soruyor
            return RedirectToAction("skillList");
        }
    }
}
