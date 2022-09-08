using FoxSoftware.Ortak.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.Entites.Concreate
{
    public class Musteri : BaseClass
    {

        public Musteri()
        {
        }

        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TCKN { get; set; }

        public int TelefonNoId { get; set; }
        public virtual TelefonNo TelefonNo { get; set; }

        public int AdresId { get; set; }
        public virtual AdresBilgisi Adres { get; set; }

        public int MailId { get; set; }
        public virtual Email Mail { get; set; }


        [NotMapped]
        public string MusteriAdSoyad
        {
            get
            {
                return Adi + " " + Soyadi;
            }
        }

    }
}
