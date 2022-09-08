using FoxSoftware.Ortak.Base;
using FoxSoftware.Ortak.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.Entites.Concreate
{
    public class StokHrkDetay : BaseClass
    {
        public int StokHrkAnaId
        {
            get;
            set;
        }
        public int UrunId { get; set; }
        public int Sira { get; set; }
        public double Miktar { get; set; }
        public double BirimFiyat { get; set; }
        [NotMapped]
        public double ToplamFiyat
        {
            get
            {
                return BirimFiyat * Miktar;
            }
        }
        public virtual Urun Urun { get; set; }

        public SatisTipi SatisTipi { get; set; }
        public virtual StokHrkAna StokHrkAna { get; set; }

    }
}
