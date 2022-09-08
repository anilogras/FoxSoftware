using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
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

namespace FoxSoftware.UI.Hareketler
{
    public partial class FrmKargoTakip : DevExpress.XtraEditors.XtraForm
    {
        public FoxSoftWareBusinessUOW _BusinesUOW;
        public FrmKargoTakip()
        {
            InitializeComponent();
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
            comboBoxEdit1.EditValueChanged += ComboBoxEdit1_EditValueChanged;
            ceVerildi.CheckedChanged += CeVerildi_CheckedChanged;
        }
        private void CeVerildi_CheckedChanged(object sender, EventArgs e)
        {
            if (ceVerildi.Checked==true)
            {
                kargodurumu = 1;
            }
            else
            {
                kargodurumu = 0;
            }
        }

        private void ComboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedIndex == 0)
            {
                satistipi = 1;
            }
            if (comboBoxEdit1.SelectedIndex == 1)
            {
                satistipi = 2;
            }
        }

        int satistipi = 0;
        int kargodurumu = 0;
        private void FrmKargoTakip_Load(object sender, EventArgs e)
        {
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            comboBoxEdit1.SelectedIndex = 0;
            UISqlHelper.NowDateTime(dateEdit1, dateEdit2);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            string ilkTarih = UISqlHelper.DateFormatForSql1(Convert.ToDateTime(dateEdit1.EditValue));
            string sonTarih = UISqlHelper.DateFormatForSql2(Convert.ToDateTime(dateEdit2.EditValue));
            string sorgu = "select convert(varchar, shrkana.Tarih, 105) as 'Sipariş Tarihi',convert(varchar,shrkana.Saat,20) as 'Sipariş Saati',shrkana.Id as 'Sipariş ID',mus.Adi + mus.Soyadi as 'Adı Soyadı',telefon.No as 'Telefon',mus.TCKN as 'T.C',il.Adi as 'Şehir',ilce.Adi as 'İlçe',adres.Adres as 'Adres',email.MailAdres as 'E-Mail',case when shrkana.KargoDurumu = 0 then 'Verilmedi' when shrkana.KargoDurumu = 1 then 'Verildi' end as 'Kargo Verildi',shrkana.KargoTakipNo as 'Kargo Takip No' from SatHrkAnas shrkana left join Musteris mus on mus.Id = shrkana.MusteriId left join AdresBilgisis adres on adres.Id = mus.AdresId left join Ils il on il.Id=adres.IlId left join Ilces ilce on ilce.Id = adres.IlceId left join Emails email on email.Id = mus.MailId left join TelefonNoes telefon on telefon.Id = mus.TelefonNoId " +
                "where shrkana.Silinmis=0 and shrkana.SatisTipi =1 and shrkana.KargoDurumu= " + kargodurumu.ToString() + "and shrkana.SatisTipi=" + $"{satistipi.ToString()} and shrkana.Tarih between {ilkTarih} and {sonTarih}";
            var res = _BusinesUOW.SatHrkAnaRepository.GetSQLResult(sorgu);
            gridControl1.DataSource = res;
        }
    }
}
