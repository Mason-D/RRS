using Microsoft.AspNetCore.Mvc;

namespace RRS.Areas.Admin.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
