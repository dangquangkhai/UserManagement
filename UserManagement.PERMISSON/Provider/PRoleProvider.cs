using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.PERMISSON.Helper;
using UserManagement.PERMISSON.Model;

namespace UserManagement.PERMISSON.Provider
{
    public class PRoleProvider: BaseProvider
    {
        public Role[] getAllRoles()
        {
            Role[] role = base.db.Roles.ToArray();
            return role;
        }

        public bool validRole(Role role)
        {
            try
            {
                Role check = base.db.Roles.Where(g => g.Name == role.Name).FirstOrDefault();
                return (check == null) ? (true) : (false);
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool createRole(Role role)
        {
            try
            {
                if (validRole(role))
                {
                    role.Created = DateTime.Today;
                    base.db.Roles.Add(role);
                    base.db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool editRole(int ID, Role role)
        {
            try
            {
                Role editRole = base.db.Roles.Where(g => g.ID == ID).FirstOrDefault();
                editRole.Name = role.Name;
                editRole.Descriptions = role.Descriptions;
                editRole.Modified = DateTime.Today;
                base.db.SaveChanges();
                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }


        public Role getRoleById(int ID)
        {
            try
            {
                return base.db.Roles.Where(g => g.ID == ID).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool deleteRole(int ID)
        {
            try
            {
                Role delete = base.db.Roles.Where(g => g.ID == ID).FirstOrDefault();
                base.db.Roles.Attach(delete);
                base.db.Roles.Remove(delete);
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
