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
    public partial class urunturpredicate : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        public urunturpredicate()
        {
            InitializeComponent();
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmUrunTurTanim btanim = new FrmUrunTurTanim();
            DialogResult result = btanim.ShowDialog();
            if (result == DialogResult.OK)
            {
                yenile();
            }
        }
        public void yenile()
        {
            gridControl1.DataSource = _BusinesUOW.UrunTurRepository.GetAll().Select(x => new
            {
                x.Id,
                x.Adi,
                x.Silinmis
            });
        }
        private void urunturpredicate_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            yenile();
        }
    }
}
