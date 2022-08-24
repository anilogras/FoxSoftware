using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.Entites.Concreate;
using FoxSoftware.Ortak.Base;
using FoxSoftware.Ortak.Enums;
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
    public partial class FrmUrunTanim : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        public FrmUrunTanim()
        {
            InitializeComponent();
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Değişiklikler kaydedilsin mi?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Urun u = new Urun()
                {
                    UrunTipId = Convert.ToInt32(comboBoxEdit7.EditValue),
                    Kodu = textEdit5.Text,
                    Adi = textEdit1.Text,
                    BirimFiyat = Convert.ToDouble(textEdit2.Text),
                    Maliyet = Convert.ToDouble(textEdit3.Text),
                    BirimId = Convert.ToInt32(comboBoxEdit3.EditValue),
                    MarkaId = Convert.ToInt32(comboBoxEdit2.EditValue),
                    UrunTurId = Convert.ToInt32(comboBoxEdit4.EditValue),
                    KokuTuruId = Convert.ToInt32(comboBoxEdit5.EditValue),
                    Silinmis = false,
                    Cinsiyet = (Cinsiyet)comboBoxEdit1.SelectedIndex+1
                   //Cinsiyet=Convert.ToInt32(comboBoxEdit1.SelectedIndex)
                };
                _BusinesUOW.UrunRepository.Add(u);

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

        private void FrmUrunTanim_Load(object sender, EventArgs e)
        {
            comboBoxEdit7.Properties.DisplayMember = "Adi";
            comboBoxEdit7.Properties.ValueMember = "Id";
            comboBoxEdit7.Properties.DataSource = _BusinesUOW.urunTipRepository.GetAll().Select(x => new
            {
                x.Id,
                x.Adi
            });
            comboBoxEdit2.Properties.DisplayMember = "Adi";
            comboBoxEdit2.Properties.ValueMember = "Id";
            comboBoxEdit2.Properties.DataSource = _BusinesUOW.MarkaRepository.GetAll().Select(x => new
            {
                x.Id,
                x.Adi
            });
            comboBoxEdit3.Properties.DisplayMember = "Adi";
            comboBoxEdit3.Properties.ValueMember = "Id";
            comboBoxEdit3.Properties.DataSource = _BusinesUOW.BirimRepository.GetAll().Select(x => new
            {
                x.Id,
                x.Adi
            });
            comboBoxEdit4.Properties.DisplayMember = "Adi";
            comboBoxEdit4.Properties.ValueMember = "Id";
            comboBoxEdit4.Properties.DataSource = _BusinesUOW.UrunTurRepository.GetAll().Select(x => new
            {
                x.Id,
                x.Adi
            });
            comboBoxEdit5.Properties.DisplayMember = "Adi";
            comboBoxEdit5.Properties.ValueMember = "Id";
            comboBoxEdit5.Properties.DataSource = _BusinesUOW.KokuTuruRepository.GetAll().Select(x => new
            {
                x.Id,
                x.Adi
            });
            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit1.Properties.Items.AddRange(Enum.GetNames(typeof(Cinsiyet)));
            comboBoxEdit1.SelectedIndex = 0;
        }
    }
}
