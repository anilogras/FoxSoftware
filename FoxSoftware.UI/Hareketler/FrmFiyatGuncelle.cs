using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.Entites.Concreate;
using FoxSoftware.Ortak.Base;
using FoxSoftware.Ortak.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxSoftware.UI.Hareketler
{
    public partial class FrmFiyatGuncelle : DevExpress.XtraEditors.XtraForm
    {
        public FoxSoftWareBusinessUOW _BusinesUOW;
        int satistipi = 0;
        private List<Urun> filtreliUrunler;
        public FrmFiyatGuncelle()
        {
            InitializeComponent();
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
            btnGuncelle.Click += BtnGuncelle_Click;
            this.Load += FrmFiyatGuncelle_Load;
            cbUrunTipi.EditValueChanged += CbUrunTipi_EditValueChanged;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            double birimFiyat = Convert.ToDouble(txtBirimFiyat.EditValue);
            double birimMaliyet = Convert.ToDouble(txtMaliyet.EditValue);
            if (txtBirimFiyat.Text == null || txtBirimFiyat.Text.Trim() == "" || txtMaliyet.Text == null || txtMaliyet.Text.Trim() == "")
            {
                var res = UIHelper.MesajKayitEdemez();
            }
            else
            {
                var res = UIHelper.KayitGuncelle();
                if (res == DialogResult.Yes)
                {
                    if (filtreliUrunler.Count() != 0)
                    {

                        foreach (Urun urun in filtreliUrunler)
                        {
                            urun.BirimFiyat = birimFiyat;
                            urun.Maliyet = birimMaliyet;
                        }

                        int snc = _BusinesUOW.Complete();

                        if (snc > 0)
                        {
                            var r = UIHelper.MesajVer();
                        }
                        else
                        {
                            MessageBox.Show("Başarısız");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Fiyatı Değişecek Ürün Bulunamdı");
                    }
                }
            }            
            Yenile();
        }
        private void FrmFiyatGuncelle_Load(object sender, EventArgs e)
        {
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = false;
            cbUrunTipi.SelectedIndex = 0;
            cbKokuTuru.EditValue = 2;
            cbUrunTuru.EditValue = 2;
            cbUrunTuru.Properties.DisplayMember = "Adi";
            cbUrunTuru.Properties.ValueMember = "Id";
            cbUrunTuru.Properties.DataSource = _BusinesUOW.UrunTurRepository.GetAll().Select(x => new
            {
                Id = x.Id,
                Adi = x.Adi
            });
            cbKokuTuru.Properties.DisplayMember = "Adi";
            cbKokuTuru.Properties.ValueMember = "Id";
            cbKokuTuru.Properties.DataSource = _BusinesUOW.KokuTuruRepository.GetAll().Select(x => new
            {
                Id = x.Id,
                Adi = x.Adi
            });
            //Yenile();
        }
        public void Yenile()
        {
            int urunturu = Convert.ToInt32(cbUrunTuru.EditValue);
            int kokuturu = Convert.ToInt32(cbKokuTuru.EditValue); ;
            if (satistipi == 1)
            {
                gridView1.OptionsBehavior.Editable = false;
                _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
                filtreliUrunler = _BusinesUOW.UrunRepository.GetAll().Where(x => x.StokTipi == StokTipi.Satis && x.SatisTipi == SatisTipi.Parfum && x.UrunTurId == urunturu && x.KokuTuruId == kokuturu).ToList();
                gridControl1.DataSource = filtreliUrunler;
            }
            if (satistipi == 2)
            {
                gridView1.OptionsBehavior.Editable = false;
                _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
                filtreliUrunler = _BusinesUOW.UrunRepository.GetAll().Where(x => x.StokTipi == StokTipi.Satis && x.SatisTipi == SatisTipi.Kozmetik).ToList();
                gridControl1.DataSource = filtreliUrunler;
            }
        }
        private void CbUrunTipi_EditValueChanged(object sender, EventArgs e)
        {
            if (cbUrunTipi.SelectedIndex == 0)
            {
                satistipi = 1;
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            if (cbUrunTipi.SelectedIndex == 1)
            {
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                satistipi = 2;
            }
        }

        private void btnRaporla_Click(object sender, EventArgs e)
        {
            Yenile();
        }
    }
}
