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
    }
}
