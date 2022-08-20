using FoxSoftware.Entites.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.DataAccess.Repositories
{
    public class IlRepository : GenericRepository<Il>
    {
        public IlRepository(Context context) : base(context)
        {

        }
    }
}
