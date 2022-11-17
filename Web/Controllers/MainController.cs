using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class MainController: Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}