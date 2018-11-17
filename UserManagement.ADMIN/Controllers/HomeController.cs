using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.PERMISSON.Helper;

namespace UserManagement.ADMIN.Controllers
{
    public class HomeController : Controller
    { 
        [RequestLogin()]
        public ActionResult Index()
        {
            return View();
        }
    }
}