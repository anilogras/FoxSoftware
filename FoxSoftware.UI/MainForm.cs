using DevExpress.XtraBars.Ribbon;
using FoxSoftware.UI.Hareketler;
using FoxSoftware.UI.Raporlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxSoftware.UI
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        FrmSatisHrk frmsatis;
        stokhrkpredicate shrkpredicate;
        sathrkpredicate sathrkpredicate;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["sathrkpredicate"] == null)  // Form açık mı?
            {
                sathrkpredicate = new sathrkpredicate();
                sathrkpredicate.MdiParent = this;
                sathrkpredicate.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "sathrkpredicate").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["FrmStokPredicate"] == null)  // Form açık mı?
            {
                shrkpredicate = new stokhrkpredicate();
                shrkpredicate.MdiParent = this;
                shrkpredicate.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "FrmStokPredicate").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Application.OpenForms["FrmUrunPredicate"] == null)  // Form açık mı?
            {
                FrmUrunPredicate urunpre = new FrmUrunPredicate();
                urunpre.MdiParent = this;
                urunpre.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "FrmUrunPredicate").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["FrmKargoTakip"] == null)  // Form açık mı?
            {
                FrmKargoTakip frmkargo = new FrmKargoTakip();
                frmkargo.MdiParent = this;
                frmkargo.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "FrmKargoTakip").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["musteripredicate"] == null)  // Form açık mı?
            {
                musteripredicate musteripre = new musteripredicate();
                musteripre.MdiParent = this;
                musteripre.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "musteripredicate").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["firmapredicate"] == null)  // Form açık mı?
            {
                firmapredicate firmapre = new firmapredicate();
                firmapre.MdiParent = this;
                firmapre.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "firmapredicate").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["birimpredicate"] == null)  // Form açık mı?
            {
                birimpredicate birimpre = new birimpredicate();
                birimpre.MdiParent = this;
                birimpre.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "birimpredicate").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["markapredicate"] == null)  // Form açık mı?
            {
                markapredicate markapre = new markapredicate();
                markapre.MdiParent = this;
                markapre.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "markapredicate").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["kokuturpredicate"] == null)  // Form açık mı?
            {
                kokuturpredicate kokuturpre = new kokuturpredicate();
                kokuturpre.MdiParent = this;
                kokuturpre.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "kokuturpredicate").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["urunturpredicate"] == null)  // Form açık mı?
            {
                urunturpredicate urunturpre = new urunturpredicate();
                urunturpre.MdiParent = this;
                urunturpre.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "urunturpredicate").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }
        private void barButtonItem15_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["frmgirilensiparis"] == null)  // Form açık mı?
            {
                frmgirilensiparis girilensip = new frmgirilensiparis();
                girilensip.MdiParent = this;
                girilensip.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "frmgirilensiparis").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem16_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["frmstokalim"] == null)  // Form açık mı?
            {
                frmstokalim stokalim = new frmstokalim();
                stokalim.MdiParent = this;
                stokalim.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "frmstokalim").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem17_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["frmmaliyet"] == null)  // Form açık mı?
            {
                frmmaliyet maliyet = new frmmaliyet();
                maliyet.MdiParent = this;
                maliyet.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "frmmaliyet").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem13_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["frmpopulersehir"] == null)  // Form açık mı?
            {
                frmpopulersehir popsehir = new frmpopulersehir();
                popsehir.MdiParent = this;
                popsehir.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "frmpopulersehir").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem14_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["frmpopulerurun"] == null)  // Form açık mı?
            {
                frmpopulerurun popurun = new frmpopulerurun();
                popurun.MdiParent = this;
                popurun.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "frmpopulerurun").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }
        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Application.OpenForms["frmgrafikrapor"] == null)  // Form açık mı?
            {
                frmgrafikrapor grafikrapor = new frmgrafikrapor();
                grafikrapor.MdiParent = this;
                grafikrapor.Show();
                
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "frmgrafikrapor").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["frmstokpredicate"] == null)  // Form açık mı?
            {
                FrmStokPredicate frmstokpredicate = new FrmStokPredicate();
                frmstokpredicate.MdiParent = this;
                frmstokpredicate.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "frmstokpredicate").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["frmaylikmaliyet"] == null)  // Form açık mı?
            {
                frmaylikmaliyet frmaylik = new frmaylikmaliyet();
                frmaylik.MdiParent = this;
                frmaylik.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "frmaylikmaliyet").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (Application.OpenForms["frmyillikmaliyet"] == null)  // Form açık mı?
            {
                frmyillikmaliyet frmyillik = new frmyillikmaliyet();
                frmyillik.MdiParent = this;
                frmyillik.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "frmyillikmaliyet").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            barButtonItem23.PerformClick();
            barButtonItem29.PerformClick();
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Application.OpenForms["FrmFiyatGuncelle"] == null)  // Form açık mı?
            {
                FrmFiyatGuncelle frmupdate = new FrmFiyatGuncelle();
                frmupdate.MdiParent = this;
                frmupdate.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "FrmFiyatGuncelle").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Application.OpenForms["frmgrafikraporkozmetik"] == null)  // Form açık mı?
            {
                frmgrafikraporkozmetik frmupdate = new frmgrafikraporkozmetik();
                frmupdate.MdiParent = this;
                frmupdate.Show();
            }
            else
            {
                var activeList = this.MdiChildren.Where(x => x.Name == "frmgrafikraporkozmetik").FirstOrDefault();
                this.ActiveControl = activeList;
            }
        }

        private void btnTransferForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                TransferForm trform = new TransferForm();
                trform.Show();
        }
    }
}
