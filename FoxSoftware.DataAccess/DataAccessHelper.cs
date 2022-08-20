using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.DataAccess
{
    public static class DataAccessHelper
    {
        public static DbContext NewContext { get { return GetNewContext(); } }

        private static DbContext GetNewContext()
        {
            return new Context();
        }
    }
}
