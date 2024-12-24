namespace denden
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.calisanIslemleri = new System.Windows.Forms.Button();
            this.uyeIslemleri = new System.Windows.Forms.Button();
            this.kitapIslemleri = new System.Windows.Forms.Button();
            this.tedarik = new System.Windows.Forms.Button();
            this.etkinlikler = new System.Windows.Forms.Button();
            this.bagisIslemleri = new System.Windows.Forms.Button();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.ara = new System.Windows.Forms.Button();
            this.listBoxSonuclar = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // calisanIslemleri
            // 
            this.calisanIslemleri.BackColor = System.Drawing.Color.Sienna;
            this.calisanIslemleri.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.calisanIslemleri.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.calisanIslemleri.Location = new System.Drawing.Point(668, 88);
            this.calisanIslemleri.Name = "calisanIslemleri";
            this.calisanIslemleri.Size = new System.Drawing.Size(208, 61);
            this.calisanIslemleri.TabIndex = 0;
            this.calisanIslemleri.Text = "Çalışan İşlemleri";
            this.calisanIslemleri.UseVisualStyleBackColor = false;
            this.calisanIslemleri.Click += new System.EventHandler(this.calisanIslemleri_Click);
            // 
            // uyeIslemleri
            // 
            this.uyeIslemleri.BackColor = System.Drawing.Color.Sienna;
            this.uyeIslemleri.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.uyeIslemleri.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.uyeIslemleri.Location = new System.Drawing.Point(886, 86);
            this.uyeIslemleri.Name = "uyeIslemleri";
            this.uyeIslemleri.Size = new System.Drawing.Size(208, 63);
            this.uyeIslemleri.TabIndex = 1;
            this.uyeIslemleri.Text = "Üye İşlemleri";
            this.uyeIslemleri.UseVisualStyleBackColor = false;
            this.uyeIslemleri.Click += new System.EventHandler(this.uyeIslemleri_Click);
            // 
            // kitapIslemleri
            // 
            this.kitapIslemleri.BackColor = System.Drawing.Color.Sienna;
            this.kitapIslemleri.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kitapIslemleri.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.kitapIslemleri.Location = new System.Drawing.Point(668, 197);
            this.kitapIslemleri.Name = "kitapIslemleri";
            this.kitapIslemleri.Size = new System.Drawing.Size(208, 65);
            this.kitapIslemleri.TabIndex = 2;
            this.kitapIslemleri.Text = "Kitap İşlemleri";
            this.kitapIslemleri.UseVisualStyleBackColor = false;
            this.kitapIslemleri.Click += new System.EventHandler(this.kitapIslemleri_Click);
            // 
            // tedarik
            // 
            this.tedarik.BackColor = System.Drawing.Color.Sienna;
            this.tedarik.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tedarik.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.tedarik.Location = new System.Drawing.Point(886, 197);
            this.tedarik.Name = "tedarik";
            this.tedarik.Size = new System.Drawing.Size(208, 65);
            this.tedarik.TabIndex = 5;
            this.tedarik.Text = "Tedarik İşlemleri";
            this.tedarik.UseVisualStyleBackColor = false;
            this.tedarik.Click += new System.EventHandler(this.tedarik_Click);
            // 
            // etkinlikler
            // 
            this.etkinlikler.BackColor = System.Drawing.Color.Sienna;
            this.etkinlikler.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.etkinlikler.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.etkinlikler.Location = new System.Drawing.Point(882, 311);
            this.etkinlikler.Name = "etkinlikler";
            this.etkinlikler.Size = new System.Drawing.Size(212, 63);
            this.etkinlikler.TabIndex = 4;
            this.etkinlikler.Text = "Etkinlikler";
            this.etkinlikler.UseVisualStyleBackColor = false;
            this.etkinlikler.Click += new System.EventHandler(this.etkinlikler_Click);
            // 
            // bagisIslemleri
            // 
            this.bagisIslemleri.BackColor = System.Drawing.Color.Sienna;
            this.bagisIslemleri.Font = new System.Drawing.Font("Impact", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bagisIslemleri.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.bagisIslemleri.Location = new System.Drawing.Point(668, 311);
            this.bagisIslemleri.Name = "bagisIslemleri";
            this.bagisIslemleri.Size = new System.Drawing.Size(208, 61);
            this.bagisIslemleri.TabIndex = 3;
            this.bagisIslemleri.Text = "Bağış İşlemleri";
            this.bagisIslemleri.UseVisualStyleBackColor = false;
            this.bagisIslemleri.Click += new System.EventHandler(this.bagisIslemleri_Click);
            // 
            // txtAra
            // 
            this.txtAra.BackColor = System.Drawing.Color.Tan;
            this.txtAra.Location = new System.Drawing.Point(42, 88);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(241, 22);
            this.txtAra.TabIndex = 6;
            // 
            // ara
            // 
            this.ara.BackColor = System.Drawing.Color.Silver;
            this.ara.BackgroundImage = global::denden.Properties.Resources.common_search_lookup_glyph_512;
            this.ara.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ara.Location = new System.Drawing.Point(311, 69);
            this.ara.Name = "ara";
            this.ara.Size = new System.Drawing.Size(83, 53);
            this.ara.TabIndex = 7;
            this.ara.Text = "ARA";
            this.ara.UseVisualStyleBackColor = false;
            this.ara.Click += new System.EventHandler(this.ara_Click);
            // 
            // listBoxSonuclar
            // 
            this.listBoxSonuclar.FormattingEnabled = true;
            this.listBoxSonuclar.ItemHeight = 16;
            this.listBoxSonuclar.Location = new System.Drawing.Point(12, 207);
            this.listBoxSonuclar.Name = "listBoxSonuclar";
            this.listBoxSonuclar.Size = new System.Drawing.Size(640, 180);
            this.listBoxSonuclar.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::denden.Properties.Resources.ankara_kutuphane_1500x500;
            this.ClientSize = new System.Drawing.Size(1106, 507);
            this.Controls.Add(this.listBoxSonuclar);
            this.Controls.Add(this.ara);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.tedarik);
            this.Controls.Add(this.etkinlikler);
            this.Controls.Add(this.bagisIslemleri);
            this.Controls.Add(this.kitapIslemleri);
            this.Controls.Add(this.uyeIslemleri);
            this.Controls.Add(this.calisanIslemleri);
            this.Name = "Form1";
            this.Text = "Form1";
            //this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calisanIslemleri;
        private System.Windows.Forms.Button uyeIslemleri;
        private System.Windows.Forms.Button kitapIslemleri;
        private System.Windows.Forms.Button tedarik;
        private System.Windows.Forms.Button etkinlikler;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Button ara;
        private System.Windows.Forms.ListBox listBoxSonuclar;
        private System.Windows.Forms.Button bagisIslemleri;
    }
}

