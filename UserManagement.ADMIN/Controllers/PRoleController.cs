namespace UserManagement.ADMIN.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using UserManagement.PERMISSON.Model;
    using UserManagement.PERMISSON.Provider;

    /// <summary>
    /// Defines the <see cref="PRoleController" />
    /// </summary>
    public class PRoleController : Controller
    {
        /// <summary>
        /// Defines the _provider
        /// </summary>
        internal PRoleProvider _provider = new PRoleProvider();

        // GET: PRole
        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The getAllRoles
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult GetAllRole()
        {
            Role[] rle = _provider.getAllRoles();
            List<object> lstResult = new List<object>();
            foreach (var item in rle)
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
            return Json(new { success = true, content = lstResult }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The CreateRole
        /// </summary>
        /// <param name="newRole">The newRole<see cref="Role"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        public ActionResult CreateRole(Role newRole)
        {
            try
            {
                return Json(new { success = _provider.createRole(newRole) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() });
            }
        }

        /// <summary>
        /// The EditRole
        /// </summary>
        /// <param name="ID">The ID<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpGet]
        public ActionResult EditRole(int ID)
        {
            try
            {
                return Json(new { success = true, content = _provider.getRoleById(ID) }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// The EditPRole
        /// </summary>
        /// <param name="ID">The ID<see cref="int"/></param>
        /// <param name="role">The role<see cref="Role"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]

        public ActionResult EditRole(int ID, Role role)
        {
            try
            {
                return Json(new { success = _provider.editRole(ID, role) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() });
            }
        }

        /// <summary>
        /// The DeleteRole
        /// </summary>
        /// <param name="ID">The ID<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]

        public ActionResult DeleteRole(int ID)
        {
            try
            {
                return Json(new { success = _provider.deleteRole(ID) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() });
            }
        }
    }
}
