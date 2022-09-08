using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
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
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxSoftware.UI.Raporlar
{
    public partial class kokuturpredicate : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        public kokuturpredicate()
        {
            InitializeComponent();
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
            gridView1.PopupMenuShowing += GridView1_PopupMenuShowing;
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
        public void FormModelGuncelle()
        {
            KokuTuru kokuturu = gridView1.GetRow(gridView1.FocusedRowHandle) as KokuTuru;

            ViewFormModel<KokuTuru> viewModel = new ViewFormModel<KokuTuru>();
            FoxSoftWareBusinessUOW guncelleUOW = new FoxSoftWareBusinessUOW();
            viewModel.Model = guncelleUOW.KokuTuruRepository.Get(x => x.Id == kokuturu.Id);
            viewModel.Context = guncelleUOW.GetContext();

            FrmKokuTurTanim btanim = new FrmKokuTurTanim(viewModel);

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
                KokuTuru birim = gridView1.GetRow(gridView1.FocusedRowHandle) as KokuTuru;
                KokuTuru br = _BusinesUOW.KokuTuruRepository.Get(x => x.Id == birim.Id);
                br.Silinmis = true;

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
            ViewFormModel<KokuTuru> model = new ViewFormModel<KokuTuru>();
            model.Context = _BusinesUOW.GetContext();
            FrmKokuTurTanim btanim2 = new FrmKokuTurTanim(model);
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
            gridControl1.DataSource = _BusinesUOW.KokuTuruRepository.GetAll();
        }
        private void kokuturpredicate_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            Yenile();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FormModelGuncelle();
        }
    }
}
