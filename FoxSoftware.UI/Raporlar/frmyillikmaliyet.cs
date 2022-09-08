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
    public partial class frmyillikmaliyet : DevExpress.XtraEditors.XtraForm
    {
        public FoxSoftWareBusinessUOW _BusinesUOW;
        public frmyillikmaliyet()
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
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sorgu = "SET language turkish Select ss.tar as 'YIL',sum(shrkdetay.Miktar)*sum(shrkdetay.BirimFiyat) as 'Ciro',sum(urun.Maliyet) as 'Maliyet',(sum(shrkdetay.Miktar)*sum(shrkdetay.BirimFiyat))-sum(urun.Maliyet)as 'Kâr' from SatHrkAnas shrkana left join SatHrkDetays shrkdetay on shrkdetay.SatHrkAnaId = shrkana.Id left join Uruns urun on urun.Id = shrkdetay.UrunId left join (select SUBSTRING((convert(varchar, s.Tarih, 120)),1,4) as tar, s.id from SatHrkAnas s) as ss on ss.Id = shrkana.Id where shrkana.Silinmis=0 and shrkdetay.Silinmis=0 and shrkana.SatisTipi=" + satistipi.ToString()+" group by ss.tar";
            var res = _BusinesUOW.SatHrkAnaRepository.GetSQLResult(sorgu);
            gridControl1.DataSource = res;
        }
    }
}
