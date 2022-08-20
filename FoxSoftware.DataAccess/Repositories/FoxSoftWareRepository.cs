using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.DataAccess.Repositories
{
    public class FoxSoftWareRepository
    {
        public FoxSoftWareRepository() : this(DataAccessHelper.NewContext)
        {

        }

        public FoxSoftWareRepository(DbContext context)
        {
            AdresBilgisiRepository = new AdresBilgisiRepository(context);
            BirimRepository = new BirimRepository(context);
            EMailRepository = new EMailRepository(context);
            FirmaRepository = new FirmaRepository(context);
            IlceRepository = new IlceRepository(context);
            IlRepository = new IlRepository(context);
            KokuTuruRepository = new KokuTuruRepository(context);
            MarkaRepository = new MarkaRepository(context);
            MusteriRepository = new MusteriRepository(context);
            satHrkAnaRepository = new SatHrkAnaRepository(context);
            satHrkDetayRepository = new SatHrkDetayRepository(context);
            stokHrkAnaRepository = new StokHrkAnaRepository(context);
            StokHrkDetayRepository = new StokHrkDetayRepository(context);
            TelefonNoRepository = new TelefonNoRepository(context);
            UrunRepository = new UrunRepository(context);
            UrunTipRepository = new UrunTipRepository(context);
            UrunTurRepository = new UrunTurRepository(context);
        }


        public AdresBilgisiRepository AdresBilgisiRepository { get; set; }
        public BirimRepository BirimRepository { get; set; }
        public EMailRepository EMailRepository { get; set; }
        public FirmaRepository FirmaRepository { get; set; }
        public IlceRepository IlceRepository { get; set; }
        public IlRepository IlRepository { get; set; }
        public KokuTuruRepository KokuTuruRepository { get; set; }
        public MarkaRepository MarkaRepository { get; set; }
        public MusteriRepository MusteriRepository { get; set; }
        public SatHrkAnaRepository satHrkAnaRepository { get; set; }
        public SatHrkDetayRepository satHrkDetayRepository { get; set; }
        public StokHrkAnaRepository stokHrkAnaRepository { get; set; }
        public StokHrkDetayRepository StokHrkDetayRepository { get; set; }
        public TelefonNoRepository TelefonNoRepository { get; set; }
        public UrunRepository UrunRepository { get; set; }
        public UrunTipRepository UrunTipRepository { get; set; }
        public UrunTurRepository UrunTurRepository { get; set; }


    }
}
