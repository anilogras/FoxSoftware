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
    public partial class FrmMusteriTanim : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        public FrmMusteriTanim()
        {
            InitializeComponent();
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Değişiklikler kaydedilsin mi?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {             
                Musteri mus = new Musteri()
                {
                    Adi = textEdit5.Text,
                    Soyadi = textEdit3.Text,
                    TCKN = textEdit4.Text,
                    //TelefonNolari=textEdit1.Text,
                    Silinmis = false,
                   
                };
                mus.Adresler.Add(new AdresBilgisi
                {
                    Adres=memoEdit1.Text,
                    IlId = Convert.ToInt32(comboBoxEdit4.EditValue),
                    IlceId = Convert.ToInt32(comboBoxEdit5.EditValue),
                });
                mus.Mailler.Add(new Email()
                {
                    MailAdres = textEdit2.Text
                });
                mus.TelefonNolari.Add(new TelefonNo()
                {
                    No = textEdit1.Text
                });
                _BusinesUOW.MusteriRepository.Add(mus);

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

        private void FrmMusteriTanim_Load(object sender, EventArgs e)
        {
            comboBoxEdit4.Properties.DisplayMember = "Adi";
            comboBoxEdit4.Properties.ValueMember = "Id";
            comboBoxEdit4.Properties.DataSource = _BusinesUOW.IlRepository.GetAll().Select(x => new
            {
                x.Id,
                x.Adi
            });
        }

        private void comboBoxEdit5_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEdit4_EditValueChanged(object sender, EventArgs e)
        {
            int IlId = Convert.ToInt32(comboBoxEdit4.EditValue);
            comboBoxEdit5.Properties.DisplayMember = "Adi";
            comboBoxEdit5.Properties.ValueMember = "Id";
            comboBoxEdit5.Properties.DataSource = _BusinesUOW.IlceRepository.GetAll(x => x.IlId == IlId).Select(x => new
            {
                x.Id,
                x.Adi
            });
        }
    }
}
