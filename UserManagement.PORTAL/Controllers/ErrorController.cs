﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserManagement.PORTAL.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Forbiden()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Internal()
        {
            return View();
        }

    }
}