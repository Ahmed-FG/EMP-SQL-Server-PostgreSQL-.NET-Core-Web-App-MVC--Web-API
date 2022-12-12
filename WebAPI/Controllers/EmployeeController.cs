using EmployeeManagement.Services;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("List")]
        public ActionResult<List<Employee>> ListEmployees()
        {
            return employeeService.ListEmployees();
        }

        [HttpGet("Get/{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            return employeeService.GetEmployee(id);
        }

        [HttpPost("Edit")]
        public ActionResult<int> EditEmployee(Employee currEmp)
        {
            return employeeService.EditEmployee(currEmp);
        }

        [HttpPost("Create")]
        public ActionResult<int> CreateEmployee(Employee newEmp)
        {
            return employeeService.CreateEmployee(newEmp);
        }

        [HttpGet("Delete/{id}")]
        public ActionResult<int> DeleteEmployee(int? id)
        {
            return employeeService.DeleteEmployee(id);
        }

    }
}