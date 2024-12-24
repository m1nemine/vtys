namespace denden
{
    partial class EtkinliklerForm
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
            this.geriDon = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtcalisanID = new System.Windows.Forms.TextBox();
            this.txtetkinlikAdi = new System.Windows.Forms.TextBox();
            this.txtaciklama = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.etkinlikEkle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cikis
            // 
            this.cikis.Font = new System.Drawing.Font("Impact", 9F);
            this.cikis.Location = new System.Drawing.Point(130, 21);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(80, 29);
            this.cikis.TabIndex = 3;
            this.cikis.Text = "çıkış";
            this.cikis.UseVisualStyleBackColor = true;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // geriDon
            // 
            this.geriDon.Font = new System.Drawing.Font("Impact", 9F);
            this.geriDon.Location = new System.Drawing.Point(22, 21);
            this.geriDon.Name = "geriDon";
            this.geriDon.Size = new System.Drawing.Size(80, 29);
            this.geriDon.TabIndex = 2;
            this.geriDon.Text = "geri dön";
            this.geriDon.UseVisualStyleBackColor = true;
            this.geriDon.Click += new System.EventHandler(this.geriDon_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(742, 109);
            this.dataGridView1.TabIndex = 4;
            // 
            // txtcalisanID
            // 
            this.txtcalisanID.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtcalisanID.Location = new System.Drawing.Point(46, 249);
            this.txtcalisanID.Name = "txtcalisanID";
            this.txtcalisanID.Size = new System.Drawing.Size(182, 26);
            this.txtcalisanID.TabIndex = 5;
            // 
            // txtetkinlikAdi
            // 
            this.txtetkinlikAdi.Font = new System.Drawing.Font("Impact", 9F);
            this.txtetkinlikAdi.Location = new System.Drawing.Point(46, 317);
            this.txtetkinlikAdi.Name = "txtetkinlikAdi";
            this.txtetkinlikAdi.Size = new System.Drawing.Size(182, 26);
            this.txtetkinlikAdi.TabIndex = 6;
            // 
            // txtaciklama
            // 
            this.txtaciklama.Font = new System.Drawing.Font("Impact", 9F);
            this.txtaciklama.Location = new System.Drawing.Point(46, 379);
            this.txtaciklama.Name = "txtaciklama";
            this.txtaciklama.Size = new System.Drawing.Size(182, 26);
            this.txtaciklama.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Impact", 9F);
            this.dateTimePicker1.Location = new System.Drawing.Point(287, 247);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(201, 26);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // etkinlikEkle
            // 
            this.etkinlikEkle.Font = new System.Drawing.Font("Impact", 9F);
            this.etkinlikEkle.Location = new System.Drawing.Point(338, 317);
            this.etkinlikEkle.Name = "etkinlikEkle";
            this.etkinlikEkle.Size = new System.Drawing.Size(110, 35);
            this.etkinlikEkle.TabIndex = 12;
            this.etkinlikEkle.Text = "Ekle";
            this.etkinlikEkle.UseVisualStyleBackColor = true;
            this.etkinlikEkle.Click += new System.EventHandler(this.etkinlikEkle_Click);
            // 
            // EtkinliklerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::denden.Properties.Resources.ankara_kutuphane_1500x500;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.etkinlikEkle);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtaciklama);
            this.Controls.Add(this.txtetkinlikAdi);
            this.Controls.Add(this.txtcalisanID);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cikis);
            this.Controls.Add(this.geriDon);
            this.Name = "EtkinliklerForm";
            this.Text = "EtkinliklerForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cikis;
        private System.Windows.Forms.Button geriDon;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtcalisanID;
        private System.Windows.Forms.TextBox txtetkinlikAdi;
        private System.Windows.Forms.TextBox txtaciklama;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button etkinlikEkle;
    }
}