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
        }

        public string Adi { get; set; }
        public string Soyadi{ get; set; }
        public string TCKN { get; set; }

        public List<TelefonNo> TelefonNolari { get; set; }
        public List<AdresBilgisi> Adresler { get; set; }
    }
}
