using UserManagement.PERMISSON.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

using System.Web.Routing;
using System.Web;
using System.Web.Mvc;

namespace UserManagement.PERMISSON.Helper
{
    public class RequestPermission : AuthorizeAttribute
    {
        protected bool bAllowAccess = false;
        UserProvider _provider = new UserProvider();
        private string sPermission = "";
        public RequestPermission(string sData)
        {
            sPermission = sData;

        }


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return bAllowAccess;
        }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //bAllowAccess = true;
            //base.OnAuthorization(filterContext);
            //return;
            string Email = HttpContext.Current.User.Identity.Name;
            if (string.IsNullOrEmpty(Email))
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Account", ReturnUrl = HttpContext.Current.Request.Url }));
                return;
            }
            if (sPermission.Equals("NONE"))
            {
                bAllowAccess = true;
            }
            else
            {
                List<string> lstPermission = _provider.getAllPermission();
                if (lstPermission.Where(e => e == sPermission).Count() == 0)
                {
                    AuthorizationContext UnAuthContext = new AuthorizationContext();
                    bAllowAccess = false;
                    base.HandleUnauthorizedRequest(UnAuthContext);
                }
                else
                {
                    bAllowAccess = true;
                }
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
