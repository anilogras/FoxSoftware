using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.DataAccess.Repositories;
using FoxSoftware.UI.Hareketler;
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
    public partial class kokuturpredicate : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        public kokuturpredicate()
        {
            InitializeComponent();
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmKokuturTanim btanim = new FrmKokuturTanim();
            DialogResult result = btanim.ShowDialog();
            if (result == DialogResult.OK)
            {
                yenile();
            }
        }
        public void yenile()
        {
            gridControl1.DataSource = _BusinesUOW.KokuTuruRepository.GetAll().Select(x => new
            {
                x.Id,
                x.Adi,
                x.Silinmis
            });
        }
        private void kokuturpredicate_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            yenile();
        }
    }
}
