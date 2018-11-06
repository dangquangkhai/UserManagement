using System.Web;
using UserManagement.LIBRARY.RDBMModels;
using UserManagement.LIBRARY.RDBMProviders;


namespace UserManagement.LIBRARY
{
    public class SessionHelper
    {
        protected static User _CurrentUser = new User();
        public static User CurrentUser 
        {
            get {
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

                return user.getUserByEmail(email);
            }
            set {
                _CurrentUser = value;
            }
        }
    }
}
