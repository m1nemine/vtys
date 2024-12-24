using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace denden
{
    public partial class EtkinliklerForm : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=emine1234;Database=kutuphane";
        private Dictionary<TextBox, string> defaultTexts = new Dictionary<TextBox, string>();
        public EtkinliklerForm()
        {
            InitializeComponent();
            InitializeDefaultTexts();
            EtkinlikBilgileriniYukle();
        }

        private void InitializeDefaultTexts()
        {
            defaultTexts[txtcalisanID] = "Çalışan ID girin...";
            defaultTexts[txtetkinlikAdi] = "Etkinlik Adı girin...";
            defaultTexts[txtaciklama] = "Açıklama girin...";

            foreach (var item in defaultTexts)
            {
                var textBox = item.Key;
                var defaultText = item.Value;

                textBox.Text = defaultText;
                textBox.ForeColor = Color.Gray;

                textBox.GotFocus += TextBox_GotFocus;
                textBox.LostFocus += TextBox_LostFocus;
            }
        }
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && defaultTexts.ContainsKey(textBox))
            {
                if (textBox.Text == defaultTexts[textBox])
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            }
        }
        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null && defaultTexts.ContainsKey(textBox))
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = defaultTexts[textBox];
                    textBox.ForeColor = Color.Gray;
                }
            }
        }

        private void EtkinlikBilgileriniYukle()
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Etkinlikler tablosundan bilgileri getir
                    string query = @"
                SELECT e.etkinlikID, e.ad AS EtkinlikAdı, e.tarih, e.aciklama, 
                       c.kisiID AS CalisanID, k.ad AS CalisanAd, k.soyad AS CalisanSoyad
                FROM Etkinlikler e
                JOIN Calisanlar c ON e.calisanID = c.kisiID
                JOIN Kisiler k ON c.kisiID = k.kisiID
                ORDER BY e.tarih DESC;
            ";

                    // Verileri DataTable'a doldur
                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable etkinlikler = new DataTable();
                        adapter.Fill(etkinlikler);

                        // DataGridView'e yükle
                        dataGridView1.DataSource = etkinlikler;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void geriDon_Click(object sender, EventArgs e)
        {
            Form1 anaSayfa = new Form1();
            anaSayfa.Show();
            this.Close(); // Kitap işlemleri formunu kapatır
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            // Kullanıcıya doğrulama sorusu sorulabilir
            var result = MessageBox.Show("Programdan çıkmak istediğinizden emin misiniz?",
                                         "Çıkış",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Programı tamamen kapat
                Application.Exit();
            }
        }

        private void etkinlikEkle_Click(object sender, EventArgs e)
        {
            // TextBox ve DateTimePicker değerlerini al
            int calisanID;
            if (!int.TryParse(txtcalisanID.Text, out calisanID) || calisanID <= 0)
            {
                MessageBox.Show("Geçerli bir Çalışan ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string etkinlikAdi = txtetkinlikAdi.Text.Trim();
            string aciklama = txtaciklama.Text.Trim();
            DateTime etkinlikTarihi = dateTimePicker1.Value;

            // Etkinlik adı boş olamaz
            if (string.IsNullOrWhiteSpace(etkinlikAdi))
            {
                MessageBox.Show("Etkinlik adı boş bırakılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Etkinlik tarihi bugünden önce olamaz
            if (etkinlikTarihi.Date < DateTime.Today)
            {
                MessageBox.Show("Etkinlik tarihi bugünden önce olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Çalışan ID'sinin veritabanında mevcut olup olmadığını kontrol et
                    string checkQuery = "SELECT COUNT(*) FROM Calisanlar WHERE kisiID = @calisanID";
                    using (var checkCmd = new NpgsqlCommand(checkQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@calisanID", calisanID);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count == 0)
                        {
                            MessageBox.Show("Geçerli bir Çalışan ID giriniz. Çalışan bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Etkinlik ekleme sorgusu
                    string query = @"
                INSERT INTO Etkinlikler (calisanID, ad, tarih, aciklama) 
                VALUES (@calisanID, @ad, @tarih, @aciklama);
            ";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@calisanID", calisanID);
                        command.Parameters.AddWithValue("@ad", etkinlikAdi);
                        command.Parameters.AddWithValue("@tarih", etkinlikTarihi);
                        command.Parameters.AddWithValue("@aciklama", aciklama);

                        // Sorguyu çalıştır
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Etkinlik başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            EtkinlikBilgileriniYukle(); // Listeyi güncelle
                        }
                        else
                        {
                            MessageBox.Show("Etkinlik eklenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
