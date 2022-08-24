using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.DataAccess.Repositories;
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
    public partial class firmapredicate : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        public firmapredicate()
        {
            InitializeComponent();
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
        }
        public void yenile()
        {
            gridControl1.DataSource = _BusinesUOW.FirmaRepository.GetAll().Select(x => new
            {
                x.Id,
                x.Adi,
                x.Silinmis
            });
        }
        private void firmapredicate_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            yenile();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmFirmaTanim btanim = new FrmFirmaTanim();
            DialogResult result = btanim.ShowDialog();
            if (result == DialogResult.OK)
            {
                yenile();
            }
        }
    }
}
