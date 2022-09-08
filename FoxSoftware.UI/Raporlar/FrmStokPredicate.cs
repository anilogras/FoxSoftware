using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.DataAccess.Repositories;
using FoxSoftware.Entites.Concreate;
using FoxSoftware.Ortak.Base;
using FoxSoftware.Ortak.Enums;
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
    public partial class FrmStokPredicate : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        public FrmStokPredicate()
        {
            InitializeComponent();
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);

            this.Load += Urunpredicate_Load;
        }

        private void Urunpredicate_Load(object sender, EventArgs e)
        {
            gridView1.PopupMenuShowing += GridView1_PopupMenuShowing;
            btnYeniUrunTanim.Click += BtnYeniUrunTanim_Click;
        }

        private void BtnYeniUrunTanim_Click(object sender, EventArgs e)
        {
            ViewFormModel<Urun> model = new ViewFormModel<Urun>();
            model.Context = _BusinesUOW.GetContext();
            FrmStokTanim btanim2 = new FrmStokTanim(model);
            DialogResult result = btanim2.ShowDialog();
            if (result == DialogResult.OK)
            {
                Yenile();
            }
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
        private void DXMenuItemGuncelle_Click(object sender, EventArgs e)
        {
            FormModelGuncelle();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FormModelGuncelle();
        }
        public void FormModelGuncelle()
        {
            Urun urun = gridView1.GetRow(gridView1.FocusedRowHandle) as Urun;

            ViewFormModel<Urun> viewModel = new ViewFormModel<Urun>();
            FoxSoftWareBusinessUOW guncelleUOW = new FoxSoftWareBusinessUOW();
            viewModel.Model = guncelleUOW.UrunRepository.Get(x => x.Id == urun.Id);
            viewModel.Context = guncelleUOW.GetContext();


            FrmStokTanim btanim = new FrmStokTanim(viewModel);

            DialogResult result = btanim.ShowDialog();
            if (result == DialogResult.OK)
            {
                Yenile();
            }
        }
        private void DXMenuItemSil_Click(object sender, EventArgs e)
        {
            var res = UIHelper.KayitSil();
            if (res == DialogResult.Yes)
            {
                Urun urun = gridView1.GetRow(gridView1.FocusedRowHandle) as Urun;
                Urun u = _BusinesUOW.UrunRepository.Get(x => x.Id == urun.Id);
                u.Silinmis = true;

                _BusinesUOW.Complete();
                var r = UIHelper.MesajVer();
                Yenile();
            }
        }

        public void Yenile()
        {
            gridView1.OptionsBehavior.Editable = false;
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
            gridControl1.DataSource = _BusinesUOW.UrunRepository.GetAll().Where(x=>x.StokTipi==StokTipi.Stok);
        }
        private void urunpredicate_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            Yenile();
        }


    }
}
