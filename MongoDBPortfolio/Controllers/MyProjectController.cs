using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities.Settings;
using MongoDBPortfolio.DAL.Entities;

namespace MongoDBPortfolio.Controllers
{
    public class MyProjectController : Controller
    {
        private readonly IMongoCollection<MyProject> _projectCollection;
        public MyProjectController(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.connectionString);
            var database = client.GetDatabase(databaseSettings.databaseName);
            _projectCollection = database.GetCollection<MyProject>(databaseSettings.myProjectCollectionName);
        }
        public async Task<IActionResult> projectList()
        {
            var values = await _projectCollection.Find(x => true).ToListAsync();
			var projectCount = await _projectCollection.CountDocumentsAsync(x => true);
			ViewBag.ProjectCount = projectCount;
			return View(values);
        }
        [HttpGet]
        public IActionResult addProject()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> addProject(MyProject myp)
        {
            await _projectCollection.InsertOneAsync(myp);
            return RedirectToAction("projectList");
        }
        public async Task<IActionResult> deleteProject(string id)
        {
            await _projectCollection.DeleteOneAsync(x => x.projectID == id);
            return RedirectToAction("projectList");
        }
        [HttpGet]
        public async Task<IActionResult> updateProject(string id)
        {
            var values = await _projectCollection.Find<MyProject>(x => x.projectID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> updateProject(MyProject myp)
        {
            var values = await _projectCollection.FindOneAndReplaceAsync(x => x.projectID == myp.projectID, myp);
            return RedirectToAction("projectList");
        }
    }
}
