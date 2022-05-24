using Microsoft.AspNetCore.Mvc;

namespace RRS.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
