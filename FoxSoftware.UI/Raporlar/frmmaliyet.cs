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
    public partial class frmmaliyet : DevExpress.XtraEditors.XtraForm
    {
        public FoxSoftWareBusinessUOW _BusinesUOW;
        public frmmaliyet()
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
        private void frmmaliyet_Load(object sender, EventArgs e)
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
            string sorgu = "Select convert(varchar, shrkana.Tarih, 105) as 'Tarih', sum(shrkdetay.Miktar)*sum(shrkdetay.BirimFiyat) as 'Ciro',sum(urun.Maliyet) as 'Maliyet',(sum(shrkdetay.Miktar)*sum(shrkdetay.BirimFiyat))-sum(urun.Maliyet)as 'Kâr' from SatHrkAnas shrkana left join SatHrkDetays shrkdetay on shrkdetay.SatHrkAnaId = shrkana.Id left join Uruns urun on urun.Id = shrkdetay.UrunId " +
                "where shrkana.Silinmis=0 and shrkdetay.Silinmis=0 and shrkana.SatisTipi = " +
                 $"{satistipi.ToString()} and shrkana.Tarih between {ilkTarih} and {sonTarih}"+
                "group by shrkana.Tarih";
            var res = _BusinesUOW.SatHrkAnaRepository.GetSQLResult(sorgu);
            gridControl1.DataSource = res;
        }
    }
}
