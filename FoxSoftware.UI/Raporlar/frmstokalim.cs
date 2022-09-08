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
    public partial class frmstokalim : DevExpress.XtraEditors.XtraForm
    {
        public FoxSoftWareBusinessUOW _BusinesUOW;
        public frmstokalim()
        {
            InitializeComponent();
            simpleButton1.Click += SimpleButton1_Click;
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
            comboBoxEdit1.EditValueChanged += ComboBoxEdit1_EditValueChanged;
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
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            string ilkTarih = UISqlHelper.DateFormatForSql1(Convert.ToDateTime(dateEdit1.EditValue));
            string sonTarih = UISqlHelper.DateFormatForSql2(Convert.ToDateTime(dateEdit2.EditValue));
            string sorgu = "select convert(varchar, shrkana.Tarih, 105) as 'Sipariş Tarih',shrkana.Id as 'Sipariş ID',urun.Kodu as 'Ürün Kodu',urun.Adi as 'Ürün Adı',birim.Adi as 'Birim',case when urun.Cinsiyet = 1 then 'Erkek' when urun.Cinsiyet = 2 then 'Kadın' when urun.Cinsiyet = 3 then 'Unisex' end as 'Cinsiyet',marka.Adi as 'Marka',urunturu.Adi as 'Ürün Türü',stkhrkdet.Miktar as'Miktar',stkhrkdet.BirimFiyat as 'Birim Fiyat',stkhrkdet.BirimFiyat*stkhrkdet.Miktar as 'Toplam Fiyat',firma.Adi as 'Firma Adı' from StokHrkAnas shrkana left join StokHrkDetays stkhrkdet on stkhrkdet.StokHrkAnaId = shrkana.Id left join Firmas firma on firma.Id = shrkana.FirmaId left join Uruns urun on urun.Id = stkhrkdet.UrunId left join Birims birim on urun.BirimId =birim.Id left join KokuTurus kokuturu on kokuturu.Id =urun.KokuTuruId left join UrunTurs urunturu on urunturu.Id = urun.UrunTurId left join Markas marka on marka.Id = urun.MarkaId where shrkana.Silinmis=0 and stkhrkdet.Silinmis=0 and shrkana.SatisTipi=" + satistipi.ToString()+" and shrkana.Tarih >= "+ilkTarih + " and shrkana.Tarih <= "+sonTarih;
             var res = _BusinesUOW.SatHrkAnaRepository.GetSQLResult(sorgu);
            gridControl1.DataSource = res;
        }
        private void frmstokalim_Load(object sender, EventArgs e)
        {
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            comboBoxEdit1.SelectedIndex = 0;
            UISqlHelper.NowDateTime(dateEdit1, dateEdit2);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
