using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.Entites.Concreate;
using FoxSoftware.Ortak.Base;
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
    public partial class FrmMusteriTanim : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        private Musteri _model;
        private DbContext _context;

        public FrmMusteriTanim(ViewFormModel<Musteri> ViewForm)
        {
            InitializeComponent();
            _context = ViewForm.Context;
            _BusinesUOW = new FoxSoftWareBusinessUOW(_context);
            if (ViewForm.Model.Id == 0)
            {
                _model = _BusinesUOW.MusteriRepository.CreateNewModel();
            }
            else
            {
                _model = ViewForm.Model;

            }
            musteriBindingSource.DataSource = _model;
            this.btnKaydet.Click += BtnKaydet_Click;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmMusteriTanim_Load(object sender, EventArgs e)
        {
            AdresIlIdComboBoxEdit.EditValueChanged += IlAdiTextEdit_EditValueChanged;
            AdresIlIdComboBoxEdit.Properties.DisplayMember = "Adi";
            AdresIlIdComboBoxEdit.Properties.ValueMember = "Id";
            AdresIlIdComboBoxEdit.Properties.DataSource = _BusinesUOW.IlRepository.GetAll().Select(x => new
            {
                Id = x.Id,
                Adi = x.Adi
            });
            AdresIlceIlIdComboBoxEdit.Properties.DisplayMember = "Adi";
            AdresIlceIlIdComboBoxEdit.Properties.ValueMember = "Id";
            AdresIlceIlIdComboBoxEdit.Properties.DataSource = _BusinesUOW.IlceRepository.GetAll().Select(x => new
            {
                Id = x.Id,
                Adi = x.Adi
            });
            AdresIlIdComboBoxEdit.EditValue = 1;
            AdresIlceIlIdComboBoxEdit.EditValue = 1;
        }

        private void IlAdiTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            int ilId = Convert.ToInt32(AdresIlIdComboBoxEdit.EditValue);
            AdresIlceIlIdComboBoxEdit.Properties.DisplayMember= "Adi";
            AdresIlceIlIdComboBoxEdit.Properties.ValueMember = "Id";
            AdresIlceIlIdComboBoxEdit.Properties.DataSource = _BusinesUOW.IlceRepository.GetAll(x => x.IlId== ilId).Select(x => new
            {
                x.Id,
                x.Adi
            });
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            if (AdiTextEdit.Text == null || (AdiTextEdit.Text.Trim() == "") || SoyadiTextEdit.Text == null || (SoyadiTextEdit.Text.Trim() == "") || SoyadiTextEdit.Text == null || (SoyadiTextEdit.Text.Trim() == ""))
            {
                var res = UIHelper.MesajKayitEdemez();
            }
            else
            {
                var res = UIHelper.KayitEkle();
                if (res == DialogResult.Yes)
                {
                    _BusinesUOW.MusteriRepository.Add(_model);
                    _context.SaveChanges();
                    var r = UIHelper.MesajVer();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            var saveResult = _BusinesUOW.Complete();
        }
    }
}
