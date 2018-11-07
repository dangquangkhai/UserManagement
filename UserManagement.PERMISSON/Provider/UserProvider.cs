using UserManagement.PERMISSON.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace UserManagement.PERMISSON.Provider
{
    public class UserProvider : BaseProvider
    {
        public List<string> getAllPermission()
        {
            string Email = HttpContext.Current.User.Identity.Name;
            return (from us in base.db.Users
                    join gu in base.db.Group_Users on us.ID equals gu.UserID
                    join gr in base.db.Group_Roles on gu.GroupID equals gr.GroupID
                    join rp in base.db.Role_Permissions on gr.RoleID equals rp.RoleID
                    join pe in base.db.Permissions on rp.PermissionID equals pe.ID
                    where us.Email == Email
                    select (pe.Name.Trim())
                               ).ToList();


        }
        public User GetByEmailAndPassword(string email, string password)
        {
            User user =  base.db.Users.Where(u => u.Email == email).FirstOrDefault();
            if (new SecureCipher().Decrypt(user.Password) == password)
            {
                return user;
            }
            else
            {
                return null;
            }
        }


        public User isLoged(int ID)
        {
            User user = base.db.Users.Where(u => u.ID == ID).FirstOrDefault();
            return user;
        }

        public User GetByEmail(string email)
        {
            return base.db.Users.Where(u => u.Email == email).FirstOrDefault();
        }

    }
}
