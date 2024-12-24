namespace denden
{
    partial class KitapIslemleriForm
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
            this.geriDon = new System.Windows.Forms.Button();
            this.cikis = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.txtKitapID = new System.Windows.Forms.TextBox();
            this.txtUyeID = new System.Windows.Forms.TextBox();
            this.btnOduncVer = new System.Windows.Forms.Button();
            this.btnIadeAl = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // geriDon
            // 
            this.geriDon.Font = new System.Drawing.Font("Impact", 9F);
            this.geriDon.Location = new System.Drawing.Point(12, 12);
            this.geriDon.Name = "geriDon";
            this.geriDon.Size = new System.Drawing.Size(80, 29);
            this.geriDon.TabIndex = 0;
            this.geriDon.Text = "geri dön";
            this.geriDon.UseVisualStyleBackColor = true;
            this.geriDon.Click += new System.EventHandler(this.geriDon_Click);
            // 
            // cikis
            // 
            this.cikis.Font = new System.Drawing.Font("Impact", 9F);
            this.cikis.Location = new System.Drawing.Point(125, 12);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(80, 29);
            this.cikis.TabIndex = 1;
            this.cikis.Text = "çıkış";
            this.cikis.UseVisualStyleBackColor = true;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(268, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(883, 339);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(146, 441);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(653, 263);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(866, 441);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersWidth = 51;
            this.dataGridView4.RowTemplate.Height = 24;
            this.dataGridView4.Size = new System.Drawing.Size(425, 263);
            this.dataGridView4.TabIndex = 5;
            // 
            // txtKitapID
            // 
            this.txtKitapID.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKitapID.ForeColor = System.Drawing.SystemColors.Window;
            this.txtKitapID.Location = new System.Drawing.Point(26, 103);
            this.txtKitapID.Name = "txtKitapID";
            this.txtKitapID.Size = new System.Drawing.Size(211, 32);
            this.txtKitapID.TabIndex = 6;
            // 
            // txtUyeID
            // 
            this.txtUyeID.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUyeID.Location = new System.Drawing.Point(26, 175);
            this.txtUyeID.Name = "txtUyeID";
            this.txtUyeID.Size = new System.Drawing.Size(211, 32);
            this.txtUyeID.TabIndex = 8;
            // 
            // btnOduncVer
            // 
            this.btnOduncVer.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOduncVer.Location = new System.Drawing.Point(63, 241);
            this.btnOduncVer.Name = "btnOduncVer";
            this.btnOduncVer.Size = new System.Drawing.Size(142, 48);
            this.btnOduncVer.TabIndex = 9;
            this.btnOduncVer.Text = "Ödünç Ver";
            this.btnOduncVer.UseVisualStyleBackColor = true;
            this.btnOduncVer.Click += new System.EventHandler(this.btnOduncVer_Click);
            // 
            // btnIadeAl
            // 
            this.btnIadeAl.Font = new System.Drawing.Font("Impact", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIadeAl.Location = new System.Drawing.Point(63, 326);
            this.btnIadeAl.Name = "btnIadeAl";
            this.btnIadeAl.Size = new System.Drawing.Size(142, 43);
            this.btnIadeAl.TabIndex = 10;
            this.btnIadeAl.Text = "İade al";
            this.btnIadeAl.UseVisualStyleBackColor = true;
            this.btnIadeAl.Click += new System.EventHandler(this.btnIadeAl_Click);
            // 
            // KitapIslemleriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.BackgroundImage = global::denden.Properties.Resources.ankara_kutuphane_1500x500;
            this.ClientSize = new System.Drawing.Size(1303, 745);
            this.Controls.Add(this.btnIadeAl);
            this.Controls.Add(this.btnOduncVer);
            this.Controls.Add(this.txtUyeID);
            this.Controls.Add(this.txtKitapID);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cikis);
            this.Controls.Add(this.geriDon);
            this.Name = "KitapIslemleriForm";
            this.Text = "KitapIslemleriForm";
            this.Load += new System.EventHandler(this.KitapIslemleriForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button geriDon;
        private System.Windows.Forms.Button cikis;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.TextBox txtKitapID;
        private System.Windows.Forms.TextBox txtUyeID;
        private System.Windows.Forms.Button btnOduncVer;
        private System.Windows.Forms.Button btnIadeAl;
    }
}