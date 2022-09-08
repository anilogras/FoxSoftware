using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxSoftware.UI
{
    public static class UIHelper
    {
        public static DialogResult FormSoruSor(string mesaj)
        {
            return MessageBox.Show(mesaj, "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult MesajVer()
        {
            return MessageBox.Show("İşlem Tamamlandı.", "MESAJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult MesajKayitEdemez()
        {
            return MessageBox.Show("Lütfen Boş Alanları Doldurunuz.", "MESAJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult KayitSil()
        {
            return MessageBox.Show("Kayıt Silinecektir Emin misiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult KayitGuncelle()
        {
            return MessageBox.Show("Kayıt Güncellenecektir Emin misiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult KayitEkle()
        {
            return MessageBox.Show("Değişiklikler kaydedilsin mi?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
