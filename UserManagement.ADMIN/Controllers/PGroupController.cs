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
            //try
            //{
                List<Group> data = _provider.getAllGroup();
                List<Object> lstResult = new List<Object>();
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
                        Modifier = item.Modifier
                    });
                }

                return Json(new { success = true, content = lstResult.ToArray() },JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    return Json(new { success = false, content = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);
            //}
        }
        [HttpPost]
        public ActionResult CreatePGroup(Group newGroup)
        {
            try
            {
                return Json(new { success = _provider.createGroup(newGroup) });
            } catch(Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() });
            }


        }


        [HttpGet]
        public ActionResult EditGroup(int ID)
        {
            try
            {
                return Json(new { success = true, content = _provider.getGroupById(ID) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]

        public ActionResult EditPGroup(int ID, Group group)
        {
            try
            {
                return Json(new { success = _provider.editGroup(ID, group) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() });
            }
        }





    }
}