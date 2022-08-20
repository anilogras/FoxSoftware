using FoxSoftware.Entites.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.DataAccess.Repositories
{
    public class BirimRepository : GenericRepository<Birim>
    {
        public BirimRepository(Context context) : base(context)
        {

        }

    }
}
