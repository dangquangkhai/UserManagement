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


    }

}
