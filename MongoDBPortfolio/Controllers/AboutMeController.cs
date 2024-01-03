using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities.Settings;
using MongoDBPortfolio.DAL.Entities;

namespace MongoDBPortfolio.Controllers
{
	public class AboutMeController : Controller
	{
		private readonly IMongoCollection<AboutMe> _aboutMeCollection;
		public AboutMeController(IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.connectionString);//mongo db istekte bulundum
			var database = client.GetDatabase(databaseSettings.databaseName);//veri tabanına istekte bulundum
			_aboutMeCollection = database.GetCollection<AboutMe>(databaseSettings.aboutMeCollectionName);
		}
			public async Task<IActionResult> aboutMeList()
			{
				var values = await _aboutMeCollection.Find(x => true).ToListAsync();
				return View(values);
			}
		[HttpGet]
		public IActionResult addAboutMe()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> addAboutMe(AboutMe abom)
		{
			await _aboutMeCollection.InsertOneAsync(abom);
			return RedirectToAction("aboutMeList");
		}
		public async Task<IActionResult> deleteAboutMe(string id)
		{
			await _aboutMeCollection.DeleteOneAsync(x => x.aboutMeID == id);
			return RedirectToAction("aboutMeList");
		}
		[HttpGet]
		public async Task<IActionResult> updateAboutMe(string id)
		{
			var values = await _aboutMeCollection.Find<AboutMe>(x => x.aboutMeID == id).FirstOrDefaultAsync();
			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> updateAboutMe(AboutMe abo)
		{
			var values = await _aboutMeCollection.FindOneAndReplaceAsync(x => x.aboutMeID == abo.aboutMeID, abo);
			return RedirectToAction("aboutMeList");
		}
	}
}
