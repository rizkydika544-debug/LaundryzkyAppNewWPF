namespace LaundryzkyApp
{
    partial class FormPembayaran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPembayaran));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTotalHeader = new System.Windows.Forms.Label();
            this.lblTotalTagihanHeader = new System.Windows.Forms.Label();
            this.lblPilihPembayaranHeader = new System.Windows.Forms.Label();
            this.rbTunai = new System.Windows.Forms.RadioButton();
            this.rbQRIS = new System.Windows.Forms.RadioButton();
            this.panelTunai = new System.Windows.Forms.Panel();
            this.panelQRIS = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.picQRIS = new System.Windows.Forms.PictureBox();
            this.lblKembalian = new System.Windows.Forms.Label();
            this.lblKembalianHead = new System.Windows.Forms.Label();
            this.btn100k = new System.Windows.Forms.Button();
            this.btn50k = new System.Windows.Forms.Button();
            this.btn20k = new System.Windows.Forms.Button();
            this.btn10k = new System.Windows.Forms.Button();
            this.txtUangBayar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKonfirmasi = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.panelTunai.SuspendLayout();
            this.panelQRIS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRIS)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.pnlHeader.Controls.Add(this.lblTotalHeader);
            this.pnlHeader.Controls.Add(this.lblTotalTagihanHeader);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(464, 90);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTotalHeader
            // 
            this.lblTotalHeader.AutoSize = true;
            this.lblTotalHeader.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalHeader.ForeColor = System.Drawing.Color.White;
            this.lblTotalHeader.Location = new System.Drawing.Point(18, 35);
            this.lblTotalHeader.Name = "lblTotalHeader";
            this.lblTotalHeader.Size = new System.Drawing.Size(79, 40);
            this.lblTotalHeader.TabIndex = 1;
            this.lblTotalHeader.Text = "Rp 0";
            // 
            // lblTotalTagihanHeader
            // 
            this.lblTotalTagihanHeader.AutoSize = true;
            this.lblTotalTagihanHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTagihanHeader.ForeColor = System.Drawing.Color.LightCyan;
            this.lblTotalTagihanHeader.Location = new System.Drawing.Point(20, 15);
            this.lblTotalTagihanHeader.Name = "lblTotalTagihanHeader";
            this.lblTotalTagihanHeader.Size = new System.Drawing.Size(110, 17);
            this.lblTotalTagihanHeader.TabIndex = 0;
            this.lblTotalTagihanHeader.Text = "TOTAL TAGIHAN";
            // 
            // lblPilihPembayaranHeader
            // 
            this.lblPilihPembayaranHeader.AutoSize = true;
            this.lblPilihPembayaranHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPilihPembayaranHeader.Location = new System.Drawing.Point(25, 110);
            this.lblPilihPembayaranHeader.Name = "lblPilihPembayaranHeader";
            this.lblPilihPembayaranHeader.Size = new System.Drawing.Size(171, 17);
            this.lblPilihPembayaranHeader.TabIndex = 1;
            this.lblPilihPembayaranHeader.Text = "Pilih Metode Pembayaran:";
            // 
            // rbTunai
            // 
            this.rbTunai.AutoSize = true;
            this.rbTunai.Checked = true;
            this.rbTunai.Location = new System.Drawing.Point(30, 138);
            this.rbTunai.Name = "rbTunai";
            this.rbTunai.Size = new System.Drawing.Size(85, 17);
            this.rbTunai.TabIndex = 2;
            this.rbTunai.TabStop = true;
            this.rbTunai.Text = "Tunai (Cash)";
            this.rbTunai.UseVisualStyleBackColor = true;
            this.rbTunai.CheckedChanged += new System.EventHandler(this.rbTunai_CheckedChanged);
            // 
            // rbQRIS
            // 
            this.rbQRIS.AutoSize = true;
            this.rbQRIS.Location = new System.Drawing.Point(210, 138);
            this.rbQRIS.Name = "rbQRIS";
            this.rbQRIS.Size = new System.Drawing.Size(112, 17);
            this.rbQRIS.TabIndex = 2;
            this.rbQRIS.Text = "QRIS / Non-Tunai";
            this.rbQRIS.UseVisualStyleBackColor = true;
            this.rbQRIS.CheckedChanged += new System.EventHandler(this.rbQRIS_CheckedChanged);
            // 
            // panelTunai
            // 
            this.panelTunai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTunai.Controls.Add(this.panelQRIS);
            this.panelTunai.Controls.Add(this.lblKembalian);
            this.panelTunai.Controls.Add(this.lblKembalianHead);
            this.panelTunai.Controls.Add(this.btn100k);
            this.panelTunai.Controls.Add(this.btn50k);
            this.panelTunai.Controls.Add(this.btn20k);
            this.panelTunai.Controls.Add(this.btn10k);
            this.panelTunai.Controls.Add(this.txtUangBayar);
            this.panelTunai.Controls.Add(this.label1);
            this.panelTunai.Location = new System.Drawing.Point(25, 180);
            this.panelTunai.Name = "panelTunai";
            this.panelTunai.Size = new System.Drawing.Size(415, 230);
            this.panelTunai.TabIndex = 3;
            // 
            // panelQRIS
            // 
            this.panelQRIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelQRIS.Controls.Add(this.label2);
            this.panelQRIS.Controls.Add(this.picQRIS);
            this.panelQRIS.Location = new System.Drawing.Point(-1, -1);
            this.panelQRIS.Name = "panelQRIS";
            this.panelQRIS.Size = new System.Drawing.Size(415, 230);
            this.panelQRIS.TabIndex = 11;
            this.panelQRIS.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(192, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 51);
            this.label2.TabIndex = 1;
            this.label2.Text = "Scan QRIS Laundryzky \r\nMenggunakan GoPay, OVO,\r\nShopeePay, Dana, atau Banking.";
            // 
            // picQRIS
            // 
            this.picQRIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQRIS.Image = ((System.Drawing.Image)(resources.GetObject("picQRIS.Image")));
            this.picQRIS.Location = new System.Drawing.Point(33, 21);
            this.picQRIS.Name = "picQRIS";
            this.picQRIS.Size = new System.Drawing.Size(137, 190);
            this.picQRIS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQRIS.TabIndex = 0;
            this.picQRIS.TabStop = false;
            // 
            // lblKembalian
            // 
            this.lblKembalian.AutoSize = true;
            this.lblKembalian.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKembalian.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblKembalian.Location = new System.Drawing.Point(15, 160);
            this.lblKembalian.Name = "lblKembalian";
            this.lblKembalian.Size = new System.Drawing.Size(58, 30);
            this.lblKembalian.TabIndex = 3;
            this.lblKembalian.Text = "Rp 0";
            // 
            // lblKembalianHead
            // 
            this.lblKembalianHead.AutoSize = true;
            this.lblKembalianHead.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKembalianHead.Location = new System.Drawing.Point(15, 135);
            this.lblKembalianHead.Name = "lblKembalianHead";
            this.lblKembalianHead.Size = new System.Drawing.Size(77, 17);
            this.lblKembalianHead.TabIndex = 3;
            this.lblKembalianHead.Text = "Kembalian:";
            // 
            // btn100k
            // 
            this.btn100k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.btn100k.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn100k.Location = new System.Drawing.Point(285, 80);
            this.btn100k.Name = "btn100k";
            this.btn100k.Size = new System.Drawing.Size(80, 32);
            this.btn100k.TabIndex = 2;
            this.btn100k.Text = "100rb";
            this.btn100k.UseVisualStyleBackColor = false;
            this.btn100k.Click += new System.EventHandler(this.btn100k_Click);
            // 
            // btn50k
            // 
            this.btn50k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.btn50k.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn50k.Location = new System.Drawing.Point(195, 80);
            this.btn50k.Name = "btn50k";
            this.btn50k.Size = new System.Drawing.Size(80, 32);
            this.btn50k.TabIndex = 2;
            this.btn50k.Text = "50rb";
            this.btn50k.UseVisualStyleBackColor = false;
            this.btn50k.Click += new System.EventHandler(this.btn50k_Click);
            // 
            // btn20k
            // 
            this.btn20k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.btn20k.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn20k.Location = new System.Drawing.Point(105, 80);
            this.btn20k.Name = "btn20k";
            this.btn20k.Size = new System.Drawing.Size(80, 32);
            this.btn20k.TabIndex = 2;
            this.btn20k.Text = "20rb";
            this.btn20k.UseVisualStyleBackColor = false;
            this.btn20k.Click += new System.EventHandler(this.btn20k_Click);
            // 
            // btn10k
            // 
            this.btn10k.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(248)))));
            this.btn10k.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn10k.Location = new System.Drawing.Point(15, 80);
            this.btn10k.Name = "btn10k";
            this.btn10k.Size = new System.Drawing.Size(80, 32);
            this.btn10k.TabIndex = 2;
            this.btn10k.Text = "10rb";
            this.btn10k.UseVisualStyleBackColor = false;
            this.btn10k.Click += new System.EventHandler(this.btn10k_Click);
            // 
            // txtUangBayar
            // 
            this.txtUangBayar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUangBayar.Location = new System.Drawing.Point(15, 35);
            this.txtUangBayar.Multiline = true;
            this.txtUangBayar.Name = "txtUangBayar";
            this.txtUangBayar.Size = new System.Drawing.Size(380, 35);
            this.txtUangBayar.TabIndex = 1;
            this.txtUangBayar.TextChanged += new System.EventHandler(this.txtUangBayar_TextChanged);
            this.txtUangBayar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUangBayar_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nominal Uang Bayar (Rp):";
            // 
            // btnKonfirmasi
            // 
            this.btnKonfirmasi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnKonfirmasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKonfirmasi.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKonfirmasi.ForeColor = System.Drawing.Color.White;
            this.btnKonfirmasi.Location = new System.Drawing.Point(25, 435);
            this.btnKonfirmasi.Name = "btnKonfirmasi";
            this.btnKonfirmasi.Size = new System.Drawing.Size(250, 48);
            this.btnKonfirmasi.TabIndex = 2;
            this.btnKonfirmasi.Text = "PROSES BAYAR";
            this.btnKonfirmasi.UseVisualStyleBackColor = false;
            this.btnKonfirmasi.Click += new System.EventHandler(this.btnKonfirmasi_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatal.ForeColor = System.Drawing.Color.Black;
            this.btnBatal.Location = new System.Drawing.Point(295, 435);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(145, 48);
            this.btnBatal.TabIndex = 2;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // FormPembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(464, 521);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnKonfirmasi);
            this.Controls.Add(this.panelTunai);
            this.Controls.Add(this.rbQRIS);
            this.Controls.Add(this.rbTunai);
            this.Controls.Add(this.lblPilihPembayaranHeader);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPembayaran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proses Pembayaran - Laundryzky";
            this.Load += new System.EventHandler(this.FormPembayaran_Load);
            this.Shown += new System.EventHandler(this.FormPembayaran_Shown);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.panelTunai.ResumeLayout(false);
            this.panelTunai.PerformLayout();
            this.panelQRIS.ResumeLayout(false);
            this.panelQRIS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRIS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTotalTagihanHeader;
        private System.Windows.Forms.Label lblTotalHeader;
        private System.Windows.Forms.Label lblPilihPembayaranHeader;
        private System.Windows.Forms.RadioButton rbTunai;
        private System.Windows.Forms.RadioButton rbQRIS;
        private System.Windows.Forms.Panel panelTunai;
        private System.Windows.Forms.TextBox txtUangBayar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn100k;
        private System.Windows.Forms.Button btn50k;
        private System.Windows.Forms.Button btn20k;
        private System.Windows.Forms.Button btn10k;
        private System.Windows.Forms.Label lblKembalianHead;
        private System.Windows.Forms.Label lblKembalian;
        private System.Windows.Forms.Button btnKonfirmasi;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Panel panelQRIS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picQRIS;
    }
}