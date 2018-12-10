using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.LIBRARY;
using UserManagement.LIBRARY.RDBMModels;
using UserManagement.LIBRARY.RDBMProviders;
using UserManagement.PERMISSON.Helper;

namespace UserManagement.ADMIN.Controllers
{
    public class AjaxUserManagementController : Controller
    {
        UserProvider _provider = new UserProvider();
        // GET: AjaxUserManagement
        [RequestLogin()]
        public ActionResult Index()
        {
            return View();
        }

        [RequestPermission("P_USER_MANAGEMENT_GET")]
        public ActionResult GetUser()
        {
            List<Object> data = new List<Object>();
            User[] AllUser = _provider.getAllUser();
            foreach (User item in AllUser)
            {
                data.Add(new
                {
                    ID = item.ID,
                    Email = item.Email,
                    Firstname = item.Firstname,
                    Lastname = item.Lastname,
                    Birthday = item.Birthday,
                    Position = item.Position,
                    Address = item.Address,
                    Phone = item.Phone,

                });
            }
            return Json(new { success = true, content = data.ToArray() }, JsonRequestBehavior.AllowGet);
        }


        [RequestPermission("P_USER_MANAGEMENT_CREATE")]
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [RequestPermission("P_USER_MANAGEMENT_CREATE")]
        [HttpPost]
        public ActionResult CreateUser(User newUser)
        {
            try
            {
                String check = _provider.createUser(newUser);
                if (check == "true")
                    return Json(new { success = true });
                else
                    return Json(new { success = false, content = check });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() });
            }

        }

        [RequestPermission("P_USER_MANAGEMENT_EDIT")]

        [HttpGet]
        public ActionResult EditUser(int? ID = null)
        {
            try
            {
                if (ID == null)
                {
                    throw new Exception("Error");
                }
                else
                {
                    ViewBag.id = ID;
                    return View();
                }

            }
            catch (Exception)
            {
                return RedirectToAction("NotFound", "Error");
            }

        }

        [RequestPermission("P_USER_MANAGEMENT_EDIT")]
        [HttpPost]
        public ActionResult EditUser(int ID, User user)
        {
            var tmp = user;
            try
            {
                bool check = _provider.editUser(ID, user);
                return Json(new { success = check });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() });
            }

        }


        [HttpGet]
        public ActionResult getEditDate(int ID)
        {
            try
            {
                var data = _provider.getUserById(ID);
                data.Password = null;
                return Json(new { success = true, content = ReflectionHelper.ModelToObject(data) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}