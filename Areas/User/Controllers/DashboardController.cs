using Microsoft.AspNetCore.Mvc;

namespace D424.Areas.User.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
