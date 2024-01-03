using Microsoft.AspNetCore.Mvc;

namespace MongoDBPortfolio.ViewComponents.HomePageComponents
{
    public class VideoModalPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
