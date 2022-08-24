using FoxSoftware.DataAccess;
using FoxSoftware.DataAccess.Repositories;
using FoxSoftware.UI.Hareketler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxSoftware.UI.Raporlar
{
    public partial class sathrkpredicate : DevExpress.XtraEditors.XtraForm
    {
        public sathrkpredicate()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmSatisHrk frmstok = new FrmSatisHrk();
            frmstok.Show();
        }
        public void yenile()
        {
            gridView1.OptionsBehavior.Editable = false;
            SatHrkAnaRepository brep = new SatHrkAnaRepository(DataAccessHelper.NewContext);
            //datastatic.dbContextYeni asya ile aynı mantık
            gridControl1.DataSource = brep.GetAll().Select(x => new {
                x.Id,
                x.Tarih,
                x.Saat,
                x.SatisTipi,
                x.Musteri,
                x.KargoDurumu,
                x.KargoTakipNo,
                x.Silinmis
            });
        }
        private void sathrkpredicate_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            yenile();
        }
    }
}
