using EmployeeManagement.DataAccess;
using EmployeeManagement.DataModel;

namespace ConsoleApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            bool usEF = false;

            IEmployeeService s;
            if (usEF)
                s = new EmployeeManagement.DataAccess.EF.EmployeeService();
            else
                s = new EmployeeManagement.DataAccess.Dapper.EmployeeService();

            var employees = s.ListEmployees();

            employees.ForEach(e => Console.WriteLine(e));


        }
    }
}