using FoxSoftware.Entites.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.DataAccess.Repositories
{
    public class SatHrkDetayRepository : GenericRepository<SatHrkDetay>
    {
        public SatHrkDetayRepository(DbContext context) : base(context)
        {

        }
    }
}
