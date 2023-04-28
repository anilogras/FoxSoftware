using FoxSoftware.Business.Services;
using FoxSoftware.DataAccess;
using FoxSoftware.Entites.Concreate;
using FoxSoftware.Ortak.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxSoftware.UI.Tanimlamalar
{
    public partial class FrmMusteriTanim : DevExpress.XtraEditors.XtraForm
    {
        FoxSoftWareBusinessUOW _BusinesUOW;
        private Musteri _model;
        private DbContext _context;
        public FoxSoftWareBusinessUOW _BusinesUOW2;

        public FrmMusteriTanim(ViewFormModel<Musteri> ViewForm)
        {
            InitializeComponent();
            _context = ViewForm.Context;
            _BusinesUOW = new FoxSoftWareBusinessUOW(_context);
            _BusinesUOW2 = new FoxSoftWareBusinessUOW(DataAccessHelper.NewContext);
            if (ViewForm.Model.Id == 0)
            {
                _model = _BusinesUOW.MusteriRepository.CreateNewModel();
            }
            else
            {
                _model = ViewForm.Model;

            }
            musteriBindingSource.DataSource = _model;
            this.btnKaydet.Click += BtnKaydet_Click;
            this.AdiTextEdit.TextChanged += AdiTextEdit_TextChanged;
            this.SoyadiTextEdit.TextChanged += SoyadiTextEdit_TextChanged;
            this.textAdiAra.TextChanged += TextAdiAra_TextChanged;
            this.textSoyadiAra.TextChanged += TextSoyadiAra_TextChanged;
            this.textAdiAra.KeyPress += TextAdiAra_KeyPress;
            //this.gridView1.Editable = false;
            //this.gridView1.group
        }

        private void TextAdiAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            string sql = "select m.Id as 'ID',m.Adi as 'Adı',m.Soyadi as 'Soyadı',m.TCKN as 'TCKN',t.No as 'Telefon',il.Adi as 'Şehir',ilce.Adi as 'İlçe' from Musteris m left join TelefonNoes t on t.id = m.TelefonNoId left join AdresBilgisis a on a.id = m.AdresId left join Ils il on il.Id = a.IlId left join Ilces ilce on ilce.Id = a.IlceId where m.Adi like '%" + textAdiAra.Text + "%' and m.Silinmis=0";
            MusteriAra(sql);
        }

        private void TextSoyadiAra_TextChanged(object sender, EventArgs e)
        {
            string sql = "select m.Id as 'ID',m.Adi as 'Adı',m.Soyadi as 'Soyadı',m.TCKN as 'TCKN',t.No as 'Telefon',il.Adi as 'Şehir',ilce.Adi as 'İlçe' from Musteris m left join TelefonNoes t on t.id = m.TelefonNoId left join AdresBilgisis a on a.id = m.AdresId left join Ils il on il.Id = a.IlId left join Ilces ilce on ilce.Id = a.IlceId where m.Soyadi like '%" + textSoyadiAra.Text + "%' and m.Silinmis=0";
            MusteriAra(sql);
        }

        private void TextAdiAra_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void SoyadiTextEdit_TextChanged(object sender, EventArgs e)
        {
            //string sql = "select * from Musteris m where m.Adi like '%" + AdiTextEdit.Text + "%' and m.Soyadi like '%" + SoyadiTextEdit.Text + "%' and m.Silinmis=0";
            string sql = "select m.Id as 'ID',m.Adi as 'Adı',m.Soyadi as 'Soyadı',m.TCKN as 'TCKN',t.No as 'Telefon',il.Adi as 'Şehir',ilce.Adi as 'İlçe' from Musteris m left join TelefonNoes t on t.id = m.TelefonNoId left join AdresBilgisis a on a.id = m.AdresId left join Ils il on il.Id = a.IlId left join Ilces ilce on ilce.Id = a.IlceId where m.Soyadi like '%" + SoyadiTextEdit.Text + "%' and m.Silinmis=0";
            MusteriAra(sql);
        }

        private void AdiTextEdit_TextChanged(object sender, EventArgs e)
        {
            string sql = "select m.Id as 'ID',m.Adi as 'Adı',m.Soyadi as 'Soyadı',m.TCKN as 'TCKN',t.No as 'Telefon',il.Adi as 'Şehir',ilce.Adi as 'İlçe' from Musteris m left join TelefonNoes t on t.id = m.TelefonNoId left join AdresBilgisis a on a.id = m.AdresId left join Ils il on il.Id = a.IlId left join Ilces ilce on ilce.Id = a.IlceId where m.Adi like '%" + AdiTextEdit.Text + "%' and m.Silinmis=0";
            MusteriAra(sql);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            
        }
        public void MusteriAra(string sql)
        {
            SqlConnection baglanti = new SqlConnection(Context._connectionString);
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataReader dr1 = komut.ExecuteReader(); 
            while (dr1.Read())
            {
                gridControl1.DataSource = dr1;
            }
            baglanti.Close();
        }
        private void FrmMusteriTanim_Load(object sender, EventArgs e)
        {
            AdresIlIdComboBoxEdit.EditValueChanged += IlAdiTextEdit_EditValueChanged;
            AdresIlIdComboBoxEdit.Properties.DisplayMember = "Adi";
            AdresIlIdComboBoxEdit.Properties.ValueMember = "Id";
            AdresIlIdComboBoxEdit.Properties.DataSource = _BusinesUOW.IlRepository.GetAll().Select(x => new
            {
                Id = x.Id,
                Adi = x.Adi
            });
            AdresIlceIlIdComboBoxEdit.Properties.DisplayMember = "Adi";
            AdresIlceIlIdComboBoxEdit.Properties.ValueMember = "Id";
            AdresIlceIlIdComboBoxEdit.Properties.DataSource = _BusinesUOW.IlceRepository.GetAll().Select(x => new
            {
                Id = x.Id,
                Adi = x.Adi
            });
            AdresIlIdComboBoxEdit.EditValue = 1;
            AdresIlceIlIdComboBoxEdit.EditValue = 1;
            //string sql2 = "select * from Musteris m where m.Adi like '%" + AdiTextEdit.Text + "%' and m.Soyadi like '%" + SoyadiTextEdit.Text + "%' and m.Silinmis=0";
            string sql2 = "select m.Id as 'ID',m.Adi as 'Adı',m.Soyadi as 'Soyadı',m.TCKN as 'TCKN',t.No as 'Telefon',il.Adi as 'Şehir',ilce.Adi as 'İlçe' from Musteris m left join TelefonNoes t on t.id = m.TelefonNoId left join AdresBilgisis a on a.id = m.AdresId left join Ils il on il.Id = a.IlId left join Ilces ilce on ilce.Id = a.IlceId where m.Silinmis=0";
            MusteriAra(sql2);
        }

        private void IlAdiTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            int ilId = Convert.ToInt32(AdresIlIdComboBoxEdit.EditValue);
            AdresIlceIlIdComboBoxEdit.Properties.DisplayMember= "Adi";
            AdresIlceIlIdComboBoxEdit.Properties.ValueMember = "Id";
            AdresIlceIlIdComboBoxEdit.Properties.DataSource = _BusinesUOW.IlceRepository.GetAll(x => x.IlId== ilId).Select(x => new
            {
                x.Id,
                x.Adi
            });

        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            if (AdiTextEdit.Text == null || (AdiTextEdit.Text.Trim() == "") || SoyadiTextEdit.Text == null || (SoyadiTextEdit.Text.Trim() == "") || SoyadiTextEdit.Text == null || (SoyadiTextEdit.Text.Trim() == ""))
            {
                var res = UIHelper.MesajKayitEdemez();
            }
            else
            {
                var res = UIHelper.KayitEkle();
                if (res == DialogResult.Yes)
                {
                    _BusinesUOW.MusteriRepository.Add(_model);
                    _context.SaveChanges();
                    var r = UIHelper.MesajVer();
                    this.DialogResult = DialogResult.OK;
                    //this.Hide();
                    this.Close();                    
                }
                ViewFormModel<Musteri> model = new ViewFormModel<Musteri>();
                model.Context = _BusinesUOW.GetContext();
                FrmMusteriTanim btanim2 = new FrmMusteriTanim(model);
                //DialogResult result = btanim2.ShowDialog();
                btanim2.Show();
            }
            var saveResult = _BusinesUOW.Complete();
        }
    }
}
