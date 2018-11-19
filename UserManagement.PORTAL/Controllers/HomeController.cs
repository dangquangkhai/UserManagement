using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.PERMISSON.Helper;
using UserManagement.LIBRARY.RDBMModels;
using UserManagement.LIBRARY.RDBMProviders;

namespace UserManagement.PORTAL.Controllers
{
    public class HomeController : Controller
    {
        UserProvider _provider = new UserProvider();

        [RequestLogin()]
        public ActionResult Index()
        {
            int ID = SessionContext.CurrentUser().ID;
            Monthly_Schedule userMonth = _provider.getDataMonth(ID);
            Salary userSalary = _provider.getSalaryOfUserByID(ID);
            PaymentPerDay paymen = _provider.getPaymentOfUserById(ID);
            ViewBag.Salary = userSalary.Payment;
            ViewBag.TotalSalary = Convert.ToDateTime(userMonth.EndDay.ToString()).Day * paymen.Money;
            ViewBag.TotalDay = Convert.ToDateTime(userMonth.EndDay.ToString()).Day;
            ViewBag.TotalRollCountday = userMonth.TotalCount;
            ViewBag.Fullname = SessionContext.CurrentUser().Firstname + " " + SessionContext.CurrentUser().Lastname;
            ViewBag.TotalUser = _provider.getAllUser().Count();
            return View();
        }

    }
}