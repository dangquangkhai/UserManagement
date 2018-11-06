using UserManagement.PERMISSON.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.PERMISSON.Provider
{
    public class BaseProvider
    {
        public RDBMDBContext db = null;
        public BaseProvider()
        {
            db = new RDBMDBContext();
        }
    }
}
