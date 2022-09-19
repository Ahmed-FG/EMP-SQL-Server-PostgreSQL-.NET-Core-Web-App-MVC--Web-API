
namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {

            //Test2(231);
            //readEmployee();
           // table_Display("employee");
            //table_Display("qualification");
            //table_Display("emplevel");
            //table_Display("position");
            //table_Display("department");
            //table_Display("dependent");
            Console.ReadLine();
        }

        private static void Test1()
        {
            var context = new EmployeeDBContext();
            var employees = context.Employee.Where(i => i.EmpFname == "Ahmed Faruk").ToArray();
            employees[0].EmpFname = "Ömer Said";

            context.SaveChanges();
        }

        private static void Test2(int v)
        {
            var context = new EmployeeDBContext();

            var employee = context.Employee.FirstOrDefault(i => i.emp_Id == v);

            var q = context.Dependent.Where(i => i.emp_Id == 231);
            var c = q.Count();
            var dependents = q.ToArray();

            var cl = context.Dependent.Local.Count;
            var cc = context.Dependent.Count();

            //var dependent = context.Dependent.Where(i => i.EmpId == 231).ToArray();
            //var c = employee?.Dependent.Count;

            //context.SaveChanges();
        }

        private static void insertEmployee()
        {
            using (var context = new EmployeeDBContext())
            {
                Employee emp = new Employee();
                emp.EmpId = 454;
                context.Add(emp);

                emp = new Employee();
                emp.EmpFname = "Ömer Said";
                context.Add(emp);

                emp = new Employee();
                emp.EmpLname = "Gezdirici";
                context.Add(emp);

                context.SaveChanges();
            }
            return;
        }


      
        private static void table_Display(String table_Name)
        {
            var table = new Table();
            var context = new EmployeeDBContext();
            List<Employee> employees = context.Employee.ToList();
            List<Department> departments = context.Department.ToList();
            List<Dependent> dependents = context.Dependent.ToList();
            List<Qualification> qualifications = context.Qualification.ToList();
            List<Position> positions = context.Position.ToList();
            List<Emplevel> emplevels = context.Emplevel.ToList();

            if (table_Name == "Employee")
            {

                table.SetHeaders("ID", "Name", "Hiredate", "Department ID", "Position ID", "Supervisor ID", "Qualification ID", "Salary", "Commision");

                foreach (Employee e in employees)
                {

                    table.AddRow($"{e.EmpId}", e.EmpFname + " " + e.EmpLname, $"{e.Hiredate:d}", $"{e.PositionId}", $"{e.DeptId}",
                        $"{e.Supervisor}", $"{e.QualId}", $"{e.Salary}", $"{e.Commission}");

                }
            }
            else if (table_Name == "Department")
            {
                table.SetHeaders("ID", "Name", "Location", "Manager");

                foreach (Department dept in departments)
                {
                    table.AddRow($"{dept.DeptId}", $"{dept.DeptName}", $"{dept.DeptLocation}", $"{dept.Manager}");
                }
            }
            else if (table_Name == "Dependent")
            {
                table.SetHeaders("ID", "Employee ID", "Dependent DOB", "Relation");

                foreach (Dependent dep in dependents)
                {
                    table.AddRow($"{dep.DependentId}", $"{dep.EmpId}", $"{dep.DepDob}", $"{dep.Relation}");
                }
            }
            else if (table_Name == "Emplevel")
            {
                table.SetHeaders("Level No", "Low Salary", "High Salary");

                foreach (Emplevel el in emplevels)
                {
                    table.AddRow($"{el.LevelNo}", $"{el.LowSalary}", $"{el.HighSalary}");
                }
            }
            else if (table_Name == "Position")
            {
                table.SetHeaders("ID", "Description");

                foreach(Position p in positions)
                {
                    table.AddRow($"{p.PositionId}", $"{p.PositionDesc}");
                }
            }
            else if (table_Name == "Qualification")
            {
                table.SetHeaders("ID", "Description");

                foreach (Qualification q in qualifications)
                {
                    table.AddRow($"{q.QualId}", $"{q.QualDesc}");
                }
            }
            Console.WriteLine(table.ToString());
        }



    }
}


