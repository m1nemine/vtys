using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace denden
{
    public partial class Form1 : Form
    {
        // PostgreSQL bağlantı dizesi
        private const string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=emine1234;Database=kutuphane";

        public Form1()
        {
            InitializeComponent();
            listBoxSonuclar.Visible = false;
        }

        private void calisanIslemleri_Click(object sender, EventArgs e)
        {
            CalisanIslemleriForm calisanIslemleriForm = new CalisanIslemleriForm();
            calisanIslemleriForm.Show();
            this.Hide();
        }


        private void uyeIslemleri_Click(object sender, EventArgs e)
        {
            UyeIslemleriForm uyeForm = new UyeIslemleriForm();
            uyeForm.Show(); // Yeni formu göster
            this.Hide();    // Mevcut formu gizle (isteğe bağlı)
        }

        private void kitapIslemleri_Click(object sender, EventArgs e)
        {
            KitapIslemleriForm kitapForm = new KitapIslemleriForm();
            kitapForm.Show();
            this.Hide(); // Ana formu gizler
        }

        private void etkinlikler_Click(object sender, EventArgs e)
        {
            EtkinliklerForm etkinliklerForm = new EtkinliklerForm();
            etkinliklerForm.Show();
            this.Hide(); // Ana formu gizler
        }

        private void bagisIslemleri_Click(object sender, EventArgs e)
        {
            // Bağış İşlemleri sayfasını aç
            BagisIslemleriForm bagisForm = new BagisIslemleriForm();
            bagisForm.Show();
            this.Hide(); // Ana sayfayı gizler
        }

        private void ara_Click(object sender, EventArgs e)
        {
            listBoxSonuclar.Visible = true;
            try
            {
                string kitapAdi = txtAra.Text.Trim();

                if (string.IsNullOrEmpty(kitapAdi))
                {
                    MessageBox.Show("Lütfen bir kitap adı giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Kitap adıyla arama sorgusu
                    string query = @"
                SELECT k.KitapID, k.ad AS KitapAd, y.ad AS YazarAd, 
                       k.durum, l.lokasyonID, s.ad AS Sube
                FROM Kitaplar k
                LEFT JOIN Yazarlar ya ON k.yazarID = ya.kisiID
                LEFT JOIN Kisiler y ON ya.kisiID = y.kisiID
                LEFT JOIN Lokasyonlar l ON k.lokasyonID = l.lokasyonID
                LEFT JOIN Subeler s ON k.subeKodu = s.SubeID
                WHERE k.ad ILIKE @kitapAdi
                ORDER BY k.KitapID ASC;
            ";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri bağla
                        command.Parameters.AddWithValue("@kitapAdi", $"%{kitapAdi}%");

                        using (var reader = command.ExecuteReader())
                        {
                            listBoxSonuclar.Items.Clear(); // ListBox'ı temizle

                            while (reader.Read())
                            {
                                // Verileri al
                                int kitapID = reader.GetInt32(0);
                                string kitapAd = reader.GetString(1);
                                string yazarAd = reader.IsDBNull(2) ? "Bilinmiyor" : reader.GetString(2);
                                bool durum = reader.GetBoolean(3);
                                int lokasyonID = reader.IsDBNull(4) ? -1 : reader.GetInt32(4);
                                string sube = reader.IsDBNull(5) ? "Bilinmiyor" : reader.GetString(5);

                                // Durum ve lokasyon bilgisi ekle
                                string kitapDurumu = durum ? "Mevcut" : "Ödünçte";
                                string sonuc = $"ID: {kitapID}, Ad: {kitapAd}, Yazar: {yazarAd}, " +
                                               $"Durum: {kitapDurumu}, Lokasyon: {lokasyonID}, Şube: {sube}";

                                // Sonucu ListBox'a ekle
                                listBoxSonuclar.Items.Add(sonuc);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tedarik_Click(object sender, EventArgs e)
        {
            // Yeni formu oluştur ve göster
            KitapTedarikForm kitapTedarikForm = new KitapTedarikForm();
            kitapTedarikForm.Show();
            this.Hide();
        }

 
    }
}
