using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.DataAccess.Repositories;
using FoxSoftware.Entites.Concreate;
using FoxSoftware.Ortak.Base;
using FoxSoftware.UI.Hareketler;
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
    public partial class stokhrkpredicate : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        public stokhrkpredicate()
        {
            InitializeComponent();
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
            gridView1.PopupMenuShowing += GridView1_PopupMenuShowing;
            gridView1.DoubleClick += GridView1_DoubleClick;
        }

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            FormModelGuncelle();
        }

        private void GridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow && e.HitInfo.InRowCell)
            {
                DXMenuItem dXMenuItemGuncelle = new DXMenuItem();
                dXMenuItemGuncelle.Click += DXMenuItemGuncelle_Click;
                dXMenuItemGuncelle.Caption = "Güncelle";
                e.Menu.Items.Add(dXMenuItemGuncelle);

                DXMenuItem dXMenuItemSil = new DXMenuItem();
                dXMenuItemSil.Click += DXMenuItemSil_Click;
                dXMenuItemSil.Caption = "Sil";
                e.Menu.Items.Add(dXMenuItemSil);
            }
        }

        private void DXMenuItemSil_Click(object sender, EventArgs e)
        {
            var res = UIHelper.KayitSil();
            if (res == DialogResult.Yes)
            {
                StokHrkAna stokhrkana = gridView1.GetRow(gridView1.FocusedRowHandle) as StokHrkAna;
                StokHrkAna br = _BusinesUOW.StokHrkAnaRepository.Get(x => x.Id == stokhrkana.Id);
                List<StokHrkDetay> br1 = _BusinesUOW.StokHrkDetayRepository.GetAll(x => x.StokHrkAnaId == stokhrkana.Id);
                br.Silinmis = true;

                foreach (var item in br1)
                {
                    item.Silinmis = true;
                }
                //SatHrkDetay sathrkdetay = gridView1.GetRow(gridView1.FocusedRowHandle) as SatHrkDetay;
                //SatHrkDetay br1 = _BusinesUOW.SatHrkDetayRepository.Get(x => x.Id == sathrkdetay.Id);
                //br1.Silinmis = true;
                _BusinesUOW.Complete();
                var r = UIHelper.MesajVer();
                Yenile();
            }
            else
            {

            }
        }

        private void DXMenuItemGuncelle_Click(object sender, EventArgs e)
        {
            FormModelGuncelle();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ViewFormModel<StokHrkAna> model = new ViewFormModel<StokHrkAna>();
            model.Model = _BusinesUOW.StokHrkAnaRepository.CreateNewModel();
            model.Context = _BusinesUOW.GetContext();
            FrmStokHrk btanim2 = new FrmStokHrk(model);
            DialogResult result = btanim2.ShowDialog();
            if (result == DialogResult.OK)
            {
                Yenile();
            }
        }
        public void Yenile()
        {
            gridView1.OptionsBehavior.Editable = false;
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
            gridControl1.DataSource = _BusinesUOW.StokHrkAnaRepository.GetAll(null, new string[] { "StokHrkDetaylar" });
            gridControl1.RefreshDataSource();
        }
        public void FormModelGuncelle()
        {
            StokHrkAna stokhrkana = gridView1.GetRow(gridView1.FocusedRowHandle) as StokHrkAna;
            ViewFormModel<StokHrkAna> viewModel = new ViewFormModel<StokHrkAna>();
            FoxSoftWareBusinessUOW guncelleUOW = new FoxSoftWareBusinessUOW();
            viewModel.Model = guncelleUOW.StokHrkAnaRepository.Get(x => x.Id == stokhrkana.Id, new string[] { "StokHrkDetaylar" });
            viewModel.Context = guncelleUOW.GetContext();
            FrmStokHrk btanim = new FrmStokHrk(viewModel);
            DialogResult result = btanim.ShowDialog();
            if (result == DialogResult.OK)
            {
                Yenile();
            }
        }
        private void sathrkpredicate_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView2.OptionsBehavior.Editable = false;
            gridView2.OptionsView.ColumnAutoWidth = false;
            gridView2.OptionsView.ShowGroupPanel = false;
            Yenile();
        }
    }
}
