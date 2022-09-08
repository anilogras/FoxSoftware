using DevExpress.Utils.Menu;
using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.DataAccess.Repositories;
using FoxSoftware.Entites.Concreate;
using FoxSoftware.Ortak.Base;
using FoxSoftware.UI.Hareketler;
using FoxSoftware.UI.Tanimlamalar;
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
    public partial class urunturpredicate : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        public urunturpredicate()
        {
            InitializeComponent();
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
            gridView1.PopupMenuShowing += GridView1_PopupMenuShowing;
        }

        private void GridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
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
        public void FormModelGuncelle()
        {
            UrunTur uruntur = gridView1.GetRow(gridView1.FocusedRowHandle) as UrunTur;

            ViewFormModel<UrunTur> viewModel = new ViewFormModel<UrunTur>();
            FoxSoftWareBusinessUOW guncelleUOW = new FoxSoftWareBusinessUOW();
            viewModel.Model = guncelleUOW.UrunTurRepository.Get(x => x.Id == uruntur.Id);
            viewModel.Context = guncelleUOW.GetContext();

            FrmUrunTurTanim btanim = new FrmUrunTurTanim(viewModel);

            DialogResult result = btanim.ShowDialog();
            if (result == DialogResult.OK)
            {
                Yenile();
            }
        }
        private void DXMenuItemGuncelle_Click(object sender, EventArgs e)
        {
            FormModelGuncelle();
        }

        private void DXMenuItemSil_Click(object sender, EventArgs e)
        {
            var res = UIHelper.KayitSil();
            if (res == DialogResult.Yes)
            {
                UrunTur uruntur = gridView1.GetRow(gridView1.FocusedRowHandle) as UrunTur;
                UrunTur utr = _BusinesUOW.UrunTurRepository.Get(x => x.Id == uruntur.Id);
                utr.Silinmis = true;

                _BusinesUOW.Complete();
                var r = UIHelper.MesajVer();
                Yenile();
            }
            else
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ViewFormModel<UrunTur> model = new ViewFormModel<UrunTur>();
            model.Context = _BusinesUOW.GetContext();
            FrmUrunTurTanim btanim2 = new FrmUrunTurTanim(model);
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
            gridControl1.DataSource = _BusinesUOW.UrunTurRepository.GetAll();
        }
        private void urunturpredicate_Load(object sender, EventArgs e)
        {
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            Yenile();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FormModelGuncelle();
        }
    }
}
