using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.Entites.Concreate
{
    public class StokHrkAna : BaseClass
    {
        public int FirmaId { get; set; }
        public DateTime Tarih { get; set; }
        public virtual Firma Firma { get; set; }
    }
}
