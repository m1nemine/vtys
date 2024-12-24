namespace denden
{
    partial class UyeIslemleriForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cikis = new System.Windows.Forms.Button();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.uyeGuncelle = new System.Windows.Forms.Button();
            this.uyeSil = new System.Windows.Forms.Button();
            this.uyeEkle = new System.Windows.Forms.Button();
            this.btnAnaSayfa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cikis
            // 
            this.cikis.Font = new System.Drawing.Font("Impact", 9F);
            this.cikis.Location = new System.Drawing.Point(143, 36);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(75, 33);
            this.cikis.TabIndex = 32;
            this.cikis.Text = "Çıkış";
            this.cikis.UseVisualStyleBackColor = true;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // txtAdres
            // 
            this.txtAdres.Font = new System.Drawing.Font("Impact", 9F);
            this.txtAdres.Location = new System.Drawing.Point(635, 321);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(175, 26);
            this.txtAdres.TabIndex = 26;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Font = new System.Drawing.Font("Impact", 9F);
            this.txtTelefon.Location = new System.Drawing.Point(635, 279);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(175, 26);
            this.txtTelefon.TabIndex = 25;
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Impact", 9F);
            this.txtMail.Location = new System.Drawing.Point(635, 239);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(175, 26);
            this.txtMail.TabIndex = 24;
            // 
            // txtSoyad
            // 
            this.txtSoyad.Font = new System.Drawing.Font("Impact", 9F);
            this.txtSoyad.Location = new System.Drawing.Point(635, 197);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(175, 26);
            this.txtSoyad.TabIndex = 23;
            // 
            // txtAd
            // 
            this.txtAd.Font = new System.Drawing.Font("Impact", 9F);
            this.txtAd.Location = new System.Drawing.Point(635, 149);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(175, 26);
            this.txtAd.TabIndex = 22;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(569, 305);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // uyeGuncelle
            // 
            this.uyeGuncelle.Font = new System.Drawing.Font("Impact", 9F);
            this.uyeGuncelle.Location = new System.Drawing.Point(870, 326);
            this.uyeGuncelle.Name = "uyeGuncelle";
            this.uyeGuncelle.Size = new System.Drawing.Size(151, 69);
            this.uyeGuncelle.TabIndex = 20;
            this.uyeGuncelle.Text = "Üye güncelle";
            this.uyeGuncelle.UseVisualStyleBackColor = true;
            this.uyeGuncelle.Click += new System.EventHandler(this.uyeGuncelle_Click);
            // 
            // uyeSil
            // 
            this.uyeSil.Font = new System.Drawing.Font("Impact", 9F);
            this.uyeSil.Location = new System.Drawing.Point(870, 197);
            this.uyeSil.Name = "uyeSil";
            this.uyeSil.Size = new System.Drawing.Size(151, 57);
            this.uyeSil.TabIndex = 19;
            this.uyeSil.Text = "Üye Sil";
            this.uyeSil.UseVisualStyleBackColor = true;
            this.uyeSil.Click += new System.EventHandler(this.uyeSil_Click);
            // 
            // uyeEkle
            // 
            this.uyeEkle.Font = new System.Drawing.Font("Impact", 9F);
            this.uyeEkle.Location = new System.Drawing.Point(870, 71);
            this.uyeEkle.Name = "uyeEkle";
            this.uyeEkle.Size = new System.Drawing.Size(151, 58);
            this.uyeEkle.TabIndex = 18;
            this.uyeEkle.Text = "Üye Ekle";
            this.uyeEkle.UseVisualStyleBackColor = true;
            this.uyeEkle.Click += new System.EventHandler(this.uyeEkle_Click);
            // 
            // btnAnaSayfa
            // 
            this.btnAnaSayfa.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAnaSayfa.Location = new System.Drawing.Point(31, 33);
            this.btnAnaSayfa.Name = "btnAnaSayfa";
            this.btnAnaSayfa.Size = new System.Drawing.Size(81, 36);
            this.btnAnaSayfa.TabIndex = 17;
            this.btnAnaSayfa.Text = "geri dön";
            this.btnAnaSayfa.UseVisualStyleBackColor = true;
            this.btnAnaSayfa.Click += new System.EventHandler(this.btnAnaSayfa_Click);
            // 
            // UyeIslemleriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::denden.Properties.Resources.ankara_kutuphane_1500x500;
            this.ClientSize = new System.Drawing.Size(1041, 461);
            this.Controls.Add(this.cikis);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.uyeGuncelle);
            this.Controls.Add(this.uyeSil);
            this.Controls.Add(this.uyeEkle);
            this.Controls.Add(this.btnAnaSayfa);
            this.Name = "UyeIslemleriForm";
            this.Text = "UyeIslemleriForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cikis;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button uyeGuncelle;
        private System.Windows.Forms.Button uyeSil;
        private System.Windows.Forms.Button uyeEkle;
        private System.Windows.Forms.Button btnAnaSayfa;
    }
}