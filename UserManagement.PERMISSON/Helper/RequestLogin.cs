using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UserManagement.PERMISSON.Provider;
using UserManagement.PERMISSON.Model;

namespace UserManagement.PERMISSON.Helper
{
    public class RequestLogin : AuthorizeAttribute
    {

        bool AllowAccess = false;
        public RequestLogin()
        {

        }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return AllowAccess;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //bAllowAccess = true;
            //base.OnAuthorization(filterContext);
            //return;
            //string Email = HttpContext.Current.User.Identity.Name;
            try
            {
                RDBMDBContext db = new RDBMDBContext();
                if (!db.Database.Exists())
                {
                    throw new Exception("Lost connection");
                }
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Account", ReturnUrl = HttpContext.Current.Request.Url }));
                    return;
                }
                else
                {
                    //List<string> lstPermission = _provider.getAllPermission();
                    //if (lstPermission.Where(e => e == sPermission).Count() == 0)
                    //{
                    //    AuthorizationContext UnAuthContext = new AuthorizationContext();
                    //    bAllowAccess = false;
                    //    base.HandleUnauthorizedRequest(UnAuthContext);
                    //}
                    //else
                    //{
                    //    bAllowAccess = true;
                    //}
                    AllowAccess = true;
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Error", action = "Forbiden" }));
            }
            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new
            RouteValueDictionary(new { controller = "Error", action = "Forbiden" }));


        }

    }
}
