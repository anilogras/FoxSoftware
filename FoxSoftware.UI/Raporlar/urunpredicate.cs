using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.DataAccess.Repositories;
using FoxSoftware.Entites.Concreate;
using FoxSoftware.UI.Hareketler;
using FoxSoftware.UI.Tanimlamalar;
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
    public partial class urunpredicate : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        public urunpredicate()
        {
            InitializeComponent();
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmUrunTanim frmstok = new FrmUrunTanim();
            DialogResult result = frmstok.ShowDialog();
            if (result == DialogResult.OK)
            {
                yenile();
            }
        }
        public void yenile()
        {
            gridView1.OptionsBehavior.Editable = false;
            gridControl1.DataSource = _BusinesUOW.UrunRepository.GetAll().Select(x => new
            {
                UrunID = x.Id,
                UrunTipi = x.UrunTip.Adi,
                UrunAdi = x.Adi,
                Birim = x.Birim.Adi,
                x.Cinsiyet,
                Marka= x.Marka.Adi,
                KokuTuru = x.KokuTuru.Adi,
                UrunTuru = x.UrunTur.Adi,
                x.BirimFiyat,
                x.Maliyet,
                x.Silinmis
            });
        }
        private void urunpredicate_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            yenile();
        }
    }
}
