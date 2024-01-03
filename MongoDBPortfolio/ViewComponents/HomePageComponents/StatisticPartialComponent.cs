using Microsoft.AspNetCore.Mvc;

namespace MongoDBPortfolio.ViewComponents.HomePageComponents
{
    public class StatisticPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
