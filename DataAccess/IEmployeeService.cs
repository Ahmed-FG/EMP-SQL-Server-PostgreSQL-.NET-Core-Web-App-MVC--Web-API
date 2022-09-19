using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        int CreateEmployee(Employee newItem);
        int DeleteEmployee(int? id);
        int EditEmployee(Employee currEmp);
        Employee GetEmployee(int? id);
        List<Employee> ListEmployees();
    }
}