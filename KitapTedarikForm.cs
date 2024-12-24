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
    public partial class KitapTedarikForm : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=emine1234;Database=kutuphane";
        private Dictionary<TextBox, string> defaultTexts = new Dictionary<TextBox, string>();
        public KitapTedarikForm()
        {
            InitializeComponent();
            InitializeDefaultTexts();
            TedarikcileriYukle();
            KitaplariYukle();
        }

        private void InitializeDefaultTexts()
        {
            defaultTexts[txtKitapID] = "Kitap ID girin...";
            defaultTexts[txtTedarikci] = "Tedarikçi ID  girin...";
            defaultTexts[txtSubeKodu] = "Şube Kodu girin...";
            defaultTexts[txtFiyat] = "Fiyat girin...";
            defaultTexts[txtMiktar] = "Miktar girin...";

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
        private void KitaplariYukle()
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = @"
                    SELECT 
                        k.KitapID, 
                        k.ad AS KitapAd, 
                        y.ad AS YazarAd, 
                        yv.ad AS Yayinevi, 
                        kk.ad AS Kategori, 
                        k.yayinYili, 
                        s.ad AS Sube, 
                        CASE 
                            WHEN k.durum = TRUE THEN 'Mevcut' 
                            ELSE 'Ödünçte' 
                        END AS Durum
                    FROM Kitaplar k
                    LEFT JOIN Yazarlar ya ON k.yazarID = ya.kisiID
                    LEFT JOIN Kisiler y ON ya.kisiID = y.kisiID
                    LEFT JOIN Yayinevi yv ON k.yayinEviID = yv.yayineviID
                    LEFT JOIN Kitap_Kategorileri kk ON k.kategoriID = kk.kategoriKodu
                    LEFT JOIN Subeler s ON k.subeKodu = s.SubeID
                    ORDER BY k.KitapID ASC;";


                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable kitaplar = new DataTable();
                        adapter.Fill(kitaplar);
                        dataGridView1.DataSource = kitaplar;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TedarikcileriYukle()
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = @"
                    SELECT t.tedarikciID, t.ad AS TedarikciAd, t.iletisim
                    FROM Tedarikci t;
                ";

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable tedarikciler = new DataTable();
                        adapter.Fill(tedarikciler);
                        dataGridView2.DataSource = tedarikciler;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kitapAl_Click(object sender, EventArgs e)
        {
            try
            {
                // TextBox'lardan alınan verileri doğrula ve al
                int tedarikciID = int.Parse(txtTedarikci.Text);
                int kitapID = int.Parse(txtKitapID.Text);
                int subeKodu = int.Parse(txtSubeKodu.Text);
                int miktar = int.Parse(txtMiktar.Text);
                decimal fiyat = decimal.Parse(txtFiyat.Text);

                // Bugünün tarihini al
                DateTime tarih = DateTime.Now;

                // PostgreSQL bağlantısını başlat
                using (NpgsqlConnection baglanti = new NpgsqlConnection("Host=localhost;Username=postgres;Password=emine1234;Database=yeni19"))
                {
                    baglanti.Open();

                    // Kitap alımını ekle
                    using (NpgsqlCommand komut = new NpgsqlCommand(
                        "INSERT INTO Kitap_Alim (tedarikciID, tarih, miktar, fiyat, kitapID, subeKodu) VALUES (@tedarikciID, @tarih, @miktar, @fiyat, @kitapID, @subeKodu);",
                        baglanti))
                    {
                        komut.Parameters.AddWithValue("tedarikciID", tedarikciID);
                        komut.Parameters.AddWithValue("tarih", tarih);
                        komut.Parameters.AddWithValue("miktar", miktar);
                        komut.Parameters.AddWithValue("fiyat", fiyat);
                        komut.Parameters.AddWithValue("kitapID", kitapID);
                        komut.Parameters.AddWithValue("subeKodu", subeKodu);

                        komut.ExecuteNonQuery();

                        MessageBox.Show("Kitap alımı başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Kitapları ekle
                    for (int i = 0; i < miktar; i++)
                    {
                        // Kitap bilgilerini al
                        string selectQuery = "SELECT * FROM Kitaplar WHERE KitapID = @kitapID";
                        using (var selectCmd = new NpgsqlCommand(selectQuery, baglanti))
                        {
                            selectCmd.Parameters.AddWithValue("@kitapID", kitapID);
                            using (var reader = selectCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string kitapAdi = reader["ad"].ToString();
                                    int yazarID = (int)reader["yazarID"];
                                    int yayinEviID = (int)reader["yayinEviID"];
                                    int kategoriID = (int)reader["kategoriID"];
                                    int yayinYili = (int)reader["yayinYili"];

                                    reader.Close();

                                    // Yeni kitap ekle
                                    using (var kitapCmd = new NpgsqlCommand("INSERT INTO Kitaplar (ad, yazarID, yayinEviID, kategoriID, yayinYili, subeKodu) VALUES (@ad, @yazarID, @yayinEviID, @kategoriID, @yayinYili, @subeKodu)", baglanti))
                                    {
                                        kitapCmd.Parameters.AddWithValue("@ad", kitapAdi);
                                        kitapCmd.Parameters.AddWithValue("@yazarID", yazarID);
                                        kitapCmd.Parameters.AddWithValue("@yayinEviID", yayinEviID);
                                        kitapCmd.Parameters.AddWithValue("@kategoriID", kategoriID);
                                        kitapCmd.Parameters.AddWithValue("@yayinYili", yayinYili);
                                        kitapCmd.Parameters.AddWithValue("@subeKodu", subeKodu);
                                        kitapCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
                // Yeni eklenen kitapları görmek için DataGridView'i yenile
                KitaplariYukle();
            }
            catch (Npgsql.PostgresException ex)
            {
                MessageBox.Show($"Veritabanı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void maliyet_Click(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection baglanti = new NpgsqlConnection("Host=localhost;Username=postgres;Password=emine1234;Database=kutuphane"))
                {
                    baglanti.Open();

                    // Toplam gideri hesaplayan fonksiyonu çağır
                    using (NpgsqlCommand komut = new NpgsqlCommand("SELECT toplam_gider_hesapla();", baglanti))
                    {
                        object toplamGider = komut.ExecuteScalar();

                        if (toplamGider != null)
                        {
                            // Toplam gideri göster
                            MessageBox.Show($"Toplam Gider: {toplamGider} TL", "Toplam Gider Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Toplam gider hesaplanamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Npgsql.PostgresException ex)
            {
                MessageBox.Show($"Veritabanı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beklenmeyen bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void geriDon_Click_1(object sender, EventArgs e)
        {
            Form1 anaSayfa = new Form1();
            anaSayfa.Show();
            this.Close(); // Kitap işlemleri formunu kapatır
        }

        private void cikis_Click_1(object sender, EventArgs e)
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
    }
}
