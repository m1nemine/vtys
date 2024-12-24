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
    public partial class CalisanIslemleriForm : Form
    {
        // Veritabanı bağlantı dizesi
        private const string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=emine1234;Database=kutuphane";
        private Dictionary<TextBox, string> defaultTexts = new Dictionary<TextBox, string>();

        public CalisanIslemleriForm()
        {
            InitializeComponent();
            InitializeDefaultTexts();
            CalisanBilgileriniYukle();
        }

        private void InitializeDefaultTexts()
        {
            defaultTexts[txtAd] = "Ad girin...";
            defaultTexts[txtSoyad] = "Soy ad girin...";
            defaultTexts[txtMail] = "Mail girin...";
            defaultTexts[txtTelefon] = "Telefon girin...";
            defaultTexts[txtAdres] = "Adres girin...";

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

        private void CalisanBilgileriniYukle()
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Çalışan bilgilerini çekmek için sorgu
                    string query = @"
                        SELECT k.kisiID, k.ad, k.soyad, k.telefonNo, k.mail, k.adres, c.baslamaTarihi
                        FROM Calisanlar c
                        JOIN Kisiler k ON c.kisiID = k.kisiID;
                    ";

                    // Verileri DataTable'a doldur
                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable calisanlar = new DataTable();
                        adapter.Fill(calisanlar);

                        // DataGridView'e yükle
                        dataGridView1.DataSource = calisanlar;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ana Sayfa Butonu Tıklama Olayı
        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            Form1 anaSayfa = new Form1();
            anaSayfa.Show();
            this.Close();
        }

        private void calisanEkle_Click(object sender, EventArgs e)
        {
            // TextBox'lardan verileri al
            string ad = txtAd.Text.Trim();
            string soyad = txtSoyad.Text.Trim();
            string mail = txtMail.Text.Trim();
            string telefonNo = txtTelefon.Text.Trim();
            string adres = txtAdres.Text.Trim();

            // Girişlerin doğruluğunu kontrol et
            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad))
            {
                MessageBox.Show("Ad ve Soyad alanları zorunludur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Çalışanı eklemek için SQL sorgusu
                    string queryKisiler = @"
                INSERT INTO Kisiler (ad, soyad, telefonNo, mail, adres)
                VALUES (@ad, @soyad, @telefonNo, @mail, @adres)
                RETURNING kisiID;";

                    int yeniKisiID;

                    // Kisiler tablosuna ekleme
                    using (var cmdKisiler = new NpgsqlCommand(queryKisiler, connection))
                    {
                        cmdKisiler.Parameters.AddWithValue("ad", ad);
                        cmdKisiler.Parameters.AddWithValue("soyad", soyad);
                        cmdKisiler.Parameters.AddWithValue("telefonNo", (object)telefonNo ?? DBNull.Value);
                        cmdKisiler.Parameters.AddWithValue("mail", (object)mail ?? DBNull.Value);
                        cmdKisiler.Parameters.AddWithValue("adres", (object)adres ?? DBNull.Value);

                        yeniKisiID = (int)cmdKisiler.ExecuteScalar();
                    }

                    // Çalışanlar tablosuna ekleme
                    string queryCalisanlar = @"
                INSERT INTO Calisanlar (kisiID, baslamaTarihi)
                VALUES (@kisiID, @baslamaTarihi);";

                    using (var cmdCalisanlar = new NpgsqlCommand(queryCalisanlar, connection))
                    {
                        cmdCalisanlar.Parameters.AddWithValue("kisiID", yeniKisiID);
                        cmdCalisanlar.Parameters.AddWithValue("baslamaTarihi", DateTime.Now);

                        cmdCalisanlar.ExecuteNonQuery();
                    }

                    MessageBox.Show("Çalışan başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // DataGridView'i güncelle
                    CalisanBilgileriniYukle();

                    // TextBox'ları temizle
                    txtAd.Clear();
                    txtSoyad.Clear();
                    txtMail.Clear();
                    txtTelefon.Clear();
                    txtAdres.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eğer tıklanan satır geçerli bir satır değilse, çık
            if (e.RowIndex < 0) return;

            // Seçilen satırın verilerini al
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // TextBox'lara verileri yükle
            txtAd.Text = row.Cells["ad"].Value?.ToString() ?? "";
            txtSoyad.Text = row.Cells["soyad"].Value?.ToString() ?? "";
            txtMail.Text = row.Cells["mail"].Value?.ToString() ?? "";
            txtTelefon.Text = row.Cells["telefonNo"].Value?.ToString() ?? "";
            txtAdres.Text = row.Cells["adres"].Value?.ToString() ?? "";
        }

        private void calisanGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Seçili çalışanın ID'sini al
                    if (dataGridView1.CurrentRow == null)
                    {
                        MessageBox.Show("Güncellenecek çalışanı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int kisiID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["kisiID"].Value);

                    // Güncelleme sorgusu
                    string updateQuery = @"
                UPDATE Kisiler
                SET ad = @ad, soyad = @soyad, telefonNo = @telefonNo, mail = @mail, adres = @adres
                WHERE kisiID = @kisiID;
            ";

                    using (var command = new NpgsqlCommand(updateQuery, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@ad", txtAd.Text);
                        command.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                        command.Parameters.AddWithValue("@telefonNo", txtTelefon.Text);
                        command.Parameters.AddWithValue("@mail", txtMail.Text);
                        command.Parameters.AddWithValue("@adres", txtAdres.Text);
                        command.Parameters.AddWithValue("@kisiID", kisiID);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Çalışan başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Güncellenen bilgileri yenile
                        CalisanBilgileriniYukle();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calisanSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili çalışanın olup olmadığını kontrol et
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Silinecek çalışanı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Eğer seçili satır yoksa işlemi sonlandır
                }

                // Seçili çalışanın ID'sini al
                int kisiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["kisiID"].Value);

                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Silme sorgusu (Çalışanlar ve Kisiler tablosundan silme işlemi)
                    string deleteQuery = "DELETE FROM Calisanlar WHERE kisiID = @kisiID; DELETE FROM Kisiler WHERE kisiID = @kisiID;";

                    using (var command = new NpgsqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@kisiID", kisiID);

                        // Silme işlemi
                        command.ExecuteNonQuery();
                        MessageBox.Show("Çalışan başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Silinen bilgileri yenile
                        CalisanBilgileriniYukle();
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi ver
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
