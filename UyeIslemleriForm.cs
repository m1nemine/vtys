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
    public partial class UyeIslemleriForm : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=emine1234;Database=kutuphane";
        private Dictionary<TextBox, string> defaultTexts = new Dictionary<TextBox, string>();
        public UyeIslemleriForm()
        {
            InitializeComponent();
            InitializeDefaultTexts();
            UyeBilgileriniYukle();
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
        private void UyeBilgileriniYukle()
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT k.kisiID, k.ad, k.soyad, k.telefonNo, k.mail, k.adres, u.uyelikTarihi
                        FROM Uyeler u
                        JOIN Kisiler k ON u.kisiID = k.kisiID;
                    ";

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable uyeler = new DataTable();
                        adapter.Fill(uyeler);
                        dataGridView1.DataSource = uyeler;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnAnaSayfa_Click(object sender, EventArgs e)
        {
            Form1 anaSayfa = new Form1();
            anaSayfa.Show();
            this.Close();
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

        private void uyeEkle_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO Kisiler (ad, soyad, telefonNo, mail, adres)
                        VALUES (@ad, @soyad, @telefonNo, @mail, @adres)
                        RETURNING kisiID;
                    ";

                    int yeniKisiID;
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("ad", txtAd.Text);
                        cmd.Parameters.AddWithValue("soyad", txtSoyad.Text);
                        cmd.Parameters.AddWithValue("telefonNo", txtTelefon.Text);
                        cmd.Parameters.AddWithValue("mail", txtMail.Text);
                        cmd.Parameters.AddWithValue("adres", txtAdres.Text);

                        yeniKisiID = (int)cmd.ExecuteScalar();
                    }

                    string uyeQuery = "INSERT INTO Uyeler (kisiID, uyelikTarihi) VALUES (@kisiID, @uyelikTarihi)";
                    using (var cmd = new NpgsqlCommand(uyeQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("kisiID", yeniKisiID);
                        cmd.Parameters.AddWithValue("uyelikTarihi", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Üye başarıyla eklendi.");
                    UyeBilgileriniYukle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uyeSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili satır olup olmadığını kontrol et
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Silinecek üye seçilmedi. Lütfen bir üye seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Eğer seçili satır yoksa işlem yapılmasın
                }

                // Veritabanı bağlantısı
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Silme sorgusu
                    string query = "DELETE FROM Uyeler WHERE kisiID = @kisiID";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        // Seçilen satırdaki kisiID değerini al ve parametre olarak ekle
                        cmd.Parameters.AddWithValue("kisiID", int.Parse(dataGridView1.SelectedRows[0].Cells["kisiID"].Value.ToString()));
                        cmd.ExecuteNonQuery();
                    }

                    // Silme işlemi başarılı olduğunda kullanıcıyı bilgilendir
                    MessageBox.Show("Üye başarıyla silindi.");
                    UyeBilgileriniYukle(); // Listeyi güncelle
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıyı bilgilendir
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void uyeGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Öncelikle kişi var mı kontrol et
                    string kontrolQuery = "SELECT kisiID FROM Kisiler WHERE telefonNo = @telefonNo";
                    int kisiID;
                    using (var cmd = new NpgsqlCommand(kontrolQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("telefonNo", txtTelefon.Text);

                        var result = cmd.ExecuteScalar();
                        kisiID = result != null ? (int)result : -1;
                    }

                    if (kisiID != -1) // Kişi zaten varsa güncelle
                    {
                        string guncelleQuery = @"
                    UPDATE Kisiler
                    SET ad = @ad, soyad = @soyad, mail = @mail, adres = @adres
                    WHERE kisiID = @kisiID";

                        using (var cmd = new NpgsqlCommand(guncelleQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("ad", txtAd.Text);
                            cmd.Parameters.AddWithValue("soyad", txtSoyad.Text);
                            cmd.Parameters.AddWithValue("mail", txtMail.Text);
                            cmd.Parameters.AddWithValue("adres", txtAdres.Text);
                            cmd.Parameters.AddWithValue("kisiID", kisiID);

                            cmd.ExecuteNonQuery();
                        }

                        string uyeGuncelleQuery = @"
                    UPDATE Uyeler
                    SET uyelikTarihi = @uyelikTarihi
                    WHERE kisiID = @kisiID";

                        using (var cmd = new NpgsqlCommand(uyeGuncelleQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("uyelikTarihi", DateTime.Now);
                            cmd.Parameters.AddWithValue("kisiID", kisiID);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Üye başarıyla güncellendi.");
                    }
                    else // Kişi yoksa yeni ekle
                    {
                        string ekleQuery = @"
                    INSERT INTO Kisiler (ad, soyad, telefonNo, mail, adres)
                    VALUES (@ad, @soyad, @telefonNo, @mail, @adres)
                    RETURNING kisiID;";

                        using (var cmd = new NpgsqlCommand(ekleQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("ad", txtAd.Text);
                            cmd.Parameters.AddWithValue("soyad", txtSoyad.Text);
                            cmd.Parameters.AddWithValue("telefonNo", txtTelefon.Text);
                            cmd.Parameters.AddWithValue("mail", txtMail.Text);
                            cmd.Parameters.AddWithValue("adres", txtAdres.Text);

                            kisiID = (int)cmd.ExecuteScalar();
                        }

                        string uyeQuery = "INSERT INTO Uyeler (kisiID, uyelikTarihi) VALUES (@kisiID, @uyelikTarihi)";
                        using (var cmd = new NpgsqlCommand(uyeQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("kisiID", kisiID);
                            cmd.Parameters.AddWithValue("uyelikTarihi", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Üye başarıyla eklendi.");
                    }

                    UyeBilgileriniYukle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Eğer seçili satır geçerli bir satır değilse (örn. başlık satırı) geri dön
            if (e.RowIndex < 0) return;

            // Seçilen satırın hücre değerlerini al ve ilgili TextBox'lara yükle
            DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
            txtAd.Text = selectedRow.Cells["ad"].Value?.ToString() ?? string.Empty;
            txtSoyad.Text = selectedRow.Cells["soyad"].Value?.ToString() ?? string.Empty;
            txtTelefon.Text = selectedRow.Cells["telefonNo"].Value?.ToString() ?? string.Empty;
            txtMail.Text = selectedRow.Cells["mail"].Value?.ToString() ?? string.Empty;
            txtAdres.Text = selectedRow.Cells["adres"].Value?.ToString() ?? string.Empty;
        }
    }
}
