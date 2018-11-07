namespace UserManagement.ADMIN.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using UserManagement.PERMISSON.Model;
    using UserManagement.PERMISSON.Provider;

    /// <summary>
    /// Defines the <see cref="PGroupController" />
    /// </summary>
    public class PGroupController : Controller
    {
        /// <summary>
        /// Defines the _provider
        /// </summary>
        internal PGroupProvider _provider = new PGroupProvider();

        // GET: PGroup
        /// <summary>
        /// The Index
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The GetAllGroup
        /// </summary>
        /// <returns>The <see cref="ActionResult"/></returns>
        public ActionResult GetAllGroup()
        {
            try
            {
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

                return Json(new { success = true, content = lstResult.ToArray() }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    content = ex.Message.ToString()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// The CreatePGroup
        /// </summary>
        /// <param name="newGroup">The newGroup<see cref="Group"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
        [HttpPost]
        public ActionResult CreatePGroup(Group newGroup)
        {
            try
            {
                return Json(new { success = _provider.createGroup(newGroup) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() });
            }
        }

        /// <summary>
        /// The EditGroup
        /// </summary>
        /// <param name="ID">The ID<see cref="int"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
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

        /// <summary>
        /// The EditPGroup
        /// </summary>
        /// <param name="ID">The ID<see cref="int"/></param>
        /// <param name="group">The group<see cref="Group"/></param>
        /// <returns>The <see cref="ActionResult"/></returns>
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


       [HttpPost]

       public ActionResult DeleteGroup(int ID)
        {
            try
            {
                return Json(new { success = _provider.deleteGroup(ID) });
            } catch(Exception ex)
            {
                return Json(new { success = false, content = ex.Message.ToString() });
            }
        }

    }
}
