using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("/")]
    public class MainController : Controller
    {
        private IMapper mapper;

        public MainController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}