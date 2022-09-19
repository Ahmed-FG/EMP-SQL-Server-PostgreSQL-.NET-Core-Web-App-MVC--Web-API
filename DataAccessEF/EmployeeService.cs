using EmployeeManagement.Models;

namespace EmployeeManagement.Services.EF
{
    public class EmployeeService : IEmployeeService
    {

        public List<Employee> ListEmployees()
        {
            using (var context = new EmployeeDBContext())
            {
                var e = context.Employee.ToList();
                return e;
            }
        }

        public Employee GetEmployee(int? id)
        {
            using (var context = new EmployeeDBContext())
            {
                var e = context.Employee.Where(x => x.EmpId == id).FirstOrDefault();
                return e;
            }
        }

        public int EditEmployee(Employee currEmp)
        {
            using (var context = new EmployeeDBContext())
            {
                var e = context.Employee.FirstOrDefault(x => x.EmpId == currEmp.EmpId);

                if (e != null)
                {
                    e.EmpId = currEmp.EmpId;
                    e.EmpFname = currEmp.EmpFname;
                    e.EmpLname = currEmp.EmpLname;
                    e.PositionId = currEmp.PositionId;
                    e.Supervisor = currEmp.Supervisor;
                    e.Hiredate = currEmp.Hiredate;
                    e.Salary = currEmp.Salary;
                    e.Commission = currEmp.Commission;
                    e.QualId = currEmp.QualId;
                    e.DeptId = currEmp.DeptId;
                    return context.SaveChanges();
                }
            }
            return 0;
        }

        public int DeleteEmployee(int? id)
        {
            using (var context = new EmployeeDBContext())
            {
                var e = context.Employee.FirstOrDefault(x => x.EmpId == id);
                if (e != null)
                {
                    context.Employee.Remove(e);
                    return context.SaveChanges();
                }
            }
            return 0;
        }

        public int CreateEmployee(Employee newItem)
        {
            using (var employee = new EmployeeDBContext())
            {
                employee.Employee.Add(newItem);
                return employee.SaveChanges();
            }
        }

    }

}
