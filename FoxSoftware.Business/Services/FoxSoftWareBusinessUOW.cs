using FoxSoftware.DataAccess;
using FoxSoftware.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxSoftware.Business.Services
{
    public class FoxSoftWareBusinessUOW
    {
        private DbContext _context { get; set; }

        public FoxSoftWareBusinessUOW() : this(DataAccessHelper.NewContext)
        {

        }

        public FoxSoftWareBusinessUOW(DbContext context)
        {
            _context = context;
            BirimRepository = new BirimRepository(_context);
            AdresBilgisiRepository = new AdresBilgisiRepository(_context);
            EMailRepository = new EMailRepository(_context);
            FirmaRepository = new FirmaRepository(_context);
            IlceRepository = new IlceRepository(_context);
            IlRepository = new IlRepository(_context);
            KokuTuruRepository = new KokuTuruRepository(_context);
            MarkaRepository = new MarkaRepository(_context);
            MusteriRepository = new MusteriRepository(_context);
            SatHrkAnaRepository = new SatHrkAnaRepository(_context);
            SatHrkDetayRepository = new SatHrkDetayRepository(_context);
            TelefonNoRepository = new TelefonNoRepository(_context);
            UrunRepository = new UrunRepository(_context);
            UrunTurRepository = new UrunTurRepository(_context);
            StokHrkAnaRepository = new StokHrkAnaRepository(_context);
            StokHrkDetayRepository = new StokHrkDetayRepository(_context);
            OdemeYontemiRepository = new OdemeYontemiRepository(_context);

        }
        public BirimRepository BirimRepository { get; set; }
        public OdemeYontemiRepository OdemeYontemiRepository { get; set; }
        public AdresBilgisiRepository AdresBilgisiRepository { get; set; }
        public EMailRepository EMailRepository { get; set; }
        public FirmaRepository FirmaRepository { get; set; }
        public IlceRepository IlceRepository { get; set; }
        public IlRepository IlRepository { get; set; }
        public KokuTuruRepository KokuTuruRepository { get; set; }
        public MarkaRepository MarkaRepository { get; set; }
        public MusteriRepository MusteriRepository { get; set; }
        public SatHrkAnaRepository SatHrkAnaRepository { get; set; }
        public SatHrkDetayRepository SatHrkDetayRepository { get; set; }
        public TelefonNoRepository TelefonNoRepository { get; set; }
        public UrunRepository UrunRepository { get; set; }
        public UrunTurRepository UrunTurRepository { get; set; }
        public StokHrkAnaRepository StokHrkAnaRepository { get; set; }
        public StokHrkDetayRepository StokHrkDetayRepository { get; set; }

        public DbContext GetContext()
        {
            return _context;
        }
        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt yapılırken hata oluştu lütfen ekranı kapatıp tekrar deneyiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
