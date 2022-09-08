
namespace FoxSoftware.UI.Raporlar
{
    partial class FrmStokPredicate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FoxSoftware.UI.Raporlar.SplashScreen1), true, true);
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.urunBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCinsiyet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSatisTipi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUrunTipId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarkaId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirimId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKokuTuruId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUrunTurId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKokuTuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUrunTur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSilinmis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnYeniUrunTanim = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gridControl1);
            this.dataLayoutControl1.Controls.Add(this.btnYeniUrunTanim);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1060, 571);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.urunBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1036, 521);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // urunBindingSource
            // 
            this.urunBindingSource.DataSource = typeof(FoxSoftware.Entites.Concreate.Urun);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCinsiyet,
            this.colSatisTipi,
            this.colKodu,
            this.colUrunTipId,
            this.colMarkaId,
            this.colBirimId,
            this.colKokuTuruId,
            this.colUrunTurId,
            this.colMarka,
            this.colBirim,
            this.colKokuTuru,
            this.colUrunTur,
            this.colAdi,
            this.colId,
            this.colSilinmis});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colCinsiyet
            // 
            this.colCinsiyet.FieldName = "Cinsiyet";
            this.colCinsiyet.Name = "colCinsiyet";
            this.colCinsiyet.Visible = true;
            this.colCinsiyet.VisibleIndex = 4;
            // 
            // colSatisTipi
            // 
            this.colSatisTipi.FieldName = "SatisTipi";
            this.colSatisTipi.Name = "colSatisTipi";
            this.colSatisTipi.Visible = true;
            this.colSatisTipi.VisibleIndex = 1;
            // 
            // colKodu
            // 
            this.colKodu.FieldName = "Kodu";
            this.colKodu.Name = "colKodu";
            this.colKodu.Visible = true;
            this.colKodu.VisibleIndex = 2;
            // 
            // colUrunTipId
            // 
            this.colUrunTipId.FieldName = "UrunTipId";
            this.colUrunTipId.Name = "colUrunTipId";
            // 
            // colMarkaId
            // 
            this.colMarkaId.FieldName = "MarkaId";
            this.colMarkaId.Name = "colMarkaId";
            // 
            // colBirimId
            // 
            this.colBirimId.FieldName = "BirimId";
            this.colBirimId.Name = "colBirimId";
            // 
            // colKokuTuruId
            // 
            this.colKokuTuruId.FieldName = "KokuTuruId";
            this.colKokuTuruId.Name = "colKokuTuruId";
            // 
            // colUrunTurId
            // 
            this.colUrunTurId.FieldName = "UrunTurId";
            this.colUrunTurId.Name = "colUrunTurId";
            // 
            // colMarka
            // 
            this.colMarka.Caption = "Marka";
            this.colMarka.FieldName = "Marka.Adi";
            this.colMarka.Name = "colMarka";
            this.colMarka.Visible = true;
            this.colMarka.VisibleIndex = 5;
            // 
            // colBirim
            // 
            this.colBirim.Caption = "Birim";
            this.colBirim.FieldName = "Birim.Adi";
            this.colBirim.Name = "colBirim";
            this.colBirim.Visible = true;
            this.colBirim.VisibleIndex = 6;
            // 
            // colKokuTuru
            // 
            this.colKokuTuru.Caption = "Koku Türü";
            this.colKokuTuru.FieldName = "KokuTuru.Adi";
            this.colKokuTuru.Name = "colKokuTuru";
            this.colKokuTuru.Visible = true;
            this.colKokuTuru.VisibleIndex = 7;
            // 
            // colUrunTur
            // 
            this.colUrunTur.Caption = "Ürün Türü";
            this.colUrunTur.FieldName = "UrunTur.Adi";
            this.colUrunTur.Name = "colUrunTur";
            this.colUrunTur.Visible = true;
            this.colUrunTur.VisibleIndex = 8;
            // 
            // colAdi
            // 
            this.colAdi.Caption = "Adi";
            this.colAdi.FieldName = "Adi";
            this.colAdi.Name = "colAdi";
            this.colAdi.Visible = true;
            this.colAdi.VisibleIndex = 3;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colSilinmis
            // 
            this.colSilinmis.FieldName = "Silinmis";
            this.colSilinmis.Name = "colSilinmis";
            // 
            // btnYeniUrunTanim
            // 
            this.btnYeniUrunTanim.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnYeniUrunTanim.Appearance.Options.UseFont = true;
            this.btnYeniUrunTanim.Location = new System.Drawing.Point(12, 12);
            this.btnYeniUrunTanim.MaximumSize = new System.Drawing.Size(150, 22);
            this.btnYeniUrunTanim.Name = "btnYeniUrunTanim";
            this.btnYeniUrunTanim.Size = new System.Drawing.Size(147, 22);
            this.btnYeniUrunTanim.StyleController = this.dataLayoutControl1;
            this.btnYeniUrunTanim.TabIndex = 4;
            this.btnYeniUrunTanim.Text = "Yeni Stok Kodu Tanimla";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1060, 571);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnYeniUrunTanim;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(151, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(151, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(889, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1040, 525);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // FrmStokPredicate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 571);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "FrmStokPredicate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stok Kodu Listesi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.urunpredicate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnYeniUrunTanim;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.BindingSource urunBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCinsiyet;
        private DevExpress.XtraGrid.Columns.GridColumn colSatisTipi;
        private DevExpress.XtraGrid.Columns.GridColumn colKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colUrunTipId;
        private DevExpress.XtraGrid.Columns.GridColumn colMarkaId;
        private DevExpress.XtraGrid.Columns.GridColumn colBirimId;
        private DevExpress.XtraGrid.Columns.GridColumn colKokuTuruId;
        private DevExpress.XtraGrid.Columns.GridColumn colUrunTurId;
        private DevExpress.XtraGrid.Columns.GridColumn colMarka;
        private DevExpress.XtraGrid.Columns.GridColumn colBirim;
        private DevExpress.XtraGrid.Columns.GridColumn colKokuTuru;
        private DevExpress.XtraGrid.Columns.GridColumn colUrunTur;
        private DevExpress.XtraGrid.Columns.GridColumn colAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colSilinmis;
    }
}