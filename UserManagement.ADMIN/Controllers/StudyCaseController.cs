using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserManagement.ADMIN.Controllers
{
    class UserObj
    {
        public int ID { get; set; }
        public String FullName { get; set; }
    }
    public class StudyCaseController : Controller
    {
        UserObj editObj = new UserObj()
        {
            ID = 1,
            FullName = "Đặng Quang Khải"
        };
        // GET: StudyCase
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetData()
        {
            Object exempleObj = new
            {
                ID = 1,
                FullName = "Đặng Quang Khải",
                Address = "348/28 - Đs.8 - P11 - Q.Gò Vấp",
                Age = 18,
                Phone = "01663288969"
            };
            return Json(new { success = true, content = exempleObj }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public JsonResult EditID(int ID)
        {
            editObj.ID = ID;
            return Json(new { success = true, content = editObj });
        }


    }
}