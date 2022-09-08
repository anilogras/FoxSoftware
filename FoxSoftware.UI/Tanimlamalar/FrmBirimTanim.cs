using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.DataAccess.Repositories;
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
    public partial class FrmBirimTanim : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        private Birim _model;
        private DbContext _context;
        public FrmBirimTanim(ViewFormModel<Birim> ViewForm)
        {
            InitializeComponent();
            _model = ViewForm.CreateModel();
            _context = ViewForm.Context;
            _BusinesUOW = new FoxSoftWareBusinessUOW(_context);
            birimBindingSource.DataSource = ViewForm.Model;
        }

        private void FrmBirimTanim_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
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
