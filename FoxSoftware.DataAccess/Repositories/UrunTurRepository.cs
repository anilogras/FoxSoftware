﻿using FoxSoftware.Entites.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.DataAccess.Repositories
{
    public class UrunTurRepository : GenericRepository<UrunTur>
    {
        public UrunTurRepository(Context context) : base(context)
        {

        }
    }
}
