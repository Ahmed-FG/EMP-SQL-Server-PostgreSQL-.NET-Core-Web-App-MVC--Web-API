using EmployeeManagement.Services;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public ActionResult Index()
        {
            var employees = employeeService.ListEmployees();
            return View(employees);
        }

        public ActionResult Edit(int id)
        {
            var e = employeeService.GetEmployee(id);
            return View(e);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee currEmp)
        {
            employeeService.EditEmployee(currEmp);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee newEmp)
        {
            employeeService.CreateEmployee(newEmp);
            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            var employee = employeeService.GetEmployee(id);
            return View(employee);
        }


    }
}
