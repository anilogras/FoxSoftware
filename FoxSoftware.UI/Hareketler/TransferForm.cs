using FoxSoftware.DataAccess;
using FoxSoftware.Entites.Concreate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxSoftware.UI.Hareketler
{
    public partial class TransferForm : Form
    {
        public TransferForm()
        {
            InitializeComponent();

            this.button1.Click += Button1_Click;

        }
        string database = "";
        string dataname = "";
        private void Button1_Click(object sender, EventArgs e)
        {
            database = txtDataBase.Text;
            dataname = txtDataName.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=" + database + ";Initial Catalog=" + dataname + ";Integrated Security =true;");
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            SqlCommand komut = new SqlCommand("select * from musteri", conn);
            SqlDataReader dr1 = komut.ExecuteReader();


            Context cntx = new Context();

            List<Musteri> mstrler = new List<Musteri>();


            while (dr1.Read())
            {

                Email mail = new Email();
                mail.Silinmis = false;
                mail.MailAdres = dr1["email"].ToString();


                string adsoyaad = dr1["adsoyad"].ToString();
                string ad = adsoyaad.Substring(0, adsoyaad.IndexOf(" ") == -1 ? adsoyaad.Length : adsoyaad.IndexOf(" "));
                string soyad = adsoyaad.Substring(adsoyaad.IndexOf(" ") == -1 ? 0 : adsoyaad.IndexOf(" "), adsoyaad.IndexOf(" ") == -1 ? adsoyaad.Length : adsoyaad.Length - adsoyaad.IndexOf(" "));


                string il = dr1["il"].ToString().ToLower();
                string ilce = dr1["ilce"].ToString().ToLower();

                Il vtIl = null;
                Ilce vtIlce = null;


                if (!il.Contains("-"))
                    vtIl = cntx.Set<Il>().Where(x => x.Adi.ToLower() == il).FirstOrDefault();

                if (!ilce.Contains("-"))
                    vtIlce = cntx.Set<Ilce>().Where(x => x.Adi.ToLower() == ilce).FirstOrDefault();


                AdresBilgisi adresBilgisi = new AdresBilgisi();
                adresBilgisi.Adres = dr1["adres"].ToString();

                if (vtIl != null)
                    adresBilgisi.IlId = vtIl.Id;

                if (vtIlce != null)
                    adresBilgisi.IlceId = vtIlce.Id;

                TelefonNo tel = new TelefonNo();
                tel.No = dr1["telefon"].ToString();

                mstrler.Add(new Musteri
                {
                    Adi = ad,
                    Soyadi = soyad,
                    Mail = mail,
                    MailId = mail.Id,
                    AdresId = adresBilgisi.Id,
                    TCKN = dr1["tc"].ToString(),
                    Adres = adresBilgisi,
                    TelefonNo = tel,
                    TelefonNoId = tel.Id,
                    Silinmis = false,
                });
                // dr1[""]
            }


            foreach (Musteri musteri in mstrler)
            {
                cntx.Musteri.Add(musteri);
            }

            cntx.SaveChanges();
            MessageBox.Show("İşlem Tamamlandı");
            this.Close();
        }

        private void TransferForm_Load(object sender, EventArgs e)
        {
            //button1.Visible = false;
        }

        private void TransferForm_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F8)
            //{
            //    button1.Visible = true;
            //}
        }
    }
}
