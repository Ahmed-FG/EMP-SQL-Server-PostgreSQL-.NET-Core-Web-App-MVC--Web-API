using EmpManagementDapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAppDapper.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var employees = DBMethods.ListEmployees();
            return View(employees);
        }
    }
}
