using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamWebApp.Models;

namespace ExamWebApp.Controllers
{
    public class MVCController : Controller
    {
        public ViewResult Display()
        {
            var context = new MyDatabase();
            var model = context.EmpTables.ToArray();
            return View(model);
        }
        public ActionResult Find(string id)
        {
            int EmpId = int.Parse(id);
            var context = new MyDatabase();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpID == EmpId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Find(EmpTable emp)
        {
            var context = new MyDatabase();
            var model = context.EmpTables.FirstOrDefault((e) => e.EmpID == emp.EmpID);
            model.EmpName = emp.EmpName;
            model.EmpAddress = emp.EmpAddress;
            model.EmpSalary = emp.EmpSalary;
            context.SaveChanges();
            return RedirectToAction("Display");
        }
        public ViewResult NewEmployee()
        {
            var model = new EmpTable();
            return View(model);
        }
        [HttpPost]
        public ActionResult NewEmployee(EmpTable emp)
        {
            var context = new MyDatabase();
            context.EmpTables.Add(emp);
            context.SaveChanges();
            return RedirectToAction("Display");
        }
    }
}