
using Dapper;
using Microsoft.Data.SqlClient;
using System.ComponentModel;

namespace empManagementDapper
{
    public static class DBMethods
    {

        public static string  ConStr { get; set; } = "Data Source=.;Initial Catalog=\"Employee DB\";Integrated Security=True;TrustServerCertificate=True;TrustServerCertificate=True";


        public static List<Employee> ListEmployees()
        {
            var sql = "select * from employee ";
            using (var con = new SqlConnection(ConStr))
            {
                con.Open();
                return con.Query<Employee>(sql).ToList();
            }
        }

        public static Employee GetEmployee(int? id)
        {
            string sql = 
@"select * from employee 
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

        public static int EditEmployee(Employee currEmp)
        {
            var sql = 
@"Update employee set 
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
                return con.Execute(sql,currEmp);
            }
        }

        public static int DeleteEmployee(int? id)
        {
            var sql = "Delete from employee where EmpId=@id";
            using (var con = new SqlConnection(ConStr))
            {
                con.Open();
                return con.Execute(sql, new
                {
                    id = id
                });
            }
        }

        public static int CreateEmployees(Employee newItem)
        {
            var sql = "Insert into employee(EmpId,EmpFname,EmpLname,DeptId,QualId,PositionId,Supervisor,Hiredate,Salary,Commission) values(@EmpId,@EmpFname,@EmpLname,@DeptId,@QualId,@PositionId,@Supervisor,@Hiredate,@Salary,@Commission)  ";
            using (var con = new SqlConnection(ConStr))
            {
                con.Open();
                return con.Execute(sql,newItem);
            }
        }

    }

}
