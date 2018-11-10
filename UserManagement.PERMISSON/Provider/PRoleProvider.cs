using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.PERMISSON.Helper;
using UserManagement.PERMISSON.Model;

namespace UserManagement.PERMISSON.Provider
{
    public class PRoleProvider : BaseProvider
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

        public List<Permission> getAllPermission()
        {
            try
            {
                return base.db.Permissions.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Permission[] GetAllPermissionsOfRoleByID(int ID)
        {
            List<Permission> retList = new List<Permission>();
            var query = (from Rol in db.Role_Permissions
                         join Per in db.Permissions on Rol.PermissionID equals Per.ID
                         where Rol.RoleID == ID
                         select new { Name = Per.Name, ID = Per.ID });
            foreach (var item in query)
            {
                Permission pitem = new Permission();
                pitem.ID = item.ID;
                pitem.Name = item.Name;
                retList.Add(pitem);
            }
            return retList.ToArray();

        }

        public bool updatePRolePermission(int ID, Permission[] PermissionList)
        {
            try
            {
                List<Role_Permissions> select = base.db.Role_Permissions.Where(g => g.RoleID == ID).ToList();
                if (select.Count <= 0)
                {
                    foreach (Permission item in PermissionList)
                    {
                        Role_Permissions addItem = new Role_Permissions();
                        if (item.Checked == true)
                        {
                            addItem.RoleID = ID;
                            addItem.PermissionID = item.ID;
                            select.Add(addItem);
                        }
                    }
                    base.db.Role_Permissions.AddRange(select);
                    base.db.SaveChanges();
                }
                else
                {
                    foreach (Permission item in PermissionList)
                    {
                        Role_Permissions addItem = new Role_Permissions();
                        if (item.Checked == false && select.Where(g => g.PermissionID == item.ID).Count() == 1)
                        {
                            base.db.Role_Permissions.Remove(select.Where(g => g.PermissionID == item.ID).FirstOrDefault());
                        }

                        if (item.Checked == true && select.Where(g => g.PermissionID == item.ID).Count() == 0)
                        {
                            addItem.RoleID = ID;
                            addItem.PermissionID = item.ID;
                            base.db.Role_Permissions.Add(addItem);
                        }
                    }
                    base.db.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
