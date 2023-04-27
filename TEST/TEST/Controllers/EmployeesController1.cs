using Microsoft.AspNetCore.Mvc;

namespace TEST.Controllers
{
    public class EmployeesController1 : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
