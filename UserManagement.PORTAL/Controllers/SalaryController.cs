using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.LIBRARY.RDBMModels;
using UserManagement.LIBRARY.RDBMProviders;
using UserManagement.PERMISSON.Helper;

namespace UserManagement.PORTAL.Controllers
{
    public class SalaryController : Controller
    {
        UserProvider _provider = new UserProvider();
        // GET: Salary
        [RequestLogin()]
        public ActionResult Index()
        {
            ViewBag.FullName = SessionContext.CurrentUser().Firstname + " " + SessionContext.CurrentUser().Lastname;
            return View();
        }

        public JsonResult GetSalaryOfCurrentUser()
        {
            try
            {
                int ID = SessionContext.CurrentUser().ID;
                Salary userSalary = _provider.getSalaryOfUserByID(ID);
                Object data = new {
                    userSalary.ID,
                    userSalary.UserID,
                    userSalary.MonthID,
                    userSalary.Payment,
                    userSalary.PayMentOfUserID,
                    FullName = userSalary.User.Firstname + " " + userSalary.User.Lastname

                };

                return Json(new { success = true, content = data },JsonRequestBehavior.AllowGet);

            }catch(Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);

            }
        }
    }
}