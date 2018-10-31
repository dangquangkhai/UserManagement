using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.LIBRARY.RDBMModels;

namespace UserManagement.LIBRARY.RDBMProviders
{
    public class RDBMBaseProvider
    {
        public RDBMDBContext db = null;
        public RDBMBaseProvider()
        {
            db = new RDBMDBContext();
        }
    }
}
