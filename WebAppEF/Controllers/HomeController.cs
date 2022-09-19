using EmpManagementEF;
using Microsoft.AspNetCore.Mvc;

namespace WebAppEF.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (var context = new EmployeeDBContext())
            {
                var e = context.Employee.ToList();
            }
            return View();
        }
    }
}
