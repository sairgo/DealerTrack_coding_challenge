using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public static class GeneralFunctions
    {
        public static List<string> RetrieveColumnNamesOfClass(object oClass)
        {
            List<string> columnList = new List<string>();
            if (oClass != null)
            {
                foreach (var prop in oClass.GetType().GetProperties())
                {
                    columnList.Add(prop.Name);
                }
            }
            return columnList;
        }
    }
}
