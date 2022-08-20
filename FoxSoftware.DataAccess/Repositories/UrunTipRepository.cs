using FoxSoftware.Entites.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.DataAccess.Repositories
{
    public class UrunTipRepository : GenericRepository<UrunTip>
    {
        public UrunTipRepository(Context context) : base(context)
        {

        }
    }
}
