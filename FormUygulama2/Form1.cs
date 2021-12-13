using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUygulama2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMesajGoster_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kullanıcıya göstermek istediğimiz bilgi", "Başlık bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void brnSoruSor_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Yeniden denemek ister misiniz?", "Soru", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {

            }
            if (res == DialogResult.No)
            {

            }
            if (res == DialogResult.Cancel)
            {

            }
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            int islemSonuc = yeniMusteriEkle(new Musteri()
            {
                id = Guid.NewGuid(),
                Isim = txtIsim.Text,
                Soyisim = txtSoyisim.Text,
                EmailAdres = txtEmailAdres.Text,
                TelefonNumarasi = txtTelefon.Text
            });
            
            if (islemSonuc > 0)
            {
                DialogResult res = MessageBox.Show("Müşteri ekleme işlemi başarılı, yeni müşteri kaydı eklemek ister misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    BildirimCubugu = new NotifyIcon();
                    BildirimCubugu.BalloonTipText = "Toplam müşteri kayıt adedi : " + SanalDatabase.musteriler.Count.ToString();
                    BildirimCubugu.BalloonTipTitle = "Müşteri Adedi bilgisi";
                    BildirimCubugu.Visible = true;
                    BildirimCubugu.Icon = SystemIcons.Information;
                    BildirimCubugu.ShowBalloonTip(2000);
                }
                else if (res == DialogResult.No)
                {

                }

                EkranTemizle();
                EkranListele();

            }
            else
            {
                MessageBox.Show("Hata: Kayıt ekleme işlemi yapılamadı.");
            }
                
        }

        private void EkranTemizle()
        {
            txtIsim.Text = string.Empty;
            txtSoyisim.Text = string.Empty;
            txtEmailAdres.Text = string.Empty;
            txtTelefon.Text = string.Empty;
        }

        private void EkranListele()
        {
            lstMusteriler.Items.Clear();
            //lstMusteriler.DataSource = SanalDatabase.musteriler;
            foreach (var item in SanalDatabase.musteriler)
            {
                lstMusteriler.Items.Add(item);
            }
        }

        private int yeniMusteriEkle(Musteri musteri)
        {
            SanalDatabase.musteriler.Add(musteri);
            return 1;
        }
    }
}
