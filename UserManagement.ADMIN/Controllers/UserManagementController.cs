using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.LIBRARY;
using UserManagement.LIBRARY.RDBMModels;
using UserManagement.LIBRARY.RDBMProviders;

namespace UserManagement.ADMIN.Controllers
{

    public class UserManagementController : Controller
    {
        UserProvider _provider = new UserProvider();
        // GET: UserManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUser()
        {
            User[] AllUser = _provider.getAllUser();
            return Json(new { success = true, content = AllUser}, JsonRequestBehavior.AllowGet);
        }
    }
}