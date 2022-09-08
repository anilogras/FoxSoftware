using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
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
    public partial class frmgirilensiparis : DevExpress.XtraEditors.XtraForm
    {
        public FoxSoftWareBusinessUOW _BusinesUOW;
        public frmgirilensiparis()
        {
            InitializeComponent();
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
            this.btnRapor.Click += BtnRapor_Click;
        }
        int satistipi = 0;
        private void BtnRapor_Click(object sender, EventArgs e)
        {
            string ilkTarih = UISqlHelper.DateFormatForSql1(Convert.ToDateTime(dateEdit1.EditValue));
            string sonTarih = UISqlHelper.DateFormatForSql2(Convert.ToDateTime(dateEdit2.EditValue));
            string sorgu = "select convert(varchar, shrkana.Tarih, 105) as 'Sipariş Tarih',shrkana.Id as 'Sipariş ID',urun.Kodu as" +
                " 'Ürün Kodu',urun.Adi as 'Ürün Adı',birim.Adi as 'Birim',case when urun.Cinsiyet = 1 then " +
                "'Erkek' when urun.Cinsiyet = 2 then 'Kadın' when urun.Cinsiyet = 3 then 'Unisex' end as " +
                "'Cinsiyet',marka.Adi as 'Marka',urunturu.Adi as 'Ürün Türü',sathrkdet.Miktar as " +
                "'Miktar',sathrkdet.BirimFiyat as 'Birim Fiyat',sathrkdet.BirimFiyat*sathrkdet.Miktar as " +
                "'Toplam Fiyat',urun.Maliyet as 'Maliyet',mus.Adi + ' '+ mus.Soyadi as 'Adı Soyadı',telefon.No as " +
                "'Telefon',mus.TCKN as 'T.C No',il.Adi as 'Şehir',ilce.Adi as 'İlçe',adres.Adres as 'Adres',email.MailAdres 'E-Mail' " +
                "from SatHrkAnas shrkana left join SatHrkDetays sathrkdet on sathrkdet.SatHrkAnaId = shrkana.Id left join Musteris" +
                " mus on mus.Id = shrkana.MusteriId left join Uruns urun on urun.Id = sathrkdet.UrunId left join Birims birim on urun.BirimId =" +
                " birim.Id left join AdresBilgisis adres on mus.AdresId = adres.Id left join Emails email on email.Id = mus.MailId left join Ils" +
                " il on il.Id = adres.IlId left join Ilces ilce on ilce.Id = adres.IlceId left join KokuTurus kokuturu on kokuturu.Id =" +
                " urun.KokuTuruId left join UrunTurs urunturu on urunturu.Id = urun.UrunTurId left join Markas marka on" +
                " marka.Id = urun.MarkaId left join TelefonNoes telefon on telefon.Id = mus.TelefonNoId where shrkana.Silinmis=0 and sathrkdet.Silinmis=0 and shrkana.SatisTipi=" +
                 $"{satistipi.ToString()} and shrkana.Tarih between {ilkTarih} and {sonTarih}";
            var res = _BusinesUOW.SatHrkAnaRepository.GetSQLResult(sorgu);
            gridControl1.DataSource = res;
        }
        private void frmgirilensiparis_Load(object sender, EventArgs e)
        {
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            comboBoxEdit1.SelectedIndex = 0;
            UISqlHelper.NowDateTime(dateEdit1, dateEdit2);
        }
        private void comboBoxEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedIndex==0)
            {
                satistipi = 1;
            }
            if (comboBoxEdit1.SelectedIndex==1)
            {
                satistipi = 2;
            }
        }
    }
}
