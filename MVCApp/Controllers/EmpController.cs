using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class EmpController : Controller
    {
        public ViewResult AllEmployees()
        {
            var context = new LnttrainingEntities1();
            var model = context.EmpTable.ToList();
            return View(model);
        }

        public ViewResult Find(string id)
        {
            int empid = int.Parse(id);
            var context = new LnttrainingEntities1();
            var model = context.EmpTable.FirstOrDefault((e) => e.EmpId == empid);
            return View(model);

        }

        [HttpPost]
        public ActionResult Find(EmpTable emp)
        {
            var context = new LnttrainingEntities1();
            var model = context.EmpTable.FirstOrDefault((e) => e.EmpId == emp.EmpId);
            model.EmpName = emp.EmpName;
            model.EmpAddress = emp.EmpAddress;
            model.EmpSalary = emp.EmpSalary;
            context.SaveChanges();//Commits the changes made to the records...
            return RedirectToAction("AllEmployees");
        }

        public ViewResult NewEmployee()
        {
            var model = new EmpTable();
            return View(model);

        }
        [HttpPost]
        public ActionResult NewEmployee(EmpTable emp)
        {
            var context = new LnttrainingEntities1();
            context.EmpTable.Add(emp);
            context.SaveChanges();
            return RedirectToAction("AllEmployees");
        }

        public ActionResult Delete(string id)
        {
            
            int empId = int.Parse(id);
            var context = new LnttrainingEntities1();
            var model = context.EmpTable.FirstOrDefault((e) => e.EmpId == empId);
            context.EmpTable.Remove(model);
            context.SaveChanges();
            return RedirectToAction("AllEmployees");
        }

    }
    }
