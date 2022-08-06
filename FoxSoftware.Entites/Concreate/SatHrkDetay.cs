using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.Entites.Concreate
{
    public class SatHrkDetay : BaseClass
    {
        public int UrunId { get; set; }
        public int BirimId { get; set; }
        public int Sira { get; set; }
        public double Miktar { get; set; }
        public double BirimFiyat { get; set; }
        public double ToplamFiyat { get; set; }
        public virtual Urun Urun { get; set; }
        public virtual Birim Birim { get; set; }
    }
}
