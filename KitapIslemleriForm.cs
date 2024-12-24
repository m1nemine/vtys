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
using System.Xml.Linq;

namespace denden
{
    public partial class KitapIslemleriForm : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=emine1234;Database=kutuphane";
        private Dictionary<TextBox, string> defaultTexts = new Dictionary<TextBox, string>();
        public KitapIslemleriForm()
        {
            InitializeComponent();
            InitializeDefaultTexts();
            KitaplariYukle();
            UyeleriYukle();
            IslemleriYukle();
            dataGridView4.Visible = false;
        }
        private void InitializeDefaultTexts()
        {
            defaultTexts[txtKitapID] = "Kitap ID girin...";
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

        private void UyeleriYukle()
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = @"
                    SELECT u.kisiID, k.ad AS UyeAd, k.soyad AS UyeSoyad, k.telefonNo, 
                           k.mail, u.uyelikTarihi
                    FROM Uyeler u
                    JOIN Kisiler k ON u.kisiID = k.kisiID;
                ";

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable uyeler = new DataTable();
                        adapter.Fill(uyeler);
                        dataGridView2.DataSource = uyeler;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void IslemleriYukle()
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = @"
                    SELECT i.islemID, k.ad AS KitapAd, u.ad AS UyeAd, u.soyad AS UyeSoyad, 
                           i.islemTuru
                    FROM Islemler i
                    JOIN Kitaplar k ON i.kitapID = k.KitapID
                    JOIN Kisiler u ON i.uyeID = u.kisiID;
                ";

                    using (var adapter = new NpgsqlDataAdapter(query, connection))
                    {
                        DataTable islemler = new DataTable();
                        adapter.Fill(islemler);
                        dataGridView4.DataSource = islemler;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    txtKitapID.Text = row.Cells["KitapID"].Value.ToString(); // Kitap ID'sini al
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                    txtUyeID.Text = row.Cells["kisiID"].Value.ToString(); // Üye ID'sini al
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOduncVer_Click(object sender, EventArgs e)
        {
            int kitapID;
            int uyeID;

            // Kitap ID'sini al
            if (!int.TryParse(txtKitapID.Text, out kitapID))
            {
                MessageBox.Show("Geçerli bir Kitap ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Üye ID'sini al
            if (!int.TryParse(txtUyeID.Text, out uyeID))
            {
                MessageBox.Show("Geçerli bir Üye ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Kitap ID kontrolü
                    string kitapKontrolQuery = "SELECT COUNT(*) FROM Kitaplar WHERE KitapID = @kitapID";
                    using (var command = new NpgsqlCommand(kitapKontrolQuery, connection))
                    {
                        command.Parameters.AddWithValue("@kitapID", kitapID);
                        int kitapVarMi = Convert.ToInt32(command.ExecuteScalar());
                        if (kitapVarMi == 0)
                        {
                            MessageBox.Show("Bu ID'ye sahip bir kitap bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Üye ID kontrolü
                    string uyeKontrolQuery = "SELECT COUNT(*) FROM Uyeler WHERE kisiID = @uyeID";
                    using (var command = new NpgsqlCommand(uyeKontrolQuery, connection))
                    {
                        command.Parameters.AddWithValue("@uyeID", uyeID);
                        int uyeVarMi = Convert.ToInt32(command.ExecuteScalar());
                        if (uyeVarMi == 0)
                        {
                            MessageBox.Show("Bu ID'ye sahip bir üye bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Kitap ödünç durum kontrolü
                    string oduncDurumKontrolQuery = "SELECT durum FROM Kitaplar WHERE KitapID = @kitapID";
                    using (var command = new NpgsqlCommand(oduncDurumKontrolQuery, connection))
                    {
                        command.Parameters.AddWithValue("@kitapID", kitapID);
                        bool kitapDurum = (bool)command.ExecuteScalar();
                        if (!kitapDurum) // Eğer durum FALSE ise ödünçte
                        {
                            MessageBox.Show("Bu kitap şu anda ödünç verilmiş durumda.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // "kitap_odunc_verme" fonksiyonunu çağır
                    string functionQuery = "SELECT kitap_odunc_verme(@kitapID, @uyeID)";
                    using (var command = new NpgsqlCommand(functionQuery, connection))
                    {
                        command.Parameters.AddWithValue("@kitapID", kitapID);
                        command.Parameters.AddWithValue("@uyeID", uyeID);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kitap ödünç verildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IslemleriYukle(); // İşlemler listesini güncelle
                    KitaplariYukle(); // Kitap durumunu güncelle
                }
                dataGridView4.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIadeAl_Click(object sender, EventArgs e)
        {
            int kitapID;
            int uyeID;

            // Kitap ID'sini al
            if (!int.TryParse(txtKitapID.Text, out kitapID))
            {
                MessageBox.Show("Geçerli bir Kitap ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Üye ID'sini al
            if (!int.TryParse(txtUyeID.Text, out uyeID))
            {
                MessageBox.Show("Geçerli bir Üye ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Kitap ID kontrolü
                    string kitapKontrolQuery = "SELECT COUNT(*) FROM Kitaplar WHERE KitapID = @kitapID";
                    using (var command = new NpgsqlCommand(kitapKontrolQuery, connection))
                    {
                        command.Parameters.AddWithValue("@kitapID", kitapID);
                        int kitapVarMi = Convert.ToInt32(command.ExecuteScalar());
                        if (kitapVarMi == 0)
                        {
                            MessageBox.Show("Bu ID'ye sahip bir kitap bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Üye ID kontrolü
                    string uyeKontrolQuery = "SELECT COUNT(*) FROM Uyeler WHERE kisiID = @uyeID";
                    using (var command = new NpgsqlCommand(uyeKontrolQuery, connection))
                    {
                        command.Parameters.AddWithValue("@uyeID", uyeID);
                        int uyeVarMi = Convert.ToInt32(command.ExecuteScalar());
                        if (uyeVarMi == 0)
                        {
                            MessageBox.Show("Bu ID'ye sahip bir üye bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Ödünç kontrolü: Kitap bu üye tarafından ödünç alınmış mı?
                    string oduncKontrolQuery = @"
                SELECT COUNT(*) 
                FROM Islemler 
                WHERE kitapID = @kitapID 
                  AND uyeID = @uyeID 
                  AND islemTuru = 'ödünç'
                  AND NOT EXISTS (
                      SELECT 1 
                      FROM Islemler AS i2
                      WHERE i2.kitapID = Islemler.kitapID 
                        AND i2.uyeID = Islemler.uyeID 
                        AND i2.islemTuru = 'iade'
                  )";
                    using (var command = new NpgsqlCommand(oduncKontrolQuery, connection))
                    {
                        command.Parameters.AddWithValue("@kitapID", kitapID);
                        command.Parameters.AddWithValue("@uyeID", uyeID);
                        int oduncVarMi = Convert.ToInt32(command.ExecuteScalar());
                        if (oduncVarMi == 0)
                        {
                            MessageBox.Show("Bu kitap belirtilen üye tarafından ödünç alınmamış veya iade edilmiş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // "kitap_iade_verme" fonksiyonunu çağır
                    string functionQuery = "SELECT kitap_iade_verme(@kitapID, @uyeID)";
                    using (var command = new NpgsqlCommand(functionQuery, connection))
                    {
                        command.Parameters.AddWithValue("@kitapID", kitapID);
                        command.Parameters.AddWithValue("@uyeID", uyeID);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kitap iade alındı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IslemleriYukle(); // İşlemler listesini güncelle
                    KitaplariYukle(); // Kitap durumunu güncelle
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KitapIslemleriForm_Load(object sender, EventArgs e)
        {

        }
    }
}
