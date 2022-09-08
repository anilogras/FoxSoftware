using FoxSoftware.Entites.Concreate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.DataAccess.Repositories
{
    public class StokHrkAnaRepository : GenericRepository<StokHrkAna>
    {
        public StokHrkAnaRepository(DbContext context) : base(context)
        {


        }

        public StokHrkAna CreateNewModel()
        {
            StokHrkAna ana = new StokHrkAna();
            ana.StokHrkDetaylar = new BindingList<StokHrkDetay>();

            return ana;
        }
    }
}
