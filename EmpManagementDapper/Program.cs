
using Dapper;
using empManagementDapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;

namespace empManagementDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var conStr = "Data Source=.;Initial Catalog=\"Employee DB\";Integrated Security=True";
            if (args.Count() >= 1)
            {
                conStr = args[0];
            }
            Console.WriteLine($"Using Data Source:'{conStr}'");

            //test1();
            //test2();
            test3();
            
            //test4();

            // Create connection string
           
            //var builder = new SqlConnectionStringBuilder()
            //{
            //    DataSource = conStr,
            //    AttachDBFilename = $@"{dataFolder.FullName}\DapperSample.mdf",
            //    IntegratedSecurity = true,
            //    ConnectTimeout = 10,
            //    ApplicationName = "Dapper.Samples.Basics"
            //};
        }
        public static void test1()
        {
            var conStr = "Data Source=.;Initial Catalog=\"Employee DB\";Integrated Security=True";

            Console.WriteLine("Please enter the sql code you want to run in this table");
            String sqlUse = Console.ReadLine();
            var sql = sqlUse;


            List<Employee> Employees;
            using (var con = new SqlConnection(conStr))
            {
                con.Open();

                Employees = con.Query<Employee>(sql).ToList();

                foreach (Employee e in Employees)
                {
                    Console.WriteLine($"{e.EmpId} | {e.EmpFname}  {e.EmpLname} | {e.Hiredate:d} | {e.PositionId} | {e.DeptId} | {e.Supervisor} | {e.QualId} | {e.Salary} | {e.Commission}");
                    Console.WriteLine();
                }
                Console.ReadLine();
            }

        }

        public static void test2()
        {
            var conStr = "Data Source=.;Initial Catalog=\"Employee DB\";Integrated Security=True";

            List<Department> departments;
            using (var con = new SqlConnection(conStr))
            {
                con.Open();
                var sql2 = "select * from department ";


                departments = con.Query<Department>(sql2).ToList();
                foreach (Department d in departments)
                {
                    Console.WriteLine($"{d.DeptId} | {d.DeptName} | {d.DeptLocation} | {d.Manager}");
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }

        public static void test3()
        {
            var Employees = DBMethods.ListEmployees();

            foreach (Employee e in Employees)
            {
                Console.WriteLine($"{e.EmpId} | {e.EmpFname}  {e.EmpLname} | {e.Hiredate:d} | {e.PositionId} | {e.DeptId} | {e.Supervisor} | {e.QualId} | {e.Salary} | {e.Commission}");
                Console.WriteLine();
            }
            Console.ReadLine();
        }


        //public static async void test4()
        //{
        //    var conStr = "Data Source=.;Initial Catalog=\"Employee DB\";Integrated Security=True";
        //    using (var con = new SqlConnection(conStr))
        //    {
        //        var sql = @"select EmpId, EmpFname, EmpLname, e.dept_Id, dept_Name
        //                  from Employee e 
        //                  inner join department d on e.dept_Id=d.dept_Id ";

        //       List<Employee> Employees = con.Query<Employee>(sql);

        //        Employees.ToList().ForEach(Employee => Console.WriteLine($"Employee: {Employee.EmpFname}, {Employee.EmpLname}, Department: {Employee.Dept.Dept_Name}"));
        //        Console.ReadLine();
        //        }
        //    }


    }

}
