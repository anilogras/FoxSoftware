using FoxSoftware.Entites.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.DataAccess.Repositories
{
    public class MusteriRepository : GenericRepository<Musteri>
    {
        public MusteriRepository(DbContext context) : base(context)
        {

        }
        public Musteri CreateNewModel() 
        {
            Musteri musteri = new Musteri();
            musteri.Adres = new AdresBilgisi();
            musteri.Mail = new Email();
            musteri.TelefonNo = new TelefonNo();
            return musteri;
        }
    }
}
