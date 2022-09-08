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
    public partial class FrmFirmaTanim : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        private Firma _model;
        private DbContext _context;
        public FrmFirmaTanim(ViewFormModel<Firma> ViewForm)
        {
            InitializeComponent();
            _model = ViewForm.CreateModel();
            _context = ViewForm.Context;
            _BusinesUOW = new FoxSoftWareBusinessUOW(_context);
            firmaBindingSource.DataSource = ViewForm.Model;
        }
        private void FrmFirmaTanim_Load(object sender, EventArgs e)
        {
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (AdiTextEdit.Text == null || AdiTextEdit.Text.Trim() == "")
            {
                var res = UIHelper.MesajKayitEdemez();
            }
            else
            {
                var res = UIHelper.KayitEkle();
                if (res == DialogResult.Yes)
                {
                    var save = _context.SaveChanges();
                    var r = UIHelper.MesajVer();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
