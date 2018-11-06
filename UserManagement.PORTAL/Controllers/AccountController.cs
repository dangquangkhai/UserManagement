using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.LIBRARY.RDBMProviders;
using UserManagement.LIBRARY.RDBMModels;

namespace UserManagement.PORTAL.Controllers
{
    public class AccountController : Controller
    {
        UserProvider _provider = new UserProvider();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult getAllData()
        {
           User[] data = _provider.GetAllListUser().ToArray();
            return Json(new { success = true, content = data },JsonRequestBehavior.AllowGet);
        }
    }
}