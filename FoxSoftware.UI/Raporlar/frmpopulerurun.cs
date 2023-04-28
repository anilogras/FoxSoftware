using DevExpress.XtraGrid;
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
    public partial class frmpopulerurun : DevExpress.XtraEditors.XtraForm
    {
        public FoxSoftWareBusinessUOW _BusinesUOW;
        public frmpopulerurun()
        {
            InitializeComponent();
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
        private void frmpopulerurun_Load(object sender, EventArgs e)
        {
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            comboBoxEdit1.SelectedIndex = 0;
            UISqlHelper.NowDateTime(dateEdit1, dateEdit2);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GridColumnSummaryItem item1 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Toplam Tutar", "Top: {0}");
            GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Maliyet", "Top: {0}");
            GridColumnSummaryItem item3 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Kâr", "Top: {0}");
            if (gridView1.Columns.Count > 0)
            {
                gridView1.Columns["Toplam Tutar"].Summary.Clear();
                gridView1.Columns["Maliyet"].Summary.Clear();
                gridView1.Columns["Kâr"].Summary.Clear();
            }
            string ilkTarih = UISqlHelper.DateFormatForSql1(Convert.ToDateTime(dateEdit1.EditValue));
            string sonTarih = UISqlHelper.DateFormatForSql2(Convert.ToDateTime(dateEdit2.EditValue));
            string sorgu = "Select urun.Kodu as 'Ürün Kodu',urun.Adi as 'Ürün Adı',birim.Adi as 'Birim',case when urun.Cinsiyet =1 then 'Erkek' when urun.Cinsiyet =2 then 'Kadın' when urun.Cinsiyet =3 then 'Unisex' end as 'Cinsiyet',uruntur.Adi as 'Ürün Türü',kokutur.Adi as 'Koku Türü',sum(shrkdetay.Miktar) as 'Toplam Miktar',sum(shrkdetay.Miktar)*sum(shrkdetay.BirimFiyat) as 'Toplam Tutar',sum(urun.Maliyet) as 'Maliyet',(sum(shrkdetay.Miktar)*sum(shrkdetay.BirimFiyat))-sum(urun.Maliyet)as 'Kâr' from SatHrkAnas shrkana left join SatHrkDetays shrkdetay on shrkdetay.SatHrkAnaId = shrkana.Id left join Uruns urun on urun.Id = shrkdetay.UrunId left join Birims birim on birim.Id = urun.BirimId left join Markas marka on marka.Id = urun.MarkaId left join UrunTurs uruntur on uruntur.Id = urun.UrunTurId left join KokuTurus kokutur on kokutur.Id = urun.KokuTuruId " +
                "where shrkana.Silinmis=0 and shrkdetay.Silinmis=0 and shrkana.SatisTipi=" +
                 $"{satistipi.ToString()} and shrkana.Tarih between {ilkTarih} and {sonTarih}" +
                " group by urun.Kodu,urun.Adi,birim.adi,urun.Cinsiyet,uruntur.Adi,kokutur.Adi "+
                "order by sum(shrkdetay.Miktar) desc";
            var res = _BusinesUOW.SatHrkAnaRepository.GetSQLResult(sorgu);
            gridControl1.DataSource = res;
            gridView1.Columns["Toplam Tutar"].Summary.Add(item1);
            gridView1.Columns["Maliyet"].Summary.Add(item2);
            gridView1.Columns["Kâr"].Summary.Add(item3);
        }
    }
}
