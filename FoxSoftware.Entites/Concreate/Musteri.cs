using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.Entites.Concreate
{
    public class Musteri : BaseClass
    {

        public Musteri()
        {
            TelefonNolari = new List<TelefonNo>();
            Adresler = new List<AdresBilgisi>();
            Mailler = new List<Email>();
        }

        public string Adi { get; set; }
        public string Soyadi{ get; set; }
        public string TCKN { get; set; }

         public virtual List<TelefonNo> TelefonNolari { get; set; }
         public virtual List<AdresBilgisi> Adresler { get; set; }
         public virtual List<Email> Mailler { get; set; }
    }
}
