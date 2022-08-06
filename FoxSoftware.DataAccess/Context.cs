using FoxSoftware.Entites.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AdresBilgisi> Adresbilgileri { get; set; }



    }
}
