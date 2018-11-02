using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
            List<Object> data = new List<Object>();
            User[] AllUser = _provider.getAllUser();
            foreach (User item in AllUser)
            {
                data.Add(new {
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
            return Json(new { success = true, content = data.ToArray()}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

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
            } catch(Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() });
            }

        }

        [HttpGet]
        public ActionResult EditUser(int ID)
        {
            ViewBag.id = ID;
            return View();
        }


        [HttpPost]
        public ActionResult EditUser(int ID, User user)
        {
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
                return Json(new { success = true, content = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);
            }

        }

    }
}