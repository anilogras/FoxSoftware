using DevExpress.Utils.Menu;
using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.DataAccess.Repositories;
using FoxSoftware.Entites.Concreate;
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
    public partial class birimpredicate : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        public birimpredicate()
        {
            InitializeComponent();
            gridView1.PopupMenuShowing += GridView1_PopupMenuShowing;
            _BusinesUOW = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
        }

        private void GridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            //DXMenuItem menuItemDeleteRow = new DXMenuItem(deleteRowsCommandCaption, new EventHandler(OnDeleteRowClick), imageCollection1.Images[0]);
            DXMenuItem dXMenuItemGuncelle = new DXMenuItem();
            dXMenuItemGuncelle.Click += DXMenuItemGuncelle_Click;
            dXMenuItemGuncelle.Caption = "Güncelle";
            e.Menu.Items.Add(dXMenuItemGuncelle);
            DXMenuItem dXMenuItemSil = new DXMenuItem();
            dXMenuItemSil.Click += DXMenuItemSil_Click;
            dXMenuItemSil.Caption = "Sil";
            //dXMenuItemSil.ImageOptions.Image = 
            e.Menu.Items.Add(dXMenuItemSil);
        }

        private void DXMenuItemGuncelle_Click(object sender, EventArgs e)
        {

        }

        private void DXMenuItemSil_Click(object sender, EventArgs e)
        {
            var res = UIHelper.KayitSil();
            if (res == DialogResult.Yes)
            {
                Birim birim = gridView1.GetRow(gridView1.FocusedRowHandle) as Birim;
                Birim br = _BusinesUOW.BirimRepository.Get(x => x.Id == birim.Id);
                br.Silinmis = true;

                _BusinesUOW.Complete();
                var r = UIHelper.MesajVer();
                yenile();
            }
            else
            {

            }
        }

        public void yenile()
        {
            gridControl1.DataSource = _BusinesUOW.BirimRepository.GetAll().Where(x => x.Silinmis == false).Select(x => new Birim
            {
                Id = x.Id,
                Adi = x.Adi
            });
        }
        private void birimpredicate_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ColumnAutoWidth = false;
            yenile();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            FrmBirimTanim btanim = new FrmBirimTanim();
            DialogResult result = btanim.ShowDialog();
            if (result == DialogResult.OK)
            {
                yenile();
            }
        }
    }
}
