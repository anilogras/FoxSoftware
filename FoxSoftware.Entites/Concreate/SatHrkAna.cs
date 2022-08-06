using FoxSoftware.Ortak.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.Entites.Concreate
{
    public class SatHrkAna : BaseClass
    {
        public int MusteriId { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan Saat { get; set; }
        public int MyProperty { get; set; }
        public string KargoTakipNo { get; set; }
        public virtual Musteri Musteri { get; set; }
        public KargoDurumu KargoDurumu { get; set; }
    }
}
