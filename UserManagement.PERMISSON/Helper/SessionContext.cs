using UserManagement.PERMISSON.Model;
using UserManagement.PERMISSON.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace UserManagement.PERMISSON.Helper
{
    public class SessionContext
    {
        public void SetAuthenticationToken(string name, bool isPersistant, User userData)
        {
            string data = null;
            if (userData != null)
                data = new JavaScriptSerializer().Serialize(userData);

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, name, DateTime.Now, DateTime.Now.AddYears(1), isPersistant, userData.ID.ToString());

            string cookieData = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieData)
            {
                HttpOnly = true,
                Expires = ticket.Expiration
            };

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static User CurrentUser()
        {
            string email = HttpContext.Current.User.Identity.Name;
            if (string.IsNullOrEmpty(email))
            {
                User anonymousUser = new User();
                anonymousUser.ID = -1;
                anonymousUser.Firstname = "Vô";
                anonymousUser.Lastname = "Danh";
                return anonymousUser;
            }
            UserProvider user = new UserProvider();

            return user.GetByEmail(email);
        }
    }
}
