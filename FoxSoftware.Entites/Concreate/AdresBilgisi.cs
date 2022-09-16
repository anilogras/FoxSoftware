using FoxSoftware.Ortak.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.Entites.Concreate
{
    public class AdresBilgisi : BaseClass
    {
        public string Adres { get; set; }
        public int? IlceId { get; set; }
        public int? IlId { get; set; }
        public virtual Ilce Ilce { get; set; }
        public virtual Il Il { get; set; }
    }
}
