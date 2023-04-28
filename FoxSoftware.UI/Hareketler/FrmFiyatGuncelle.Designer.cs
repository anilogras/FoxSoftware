
namespace FoxSoftware.UI.Hareketler
{
    partial class FrmFiyatGuncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFiyatGuncelle));
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.urunBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCinsiyet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarka = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKokuTuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUrunTur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirimFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaliyet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSatisTipi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.cbUrunTipi = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtBirimFiyat = new DevExpress.XtraEditors.TextEdit();
            this.txtMaliyet = new DevExpress.XtraEditors.TextEdit();
            this.cbKokuTuru = new DevExpress.XtraEditors.LookUpEdit();
            this.cbUrunTuru = new DevExpress.XtraEditors.LookUpEdit();
            this.btnRaporla = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUrunTipi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirimFiyat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaliyet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKokuTuru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUrunTuru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gridControl1);
            this.dataLayoutControl1.Controls.Add(this.btnGuncelle);
            this.dataLayoutControl1.Controls.Add(this.cbUrunTipi);
            this.dataLayoutControl1.Controls.Add(this.txtBirimFiyat);
            this.dataLayoutControl1.Controls.Add(this.txtMaliyet);
            this.dataLayoutControl1.Controls.Add(this.cbKokuTuru);
            this.dataLayoutControl1.Controls.Add(this.cbUrunTuru);
            this.dataLayoutControl1.Controls.Add(this.btnRaporla);
            this.dataLayoutControl1.DataSource = this.urunBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(977, 593);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.urunBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 60);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(953, 521);
            this.gridControl1.TabIndex = 14;
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
            this.colId,
            this.colAdi,
            this.colKodu,
            this.colCinsiyet,
            this.colBirim,
            this.colMarka,
            this.colKokuTuru,
            this.colUrunTur,
            this.colBirimFiyat,
            this.colMaliyet,
            this.colSatisTipi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colAdi
            // 
            this.colAdi.FieldName = "Adi";
            this.colAdi.Name = "colAdi";
            this.colAdi.Visible = true;
            this.colAdi.VisibleIndex = 2;
            // 
            // colKodu
            // 
            this.colKodu.FieldName = "Kodu";
            this.colKodu.Name = "colKodu";
            this.colKodu.Visible = true;
            this.colKodu.VisibleIndex = 3;
            // 
            // colCinsiyet
            // 
            this.colCinsiyet.FieldName = "Cinsiyet";
            this.colCinsiyet.Name = "colCinsiyet";
            this.colCinsiyet.Visible = true;
            this.colCinsiyet.VisibleIndex = 4;
            // 
            // colBirim
            // 
            this.colBirim.FieldName = "Birim.Adi";
            this.colBirim.Name = "colBirim";
            this.colBirim.Visible = true;
            this.colBirim.VisibleIndex = 5;
            // 
            // colMarka
            // 
            this.colMarka.FieldName = "Marka.Adi";
            this.colMarka.Name = "colMarka";
            this.colMarka.Visible = true;
            this.colMarka.VisibleIndex = 6;
            // 
            // colKokuTuru
            // 
            this.colKokuTuru.FieldName = "KokuTuru.Adi";
            this.colKokuTuru.Name = "colKokuTuru";
            this.colKokuTuru.Visible = true;
            this.colKokuTuru.VisibleIndex = 7;
            // 
            // colUrunTur
            // 
            this.colUrunTur.FieldName = "UrunTur.Adi";
            this.colUrunTur.Name = "colUrunTur";
            this.colUrunTur.Visible = true;
            this.colUrunTur.VisibleIndex = 8;
            // 
            // colBirimFiyat
            // 
            this.colBirimFiyat.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.colBirimFiyat.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.colBirimFiyat.AppearanceCell.Options.UseFont = true;
            this.colBirimFiyat.AppearanceCell.Options.UseForeColor = true;
            this.colBirimFiyat.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.colBirimFiyat.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colBirimFiyat.AppearanceHeader.Options.UseFont = true;
            this.colBirimFiyat.AppearanceHeader.Options.UseForeColor = true;
            this.colBirimFiyat.FieldName = "BirimFiyat";
            this.colBirimFiyat.Name = "colBirimFiyat";
            this.colBirimFiyat.Visible = true;
            this.colBirimFiyat.VisibleIndex = 9;
            // 
            // colMaliyet
            // 
            this.colMaliyet.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.colMaliyet.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.colMaliyet.AppearanceCell.Options.UseFont = true;
            this.colMaliyet.AppearanceCell.Options.UseForeColor = true;
            this.colMaliyet.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.colMaliyet.AppearanceHeader.ForeColor = System.Drawing.Color.Black;
            this.colMaliyet.AppearanceHeader.Options.UseFont = true;
            this.colMaliyet.AppearanceHeader.Options.UseForeColor = true;
            this.colMaliyet.FieldName = "Maliyet";
            this.colMaliyet.Name = "colMaliyet";
            this.colMaliyet.Visible = true;
            this.colMaliyet.VisibleIndex = 10;
            // 
            // colSatisTipi
            // 
            this.colSatisTipi.FieldName = "SatisTipi";
            this.colSatisTipi.Name = "colSatisTipi";
            this.colSatisTipi.Visible = true;
            this.colSatisTipi.VisibleIndex = 1;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Appearance.Options.UseFont = true;
            this.btnGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuncelle.ImageOptions.Image")));
            this.btnGuncelle.Location = new System.Drawing.Point(684, 12);
            this.btnGuncelle.MaximumSize = new System.Drawing.Size(167, 44);
            this.btnGuncelle.MinimumSize = new System.Drawing.Size(167, 44);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(167, 44);
            this.btnGuncelle.StyleController = this.dataLayoutControl1;
            this.btnGuncelle.TabIndex = 13;
            this.btnGuncelle.Text = "Güncelle";
            // 
            // cbUrunTipi
            // 
            this.cbUrunTipi.Location = new System.Drawing.Point(75, 12);
            this.cbUrunTipi.MaximumSize = new System.Drawing.Size(100, 0);
            this.cbUrunTipi.MinimumSize = new System.Drawing.Size(100, 0);
            this.cbUrunTipi.Name = "cbUrunTipi";
            this.cbUrunTipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUrunTipi.Properties.Items.AddRange(new object[] {
            "Parfum",
            "Kozmetik"});
            this.cbUrunTipi.Size = new System.Drawing.Size(100, 20);
            this.cbUrunTipi.StyleController = this.dataLayoutControl1;
            this.cbUrunTipi.TabIndex = 15;
            // 
            // txtBirimFiyat
            // 
            this.txtBirimFiyat.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.urunBindingSource, "Maliyet", true));
            this.txtBirimFiyat.Location = new System.Drawing.Point(75, 36);
            this.txtBirimFiyat.MaximumSize = new System.Drawing.Size(100, 0);
            this.txtBirimFiyat.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtBirimFiyat.Name = "txtBirimFiyat";
            this.txtBirimFiyat.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtBirimFiyat.Size = new System.Drawing.Size(100, 20);
            this.txtBirimFiyat.StyleController = this.dataLayoutControl1;
            this.txtBirimFiyat.TabIndex = 18;
            // 
            // txtMaliyet
            // 
            this.txtMaliyet.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.urunBindingSource, "Maliyet", true));
            this.txtMaliyet.Location = new System.Drawing.Point(242, 36);
            this.txtMaliyet.MaximumSize = new System.Drawing.Size(100, 0);
            this.txtMaliyet.MinimumSize = new System.Drawing.Size(100, 0);
            this.txtMaliyet.Name = "txtMaliyet";
            this.txtMaliyet.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.txtMaliyet.Size = new System.Drawing.Size(100, 20);
            this.txtMaliyet.StyleController = this.dataLayoutControl1;
            this.txtMaliyet.TabIndex = 19;
            // 
            // cbKokuTuru
            // 
            this.cbKokuTuru.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.urunBindingSource, "KokuTuruId", true));
            this.cbKokuTuru.Location = new System.Drawing.Point(242, 12);
            this.cbKokuTuru.MaximumSize = new System.Drawing.Size(100, 0);
            this.cbKokuTuru.MinimumSize = new System.Drawing.Size(100, 0);
            this.cbKokuTuru.Name = "cbKokuTuru";
            this.cbKokuTuru.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cbKokuTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbKokuTuru.Properties.NullText = "";
            this.cbKokuTuru.Properties.PopupSizeable = false;
            this.cbKokuTuru.Size = new System.Drawing.Size(100, 20);
            this.cbKokuTuru.StyleController = this.dataLayoutControl1;
            this.cbKokuTuru.TabIndex = 17;
            // 
            // cbUrunTuru
            // 
            this.cbUrunTuru.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.urunBindingSource, "UrunTurId", true));
            this.cbUrunTuru.Location = new System.Drawing.Point(409, 12);
            this.cbUrunTuru.MaximumSize = new System.Drawing.Size(100, 0);
            this.cbUrunTuru.MinimumSize = new System.Drawing.Size(100, 0);
            this.cbUrunTuru.Name = "cbUrunTuru";
            this.cbUrunTuru.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cbUrunTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbUrunTuru.Properties.NullText = "";
            this.cbUrunTuru.Properties.PopupSizeable = false;
            this.cbUrunTuru.Size = new System.Drawing.Size(100, 20);
            this.cbUrunTuru.StyleController = this.dataLayoutControl1;
            this.cbUrunTuru.TabIndex = 16;
            // 
            // btnRaporla
            // 
            this.btnRaporla.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporla.Appearance.Options.UseFont = true;
            this.btnRaporla.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRaporla.ImageOptions.Image")));
            this.btnRaporla.Location = new System.Drawing.Point(513, 12);
            this.btnRaporla.MaximumSize = new System.Drawing.Size(167, 44);
            this.btnRaporla.MinimumSize = new System.Drawing.Size(167, 44);
            this.btnRaporla.Name = "btnRaporla";
            this.btnRaporla.Size = new System.Drawing.Size(167, 44);
            this.btnRaporla.StyleController = this.dataLayoutControl1;
            this.btnRaporla.TabIndex = 20;
            this.btnRaporla.Text = "Raporla";
            this.btnRaporla.Click += new System.EventHandler(this.btnRaporla_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem7});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(977, 593);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.gridControl1;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(957, 525);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.cbUrunTuru;
            this.layoutControlItem1.Location = new System.Drawing.Point(334, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(167, 24);
            this.layoutControlItem1.Text = "Ürün Türü";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.cbKokuTuru;
            this.layoutControlItem4.Location = new System.Drawing.Point(167, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(167, 24);
            this.layoutControlItem4.Text = "KokuTürü";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.txtBirimFiyat;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(167, 24);
            this.layoutControlItem5.Text = "Birim Fiyat";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.txtMaliyet;
            this.layoutControlItem6.Location = new System.Drawing.Point(167, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(334, 24);
            this.layoutControlItem6.Text = "Maliyet";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnGuncelle;
            this.layoutControlItem2.Location = new System.Drawing.Point(672, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(285, 48);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.cbUrunTipi;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(167, 24);
            this.layoutControlItem3.Text = "Ürün Tipi";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnRaporla;
            this.layoutControlItem7.Location = new System.Drawing.Point(501, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(171, 48);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // FrmFiyatGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 593);
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "FrmFiyatGuncelle";
            this.Text = "Toplu Fiyat Güncelleme Ekranı";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUrunTipi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBirimFiyat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaliyet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbKokuTuru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbUrunTuru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.ComboBoxEdit cbUrunTipi;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TextEdit txtBirimFiyat;
        private DevExpress.XtraEditors.TextEdit txtMaliyet;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private System.Windows.Forms.BindingSource urunBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colCinsiyet;
        private DevExpress.XtraGrid.Columns.GridColumn colBirim;
        private DevExpress.XtraGrid.Columns.GridColumn colMarka;
        private DevExpress.XtraGrid.Columns.GridColumn colKokuTuru;
        private DevExpress.XtraGrid.Columns.GridColumn colUrunTur;
        private DevExpress.XtraGrid.Columns.GridColumn colBirimFiyat;
        private DevExpress.XtraGrid.Columns.GridColumn colMaliyet;
        private DevExpress.XtraEditors.LookUpEdit cbKokuTuru;
        private DevExpress.XtraEditors.LookUpEdit cbUrunTuru;
        private DevExpress.XtraEditors.SimpleButton btnRaporla;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraGrid.Columns.GridColumn colSatisTipi;
    }
}