using Microsoft.AspNetCore.Mvc;

namespace MongoDBPortfolio.Controllers
{
	public class CVController : Controller
	{
		public IActionResult DownloadCv()
		{
			// PDF dosyasının yolunu wwwroot klasöründen belirtin
			string pdfFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "OnurEyupogluCV.pdf");

			// Dosya yoksa veya okunamıyorsa NotFound döndür
			if (!System.IO.File.Exists(pdfFilePath))
			{
				return NotFound();
			}

			// PDF dosyasını byte dizisine çevirerek kullanıcıya indirme
			byte[] pdfBytes = System.IO.File.ReadAllBytes(pdfFilePath);
			return File(pdfBytes, "application/pdf", "OnurEyupogluCV.pdf");
		}
	}
}
