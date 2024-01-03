using Microsoft.AspNetCore.Mvc;

namespace MongoDBPortfolio.ViewComponents.HomePageComponents
{
    public class SpinnerPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
