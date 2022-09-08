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
    public partial class frmpopulersehir : DevExpress.XtraEditors.XtraForm
    {
        public FoxSoftWareBusinessUOW _BusinesUOW;
        public frmpopulersehir()
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
        private void frmpopulersehir_Load(object sender, EventArgs e)
        {
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            comboBoxEdit1.SelectedIndex = 0;
            UISqlHelper.NowDateTime(dateEdit1, dateEdit2);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string ilkTarih = UISqlHelper.DateFormatForSql1(Convert.ToDateTime(dateEdit1.EditValue));
            string sonTarih = UISqlHelper.DateFormatForSql2(Convert.ToDateTime(dateEdit2.EditValue));
            string sorgu = "Select sehir.Adi as 'Şehir',ilce.Adi as 'İlçe',sum(shrkdetay.Miktar) as 'Toplam Miktar',sum(shrkdetay.Miktar)*sum(shrkdetay.BirimFiyat) as 'Toplam Tutar'from SatHrkAnas shrkana left join SatHrkDetays shrkdetay on shrkdetay.SatHrkAnaId = shrkana.Id left join Musteris mus on mus.Id = shrkana.MusteriId left join AdresBilgisis adres on adres.Id = mus.AdresId left join Ils sehir on sehir.Id = adres.IlId left join Ilces ilce on ilce.Id = adres.IlceId " +
                "where shrkana.Silinmis=0 and shrkdetay.Silinmis=0 and shrkana.SatisTipi=" +
                 $"{satistipi.ToString()} and shrkana.Tarih between {ilkTarih} and {sonTarih}"+
                "group by sehir.Adi,ilce.Adi";
            var res = _BusinesUOW.SatHrkAnaRepository.GetSQLResult(sorgu);
            gridControl1.DataSource = res;
        }
    }
}
