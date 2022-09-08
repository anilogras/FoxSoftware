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
            sathrkpredicate = new sathrkpredicate();
            sathrkpredicate.MdiParent = this;
            if (Application.OpenForms["sathrkpredicate"] == null)  // Form açık mı?
            {
                sathrkpredicate.Show();
            }
            else
            {
                sathrkpredicate.Close();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                shrkpredicate = new stokhrkpredicate();
                shrkpredicate.MdiParent = this;
            if (Application.OpenForms["stokhrkpredicate"] == null)  // Form açık mı?
            {
                shrkpredicate.Show();
            }
            else
            {
                shrkpredicate.Close();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmUrunPredicate urunpre = new FrmUrunPredicate();
            urunpre.MdiParent = this;
            if (Application.OpenForms["urunpredicate"] == null)  // Form açık mı?
            {
                urunpre.Show();
            }
            else
            {
                urunpre.Close();
            }
            
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmKargoTakip frmkargo = new FrmKargoTakip();
            frmkargo.MdiParent = this;
            if (Application.OpenForms["FrmKargoTakip"] == null)  // Form açık mı?
            {
                frmkargo.Show();
            }
            else
            {
                frmkargo.Close();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            musteripredicate musteripre = new musteripredicate();
            musteripre.MdiParent = this;
            if (Application.OpenForms["musteripredicate"] == null)  // Form açık mı?
            {
                musteripre.Show();
            }
            else
            {
                musteripre.Close();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            firmapredicate firmapre = new firmapredicate();
            firmapre.MdiParent = this;
            if (Application.OpenForms["firmapredicate"] == null)  // Form açık mı?
            {
                firmapre.Show();
            }
            else
            {
                firmapre.Close();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            birimpredicate birimpre = new birimpredicate();
            birimpre.MdiParent = this;
            if (Application.OpenForms["birimpredicate"] == null)  // Form açık mı?
            {
                birimpre.Show();
            }
            else
            {
                birimpre.Close();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            markapredicate markapre = new markapredicate();
            markapre.MdiParent = this;
            if (Application.OpenForms["markapredicate"] == null)  // Form açık mı?
            {
                markapre.Show();
            }
            else
            {
                markapre.Close();
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            kokuturpredicate kokuturpre = new kokuturpredicate();
            kokuturpre.MdiParent = this;
            if (Application.OpenForms["kokuturpredicate"] == null)  // Form açık mı?
            {
                kokuturpre.Show();
            }
            else
            {
                kokuturpre.Close();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            urunturpredicate urunturpre = new urunturpredicate();
            urunturpre.MdiParent = this;
            if (Application.OpenForms["urunturpredicate"] == null)  // Form açık mı?
            {
                urunturpre.Show();
            }
            else
            {
                urunturpre.Close();
            }
        }
        private void barButtonItem15_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmgirilensiparis girilensip = new frmgirilensiparis();
            girilensip.MdiParent = this;
            if (Application.OpenForms["frmgirilensiparis"] == null)  // Form açık mı?
            {
                girilensip.Show();
            }
            else
            {
                girilensip.Close();
            }
        }

        private void barButtonItem16_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmstokalim stokalim = new frmstokalim();
            stokalim.MdiParent = this;
            if (Application.OpenForms["frmstokalim"] == null)  // Form açık mı?
            {
                stokalim.Show();
            }
            else
            {
                stokalim.Close();
            }
        }

        private void barButtonItem17_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmmaliyet maliyet = new frmmaliyet();
            maliyet.MdiParent = this;
            if (Application.OpenForms["frmmaliyet"] == null)  // Form açık mı?
            {
                maliyet.Show();
            }
            else
            {
                maliyet.Close();
            }
        }

        private void barButtonItem13_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmpopulersehir popsehir = new frmpopulersehir();
            popsehir.MdiParent = this;
            if (Application.OpenForms["frmpopulersehir"] == null)  // Form açık mı?
            {
                popsehir.Show();
            }
            else
            {
                popsehir.Close();
            }
        }

        private void barButtonItem14_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmpopulerurun popurun = new frmpopulerurun();
            popurun.MdiParent = this;
            if (Application.OpenForms["frmpopulerurun"] == null)  // Form açık mı?
            {
                popurun.Show();
            }
            else
            {
                popurun.Close();
            }
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmgrafikrapor grafikrapor = new frmgrafikrapor();
            grafikrapor.MdiParent = this;
            if (Application.OpenForms["frmgrafikrapor"] == null)  // Form açık mı?
            {
                grafikrapor.Show();
            }
            else
            {
                grafikrapor.Close();
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
            FrmStokPredicate frmstokpredicate = new FrmStokPredicate();
            frmstokpredicate.MdiParent = this;
            if (Application.OpenForms["frmstokpredicate"] == null)  // Form açık mı?
            {
                frmstokpredicate.Show();
            }
            else
            {
                frmstokpredicate.Close();
            }
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmaylikmaliyet frmaylik = new frmaylikmaliyet();
            frmaylik.MdiParent = this;
            if (Application.OpenForms["frmaylikmaliyet"] == null)  // Form açık mı?
            {
                frmaylik.Show();
            }
            else
            {
                frmaylik.Close();
            }
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmyillikmaliyet frmyillik = new frmyillikmaliyet();
            frmyillik.MdiParent = this;
            if (Application.OpenForms["frmyillikmaliyet"] == null)  // Form açık mı?
            {
                frmyillik.Show();
            }
            else
            {
                frmyillik.Close();
            }
        }
    }
}
