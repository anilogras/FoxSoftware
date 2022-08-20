using FoxSoftware.Entites.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSoftware.DataAccess
{
    public class Context : DbContext
    {
        public Context() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Stok_Takip;Integrated Security =true;")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AdresBilgisi> AdresBilgisi { get; set; }
        public DbSet<Birim> Birim{ get; set; }
        public DbSet<Email> Email{ get; set; }
        public DbSet<Firma> Firma { get; set; }
        public DbSet<Il> Il { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<KokuTuru> KokuTuru { get; set; }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<SatHrkAna> SatHrkAna { get; set; }
        public DbSet<SatHrkDetay> SatHrkDetay{ get; set; }
        public DbSet<StokHrkAna> StokHrkAna{ get; set; }
        public DbSet<StokHrkDetay> StokHrkDetay { get; set; }
        public DbSet<TelefonNo> TelefonNo { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<UrunTip> UrunTip{ get; set; }
        public DbSet<UrunTur> UrunTur{ get; set; }
    }
}
