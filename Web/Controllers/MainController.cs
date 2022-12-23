using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class MainController : Controller
    {
        private IMapper mapper;

        public MainController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}