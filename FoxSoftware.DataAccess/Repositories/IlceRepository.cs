using FoxSoftware.Entites.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.DataAccess.Repositories
{
    public class IlceRepository : GenericRepository<Ilce>
    {
        public IlceRepository(Context context) : base(context)
        {

        }
    }
}
