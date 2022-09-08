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

namespace FoxSoftware.UI.Tanimlamalar
{
    public partial class FrmUrunTanim : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;

        private Urun _model;
        private DbContext _context;
        public FrmUrunTanim(ViewFormModel<Urun> ViewForm)
        {
            InitializeComponent();
            _model = ViewForm.CreateModel();
            _context = ViewForm.Context;
            _BusinesUOW = new FoxSoftWareBusinessUOW(_context);
            CbSatisTipi.EditValueChanged += CbSatisTipi_EditValueChanged;
            //CbSatisTipi.Validating += CbSatisTipi_Validating;
            //CbSatisTipi.Validated += CbSatisTipi_Validated;
            _model.StokTipi = StokTipi.Satis;

            if (_model.Id == 0)
            {
                _model.SatisTipi = SatisTipi.Kozmetik;
                _model.Cinsiyet = Cinsiyet.Erkek;
                _model.MarkaId = 2;
                CbSatisTipi.EditValue = 1;
                _model.UrunTurId = 2;
                _model.KokuTuruId = 2;
            }


            urunBindingSource.DataSource = _model;

            _model.PropertyChanged += _model_PropertyChanged;
        }

        private void CbSatisTipi_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;

            //throw new NotImplementedException();
        }

        private void CbSatisTipi_Validated(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SatisTipi")
            {
                SatisTipiKontrol();
            }
        }

        private void CbSatisTipi_EditValueChanged(object sender, EventArgs e)
        {
            var asasds = CbSatisTipi.EditValue;
            _model.SatisTipi = (SatisTipi)asasds;
            SatisTipiKontrol();
        }

        private void FrmUrunTanim_Load(object sender, EventArgs e)
        {

            btnKaydet.Click += BtnKaydet_Click;
            lookupMarka.Properties.DisplayMember = "Adi";
            lookupMarka.Properties.ValueMember = "Id";
            lookupMarka.Properties.DataSource = _BusinesUOW.MarkaRepository.GetAll().Select(x => new
            {
                Id = x.Id,
                Adi = x.Adi
            });
            lookupBirim.Properties.DisplayMember = "Adi";
            lookupBirim.Properties.ValueMember = "Id";
            lookupBirim.Properties.DataSource = _BusinesUOW.BirimRepository.GetAll().Select(x => new
            {
                Id = x.Id,
                Adi = x.Adi
            });
            lookupUrunTur.Properties.DisplayMember = "Adi";
            lookupUrunTur.Properties.ValueMember = "Id";
            lookupUrunTur.Properties.DataSource = _BusinesUOW.UrunTurRepository.GetAll().Select(x => new
            {
                Id = x.Id,
                Adi = x.Adi
            });
            lookupKokuTur.Properties.DisplayMember = "Adi";
            lookupKokuTur.Properties.ValueMember = "Id";
            lookupKokuTur.Properties.DataSource = _BusinesUOW.KokuTuruRepository.GetAll().Select(x => new
            {
                Id = x.Id,
                Adi = x.Adi
            });

            Dictionary<int, string> stokEnumData = Enum.GetValues(typeof(StokTipi))
              .Cast<StokTipi>().ToDictionary(x => (int)x, x => x.ToString());


            Dictionary<int, string> cinsiyetEnumData = Enum.GetValues(typeof(Cinsiyet))
              .Cast<Cinsiyet>().ToDictionary(x => (int)x, x => x.ToString());


            Dictionary<int, string> satisEnumData = Enum.GetValues(typeof(SatisTipi))
              .Cast<SatisTipi>().ToDictionary(x => (int)x, x => x.ToString());


            CbCinsiyet.Properties.Items.AddRange(Enum.GetValues(typeof(Cinsiyet)));
            CbSatisTipi.Properties.Items.AddRange(Enum.GetValues(typeof(SatisTipi)));

            SatisTipiKontrol();

        }
        public void SatisTipiKontrol()
        {
            if (_model.SatisTipi == SatisTipi.Parfum)//parfum
            {
                cinsiyetLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                markaLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                urunturuLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                kokuturuLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                birimfiyatLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                maliyetLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else if (_model.SatisTipi == SatisTipi.Kozmetik)//kozmetik
            {
                cinsiyetLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                markaLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                urunturuLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                kokuturuLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
        private void textMaliyet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void textBirimFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        public void KaydetMethod()
        {
            var res = UIHelper.KayitEkle();
            if (res == DialogResult.Yes)
            {
                int snc = _BusinesUOW.Complete();
                var r = UIHelper.MesajVer();
                this.DialogResult = DialogResult.OK;
                this.Close();
                //var save = _context.SaveChanges();
                //var r = UIHelper.MesajVer();
                //this.DialogResult = DialogResult.OK;
                //this.Close();
            }
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (_model.SatisTipi == SatisTipi.Parfum)//parfüm
            {
                if (textUrunKodu.Text == null || textUrunKodu.Text.Trim() == "" || textUrunAdi.Text == null || textUrunAdi.Text.Trim() == "" || textBirimFiyat.Text == null || textBirimFiyat.Text.Trim() == "" || textMaliyet.Text == null || textMaliyet.Text.Trim() == "" || lookupMarka.Text.Trim() == "" || lookupUrunTur.Text.Trim() == "" || lookupKokuTur.Text.Trim() == "" || lookupBirim.Text.Trim() == "")
                {
                    var res = UIHelper.MesajKayitEdemez();
                }
                else
                {
                    KaydetMethod();
                }


            }
            else if (_model.SatisTipi == SatisTipi.Kozmetik)//kozmetik
            {
                if (textBirimFiyat.Text == null || textBirimFiyat.Text.Trim() == "" || textMaliyet.Text == null || textMaliyet.Text.Trim() == "" || textUrunKodu.Text == null || textUrunKodu.Text.Trim() == "" || textUrunAdi.Text == null || textUrunAdi.Text.Trim() == "" || lookupBirim.Text.Trim() == "")
                {
                    var res = UIHelper.MesajKayitEdemez();
                }
                else
                {
                    KaydetMethod();
                }
            }
        }
    }
}
