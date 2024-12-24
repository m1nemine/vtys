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
    public partial class BagisIslemleriForm : Form
    {
     
        private const string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=emine1234;Database=kutuphane";
        private Dictionary<TextBox, string> defaultTexts = new Dictionary<TextBox, string>();

        public BagisIslemleriForm()
        {
            InitializeComponent();
            InitializeDefaultTexts();
            UyeBilgileriniYukle();
            BagisBilgileriniYukle();
            txtAciklama.Visible = false;
            listBoxKitaplar.Visible = false;
            label3.Visible = false;

        }

        private void InitializeDefaultTexts()
        {
            defaultTexts[txtKitapAdedi] = "Kitap adedi girin...";
            defaultTexts[txtUyeID] = "Üye ID girin...";

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

                    // Üyeler tablosundan bilgileri getir
                    string query = @"
                SELECT u.kisiID, k.ad AS UyeAd, k.soyad AS UyeSoyad, k.telefonNo, k.mail, u.uyelikTarihi
                FROM Uyeler u
                JOIN Kisiler k ON u.kisiID = k.kisiID
                ORDER BY u.uyelikTarihi DESC;
            ";

                    // Verileri DataTable'a doldur
                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable uyeler = new DataTable();
                        adapter.Fill(uyeler);

                        // DataGridView'e yükle
                        dataGridView1.DataSource = uyeler;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BagisBilgileriniYukle()
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Bağışlar tablosundan bilgileri getir
                    string query = @"
                SELECT b.bagisID, u.kisiID AS UyeID, k.ad AS UyeAd, k.soyad AS UyeSoyad, 
                       b.kitapAdeti, b.tarih, b.aciklama
                FROM Bagis b
                JOIN Uyeler u ON b.uyeID = u.kisiID
                JOIN Kisiler k ON u.kisiID = k.kisiID
                ORDER BY b.tarih DESC;
            ";

                    // Verileri DataTable'a doldur
                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable bagislar = new DataTable();
                        adapter.Fill(bagislar);

                        // DataGridView'e yükle
                        dataGridView2.DataSource = bagislar;
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

        private void bagisEkle_Click(object sender, EventArgs e)
        {
            int uyeID;
            if (!int.TryParse(txtUyeID.Text, out uyeID))
            {
                MessageBox.Show("Geçerli bir Üye ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Üye ID'nin geçerliliğini kontrol et
            if (!UyeVarMi(uyeID))
            {
                MessageBox.Show("Lütfen üyeyi listeden seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int kitapAdeti;
            if (!int.TryParse(txtKitapAdedi.Text, out kitapAdeti) || kitapAdeti <= 0)
            {
                MessageBox.Show("Geçerli bir kitap adedi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    // "bagis_ekle" fonksiyonunu çağır
                    string bagisQuery = "SELECT bagis_ekle(@uyeID, @kitapAdeti, NULL)";
                    using (var bagisCommand = new NpgsqlCommand(bagisQuery, connection))
                    {
                        bagisCommand.Parameters.AddWithValue("@uyeID", uyeID);
                        bagisCommand.Parameters.AddWithValue("@kitapAdeti", kitapAdeti);

                        // Bağışı ekle
                        bagisCommand.ExecuteNonQuery();
                    }

                    // Kitapları rastgele seç ve veritabanına ekle
                    List<string> bagislananKitaplar = new List<string>();
                    for (int i = 0; i < kitapAdeti; i++)
                    {
                        string selectQuery = "SELECT * FROM Kitaplar ORDER BY RANDOM() LIMIT 1";
                        using (var selectCommand = new NpgsqlCommand(selectQuery, connection))
                        {
                            using (var reader = selectCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Rastgele seçilen kitabın bilgilerini al
                                    string kitapAdi = reader["ad"].ToString();
                                    int yazarID = (int)reader["yazarID"];
                                    int yayinEviID = (int)reader["yayinEviID"];
                                    int kategoriID = (int)reader["kategoriID"];
                                    int yayinYili = (int)reader["yayinYili"];
                                    int subeKodu = (int)reader["subeKodu"];

                                    reader.Close(); // Reader'ı kapatmayı unutmayın

                                    // Yeni kitap ekleme sorgusu
                                    string insertQuery = "INSERT INTO Kitaplar (ad, yazarID, yayinEviID, kategoriID, yayinYili, subeKodu) VALUES (@ad, @yazarID, @yayinEviID, @kategoriID, @yayinYili, @subeKodu)";
                                    using (var kitapCommand = new NpgsqlCommand(insertQuery, connection))
                                    {
                                        kitapCommand.Parameters.AddWithValue("@ad", kitapAdi);
                                        kitapCommand.Parameters.AddWithValue("@yazarID", yazarID);
                                        kitapCommand.Parameters.AddWithValue("@yayinEviID", yayinEviID);
                                        kitapCommand.Parameters.AddWithValue("@kategoriID", kategoriID);
                                        kitapCommand.Parameters.AddWithValue("@yayinYili", yayinYili);
                                        kitapCommand.Parameters.AddWithValue("@subeKodu", subeKodu);

                                        kitapCommand.ExecuteNonQuery(); // Kitabı veritabanına ekle
                                    }

                                    bagislananKitaplar.Add(kitapAdi); // Kitap adını listeye ekle
                                }
                            }
                        }
                    }

                    // ListBox'a bağışlanan kitapları ekleyin
                    listBoxKitaplar.Items.Clear(); // Önceki kitapları temizle
                    foreach (var kitap in bagislananKitaplar)
                    {
                        listBoxKitaplar.Items.Add(kitap); // Her bir kitabı ListBox'a ekle
                    }

                    MessageBox.Show("Bağış başarıyla eklendi ve kitaplar kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listBoxKitaplar.Visible = true;
                    label3.Visible = true;
                }
                BagisBilgileriniYukle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        // Üyenin var olup olmadığını kontrol eden metot
        private bool UyeVarMi(int uyeID)
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Uyeler WHERE kisiID = @uyeID";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@uyeID", uyeID);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0; // Eğer kayıt varsa true döner
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Seçilen satırın ilgili sütunundaki değeri al
                if (e.RowIndex >= 0) // Geçerli bir satır mı?
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex]; // Seçilen satır
                    txtUyeID.Text = row.Cells["kisiID"].Value.ToString(); // "kisiID" sütunundan değer al
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
