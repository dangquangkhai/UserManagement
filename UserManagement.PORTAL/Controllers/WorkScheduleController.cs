using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.LIBRARY;
using UserManagement.LIBRARY.RDBMProviders;
using UserManagement.PERMISSON.Helper;

namespace UserManagement.PORTAL.Controllers
{
    public class WorkScheduleController : Controller
    {
        UserProvider _provider = new UserProvider();
        // GET: WorkSchedule
        [RequestLogin()]
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult getDataMonth()
        {
            int ID = SessionContext.CurrentUser().ID;
            var tmp = _provider.getDataMonth(ID);
            return Json( new { success = true, content = ReflectionHelper.ModelToObject(_provider.getDataMonth(ID)) }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult SaveMonthlySchedule(DateTime startday, DateTime endday)
        {
            //try
            //{
                int ID = SessionContext.CurrentUser().ID;
                return Json(new { success = _provider.saveMonthlySchedule(ID, startday, endday) });
            //}
            //catch(Exception ex)
            //{
            //    return Json(new { success = false, content = ex.Message.ToString() });
            //}


        }

        public ActionResult ShowCalender()
        {
            return View();
        }


    }
}