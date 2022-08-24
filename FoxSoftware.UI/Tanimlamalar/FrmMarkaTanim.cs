using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.Entites.Concreate;
using FoxSoftware.Ortak.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxSoftware.UI.Tanimlamalar
{
    public partial class FrmMarkaTanim : DevExpress.XtraEditors.XtraForm
    {
        public FrmMarkaTanim()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Değişiklikler kaydedilsin mi?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                FoxSoftWareBusinessUOW _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);

                _BusinesUOW.MarkaRepository.Add(new Marka
                {
                    Adi = textEdit2.Text,
                    Silinmis = false
                });

                int saveRes = _BusinesUOW.Complete();

                if (saveRes > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {

            }
        }
    }
}
