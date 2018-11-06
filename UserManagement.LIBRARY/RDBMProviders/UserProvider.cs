using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.LIBRARY.RDBMModels;

namespace UserManagement.LIBRARY.RDBMProviders
{
    public class UserProvider: RDBMBaseProvider
    {
        String defaultPassWord = "Iloveopsr1998";
        public User[] getAllUser()  
        {
            return base.db.Users.ToArray();
        }


        public String createUser(User user)
        {
            try
            {
                base.db.Users.Add(user);
                base.db.SaveChanges();
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public User getUserByEmail(String Email)
        {
            return base.db.Users.Where(u => u.Email == Email).FirstOrDefault();
        }


        public User getUserById(int ID)
        {
            try
            {
                return base.db.Users.Where(u => u.ID == ID).FirstOrDefault();
            }
            catch(Exception )
            {
                return null;
            }
        }

        public bool editUser(int ID, User user)
        {
            try
            {
                User edit = base.db.Users.Where(u => u.ID == ID).FirstOrDefault();

                edit.Email = (user.Email != null || user.Email != "")?(user.Email):(edit.Email);
                //if(user.Password == null || user.Password == "")
                //{
                //    edit.Password = edit.Password;
                //}
                //else
                //{
                //    edit.Password = new SecureCipher().Encrypt(user.Password);
                //}
                edit.Password = (user.Password == null || user.Password == "") ? (edit.Password) : (new SecureCipher().Encrypt(user.Password));
                edit.Firstname = user.Firstname;
                edit.Lastname = user.Lastname;
                edit.Phone = user.Phone;
                edit.Position = user.Position;
                edit.Birthday = user.Birthday;
                edit.Address = user.Address;
                edit.Image = user.Image;
                base.db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

    }
}
