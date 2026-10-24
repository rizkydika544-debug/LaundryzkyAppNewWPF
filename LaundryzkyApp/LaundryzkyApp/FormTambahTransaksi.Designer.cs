namespace LaundryzkyApp
{
    partial class FormTambahTransaksi
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
            this.lblJudul = new System.Windows.Forms.Label();
            this.panelGaris = new System.Windows.Forms.Panel();
            this.lblPelanggan = new System.Windows.Forms.Label();
            this.cmbPelanggan = new System.Windows.Forms.ComboBox();
            this.lblLayanan = new System.Windows.Forms.Label();
            this.cmbLayanan = new System.Windows.Forms.ComboBox();
            this.nudBerat = new System.Windows.Forms.NumericUpDown();
            this.llblBerat = new System.Windows.Forms.Label();
            this.lblStatusBayar = new System.Windows.Forms.Label();
            this.cmbBayar = new System.Windows.Forms.ComboBox();
            this.panelTotalBayar = new System.Windows.Forms.Panel();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudBerat)).BeginInit();
            this.panelTotalBayar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.lblJudul.Location = new System.Drawing.Point(40, 25);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(185, 30);
            this.lblJudul.TabIndex = 11;
            this.lblJudul.Text = "Tambah Transaksi";
            // 
            // panelGaris
            // 
            this.panelGaris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.panelGaris.Location = new System.Drawing.Point(40, 65);
            this.panelGaris.Name = "panelGaris";
            this.panelGaris.Size = new System.Drawing.Size(450, 2);
            this.panelGaris.TabIndex = 12;
            // 
            // lblPelanggan
            // 
            this.lblPelanggan.AutoSize = true;
            this.lblPelanggan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelanggan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblPelanggan.Location = new System.Drawing.Point(40, 85);
            this.lblPelanggan.Name = "lblPelanggan";
            this.lblPelanggan.Size = new System.Drawing.Size(73, 17);
            this.lblPelanggan.TabIndex = 13;
            this.lblPelanggan.Text = "Pelanggan";
            // 
            // cmbPelanggan
            // 
            this.cmbPelanggan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.cmbPelanggan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPelanggan.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cmbPelanggan.FormattingEnabled = true;
            this.cmbPelanggan.Location = new System.Drawing.Point(40, 110);
            this.cmbPelanggan.Name = "cmbPelanggan";
            this.cmbPelanggan.Size = new System.Drawing.Size(450, 21);
            this.cmbPelanggan.TabIndex = 14;
            this.cmbPelanggan.SelectedIndexChanged += new System.EventHandler(this.cmbPelanggan_SelectedIndexChanged);
            // 
            // lblLayanan
            // 
            this.lblLayanan.AutoSize = true;
            this.lblLayanan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLayanan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblLayanan.Location = new System.Drawing.Point(40, 155);
            this.lblLayanan.Name = "lblLayanan";
            this.lblLayanan.Size = new System.Drawing.Size(94, 17);
            this.lblLayanan.TabIndex = 15;
            this.lblLayanan.Text = "Jenis Layanan";
            // 
            // cmbLayanan
            // 
            this.cmbLayanan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.cmbLayanan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayanan.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cmbLayanan.FormattingEnabled = true;
            this.cmbLayanan.Location = new System.Drawing.Point(40, 180);
            this.cmbLayanan.Name = "cmbLayanan";
            this.cmbLayanan.Size = new System.Drawing.Size(450, 21);
            this.cmbLayanan.TabIndex = 16;
            this.cmbLayanan.SelectedIndexChanged += new System.EventHandler(this.cmbLayanan_SelectedIndexChanged);
            // 
            // nudBerat
            // 
            this.nudBerat.DecimalPlaces = 1;
            this.nudBerat.Location = new System.Drawing.Point(40, 250);
            this.nudBerat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBerat.Name = "nudBerat";
            this.nudBerat.Size = new System.Drawing.Size(210, 20);
            this.nudBerat.TabIndex = 17;
            this.nudBerat.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudBerat.ValueChanged += new System.EventHandler(this.nudBerat_ValueChanged);
            // 
            // llblBerat
            // 
            this.llblBerat.AutoSize = true;
            this.llblBerat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblBerat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.llblBerat.Location = new System.Drawing.Point(40, 225);
            this.llblBerat.Name = "llblBerat";
            this.llblBerat.Size = new System.Drawing.Size(70, 17);
            this.llblBerat.TabIndex = 18;
            this.llblBerat.Text = "Berat (Kg)";
            // 
            // lblStatusBayar
            // 
            this.lblStatusBayar.AutoSize = true;
            this.lblStatusBayar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusBayar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblStatusBayar.Location = new System.Drawing.Point(280, 225);
            this.lblStatusBayar.Name = "lblStatusBayar";
            this.lblStatusBayar.Size = new System.Drawing.Size(126, 17);
            this.lblStatusBayar.TabIndex = 19;
            this.lblStatusBayar.Text = "Status Pembayaran";
            // 
            // cmbBayar
            // 
            this.cmbBayar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.cmbBayar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBayar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cmbBayar.FormattingEnabled = true;
            this.cmbBayar.Location = new System.Drawing.Point(280, 250);
            this.cmbBayar.Name = "cmbBayar";
            this.cmbBayar.Size = new System.Drawing.Size(210, 21);
            this.cmbBayar.TabIndex = 20;
            this.cmbBayar.SelectedIndexChanged += new System.EventHandler(this.cmbBayar_SelectedIndexChanged);
            // 
            // panelTotalBayar
            // 
            this.panelTotalBayar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.panelTotalBayar.Controls.Add(this.lblTotal);
            this.panelTotalBayar.Controls.Add(this.lblTotalTitle);
            this.panelTotalBayar.Location = new System.Drawing.Point(40, 300);
            this.panelTotalBayar.Name = "panelTotalBayar";
            this.panelTotalBayar.Size = new System.Drawing.Size(450, 60);
            this.panelTotalBayar.TabIndex = 21;
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalTitle.Location = new System.Drawing.Point(15, 10);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(69, 15);
            this.lblTotalTitle.TabIndex = 22;
            this.lblTotalTitle.Text = "Total Biaya:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.lblTotal.Location = new System.Drawing.Point(15, 28);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(32, 15);
            this.lblTotal.TabIndex = 23;
            this.lblTotal.Text = "Rp 0";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(40, 370);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 15);
            this.lblError.TabIndex = 22;
            this.lblError.Visible = false;
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Location = new System.Drawing.Point(150, 410);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(130, 40);
            this.btnSimpan.TabIndex = 23;
            this.btnSimpan.Text = "SImpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatal.ForeColor = System.Drawing.Color.White;
            this.btnBatal.Location = new System.Drawing.Point(290, 410);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(130, 40);
            this.btnBatal.TabIndex = 24;
            this.btnBatal.Text = "Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // FormTambahTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 481);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.panelTotalBayar);
            this.Controls.Add(this.cmbBayar);
            this.Controls.Add(this.lblStatusBayar);
            this.Controls.Add(this.llblBerat);
            this.Controls.Add(this.nudBerat);
            this.Controls.Add(this.cmbLayanan);
            this.Controls.Add(this.lblLayanan);
            this.Controls.Add(this.cmbPelanggan);
            this.Controls.Add(this.lblPelanggan);
            this.Controls.Add(this.panelGaris);
            this.Controls.Add(this.lblJudul);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormTambahTransaksi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tambah Transaksi";
            this.Load += new System.EventHandler(this.FormTambahTransaksi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudBerat)).EndInit();
            this.panelTotalBayar.ResumeLayout(false);
            this.panelTotalBayar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Panel panelGaris;
        private System.Windows.Forms.Label lblPelanggan;
        private System.Windows.Forms.ComboBox cmbPelanggan;
        private System.Windows.Forms.Label lblLayanan;
        private System.Windows.Forms.ComboBox cmbLayanan;
        private System.Windows.Forms.NumericUpDown nudBerat;
        private System.Windows.Forms.Label llblBerat;
        private System.Windows.Forms.Label lblStatusBayar;
        private System.Windows.Forms.ComboBox cmbBayar;
        private System.Windows.Forms.Panel panelTotalBayar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;
    }
}
