using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
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
    public partial class FrmStokHrk: DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        private DbContext _context;
        private StokHrkAna _StokHrkAna;
        public FrmStokHrk(ViewFormModel<StokHrkAna> ViewForm)
        {
            InitializeComponent();

            ModelKontrol(ViewForm);
            stokHrkAnaBindingSource.DataSource = _StokHrkAna;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            gridView1.InitNewRow += GridView1_InitNewRow;
            lkpMusteri.EditValueChanged += LkpMusteri_EditValueChanged;
            this.Shown += FrmSatisHrk_Shown;

            gridView1.ValidateRow += GridView1_ValidateRow;
            gridView1.InvalidRowException += GridView1_InvalidRowException;
        }

        private void GridView1_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            var ss = e;
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            e.WindowCaption = "Hata";
            MessageBox.Show(e.ErrorText);
        }

        private void GridView1_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            StokHrkDetay stokdet = e.Row as StokHrkDetay;

            if (stokdet.UrunId == 0)
            {
                e.Valid = false;
                e.ErrorText = "Urun Boş Geçilemez";
            }

            if (stokdet.Miktar == 0)
            {
                e.Valid = false;

                e.ErrorText = "Miktar Boş Geçilemez";
            }
            if (stokdet.BirimFiyat == 0)
            {
                e.Valid = false;

                e.ErrorText = "Birim Fiyat Boş Geçilemez";
            }
        }
        private void LkpMusteri_EditValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void ModelKontrol(ViewFormModel<StokHrkAna> ViewForm)
        {
            if (ViewForm.Model.Id != 0)
            {
                _BusinesUOW = new FoxSoftWareBusinessUOW(ViewForm.Context);
                _context = _BusinesUOW.GetContext();
                _StokHrkAna = ViewForm.Model;
            }
            else
            {
                _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
                _StokHrkAna = _BusinesUOW.StokHrkAnaRepository.CreateNewModel();
                _StokHrkAna.Tarih = System.DateTime.Now;
                _StokHrkAna.Saat = new TimeSpan(DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes, DateTime.Now.TimeOfDay.Seconds);
            }
        }

        private void GridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            var grdRow = (sender as GridView).GetFocusedRow() as StokHrkDetay;
            grdRow.Sira = (sender as GridView).RowCount + 1;
        }
        private void FrmSatisHrk_Shown(object sender, EventArgs e)
        {
            if (_StokHrkAna.Id == 0)
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
                StokHrkDetay satDetGridSira = gridView1.GetRow(gridView1.FocusedRowHandle) as StokHrkDetay;
                satDetGridSira.Silinmis = true;
                gridView1.DeleteSelectedRows();
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    (gridView1.GetRow(i) as StokHrkDetay).Sira = i + 1;
                }
            }
            else
            {

            }
        }

        private void RepositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //int secilenUrunId = Convert.ToInt32((sender as LookUpEdit).EditValue);
            //StokHrkDetay satDetGridSira = gridView1.GetRow(gridView1.FocusedRowHandle) as StokHrkDetay;
            //Urun gelenUrun = _BusinesUOW.UrunRepository.Get(x => x.Id == secilenUrunId);
            //satDetGridSira.BirimFiyat = Convert.ToDouble(gelenUrun.BirimFiyat);
        }

        private void KolonGizle(LookUpEdit lkpItem)
        {

            var ass = repositoryItemLookUpEdit1.Columns["Adi"];
            foreach (var item in lkpItem.Properties.Columns)
            {

            }
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            if (SatisTipiComboBoxEdit.EditValue == null || TarihDateEdit.EditValue == null || TarihDateEdit.Text.Trim() == "" || SaatTimeSpanEdit.EditValue == null || SaatTimeSpanEdit.Text.Trim() == "" || lkpMusteri.EditValue == null || lkpMusteri.Text.Trim() == "")
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

                int satistipi = Convert.ToInt32(SatisTipiComboBoxEdit.EditValue);
                repositoryItemLookUpEdit1.DisplayMember = "Adi";
                repositoryItemLookUpEdit1.ValueMember = "Id";
                repositoryItemLookUpEdit1.DataSource = _BusinesUOW.UrunRepository.GetAll().Where(x => ((int)x.SatisTipi) == satistipi && x.StokTipi == StokTipi.Stok).Select(x => new { x.Id, x.Adi, x.Kodu });
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
                _StokHrkAna = _BusinesUOW.StokHrkAnaRepository.CreateNewModel();
                _StokHrkAna.Tarih = System.DateTime.Now;
                _StokHrkAna.Saat = new TimeSpan(DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes, DateTime.Now.TimeOfDay.Seconds);
                _StokHrkAna.SatisTipi = SatisTipi.Parfum;
                stokHrkAnaBindingSource.DataSource = _StokHrkAna; //bindingden önce değişiklik yaptır companentlerde
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

        private void FrmStokHrk_Load(object sender, EventArgs e)
        {
            lkpMusteri.Properties.DisplayMember = "Adi";
            lkpMusteri.Properties.ValueMember = "Id";
            lkpMusteri.Properties.DataSource = _BusinesUOW.FirmaRepository.GetAll().Select(x => new { x.Id, x.Adi });
            //KolonGizle(lkpMusteri);

            gridView1.Columns["Sira"].OptionsColumn.ReadOnly = true;
            //gridView1.Columns["BirimFiyat"].OptionsColumn.ReadOnly = true;
            repositoryItemLookUpEdit1.EditValueChanged += RepositoryItemLookUpEdit1_EditValueChanged;
            repositoryItemButtonEdit1.Click += RepositoryItemButtonEdit1_Click;
            SaatTimeSpanEdit.Enabled = false;
            if (_StokHrkAna.Id == 0)
            {
                btnYeniKayit.Enabled = false;
                kaydet.Enabled = false;
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
                repositoryItemLookUpEdit1.DataSource = _BusinesUOW.UrunRepository.GetAll().Where(x => ((int)x.SatisTipi) == satistipi && x.StokTipi== StokTipi.Stok).Select(x => new { x.Id, x.Adi, x.Kodu});
                //SatHrkDetaylarGridControl.DataSource = _BusinesUOW.SatHrkDetayRepository.GetAll().Where(x => x.SatHrkAnaId == _StokHrkAna.Id);
            }
        }

        private void kaydet_Click_1(object sender, EventArgs e)
        {
             var res = UIHelper.KayitEkle();
            if (res == DialogResult.Yes)
            {
                foreach (var satir in _StokHrkAna.StokHrkDetaylar)
                {
                    satir.StokHrkAnaId = _StokHrkAna.Id;
                }

                if (_StokHrkAna.Id == 0)
                {
                    _BusinesUOW.StokHrkAnaRepository.Add(_StokHrkAna);
                }

                int snc = _BusinesUOW.Complete();
                var r = UIHelper.MesajVer();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
