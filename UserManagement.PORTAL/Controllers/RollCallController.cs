using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.LIBRARY.RDBMProviders;
using UserManagement.PERMISSON.Helper;

namespace UserManagement.PORTAL.Controllers
{
    public class RollCallController : Controller
    {
        UserProvider _provider = new UserProvider();

        // GET: RollCall
        [RequestLogin()]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult IsMonthlyScheduleSet()
        {
            try
            {
                int ID = SessionContext.CurrentUser().ID;
                bool check = _provider.isMonthlyScheduleSet(ID);
                return Json(new { success = check, content = (check)?(""):("Bạn Chưa đăng ký lịch làm") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Count()
        {
            try
            {
                int ID = SessionContext.CurrentUser().ID;
                return Json(new { success = _provider.Count(ID) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() });
            }

        }
    }
}