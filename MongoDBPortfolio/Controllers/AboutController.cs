using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities;
using MongoDBPortfolio.DAL.Entities.Settings;

namespace MongoDBPortfolio.Controllers
{
	public class AboutController : Controller
	{
		private readonly IMongoCollection<About> _aboutCollection;
		public AboutController(IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.connectionString);//mongo db istekte bulundum
			var database = client.GetDatabase(databaseSettings.databaseName);//veri tabanına istekte bulundum
			_aboutCollection = database.GetCollection<About>(databaseSettings.aboutCollectionName);

		}
		public async Task<IActionResult> aboutList()
		{
			var values =await _aboutCollection.Find(x => true).ToListAsync();
			return View(values);
		}
		[HttpGet]
		public IActionResult addAbout()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> addAbout(About abo)
		{
			await _aboutCollection.InsertOneAsync(abo);
			return RedirectToAction("aboutList");
		}
		public async Task<IActionResult> deleteAbout(string id)
		{
			await _aboutCollection.DeleteOneAsync(x => x.aboutID == id);
			return RedirectToAction("aboutList");
		}
		[HttpGet]
		public async Task<IActionResult> updateAbout(string id)
		{
			var values = await _aboutCollection.Find<About>(x => x.aboutID == id).FirstOrDefaultAsync();
			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> updateAbout(About abo)
		{
			var values = await _aboutCollection.FindOneAndReplaceAsync(x => x.aboutID == abo.aboutID, abo);
			return RedirectToAction("aboutList");
		}
		
	}
}
