using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.PERMISSON.Model;

namespace UserManagement.PERMISSON.Provider
{
    public class PGroupProvider : BaseProvider
    {
        public List<Group> getAllGroup()
        {
            try
            {
                return base.db.Groups.ToList();
            } catch(Exception)
            {
                return null;
            }
        }

        public bool validGroup(Group group)
        {
            try
            {
                Group check = base.db.Groups.Where(g => g.Name == group.Name).FirstOrDefault();
                return (check == null) ? (true) : (false);
            } catch (Exception)
            {
                return false;
            }

        }

        public bool createGroup(Group newGroup)
        {
            try
            {
                if(validGroup(newGroup))
                {
                    newGroup.Created = DateTime.Today;
                    base.db.Groups.Add(newGroup);
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

        public bool editGroup(int ID, Group group)
        {
            try
            {
                Group editGroup = base.db.Groups.Where(g => g.ID == ID).FirstOrDefault();
                editGroup.Name = group.Name;
                editGroup.Descriptions = group.Descriptions;
                editGroup.Modified = DateTime.Today;
                base.db.SaveChanges();
                return true;
                

            }
            catch (Exception)
            {
                return false;
            }
        }


        public Group getGroupById(int ID)
        {
            try
            {
                return base.db.Groups.Where(g => g.ID == ID).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool deleteGroup(int ID)
        {
            try
            {
                Group delete = base.db.Groups.Where(g => g.ID == ID).FirstOrDefault();
                base.db.Groups.Attach(delete);
                base.db.Groups.Remove(delete);
                base.db.SaveChanges();
                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Role> getAllRole()
        {
            return base.db.Roles.ToList();
        }

        public List<User> getAllUser()
        {
            return base.db.Users.ToList();
        }

        public Role[] GetAllRoleOfGroupByID(int ID)
        {
            List<Role> retList = new List<Role>();
            var query = (from Group in db.Group_Roles
                         join Rol in db.Roles on Group.RoleID equals Rol.ID
                         where Group.GroupID == ID
                         select new { Name = Rol.Name, ID = Rol.ID });
            foreach (var item in query)
            {
                Role pitem = new Role();
                pitem.ID = item.ID;
                pitem.Name = item.Name;
                retList.Add(pitem);
            }
            return retList.ToArray();

        }

        public User[] GetAllUserOfGroupByID(int ID)
        {
            List<User> retList = new List<User>();
            var query = (from Group in db.Group_Users
                         join user in db.Users on Group.UserID equals user.ID
                         where Group.GroupID == ID
                         select new { F_Name = user.Firstname, L_Name = user.Lastname, U_ID = user.ID });
            foreach (var item in query)
            {
                User pitem = new User();
                pitem.ID = item.U_ID;
                pitem.Firstname = item.F_Name;
                pitem.Lastname = item.L_Name;
                retList.Add(pitem);
            }
            return retList.ToArray();

        }

        public bool updatePGroupRole(int ID, Role[] RoleList)
        {
            try
            {
                List<Group_Roles> select = base.db.Group_Roles.Where(g => g.GroupID == ID).ToList();
                if(select.Count <= 0)
                {
                    foreach(Role item in RoleList)
                    {
                        Group_Roles addItem = new Group_Roles();
                        if(item.Checked == true)
                        {
                            addItem.GroupID = ID;
                            addItem.RoleID = item.ID;
                            select.Add(addItem);
                        }
                    }
                    base.db.Group_Roles.AddRange(select);
                    base.db.SaveChanges();
                }
                else
                {
                    foreach(Role item in RoleList)
                    {
                        Group_Roles addItem = new Group_Roles();
                        if (item.Checked == false && select.Where(g => g.RoleID == item.ID).Count() == 1)
                        {
                            base.db.Group_Roles.Remove(select.Where(g => g.RoleID == item.ID).FirstOrDefault());
                        }

                        if(item.Checked == true && select.Where(g => g.RoleID == item.ID).Count() == 0)
                        {
                            addItem.GroupID = ID;
                            addItem.RoleID = item.ID;
                            base.db.Group_Roles.Add(addItem);
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

        public bool updatePGroupUser(int ID, User[] UserList)
        {
            try
            {
                List<Group_Users> select = base.db.Group_Users.Where(g => g.GroupID == ID).ToList();
                if (select.Count <= 0)
                {
                    foreach (User item in UserList)
                    {
                        Group_Users addItem = new Group_Users();
                        if (item.Checked == true)
                        {
                            addItem.GroupID = ID;
                            addItem.UserID = item.ID;
                            select.Add(addItem);
                        }
                    }
                    base.db.Group_Users.AddRange(select);
                    base.db.SaveChanges();
                }
                else
                {
                    foreach (User item in UserList)
                    {
                        Group_Users addItem = new Group_Users();
                        if (item.Checked == false && select.Where(g => g.UserID == item.ID).Count() == 1)
                        {
                            base.db.Group_Users.Remove(select.Where(g => g.UserID == item.ID).FirstOrDefault());
                        }

                        if (item.Checked == true && select.Where(g => g.UserID == item.ID).Count() == 0)
                        {
                            addItem.GroupID = ID;
                            addItem.UserID = item.ID;
                            base.db.Group_Users.Add(addItem);
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
