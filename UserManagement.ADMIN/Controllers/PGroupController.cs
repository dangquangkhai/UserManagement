using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.PERMISSON.Model;
using UserManagement.PERMISSON.Provider;
using UserManagement.LIBRARY;

namespace UserManagement.ADMIN.Controllers
{
    public class PGroupController : Controller
    {
        PGroupProvider _provider = new PGroupProvider();
        
        // GET: PGroup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllGroup()
        {
            try
            {
                var data = _provider.getAllGroup();
                List<object> lstResult = new List<object>();
                foreach (var item in data)
                {
                    lstResult.Add(new
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Descriptions = item.Descriptions,
                        Created = item.Created,
                        CreatorID = item.CreatorID,
                        Modified = item.Modified,
                        Modifier = item.Modifier,
                        CreatorName = item.User.Firstname + " " + item.User.Lastname
                    });
                }

                return Json(new { success = true, content = lstResult },JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreatePGroup()
        {
            return View();
        }



    }
}