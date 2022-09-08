using DevExpress.XtraCharts;
using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxSoftware.UI.Raporlar
{
    public partial class frmgrafikrapor : DevExpress.XtraEditors.XtraForm
    {
        public FoxSoftWareBusinessUOW _BusinesUOW;
        public frmgrafikrapor()
        {
            InitializeComponent();
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
            this.btnRaporla.Click += BtnRaporla_Click;
            checkEdit1.CheckedChanged += CheckEdit1_CheckedChanged;
            this.btnYenile.Click += BtnYenile_Click;
            this.Load += Frmgrafikrapor_Load;
        }

        private void Frmgrafikrapor_Load(object sender, EventArgs e)
        {
            RaporTipi();
            btnYenile.PerformClick();
            UISqlHelper.NowDateTime(dateEdit1, dateEdit2);
        }
        private void BtnYenile_Click(object sender, EventArgs e)
        {
            DateTime dt_Ay_ilkGun = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // Ay ilk günü
            DateTime dt_Ay_sonGun = dt_Ay_ilkGun.AddMonths(1).AddDays(-1);// Ay son günü
            DateTime dt_Bugun = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime dt_Alti_Ay_Once = dt_Bugun.AddMonths(-6);
            DateTime dt_Bu_Yil = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime dt_Bu_Hafta_ilkGun = dt_Bugun.AddDays(-6);
            string str_Ay_ilkGun = UISqlHelper.DateFormatForSql1(dt_Ay_ilkGun);
            string str_Ay_sonGun = UISqlHelper.DateFormatForSql2(dt_Ay_sonGun);
            string str_Alti_Ay_Once = UISqlHelper.DateFormatForSql1(dt_Alti_Ay_Once);
            string str_Bugun = UISqlHelper.DateFormatForSql2(dt_Bugun);
            string str_Bu_Hafta_ilkGun = UISqlHelper.DateFormatForSql1(dt_Bu_Hafta_ilkGun);
            string str_BuYil = UISqlHelper.DateFormatForSql1(dt_Bu_Yil);
            string sqlBuAy = "select sum(sdet.BirimFiyat)*sum(sdet.Miktar) as 'Ciro',sum(urun.Maliyet)*sum(sdet.Miktar) as 'Maliyet',(sum(sdet.BirimFiyat)*sum(sdet.Miktar))-(sum(Maliyet)*sum(sdet.Miktar)) as 'Kâr' from SatHrkDetays sdet left join SatHrkAnas sana on sana.Id = sdet.SatHrkAnaId left join Uruns urun on urun.Id = sdet.UrunId where sdet.Silinmis=0 and sana.Silinmis=0 and sana.Tarih between " + str_Ay_ilkGun + " and " + str_Ay_sonGun;
            string sqlAltiAy = "select sum(sdet.BirimFiyat)*sum(sdet.Miktar) as 'Ciro',sum(urun.Maliyet)*sum(sdet.Miktar) as 'Maliyet',(sum(sdet.BirimFiyat)*sum(sdet.Miktar))-(sum(Maliyet)*sum(sdet.Miktar)) as 'Kâr' from SatHrkDetays sdet left join SatHrkAnas sana on sana.Id = sdet.SatHrkAnaId left join Uruns urun on urun.Id = sdet.UrunId where sdet.Silinmis=0 and sana.Silinmis=0 and sana.Tarih between " + str_Alti_Ay_Once + " and " + str_Bugun;
            string sqlBuYil = "select sum(sdet.BirimFiyat)*sum(sdet.Miktar) as 'Ciro',sum(urun.Maliyet)*sum(sdet.Miktar) as 'Maliyet',(sum(sdet.BirimFiyat)*sum(sdet.Miktar))-(sum(Maliyet)*sum(sdet.Miktar)) as 'Kâr' from SatHrkDetays sdet left join SatHrkAnas sana on sana.Id = sdet.SatHrkAnaId left join Uruns urun on urun.Id = sdet.UrunId where sdet.Silinmis=0 and sana.Silinmis=0 and sana.Tarih >="+str_BuYil;
            //string sqlBuHafta = "SET language turkish select case when datename(dw,convert(date,sana.Tarih)) like 'Pazartesi' then '1 ' +datename(dw,convert(date,sana.Tarih)) when datename(dw,convert(date,sana.Tarih)) like '%Sal%' then '2 '+datename(dw,convert(date,sana.Tarih)) when datename(dw,convert(date,sana.Tarih)) like '%Çar%' then '3 '+datename(dw,convert(date,sana.Tarih)) when datename(dw,convert(date,sana.Tarih)) like '%Per%' then '4 '+datename(dw,convert(date,sana.Tarih)) when datename(dw,convert(date,sana.Tarih)) like 'Cuma' then '5 '+datename(dw,convert(date,sana.Tarih)) when datename(dw,convert(date,sana.Tarih)) like 'Cumartesi' then '6 '+datename(dw,convert(date,sana.Tarih)) when datename(dw,convert(date,sana.Tarih)) like 'Pazar' then '7 '+datename(dw,convert(date,sana.Tarih)) end as 'Gun', sum(sdet.BirimFiyat)*sum(sdet.Miktar) as 'Ciro', sum(urun.Maliyet)*sum(sdet.Miktar) as 'Maliyet', (sum(sdet.BirimFiyat)*sum(sdet.Miktar))-(sum(Maliyet)*sum(sdet.Miktar)) as 'Kâr' from SatHrkDetays sdet left join SatHrkAnas sana on sana.Id = sdet.SatHrkAnaId left join Uruns urun on urun.Id = sdet.UrunId where sana.Tarih >= '2022-09-02' group by datename(dw,convert(date,sana.Tarih)) order by 'Gun'";
            string sqlBuHafta = "SET language turkish select case when datename(dw,convert(date,sana.Tarih)) like 'Pazartesi' then '1 ' +datename(dw,convert(date,sana.Tarih)) when datename(dw,convert(date,sana.Tarih)) like '%Sal%' then '2 '+datename(dw,convert(date,sana.Tarih)) when datename(dw,convert(date,sana.Tarih)) like '%Çar%' then '3 '+datename(dw,convert(date,sana.Tarih)) when datename(dw,convert(date,sana.Tarih)) like '%Per%' then '4 '+datename(dw,convert(date,sana.Tarih)) when datename(dw,convert(date,sana.Tarih)) like 'Cuma' then '5 '+datename(dw,convert(date,sana.Tarih)) when datename(dw,convert(date,sana.Tarih)) like 'Cumartesi' then '6 '+datename(dw,convert(date,sana.Tarih)) when datename(dw,convert(date,sana.Tarih)) like 'Pazar' then '7 '+datename(dw,convert(date,sana.Tarih)) end as 'Argument', sum(sdet.BirimFiyat)*sum(sdet.Miktar) as 'Value1', (sum(sdet.BirimFiyat)*sum(sdet.Miktar))-(sum(Maliyet)*sum(sdet.Miktar)) as 'Value2' from SatHrkDetays sdet left join SatHrkAnas sana on sana.Id = sdet.SatHrkAnaId left join Uruns urun on urun.Id = sdet.UrunId where sana.Tarih >= "+ str_Bu_Hafta_ilkGun + " group by datename(dw,convert(date,sana.Tarih)) order by 'Argument'";
            PieChartLoad(sqlCinsiyet,chartCinsiyet);
            PieChartLoad(sqlUrunTur, chartUrunTur);
            PieChartLoad(sqlKokutur, chartKokuTur);
            PieChartLoad(sqlSehir, chartSehir);
            CiroMaliyetKarChart(sqlBuAy,chartBuAy);
            CiroMaliyetKarChart(sqlAltiAy,charAltiAy);
            CiroMaliyetKarChart(sqlBuYil, chartBuYil);
            CiroMaliyetKarSutun(sqlBuHafta, chartHafta);
        }

        private void CheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            RaporTipi();
        }

        public void PieChartLoad(string sql,ChartControl chrtcont)
        {
            var res = _BusinesUOW.UrunRepository.GetSQLResult(sql);

            List<Chart1DataSource> dt = new List<Chart1DataSource>();

            foreach (DataRow item in res.Rows)
            {

                dt.Add(new Chart1DataSource
                {
                    Arguments = item.Field<string>("Argument").ToString(),
                    Value = Convert.ToInt32(item.Field<double>(1))
                });
            }

            chrtcont.Series.Clear();
            Series series1 = new Series("Chart", ViewType.Pie);

            chrtcont.DataSource = dt;

            series1.LegendTextPattern = "{A} {V} / {VP:p0}";
            series1.Label.TextPattern = "{VP:p0} {A} ({V})";
            series1.ArgumentDataMember = "Arguments";
            series1.ValueDataMembers.AddRange(new string[] { "Value" });


            chrtcont.Series.Add(series1);
        }
        public void CiroMaliyetKarChart(string sql,ChartControl chrtcont)
        {
            SqlConnection baglanti = new SqlConnection( Context._connectionString );
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sql,baglanti);
            SqlDataReader dr1 = komut.ExecuteReader();
            chrtcont.Series.Clear();
            Series series1 = new Series("Series 1", ViewType.Pie);
            chrtcont.Series.Add(series1);
            while (dr1.Read())
            {
                chrtcont.Series["Series 1"].ArgumentDataMember = "Ciro";
                chrtcont.Series["Series 1"].Points.AddPoint("Ciro", int.Parse(dr1[0].ToString()));
                chrtcont.Series["Series 1"].LegendTextPattern = "{A} {V} TL / {VP:p0}";
                chrtcont.Series["Series 1"].Label.TextPattern = "{VP:p0} {A} ({V})";
                chrtcont.Series["Series 1"].ArgumentDataMember = "Maliyet";
                chrtcont.Series["Series 1"].Points.AddPoint("Maliyet", int.Parse(dr1[1].ToString()));
                chrtcont.Series["Series 1"].ArgumentDataMember = "Kâr";
                chrtcont.Series["Series 1"].Points.AddPoint("Kâr", int.Parse(dr1[2].ToString()));
            }
            baglanti.Close();
        }
        public void CiroMaliyetKarSutun(string sql, ChartControl chrtcont)
        {
            var res = _BusinesUOW.UrunRepository.GetSQLResult(sql);

            List<Chart2DataSource> dt = new List<Chart2DataSource>();

            foreach (DataRow item in res.Rows)
            {

                dt.Add(new Chart2DataSource
                {
                    Arguments = item.Field<string>("Argument").ToString(),
                    Value1 = Convert.ToInt32(item.Field<double>(1)),
                    Value2 = Convert.ToInt32(item.Field<double>(2))
                });
            }

            chrtcont.Series.Clear();
            Series series1 = new Series("Ciro", ViewType.Bar);
            Series series2 = new Series("Kâr", ViewType.Bar);
            chrtcont.DataSource = dt;

            series1.LegendTextPattern = "Ciro";
            series1.Label.TextPattern = "{VP:p0} {A} ({V})";
            series1.ArgumentDataMember = "Arguments";
            series1.ValueDataMembers.AddRange(new string[] { "Value1"});
            series2.LegendTextPattern = "Kâr";
            series2.Label.TextPattern = "{VP:p0} {A} ({V})";
            series2.ArgumentDataMember = "Arguments";
            series2.ValueDataMembers.AddRange(new string[] { "Value2" });
            chrtcont.Series.Add(series1);
            chrtcont.Series.Add(series2);
        }
        string sqlUrunTur = "select uruntur.Adi as 'Argument',sum(shrkdet.miktar) as 'Value' from SatHrkDetays shrkdet left join SatHrkAnas shrkana on shrkana.Id=shrkdet.SatHrkAnaId left join Uruns urun on urun.Id = shrkdet.UrunId left join UrunTurs uruntur on uruntur.Id = urun.UrunTurId where shrkana.Silinmis= 0 and shrkdet.Silinmis=0 group by uruntur.Adi";
        string sqlCinsiyet = "select case when urun.Cinsiyet = 1 Then 'Erkek' when urun.Cinsiyet = 2 Then 'Kadın' when urun.Cinsiyet = 3 Then 'Unisex' end as 'Argument', sum(shrkdet.miktar) as 'Value' from SatHrkDetays shrkdet left join SatHrkAnas shrkana on shrkana.Id=shrkdet.SatHrkAnaId left join Uruns urun on urun.Id = shrkdet.UrunId where shrkana.Silinmis= 0 and shrkdet.Silinmis=0 group by urun.Cinsiyet";
        string sqlKokutur = "select kokutur.Adi as 'Argument',sum(shrkdet.miktar) as 'Value' from SatHrkDetays shrkdet left join SatHrkAnas shrkana on shrkana.Id=shrkdet.SatHrkAnaId left join Uruns urun on urun.Id = shrkdet.UrunId left join KokuTurus kokutur on kokutur.Id = urun.UrunTurId where shrkana.Silinmis= 0 and shrkdet.Silinmis=0 group by kokutur.Adi";
        string sqlSehir = "select il.Adi as 'Argument', sum(sdet.Miktar) as 'Value' from SatHrkDetays sdet left join SatHrkAnas sana on sana.Id=sdet.SatHrkAnaId left join Musteris mus on mus.Id=sana.MusteriId left join AdresBilgisis adres on adres.Id = mus.AdresId left join Ils il on il.Id =adres.IlId where sana.Silinmis=0 and sdet.Silinmis=0 group by il.Adi";
        private void BtnRaporla_Click(object sender, EventArgs e)
        {
            string ilkTarih = UISqlHelper.DateFormatForSql1(Convert.ToDateTime(dateEdit1.EditValue));
            string sonTarih = UISqlHelper.DateFormatForSql2(Convert.ToDateTime(dateEdit2.EditValue));
            string sqlCinsiyetKosul = "select case when urun.Cinsiyet = 1 Then 'Erkek' when urun.Cinsiyet = 2 Then 'Kadın' when urun.Cinsiyet = 3 Then 'Unisex' end as 'Argument', sum(shrkdet.miktar) as 'Value' from SatHrkDetays shrkdet left join SatHrkAnas shrkana on shrkana.Id=shrkdet.SatHrkAnaId left join Uruns urun on urun.Id = shrkdet.UrunId where shrkana.Silinmis= 0 and shrkdet.Silinmis=0 and shrkana.Tarih between " +ilkTarih +" and " +sonTarih+" group by urun.Cinsiyet";
            string sqlUrunTurKosul = "select uruntur.Adi as 'Argument',sum(shrkdet.miktar) as 'Value' from SatHrkDetays shrkdet left join SatHrkAnas shrkana on shrkana.Id=shrkdet.SatHrkAnaId left join Uruns urun on urun.Id = shrkdet.UrunId left join UrunTurs uruntur on uruntur.Id = urun.UrunTurId where shrkana.Silinmis= 0 and shrkdet.Silinmis=0 and shrkana.Tarih between " + ilkTarih + " and " + sonTarih + " group by uruntur.Adi";
            string sqlKokuTurKosul = "select kokutur.Adi as 'Argument',sum(shrkdet.miktar) as 'Value' from SatHrkDetays shrkdet left join SatHrkAnas shrkana on shrkana.Id=shrkdet.SatHrkAnaId left join Uruns urun on urun.Id = shrkdet.UrunId left join KokuTurus kokutur on kokutur.Id = urun.UrunTurId where shrkana.Silinmis= 0 and shrkdet.Silinmis=0 and shrkana.Tarih between " + ilkTarih + " and " + sonTarih + " group by kokutur.Adi";
            string sqlSehirKosul = "select il.Adi as 'Argument', sum(sdet.Miktar) as 'Value' from SatHrkDetays sdet left join SatHrkAnas sana on sana.Id=sdet.SatHrkAnaId left join Musteris mus on mus.Id=sana.MusteriId left join AdresBilgisis adres on adres.Id = mus.AdresId left join Ils il on il.Id =adres.IlId where sana.Silinmis= 0 and sdet.Silinmis=0 and sana.Tarih between " + ilkTarih + " and " + sonTarih + " group by il.Adi";
            PieChartLoad(sqlCinsiyetKosul,chartCinsiyet);
            PieChartLoad(sqlCinsiyetKosul, chartUrunTur);
            PieChartLoad(sqlKokuTurKosul,chartKokuTur);
            PieChartLoad(sqlSehirKosul, chartSehir);
        }
        public void RaporTipi()
        {
            if (checkEdit1.Checked==true)
            {
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;            
            }
            else
            {
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem7.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
        public class Chart1DataSource
        {
            public int Value { get; set; }
            public string Arguments { get; set; }
        }

        public class Chart2DataSource
        {

            public int Value1 { get; set; }
            public int Value2 { get; set; }
            public string Arguments { get; set; }
        }

    }
}
