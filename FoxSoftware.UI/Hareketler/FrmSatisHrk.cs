using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.Entites.Concreate;
using FoxSoftware.Ortak.Base;
using FoxSoftware.Ortak.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxSoftware.UI.Hareketler
{
    public partial class FrmSatisHrk : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        private DbContext _context;
        private SatHrkAna _SatHrkAna;
        public FrmSatisHrk(ViewFormModel<SatHrkAna> ViewForm)
        {
            InitializeComponent();

            ModelKontrol(ViewForm);

            satHrkAnaBindingSource.DataSource = _SatHrkAna;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            gridView1.InitNewRow += GridView1_InitNewRow;
            this.Load += FrmSatisHrk_Load;
            this.Shown += FrmSatisHrk_Shown;
            this.kaydet.Click += Kaydet_Click;

            gridView1.ValidateRow += GridView1_ValidateRow;
            gridView1.InvalidRowException += GridView1_InvalidRowException;
        }

        private void GridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            var ss = e;
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            e.WindowCaption = "Hata";
            MessageBox.Show(e.ErrorText);
        }

        private void GridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            SatHrkDetay satDet = e.Row as SatHrkDetay;

            if (satDet.UrunId == 0)
            {
                e.Valid = false;
                e.ErrorText = "Urun Boş Geçilemez";
            }

            if (satDet.Miktar == 0)
            {
                e.Valid = false;

                e.ErrorText = "Miktar Boş Geçilemez";
            }
        }

        private void GridView1_InitNewRow1(object sender, InitNewRowEventArgs e)
        {

            //throw new NotImplementedException();
        }

        public void ModelKontrol(ViewFormModel<SatHrkAna> ViewForm)
        {
            if (ViewForm.Model.Id != 0)
            {
                _BusinesUOW = new FoxSoftWareBusinessUOW(ViewForm.Context);
                _context = _BusinesUOW.GetContext();
                _SatHrkAna = ViewForm.Model;
            }
            else
            {
                _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
                _SatHrkAna = _BusinesUOW.SatHrkAnaRepository.CreateNewModel();
                _SatHrkAna.Tarih = System.DateTime.Now;
                _SatHrkAna.Saat = new TimeSpan(DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes, DateTime.Now.TimeOfDay.Seconds);
            }
        }
        private void Kaydet_Click(object sender, EventArgs e)
        {
            var res = UIHelper.KayitEkle();
            if (res == DialogResult.Yes)
            {
                foreach (var satir in _SatHrkAna.SatHrkDetaylar)
                {
                    satir.SatHrkAnaId = _SatHrkAna.Id;
                }

                if (_SatHrkAna.Id == 0)
                {
                    _BusinesUOW.SatHrkAnaRepository.Add(_SatHrkAna);
                }

                int snc = _BusinesUOW.Complete();
                var r = UIHelper.MesajVer();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void GridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var grdRow = (sender as GridView).GetFocusedRow() as SatHrkDetay;
            grdRow.Sira = (sender as GridView).RowCount + 1;
        }

        private void FrmSatisHrk_Shown(object sender, EventArgs e)
        {
            if (_SatHrkAna.Id == 0)
            {
                lyGrid.Enabled = false;
            }
            else
            {
                lyGrid.Enabled = true;
            }
        }

        private void RepositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            var res = UIHelper.KayitSil();
            if (res == DialogResult.Yes)
            {
                //int secilenSatir = Convert.ToInt32((sender as GridView).GetSelectedRows);
                SatHrkDetay satDetGridSira = gridView1.GetRow(gridView1.FocusedRowHandle) as SatHrkDetay;
                satDetGridSira.Silinmis = true;
                gridView1.DeleteSelectedRows();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    (gridView1.GetRow(i) as SatHrkDetay).Sira = i + 1;
                }
            }
            else
            {

            }
        }

        private void RepositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            int secilenUrunId = Convert.ToInt32((sender as LookUpEdit).EditValue);
            SatHrkDetay satDetGridSira = gridView1.GetRow(gridView1.FocusedRowHandle) as SatHrkDetay;
            Urun gelenUrun = _BusinesUOW.UrunRepository.Get(x => x.Id == secilenUrunId);
            satDetGridSira.BirimFiyat = Convert.ToDouble(gelenUrun.BirimFiyat);
        }

        private void KolonGizle(LookUpEdit lkpItem)
        {

            var ass = repositoryItemLookUpEdit1.Columns["Adi"];
            foreach (var item in lkpItem.Properties.Columns)
            {

            }
        }
        private void FrmSatisHrk_Load(object sender, EventArgs e)
        {
            lkpMusteri.Properties.DisplayMember = "MusteriAdSoyad";
            lkpMusteri.Properties.ValueMember = "Id";
            lkpMusteri.Properties.DataSource = _BusinesUOW.MusteriRepository.GetAll().Select(x => new { x.Id, x.MusteriAdSoyad, x.TCKN, SehirAdi = x.Adres.Il.Adi, IlceAdi = x.Adres.Ilce.Adi, Telefon = x.TelefonNo.No, Adres = x.Adres.Adres });
            KolonGizle(lkpMusteri);

            if (checkEdit1.Checked == true)
            {
                ItemForKargoTakipNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                ItemForKargoTakipNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            gridView1.Columns["Sira"].OptionsColumn.ReadOnly = true;
            gridView1.Columns["BirimFiyat"].OptionsColumn.ReadOnly = true;
            repositoryItemLookUpEdit1.EditValueChanged += RepositoryItemLookUpEdit1_EditValueChanged;
            repositoryItemButtonEdit1.Click += RepositoryItemButtonEdit1_Click;
            SaatTimeSpanEdit.Enabled = false;
            if (_SatHrkAna.Id == 0)
            {
                btnYeniKayit.Enabled = false;
                kaydet.Enabled = false;
                checkEdit1.Checked = false;
                SatisTipiComboBoxEdit.SelectedIndex = 0;
                gridView1.OptionsView.ColumnAutoWidth = false;
            }
            else
            {
                kaydet.Enabled = true;
                btnBasla.Enabled = false;
                btnYeniKayit.Enabled = true;
                int satistipi = Convert.ToInt32(SatisTipiComboBoxEdit.EditValue);
                repositoryItemLookUpEdit1.DisplayMember = "Adi";
                repositoryItemLookUpEdit1.ValueMember = "Id";
                repositoryItemLookUpEdit1.DataSource = _BusinesUOW.UrunRepository.GetAll().Where(x => ((int)x.SatisTipi) == satistipi && x.StokTipi == StokTipi.Satis).Select(x => new { x.Id, x.Adi, x.Kodu });
                //SatHrkDetaylarGridControl.DataSource = _BusinesUOW.SatHrkDetayRepository.GetAll().Where(x => x.SatHrkAnaId == _SatHrkAna.Id);
            }
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            if (SatisTipiComboBoxEdit.EditValue == null || TarihDateEdit.EditValue == null || TarihDateEdit.Text.Trim() == "" || SaatTimeSpanEdit.EditValue == null || SaatTimeSpanEdit.Text.Trim() == "" || lkpMusteri.EditValue == null || lkpMusteri.Text.Trim() == "" || checkEdit1.Checked == true && KargoTakipNoTextEdit.Text.Trim() == "")
            {
                var res = UIHelper.MesajKayitEdemez();
            }
            else
            {
                gridView1.OptionsBehavior.Editable = true;
                //gridView1.Appearance.Row.BackColor = Color.Black;
                //gridView1.Appearance.Row.BackColor2 = Color.Black;
                //gridView1.Appearance.Row.BorderColor = Color.Black;
                //gridView1.Appearance.Row.ForeColor = Color.Black;
                btnBasla.Enabled = false;
                kaydet.Enabled = true;
                btnYeniKayit.Enabled = true;
                lyGrid.Enabled = true;
                ItemForSatisTipi.Enabled = false;
                ItemForTarih.Enabled = false;
                layoutControlItem2.Enabled = false;
                ItemForKargoTakipNo.Enabled = false;
                checkEditKargoVerildi.Enabled = false;

                int satistipi = Convert.ToInt32(SatisTipiComboBoxEdit.EditValue);
                repositoryItemLookUpEdit1.DisplayMember = "Adi";
                repositoryItemLookUpEdit1.ValueMember = "Id";
                repositoryItemLookUpEdit1.DataSource = _BusinesUOW.UrunRepository.GetAll().Where(x => ((int)x.SatisTipi) == satistipi && x.StokTipi == StokTipi.Satis).Select(x => new { x.Id, x.Adi, x.Kodu });
            }
        }

        private void checkEdit1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                ItemForKargoTakipNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                ItemForKargoTakipNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Yeni kayıt için ekran sıfırlanacaktır emin misiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {

                kaydet.Enabled = false;
                btnYeniKayit.Enabled = false;
                btnBasla.Enabled = true;
                gridView1.OptionsBehavior.Editable = false;
                lyGrid.Enabled = false;
                ItemForSatisTipi.Enabled = true;
                ItemForTarih.Enabled = true;
                layoutControlItem2.Enabled = true;
                ItemForKargoTakipNo.Enabled = true;
                checkEditKargoVerildi.Enabled = true;
                //gridView1.Appearance.Row.BackColor = Color.Silver;
                //gridView1.Appearance.Row.BackColor2 = Color.Silver;
                //gridView1.Appearance.Row.BorderColor = Color.Silver;
                //gridView1.Appearance.Row.ForeColor = Color.Silver;
                int rowCount = gridView1.RowCount;
                for (int i = 0; i < rowCount; i++)
                {
                    gridView1.DeleteRow(0);
                }
                gridView1.RefreshData();
                lyGrid.Enabled = false;
                _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
                _SatHrkAna = _BusinesUOW.SatHrkAnaRepository.CreateNewModel();
                _SatHrkAna.Tarih = System.DateTime.Now;
                _SatHrkAna.Saat = new TimeSpan(DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes, DateTime.Now.TimeOfDay.Seconds);
                _SatHrkAna.SatisTipi = SatisTipi.Parfum;
                _SatHrkAna.KargoDurumu = false;
                satHrkAnaBindingSource.DataSource = _SatHrkAna; //bindingden önce değişiklik yaptır companentlerde
                _context = _BusinesUOW.GetContext();
            }
            else
            {

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Satış ekranı kapatılacaktır emin misiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
