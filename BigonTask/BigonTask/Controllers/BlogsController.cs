using Microsoft.AspNetCore.Mvc;

namespace BigonTask.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int Id)
        {
            return View();
        }
    }
}
