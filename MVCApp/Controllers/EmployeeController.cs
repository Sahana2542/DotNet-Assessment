using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        public ViewResult AllEmployees()
        {
            
            var context = new LttsEntities();
            var model = context.EmpTable.ToList();
            return View(model);
        }
    }
}