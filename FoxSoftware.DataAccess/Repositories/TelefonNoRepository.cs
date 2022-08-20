using FoxSoftware.Entites.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.DataAccess.Repositories
{
    public class TelefonNoRepository : GenericRepository<TelefonNo>
    {
        public TelefonNoRepository(DbContext context) : base(context)
        {

        }
    }
}
