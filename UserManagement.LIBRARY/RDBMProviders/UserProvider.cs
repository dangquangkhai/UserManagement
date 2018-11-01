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
        public User[] getAllUser()
        {
            return base.db.Users.ToArray();
        }
    }
}
