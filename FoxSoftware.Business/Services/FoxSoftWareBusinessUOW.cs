using FoxSoftware.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.Business.Services
{
    public class FoxSoftWareBusinessUOW
    {
        private DbContext _context { get; set; }

        public FoxSoftWareBusinessUOW() : this(DataAccessHelper.NewContext)
        {

        }

        public FoxSoftWareBusinessUOW(DbContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }




    }
}
