using FoxSoftware.Ortak.Base;
using FoxSoftware.Ortak.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.Entites.Concreate
{
    public class StokHrkAna : BaseClass
    {
        public StokHrkAna()
        {
            StokHrkDetaylar = new BindingList<StokHrkDetay>();
        }
        public int FirmaId { get; set; }
        public DateTime Tarih { get; set; }
        public virtual Firma Firma { get; set; }
        public SatisTipi SatisTipi { get; set; }
        public TimeSpan Saat { get; set; }
        public System.ComponentModel.BindingList<StokHrkDetay> StokHrkDetaylar { get; set; }
    }
}
