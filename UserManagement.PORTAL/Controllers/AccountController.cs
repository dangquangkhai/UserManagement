using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.PERMISSON.Helper;
using System.Web.Security;
using UserManagement.PERMISSON.Provider;
using UserManagement.PERMISSON.Model;

namespace UserManagement.PORTAL.Controllers
{
    public class AccountController : Controller
    {
        UserProvider _provider = new UserProvider();
        // GET: Account
        public ActionResult Index(string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.ReturnUrl = ReturnUrl;
                return View();
            }

        }

        public ActionResult IsLoged()
        {
            var tmp = SessionContext.CurrentUser().ID;
            if (_provider.isLoged(SessionContext.CurrentUser().ID) != null && _provider.isLoged(SessionContext.CurrentUser().ID).ID > 0)
            {
                User userLogin = _provider.isLoged(SessionContext.CurrentUser().ID);
                User data = new User();
                data.Firstname = userLogin.Firstname;
                data.Lastname = userLogin.Lastname;
                data.Image = userLogin.Image;
                return Json(new { Login = true, contents = data }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { Login = false }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password, string ReturnUrl = null, int countTryLogin = 0, bool Remember = false)
        {
            UserProvider userProvider = new UserProvider();
            try
            {
                User user = userProvider.GetByEmailAndPassword(Email, Password);
                if (user != null)
                {
                    //if (user.IsEnabled)
                    //{
                    User tmp = user;
                    base.ViewBag.ReturnUrl = ReturnUrl;
                    FormsAuthenticationTicket formsAuthenticationTicket = new FormsAuthenticationTicket(1, Email, DateTime.Now, DateTime.Now.AddMinutes(2000.0), false, "");

                    //Set Cookie for user login without check Remember Me feauture for 2 min
                    //FormsAuthenticationTicket formsAuthenticationTicket = new FormsAuthenticationTicket(1, CompanyEmail, DateTime.Now, DateTime.Now.AddMinutes((Remember) ? (2000.0) : (2000.0)), false, "");
                    string value = FormsAuthentication.Encrypt(formsAuthenticationTicket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value)
                    {
                        Expires = formsAuthenticationTicket.Expiration,
                        Domain = FormsAuthentication.CookieDomain,
                        Path = FormsAuthentication.FormsCookiePath,
                        HttpOnly = true
                    };
                    base.Response.Cookies.Add(cookie);
                    //this.SetCurrent(username);
                    //UserSessionManager.SetCurrent(username);
                    //base.ViewBag.CurrentUser = base.VDMSUser;
                    //FormsAuthentication.RedirectFromLoginPage(username, false);
                    /*if (string.IsNullOrEmpty(ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }*/
                    return Json(new { success = true });
                    //}
                    //else
                    //{
                    //    return Json(new { success = false, content = "Tài khoản chưa được kích hoạt" });
                    //}

                }
                else
                {
                    return Json(new { success = false, content = "Email hoặc Mật Khẩu không đúng" });
                }

            }
            catch (Exception)
            {
                return Json(new { success = false, content = "Xảy ra sự cố xin vui lòng thử lại sau" });
            }

        }

        /*[HttpPost]
        public ActionResult Login(string CompanyEmail, string Password, string ReturnUrl = null, int countTryLogin = 0)
        {
            UserProvider userProvider = new UserProvider();
            User user = userProvider.GetByEmailAndPassword(CompanyEmail, Password);
            if (user != null)
            {
                base.ViewBag.ReturnUrl = ReturnUrl;
                FormsAuthenticationTicket formsAuthenticationTicket = new FormsAuthenticationTicket(1, CompanyEmail, DateTime.Now, DateTime.Now.AddMinutes(2000.0), false, "");
                string value = FormsAuthentication.Encrypt(formsAuthenticationTicket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value)
                {
                    Expires = formsAuthenticationTicket.Expiration,
                    Domain = FormsAuthentication.CookieDomain,
                    Path = FormsAuthentication.FormsCookiePath,
                    HttpOnly = true
                };
                base.Response.Cookies.Add(cookie);
                //this.SetCurrent(username);
                //UserSessionManager.SetCurrent(username);
                //base.ViewBag.CurrentUser = base.VDMSUser;
                //FormsAuthentication.RedirectFromLoginPage(username, false);
                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    return RedirectToAction("Index", "CompanyDashboard");
                }
            }

            return Redirect(ReturnUrl);
        }*/
    }
}