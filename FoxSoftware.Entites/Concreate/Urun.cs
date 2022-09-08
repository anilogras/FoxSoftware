using FoxSoftware.Ortak.Base;
using FoxSoftware.Ortak.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.Entites.Concreate
{
    public class Urun : BaseTanimClass , INotifyPropertyChanged
    {
        public Cinsiyet Cinsiyet { get; set; }
        public StokTipi StokTipi { get; set; }
        public SatisTipi SatisTipi { get; set; }

        public string Kodu { get; set; }
        public double? BirimFiyat { get; set; }
        public double? Maliyet { get; set; }
        public int? MarkaId { get; set; }
        public int BirimId { get; set; }
        public int? KokuTuruId { get; set; }
        public int? UrunTurId { get; set; }
        [ForeignKey("MarkaId")]
        public virtual Marka Marka { get; set; }

        [ForeignKey("BirimId")]
        public virtual Birim Birim { get; set; }

        [ForeignKey("KokuTuruId")]
        public virtual KokuTuru KokuTuru { get; set; }

        [ForeignKey("UrunTurId")]
        public virtual UrunTur UrunTur { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
