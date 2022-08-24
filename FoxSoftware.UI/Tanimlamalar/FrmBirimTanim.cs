using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.DataAccess.Repositories;
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
    public partial class FrmBirimTanim : DevExpress.XtraEditors.XtraForm
    {
        public FrmBirimTanim()
        {
            InitializeComponent();
        }

        private void FrmBirimTanim_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Değişiklikler kaydedilsin mi?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                FoxSoftWareBusinessUOW _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);

                _BusinesUOW.BirimRepository.Add(new Birim
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
        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
