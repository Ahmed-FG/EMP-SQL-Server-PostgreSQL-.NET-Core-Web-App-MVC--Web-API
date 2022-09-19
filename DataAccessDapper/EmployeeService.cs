﻿using Dapper;
using EmployeeManagement.Models;
using Microsoft.Data.SqlClient;

namespace EmployeeManagement.Services.Dapper
{
    public class EmployeeService : IEmployeeService
    {

        public string ConStr { get; set; } = "Data Source=.;Initial Catalog=\"Employee DB\";Integrated Security=True;TrustServerCertificate=True;TrustServerCertificate=True";


        public List<Employee> ListEmployees()
        {
            var sql = "select * from Employee ";
            using (var con = new SqlConnection(ConStr))
            {
                con.Open();
                return con.Query<Employee>(sql).ToList();
            }
        }

        public Employee GetEmployee(int? id)
        {
            string sql =
@"Select * from Employee 
where EmpId = @id";
            using (var con = new SqlConnection(ConStr))
            {
                con.Open();
                return con.Query<Employee>(sql, new
                {
                    id = id
                }).FirstOrDefault();
            }
        }

        public int EditEmployee(Employee currEmp)
        {
            var sql =
@"Update Employee set 
EmpFname=@EmpFname,
EmpLname=@EmpLname,
DeptId=@DeptId, 
QualId=@QualId, 
PositionId=@PositionId, 
Supervisor=@Supervisor, 
Hiredate=@Hiredate, 
Salary=@Salary,
Commission=@Commission 
where EmpId=@EmpId ";
            using (var con = new SqlConnection(ConStr))
            {
                con.Open();
                return con.Execute(sql, currEmp);
            }
        }

        public int DeleteEmployee(int? id)
        {
            var sql = "Delete from Employee where EmpId=@id";
            using (var con = new SqlConnection(ConStr))
            {
                con.Open();
                return con.Execute(sql, new
                {
                    id = id
                });
            }
        }

        public int CreateEmployee(Employee newItem)
        {
            var sql = "Insert into Employee(EmpId,EmpFname,EmpLname,DeptId,QualId,PositionId,Supervisor,Hiredate,Salary,Commission) values(@EmpId,@EmpFname,@EmpLname,@DeptId,@QualId,@PositionId,@Supervisor,@Hiredate,@Salary,@Commission)  ";
            using (var con = new SqlConnection(ConStr))
            {
                con.Open();
                return con.Execute(sql, newItem);
            }
        }

    }

}
