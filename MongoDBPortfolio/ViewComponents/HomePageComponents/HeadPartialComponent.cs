using Microsoft.AspNetCore.Mvc;

namespace MongoDBPortfolio.ViewComponents.HomePageComponents
{
    public class HeadPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
