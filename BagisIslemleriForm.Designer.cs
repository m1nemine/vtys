namespace denden
{
    partial class BagisIslemleriForm
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txtUyeID = new System.Windows.Forms.TextBox();
            this.txtKitapAdedi = new System.Windows.Forms.TextBox();
            this.bagisEkle = new System.Windows.Forms.Button();
            this.txtAciklama = new System.Windows.Forms.TextBox();
            this.listBoxKitaplar = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // cikis
            // 
            this.cikis.Font = new System.Drawing.Font("Impact", 9F);
            this.cikis.Location = new System.Drawing.Point(130, 24);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(80, 29);
            this.cikis.TabIndex = 5;
            this.cikis.Text = "çıkış";
            this.cikis.UseVisualStyleBackColor = true;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // geriDon
            // 
            this.geriDon.Font = new System.Drawing.Font("Impact", 9F);
            this.geriDon.Location = new System.Drawing.Point(22, 24);
            this.geriDon.Name = "geriDon";
            this.geriDon.Size = new System.Drawing.Size(80, 29);
            this.geriDon.TabIndex = 4;
            this.geriDon.Text = "geri dön";
            this.geriDon.UseVisualStyleBackColor = true;
            this.geriDon.Click += new System.EventHandler(this.geriDon_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(435, 188);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(527, 95);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(494, 188);
            this.dataGridView2.TabIndex = 7;
            // 
            // txtUyeID
            // 
            this.txtUyeID.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUyeID.Location = new System.Drawing.Point(22, 331);
            this.txtUyeID.Name = "txtUyeID";
            this.txtUyeID.Size = new System.Drawing.Size(137, 26);
            this.txtUyeID.TabIndex = 8;
            // 
            // txtKitapAdedi
            // 
            this.txtKitapAdedi.Font = new System.Drawing.Font("Impact", 9F);
            this.txtKitapAdedi.Location = new System.Drawing.Point(22, 403);
            this.txtKitapAdedi.Name = "txtKitapAdedi";
            this.txtKitapAdedi.Size = new System.Drawing.Size(137, 26);
            this.txtKitapAdedi.TabIndex = 9;
            // 
            // bagisEkle
            // 
            this.bagisEkle.Font = new System.Drawing.Font("Impact", 9F);
            this.bagisEkle.Location = new System.Drawing.Point(243, 373);
            this.bagisEkle.Name = "bagisEkle";
            this.bagisEkle.Size = new System.Drawing.Size(161, 30);
            this.bagisEkle.TabIndex = 12;
            this.bagisEkle.Text = "Bağış Ekle";
            this.bagisEkle.UseVisualStyleBackColor = true;
            this.bagisEkle.Click += new System.EventHandler(this.bagisEkle_Click);
            // 
            // txtAciklama
            // 
            this.txtAciklama.Font = new System.Drawing.Font("Impact", 9F);
            this.txtAciklama.Location = new System.Drawing.Point(22, 461);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(137, 26);
            this.txtAciklama.TabIndex = 13;
            // 
            // listBoxKitaplar
            // 
            this.listBoxKitaplar.FormattingEnabled = true;
            this.listBoxKitaplar.ItemHeight = 16;
            this.listBoxKitaplar.Location = new System.Drawing.Point(543, 319);
            this.listBoxKitaplar.Name = "listBoxKitaplar";
            this.listBoxKitaplar.Size = new System.Drawing.Size(443, 164);
            this.listBoxKitaplar.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Bağışlanan Kitaplar:";
            // 
            // BagisIslemleriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::denden.Properties.Resources.ankara_kutuphane_1500x500;
            this.ClientSize = new System.Drawing.Size(1107, 494);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxKitaplar);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.bagisEkle);
            this.Controls.Add(this.txtKitapAdedi);
            this.Controls.Add(this.txtUyeID);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cikis);
            this.Controls.Add(this.geriDon);
            this.Name = "BagisIslemleriForm";
            this.Text = "BagisIslemleriForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cikis;
        private System.Windows.Forms.Button geriDon;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtUyeID;
        private System.Windows.Forms.TextBox txtKitapAdedi;
        private System.Windows.Forms.Button bagisEkle;
        private System.Windows.Forms.TextBox txtAciklama;
        private System.Windows.Forms.ListBox listBoxKitaplar;
        private System.Windows.Forms.Label label3;
    }
}