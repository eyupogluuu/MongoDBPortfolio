using Microsoft.AspNetCore.Mvc;

namespace MongoDBPortfolio.ViewComponents.HomePage
{
    public class NavbarPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
