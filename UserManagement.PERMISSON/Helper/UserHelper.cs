using UserManagement.PERMISSON.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.PERMISSON.Helper
{
    public class UserHelper
    {
        public Permission[] AllPermissions { get; set; }
        public static bool HasPermission(Permission pms)
        {
            return true;
        }
        
    }
}
