﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.Entites.Concreate
{
    public class AdresBilgisi : BaseClass
    {
        public string Adres { get; set; }
        
        public virtual Ilce IlceId { get; set; }
    }
}
