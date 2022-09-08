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
    public partial class FrmStokTanim : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;

        private Urun _model;
        private DbContext _context;
        public FrmStokTanim(ViewFormModel<Urun> ViewForm)
        {
            InitializeComponent();
            _model = ViewForm.CreateModel();
            _context = ViewForm.Context;
            _BusinesUOW = new FoxSoftWareBusinessUOW(_context);
            cbSatisTipi.EditValueChanged += CbSatisTipi_EditValueChanged;
            _model.StokTipi = StokTipi.Stok;

            if (_model.Id == 0)
            {
                _model.SatisTipi = SatisTipi.Kozmetik;
                _model.Cinsiyet = Cinsiyet.Erkek;
                _model.MarkaId = 2;
                cbSatisTipi.EditValue = 1;
                _model.UrunTurId = 2;
                _model.KokuTuruId = 2;
            }


            urunBindingSource.DataSource = _model;

            _model.PropertyChanged += _model_PropertyChanged;
        }

        private void CbSatisTipi_EditValueChanged(object sender, EventArgs e)
        {
            var asasds = cbSatisTipi.EditValue;
            _model.SatisTipi = (SatisTipi)asasds;
            SatisTipiKontrol();
        }

        private void _model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SatisTipi")
            {
                SatisTipiKontrol();
            }
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
            cbSatisTipi.Properties.Items.AddRange(Enum.GetValues(typeof(SatisTipi)));

            SatisTipiKontrol();
        }
        private void textMaliyet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void textBirimFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
        public void SatisTipiKontrol()
        {
            if (_model.SatisTipi == SatisTipi.Parfum)//parfum
            {
                cinsiyetLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                markaLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                urunturuLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                kokuturuLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else if (_model.SatisTipi == SatisTipi.Kozmetik)//kozmetik
            {
                cinsiyetLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                markaLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                urunturuLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                kokuturuLayoutControl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
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
            }
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (_model.SatisTipi == SatisTipi.Parfum)//parfüm
            {
                if ( textUrunAdi.Text == null || textUrunAdi.Text.Trim() == "" || lookupMarka.Text.Trim() == ""  || lookupUrunTur.Text.Trim() == "" ||  lookupKokuTur.Text.Trim() == "" || lookupBirim.Text.Trim() == "")
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
                if (textUrunAdi.Text == null || textUrunAdi.Text.Trim() == "" || lookupBirim.Text.Trim()=="")
                {
                    var res = UIHelper.MesajKayitEdemez();
                }
                else
                {
                    KaydetMethod();
                }
            }
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {

        }
    }
}
