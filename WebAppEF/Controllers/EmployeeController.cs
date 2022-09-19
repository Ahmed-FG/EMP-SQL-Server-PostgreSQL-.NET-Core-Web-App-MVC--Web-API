using EmpManagementEF;
using Microsoft.AspNetCore.Mvc;

namespace WebAppEF.Controllers
{
    public class EmployeeController : Controller
    {
        //public ActionResult Index()
        //{
        //    var employees = DBMethods.ListEmployees();
        //    return View(employees);
        //}

        public ActionResult Read()
        {
            using (var context = new EmployeeDBContext())
            {
                var e = context.Employee.ToList();

                return View(e);
            }

        }
        public ActionResult Index()
        {
            using (var context = new EmployeeDBContext())
            {
                var e = context.Employee.ToList();

                return View(e);
            }

        }
        public ActionResult Edit(int id)
        {
            using (var context = new EmployeeDBContext())
            {
                var e = context.Employee.Where(x => x.EmpId == id).FirstOrDefault();
                return View(e);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee currData)
        {
            using (var context = new EmployeeDBContext())
            {
                var e = context.Employee.FirstOrDefault(x => x.EmpId == id);

                if (e != null)
                {
                    e.EmpId = currData.EmpId;
                    e.EmpFname = currData.EmpFname;
                    e.EmpLname = currData.EmpLname;
                    e.PositionId = currData.PositionId;
                    e.Supervisor = currData.Supervisor;
                    e.Hiredate = currData.Hiredate;
                    e.Salary = currData.Salary;
                    e.Commission = currData.Commission;
                    e.QualId = currData.QualId;
                    e.DeptId = currData.DeptId;
                    context.SaveChanges();

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
        public ActionResult Create(Employee newItem)
        {
            using (var employee = new EmployeeDBContext())
            {
                employee.Employee.Add(newItem);
                employee.SaveChanges();
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
        public ActionResult Delete(int id)
        {
            using (var context = new EmployeeDBContext())
            {
                var e = context.Employee.FirstOrDefault(x => x.EmpId == id);
                if (e != null)
                {
                    context.Employee.Remove(e);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var context = new EmployeeDBContext())
            {
                var e = context.Employee.Where(x => x.EmpId == id).FirstOrDefault();
                return View(e);
            }
        }


    }
}
