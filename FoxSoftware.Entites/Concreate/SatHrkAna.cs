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
    public class SatHrkAna : BaseClass
    {
        public SatHrkAna()
        {
            SatHrkDetaylar = new BindingList<SatHrkDetay>();
        }
        public int MusteriId
        {
            get;
            set;
        }
        public DateTime Tarih
        {
            get;
            set;
        }
        public TimeSpan Saat
        {
            get;
            set;
        }
        public string KargoTakipNo
        {
            get;
            set;
        }
        public virtual Musteri Musteri { get; set; }
        public bool KargoDurumu { get; set; }
        public SatisTipi SatisTipi { get; set; }
        public System.ComponentModel.BindingList<SatHrkDetay> SatHrkDetaylar { get; set; }
    }
}
