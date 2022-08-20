using FoxSoftware.Entites.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.DataAccess.Repositories
{
    public class SatHrkAnaRepository : GenericRepository<SatHrkAna>
    {
        public SatHrkAnaRepository(DbContext context) : base(context)
        {

        }
    }
}
