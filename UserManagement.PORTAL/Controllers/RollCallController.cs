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

        [HttpPost]
        public JsonResult Count()
        {
            int ID = SessionContext.CurrentUser().ID;
            return Json(new { success = _provider.Count(ID) });
        }
    }
}