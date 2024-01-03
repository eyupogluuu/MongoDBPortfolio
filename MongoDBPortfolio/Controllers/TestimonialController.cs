using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBPortfolio.DAL.Entities.Settings;
using MongoDBPortfolio.DAL.Entities;

namespace MongoDBPortfolio.Controllers
{
	public class TestimonialController : Controller
	{
		private readonly IMongoCollection<Testimonial> _testimonialCollection;
		public TestimonialController(IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.connectionString);
			var database = client.GetDatabase(databaseSettings.databaseName);
			_testimonialCollection = database.GetCollection<Testimonial>(databaseSettings.testimonialCollectionName);

		}
		public async Task<IActionResult> testimonialList()
		{
			var values = await _testimonialCollection.Find(x => true).ToListAsync();
			return View(values);
		}
		[HttpGet]
		public IActionResult addTestimonial()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> addTestimonial(Testimonial testi)
		{
			
			await _testimonialCollection.InsertOneAsync(testi);
			return RedirectToAction("testimonialList");
		}
		public async Task<IActionResult> deleteTestimonial(string id)
		{
			await _testimonialCollection.DeleteOneAsync(x => x.testimonialID == id);
			return RedirectToAction("testimonialList");
		}
		[HttpGet]
		public async Task<IActionResult> updateTestimonial(string id)
		{
			var values = await _testimonialCollection.Find(x => x.testimonialID == id).FirstOrDefaultAsync();
			return View(values);
		}
		[HttpPost]
		public async Task<IActionResult> updateTestimonial(Testimonial testi)
		{
			var values = await _testimonialCollection.FindOneAndReplaceAsync(x => x.testimonialID == testi.testimonialID, testi);
			return RedirectToAction("testimonialList");
		}
	}
}
