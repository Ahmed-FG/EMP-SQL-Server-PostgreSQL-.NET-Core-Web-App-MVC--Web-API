using EmpManagementDapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAppDapper.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            var employees = DBMethods.ListEmployees();
            return View(employees);
        }
                  
        public ActionResult Edit(int id)
        {
            var e = DBMethods.GetEmployee(id);
            return View(e);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Employee currEmp)
        {
            using(var context= new EmployeeDBContext())
            {
                var e = DBMethods.GetEmployee(id);

                if (e != null)
                {
                    e.EmpId =currEmp.EmpId;
                    e.EmpFname = currEmp.EmpFname;
                    e.EmpLname = currEmp.EmpLname;
                    e.PositionId = currEmp.PositionId;
                    e.Supervisor = currEmp.Supervisor;
                    e.Hiredate = currEmp.Hiredate;
                    e.Salary = currEmp.Salary;
                    e.Commission = currEmp.Commission;  
                    e.QualId = currEmp.QualId;
                    e.DeptId = currEmp.DeptId;
                    DBMethods.EditEmployee(currEmp);

                    return RedirectToAction("Index");
                }
                else
                    return View();

            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee newEmp)
        {
            using(var employee = new EmployeeDBContext())
            {
               
                DBMethods.CreateEmployees(newEmp);

                return RedirectToAction("Index");
            }

            string message = "Created the record successfully";

            ViewBag.Message = message;

            return View();
        }

        public ActionResult Delete()
        {
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            using (var context = new EmployeeDBContext())
            {
                var e = DBMethods.GetEmployee(id);
                if (e != null)
                {
                    DBMethods.DeleteEmployee(id);
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
        }

        public ActionResult Details(int? id)
        {
            var employee = DBMethods.GetEmployee(id);
            return View(employee);
        }


    }
}
