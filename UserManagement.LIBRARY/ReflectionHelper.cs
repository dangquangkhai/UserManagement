using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.LIBRARY
{
    public class ReflectionHelper
    {
        public static object ModelToObject(object oModel)
        {
            if (oModel == null)
            {
                return null;
            }
            Dictionary<string, object> sData = new Dictionary<string, object>();
            object oReturn = new object();
            foreach (var prop in oModel.GetType().GetProperties())
            {
                if (!prop.GetGetMethod().IsVirtual)
                {
                    sData.Add(prop.Name, prop.GetValue(oModel, null));
                }                               
            }
            return sData;
        }

        public static object ModelToObject(object oModel, string[] PropertyName)
        {
            if (oModel == null)
            {
                return null;
            }
            Dictionary<string, object> sData = new Dictionary<string, object>();
            object oReturn = new object();
            foreach (var prop in oModel.GetType().GetProperties())
            {
                if (!prop.GetGetMethod().IsVirtual)
                {
                    if (PropertyName.Where(s=>s==prop.Name).Count()>0)
                    {
                        sData.Add(prop.Name, prop.GetValue(oModel, null));
                    }                    
                }
            }
            return sData;
        }

        public static object[] ArrayModelToArrObject(object[] oModel)
        {
            if (oModel==null)
            {
                return null;
            }
            List<object> objectlst = new List<object>();
            foreach (var item in oModel)
            {
                objectlst.Add(ModelToObject(item));
            }            
            return objectlst.ToArray();
        }

        public static object[] ArrayModelToArrObject(object[] oModel, string[] lstPropertyName)
        {
            if (oModel == null)
            {
                return null;
            }
            List<object> objectlst = new List<object>();
            foreach (var item in oModel)
            {
                objectlst.Add(ModelToObject(item, lstPropertyName));
            }
            return objectlst.ToArray();
        }
    }
}
