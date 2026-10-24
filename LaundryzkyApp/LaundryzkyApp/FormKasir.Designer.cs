namespace LaundryzkyApp
{
    partial class FormKasir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKasir));
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.picIconLogout = new System.Windows.Forms.PictureBox();
            this.picIconPelanggan = new System.Windows.Forms.PictureBox();
            this.picIconTransaksi = new System.Windows.Forms.PictureBox();
            this.picIconPOS = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnMenuPelanggan = new System.Windows.Forms.Button();
            this.btnMenuTransaksi = new System.Windows.Forms.Button();
            this.btnMenuPOS = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.lblNamaUser = new System.Windows.Forms.Label();
            this.lblHalaman = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelPOS = new System.Windows.Forms.Panel();
            this.panelStrukPOS = new System.Windows.Forms.Panel();
            this.lblTotalBayarLive = new System.Windows.Forms.Label();
            this.lblTitleTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStrukStatus = new System.Windows.Forms.Label();
            this.lblStrukDetail = new System.Windows.Forms.Label();
            this.lblStrukLayanan = new System.Windows.Forms.Label();
            this.lblStrukPelanggan = new System.Windows.Forms.Label();
            this.lblHeaderStruk = new System.Windows.Forms.Label();
            this.panelInputPOS = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSimpanPOS = new System.Windows.Forms.Button();
            this.rbBayarSekarang = new System.Windows.Forms.RadioButton();
            this.rbBayarPasAmbil = new System.Windows.Forms.RadioButton();
            this.lblJudulPembayaran = new System.Windows.Forms.Label();
            this.lblHargaPerKg = new System.Windows.Forms.Label();
            this.txtBerat = new System.Windows.Forms.TextBox();
            this.lblBeratText = new System.Windows.Forms.Label();
            this.cmbLayanan = new System.Windows.Forms.ComboBox();
            this.lblJudulLayanan = new System.Windows.Forms.Label();
            this.btnTambahPelangganBaru = new System.Windows.Forms.Button();
            this.cmbPelanggan = new System.Windows.Forms.ComboBox();
            this.lblJudulPelanggan = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIconLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconPelanggan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconTransaksi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconPOS)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelPOS.SuspendLayout();
            this.panelStrukPOS.SuspendLayout();
            this.panelInputPOS.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.panelSidebar.Controls.Add(this.picIconLogout);
            this.panelSidebar.Controls.Add(this.picIconPelanggan);
            this.panelSidebar.Controls.Add(this.picIconTransaksi);
            this.panelSidebar.Controls.Add(this.picIconPOS);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnMenuPelanggan);
            this.panelSidebar.Controls.Add(this.btnMenuTransaksi);
            this.panelSidebar.Controls.Add(this.btnMenuPOS);
            this.panelSidebar.Controls.Add(this.lblRole);
            this.panelSidebar.Controls.Add(this.lblBrand);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 816);
            this.panelSidebar.TabIndex = 0;
            // 
            // picIconLogout
            // 
            this.picIconLogout.BackColor = System.Drawing.Color.Transparent;
            this.picIconLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picIconLogout.Image = ((System.Drawing.Image)(resources.GetObject("picIconLogout.Image")));
            this.picIconLogout.Location = new System.Drawing.Point(12, 250);
            this.picIconLogout.Name = "picIconLogout";
            this.picIconLogout.Size = new System.Drawing.Size(24, 24);
            this.picIconLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconLogout.TabIndex = 9;
            this.picIconLogout.TabStop = false;
            // 
            // picIconPelanggan
            // 
            this.picIconPelanggan.BackColor = System.Drawing.Color.Transparent;
            this.picIconPelanggan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picIconPelanggan.Image = ((System.Drawing.Image)(resources.GetObject("picIconPelanggan.Image")));
            this.picIconPelanggan.Location = new System.Drawing.Point(12, 200);
            this.picIconPelanggan.Name = "picIconPelanggan";
            this.picIconPelanggan.Size = new System.Drawing.Size(24, 24);
            this.picIconPelanggan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPelanggan.TabIndex = 8;
            this.picIconPelanggan.TabStop = false;
            // 
            // picIconTransaksi
            // 
            this.picIconTransaksi.BackColor = System.Drawing.Color.Transparent;
            this.picIconTransaksi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picIconTransaksi.Image = global::LaundryzkyApp.Properties.Resources.ph__washing_machine_bold;
            this.picIconTransaksi.Location = new System.Drawing.Point(12, 150);
            this.picIconTransaksi.Name = "picIconTransaksi";
            this.picIconTransaksi.Size = new System.Drawing.Size(24, 24);
            this.picIconTransaksi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconTransaksi.TabIndex = 7;
            this.picIconTransaksi.TabStop = false;
            // 
            // picIconPOS
            // 
            this.picIconPOS.BackColor = System.Drawing.Color.Transparent;
            this.picIconPOS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picIconPOS.Image = global::LaundryzkyApp.Properties.Resources.solar__cart_large_minimalistic_bold;
            this.picIconPOS.Location = new System.Drawing.Point(12, 99);
            this.picIconPOS.Name = "picIconPOS";
            this.picIconPOS.Size = new System.Drawing.Size(24, 24);
            this.picIconPOS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIconPOS.TabIndex = 6;
            this.picIconPOS.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 240);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(220, 45);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "      Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMenuPelanggan
            // 
            this.btnMenuPelanggan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnMenuPelanggan.FlatAppearance.BorderSize = 0;
            this.btnMenuPelanggan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPelanggan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuPelanggan.ForeColor = System.Drawing.Color.White;
            this.btnMenuPelanggan.Location = new System.Drawing.Point(0, 190);
            this.btnMenuPelanggan.Name = "btnMenuPelanggan";
            this.btnMenuPelanggan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuPelanggan.Size = new System.Drawing.Size(220, 45);
            this.btnMenuPelanggan.TabIndex = 4;
            this.btnMenuPelanggan.Text = "      Pelanggan";
            this.btnMenuPelanggan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuPelanggan.UseVisualStyleBackColor = false;
            this.btnMenuPelanggan.Click += new System.EventHandler(this.btnMenuPelanggan_Click);
            // 
            // btnMenuTransaksi
            // 
            this.btnMenuTransaksi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnMenuTransaksi.FlatAppearance.BorderSize = 0;
            this.btnMenuTransaksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuTransaksi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuTransaksi.ForeColor = System.Drawing.Color.White;
            this.btnMenuTransaksi.Location = new System.Drawing.Point(0, 140);
            this.btnMenuTransaksi.Name = "btnMenuTransaksi";
            this.btnMenuTransaksi.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuTransaksi.Size = new System.Drawing.Size(220, 45);
            this.btnMenuTransaksi.TabIndex = 3;
            this.btnMenuTransaksi.Text = "      Transaksi";
            this.btnMenuTransaksi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuTransaksi.UseVisualStyleBackColor = false;
            this.btnMenuTransaksi.Click += new System.EventHandler(this.btnMenuTransaksi_Click);
            // 
            // btnMenuPOS
            // 
            this.btnMenuPOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnMenuPOS.FlatAppearance.BorderSize = 0;
            this.btnMenuPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuPOS.ForeColor = System.Drawing.Color.White;
            this.btnMenuPOS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuPOS.Location = new System.Drawing.Point(0, 90);
            this.btnMenuPOS.Name = "btnMenuPOS";
            this.btnMenuPOS.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuPOS.Size = new System.Drawing.Size(220, 45);
            this.btnMenuPOS.TabIndex = 2;
            this.btnMenuPOS.Text = "      Kasir (POS)";
            this.btnMenuPOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuPOS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMenuPOS.UseVisualStyleBackColor = false;
            this.btnMenuPOS.Click += new System.EventHandler(this.btnMenuPOS_Click);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.LightCyan;
            this.lblRole.Location = new System.Drawing.Point(20, 45);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(64, 15);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Kasir Panel";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(20, 20);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(138, 25);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "LAUNDRYZKY";
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblTanggal);
            this.panelHeader.Controls.Add(this.lblNamaUser);
            this.panelHeader.Controls.Add(this.lblHalaman);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(220, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1587, 60);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggal.ForeColor = System.Drawing.Color.Gray;
            this.lblTanggal.Location = new System.Drawing.Point(1174, 32);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(133, 15);
            this.lblTanggal.TabIndex = 2;
            this.lblTanggal.Text = "Rabu, 19 Agustus 2026";
            // 
            // lblNamaUser
            // 
            this.lblNamaUser.AutoSize = true;
            this.lblNamaUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.lblNamaUser.Location = new System.Drawing.Point(1174, 12);
            this.lblNamaUser.Name = "lblNamaUser";
            this.lblNamaUser.Size = new System.Drawing.Size(121, 17);
            this.lblNamaUser.TabIndex = 1;
            this.lblNamaUser.Text = "Halo, Rizky (Kasir)";
            // 
            // lblHalaman
            // 
            this.lblHalaman.AutoSize = true;
            this.lblHalaman.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalaman.Location = new System.Drawing.Point(20, 15);
            this.lblHalaman.Name = "lblHalaman";
            this.lblHalaman.Size = new System.Drawing.Size(151, 25);
            this.lblHalaman.TabIndex = 0;
            this.lblHalaman.Text = "Kasir (POS Live)";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.panelContent.Controls.Add(this.panelPOS);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(220, 60);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1587, 756);
            this.panelContent.TabIndex = 2;
            // 
            // panelPOS
            // 
            this.panelPOS.Controls.Add(this.panelStrukPOS);
            this.panelPOS.Controls.Add(this.panelInputPOS);
            this.panelPOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPOS.Location = new System.Drawing.Point(0, 0);
            this.panelPOS.Name = "panelPOS";
            this.panelPOS.Size = new System.Drawing.Size(1587, 756);
            this.panelPOS.TabIndex = 1;
            // 
            // panelStrukPOS
            // 
            this.panelStrukPOS.BackColor = System.Drawing.Color.White;
            this.panelStrukPOS.Controls.Add(this.lblTotalBayarLive);
            this.panelStrukPOS.Controls.Add(this.lblTitleTotal);
            this.panelStrukPOS.Controls.Add(this.label1);
            this.panelStrukPOS.Controls.Add(this.lblStrukStatus);
            this.panelStrukPOS.Controls.Add(this.lblStrukDetail);
            this.panelStrukPOS.Controls.Add(this.lblStrukLayanan);
            this.panelStrukPOS.Controls.Add(this.lblStrukPelanggan);
            this.panelStrukPOS.Controls.Add(this.lblHeaderStruk);
            this.panelStrukPOS.Location = new System.Drawing.Point(738, 54);
            this.panelStrukPOS.Name = "panelStrukPOS";
            this.panelStrukPOS.Size = new System.Drawing.Size(620, 680);
            this.panelStrukPOS.TabIndex = 1;
            // 
            // lblTotalBayarLive
            // 
            this.lblTotalBayarLive.AutoSize = true;
            this.lblTotalBayarLive.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBayarLive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblTotalBayarLive.Location = new System.Drawing.Point(40, 550);
            this.lblTotalBayarLive.Name = "lblTotalBayarLive";
            this.lblTotalBayarLive.Size = new System.Drawing.Size(130, 65);
            this.lblTotalBayarLive.TabIndex = 22;
            this.lblTotalBayarLive.Text = "Rp 0";
            // 
            // lblTitleTotal
            // 
            this.lblTitleTotal.AutoSize = true;
            this.lblTitleTotal.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleTotal.Location = new System.Drawing.Point(40, 520);
            this.lblTitleTotal.Name = "lblTitleTotal";
            this.lblTitleTotal.Size = new System.Drawing.Size(107, 17);
            this.lblTitleTotal.TabIndex = 21;
            this.lblTitleTotal.Text = "Harga Total";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "----------------------------------------------------";
            // 
            // lblStrukStatus
            // 
            this.lblStrukStatus.AutoSize = true;
            this.lblStrukStatus.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrukStatus.Location = new System.Drawing.Point(40, 250);
            this.lblStrukStatus.Name = "lblStrukStatus";
            this.lblStrukStatus.Size = new System.Drawing.Size(134, 17);
            this.lblStrukStatus.TabIndex = 4;
            this.lblStrukStatus.Text = "lblStrukStatus";
            // 
            // lblStrukDetail
            // 
            this.lblStrukDetail.AutoSize = true;
            this.lblStrukDetail.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrukDetail.Location = new System.Drawing.Point(40, 180);
            this.lblStrukDetail.Name = "lblStrukDetail";
            this.lblStrukDetail.Size = new System.Drawing.Size(134, 17);
            this.lblStrukDetail.TabIndex = 3;
            this.lblStrukDetail.Text = "lblStrukDetail";
            // 
            // lblStrukLayanan
            // 
            this.lblStrukLayanan.AutoSize = true;
            this.lblStrukLayanan.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrukLayanan.Location = new System.Drawing.Point(40, 140);
            this.lblStrukLayanan.Name = "lblStrukLayanan";
            this.lblStrukLayanan.Size = new System.Drawing.Size(143, 17);
            this.lblStrukLayanan.TabIndex = 2;
            this.lblStrukLayanan.Text = "lblStrukLayanan";
            // 
            // lblStrukPelanggan
            // 
            this.lblStrukPelanggan.AutoSize = true;
            this.lblStrukPelanggan.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrukPelanggan.Location = new System.Drawing.Point(40, 100);
            this.lblStrukPelanggan.Name = "lblStrukPelanggan";
            this.lblStrukPelanggan.Size = new System.Drawing.Size(161, 17);
            this.lblStrukPelanggan.TabIndex = 1;
            this.lblStrukPelanggan.Text = "lblStrukPelanggan";
            // 
            // lblHeaderStruk
            // 
            this.lblHeaderStruk.AutoSize = true;
            this.lblHeaderStruk.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderStruk.Location = new System.Drawing.Point(160, 30);
            this.lblHeaderStruk.Name = "lblHeaderStruk";
            this.lblHeaderStruk.Size = new System.Drawing.Size(263, 22);
            this.lblHeaderStruk.TabIndex = 0;
            this.lblHeaderStruk.Text = "=== NOTA LAUNDRYZKY ===";
            // 
            // panelInputPOS
            // 
            this.panelInputPOS.BackColor = System.Drawing.Color.White;
            this.panelInputPOS.Controls.Add(this.btnReset);
            this.panelInputPOS.Controls.Add(this.btnSimpanPOS);
            this.panelInputPOS.Controls.Add(this.rbBayarSekarang);
            this.panelInputPOS.Controls.Add(this.rbBayarPasAmbil);
            this.panelInputPOS.Controls.Add(this.lblJudulPembayaran);
            this.panelInputPOS.Controls.Add(this.lblHargaPerKg);
            this.panelInputPOS.Controls.Add(this.txtBerat);
            this.panelInputPOS.Controls.Add(this.lblBeratText);
            this.panelInputPOS.Controls.Add(this.cmbLayanan);
            this.panelInputPOS.Controls.Add(this.lblJudulLayanan);
            this.panelInputPOS.Controls.Add(this.btnTambahPelangganBaru);
            this.panelInputPOS.Controls.Add(this.cmbPelanggan);
            this.panelInputPOS.Controls.Add(this.lblJudulPelanggan);
            this.panelInputPOS.Location = new System.Drawing.Point(41, 54);
            this.panelInputPOS.Name = "panelInputPOS";
            this.panelInputPOS.Size = new System.Drawing.Size(620, 680);
            this.panelInputPOS.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.btnReset.Location = new System.Drawing.Point(410, 580);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(180, 50);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "RESET";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSimpanPOS
            // 
            this.btnSimpanPOS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnSimpanPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpanPOS.ForeColor = System.Drawing.Color.White;
            this.btnSimpanPOS.Location = new System.Drawing.Point(25, 580);
            this.btnSimpanPOS.Name = "btnSimpanPOS";
            this.btnSimpanPOS.Size = new System.Drawing.Size(370, 50);
            this.btnSimpanPOS.TabIndex = 18;
            this.btnSimpanPOS.Text = "SIMPAN DAN CETAK NOTA";
            this.btnSimpanPOS.UseVisualStyleBackColor = false;
            this.btnSimpanPOS.Click += new System.EventHandler(this.btnSimpanPOS_Click);
            // 
            // rbBayarSekarang
            // 
            this.rbBayarSekarang.AutoSize = true;
            this.rbBayarSekarang.Location = new System.Drawing.Point(20, 320);
            this.rbBayarSekarang.Name = "rbBayarSekarang";
            this.rbBayarSekarang.Size = new System.Drawing.Size(139, 17);
            this.rbBayarSekarang.TabIndex = 17;
            this.rbBayarSekarang.TabStop = true;
            this.rbBayarSekarang.Text = "Lunas (Bayar Sekarang)";
            this.rbBayarSekarang.UseVisualStyleBackColor = true;
            this.rbBayarSekarang.CheckedChanged += new System.EventHandler(this.rbBayarSekarang_CheckedChanged);
            // 
            // rbBayarPasAmbil
            // 
            this.rbBayarPasAmbil.AutoSize = true;
            this.rbBayarPasAmbil.Location = new System.Drawing.Point(20, 290);
            this.rbBayarPasAmbil.Name = "rbBayarPasAmbil";
            this.rbBayarPasAmbil.Size = new System.Drawing.Size(171, 17);
            this.rbBayarPasAmbil.TabIndex = 16;
            this.rbBayarPasAmbil.TabStop = true;
            this.rbBayarPasAmbil.Text = "Belum Lunas (Bayar Pas Ambil)";
            this.rbBayarPasAmbil.UseVisualStyleBackColor = true;
            this.rbBayarPasAmbil.CheckedChanged += new System.EventHandler(this.rbBayarPasAmbil_CheckedChanged);
            // 
            // lblJudulPembayaran
            // 
            this.lblJudulPembayaran.AutoSize = true;
            this.lblJudulPembayaran.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudulPembayaran.Location = new System.Drawing.Point(20, 260);
            this.lblJudulPembayaran.Name = "lblJudulPembayaran";
            this.lblJudulPembayaran.Size = new System.Drawing.Size(171, 20);
            this.lblJudulPembayaran.TabIndex = 15;
            this.lblJudulPembayaran.Text = "3. Metode Pembayaran";
            // 
            // lblHargaPerKg
            // 
            this.lblHargaPerKg.AutoSize = true;
            this.lblHargaPerKg.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHargaPerKg.ForeColor = System.Drawing.Color.Gray;
            this.lblHargaPerKg.Location = new System.Drawing.Point(226, 211);
            this.lblHargaPerKg.Name = "lblHargaPerKg";
            this.lblHargaPerKg.Size = new System.Drawing.Size(65, 17);
            this.lblHargaPerKg.TabIndex = 14;
            this.lblHargaPerKg.Text = "Rp 0 / Kg";
            // 
            // txtBerat
            // 
            this.txtBerat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBerat.Location = new System.Drawing.Point(20, 205);
            this.txtBerat.Multiline = true;
            this.txtBerat.Name = "txtBerat";
            this.txtBerat.Size = new System.Drawing.Size(200, 35);
            this.txtBerat.TabIndex = 13;
            this.txtBerat.Text = "1";
            this.txtBerat.TextChanged += new System.EventHandler(this.txtBerat_TextChanged);
            // 
            // lblBeratText
            // 
            this.lblBeratText.AutoSize = true;
            this.lblBeratText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeratText.Location = new System.Drawing.Point(20, 180);
            this.lblBeratText.Name = "lblBeratText";
            this.lblBeratText.Size = new System.Drawing.Size(86, 20);
            this.lblBeratText.TabIndex = 12;
            this.lblBeratText.Text = "Berat (Kg):";
            // 
            // cmbLayanan
            // 
            this.cmbLayanan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayanan.FormattingEnabled = true;
            this.cmbLayanan.Location = new System.Drawing.Point(20, 130);
            this.cmbLayanan.Name = "cmbLayanan";
            this.cmbLayanan.Size = new System.Drawing.Size(565, 21);
            this.cmbLayanan.TabIndex = 11;
            this.cmbLayanan.SelectedIndexChanged += new System.EventHandler(this.cmbLayanan_SelectedIndexChanged);
            // 
            // lblJudulLayanan
            // 
            this.lblJudulLayanan.AutoSize = true;
            this.lblJudulLayanan.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudulLayanan.Location = new System.Drawing.Point(20, 100);
            this.lblJudulLayanan.Name = "lblJudulLayanan";
            this.lblJudulLayanan.Size = new System.Drawing.Size(185, 20);
            this.lblJudulLayanan.TabIndex = 10;
            this.lblJudulLayanan.Text = "2. Jenis Layanan Laundry";
            // 
            // btnTambahPelangganBaru
            // 
            this.btnTambahPelangganBaru.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnTambahPelangganBaru.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambahPelangganBaru.ForeColor = System.Drawing.Color.White;
            this.btnTambahPelangganBaru.Location = new System.Drawing.Point(475, 49);
            this.btnTambahPelangganBaru.Name = "btnTambahPelangganBaru";
            this.btnTambahPelangganBaru.Size = new System.Drawing.Size(110, 32);
            this.btnTambahPelangganBaru.TabIndex = 2;
            this.btnTambahPelangganBaru.Text = "+ Baru";
            this.btnTambahPelangganBaru.UseVisualStyleBackColor = false;
            this.btnTambahPelangganBaru.Click += new System.EventHandler(this.btnTambahPelangganBaru_Click);
            // 
            // cmbPelanggan
            // 
            this.cmbPelanggan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPelanggan.FormattingEnabled = true;
            this.cmbPelanggan.Location = new System.Drawing.Point(20, 50);
            this.cmbPelanggan.Name = "cmbPelanggan";
            this.cmbPelanggan.Size = new System.Drawing.Size(440, 21);
            this.cmbPelanggan.TabIndex = 1;
            this.cmbPelanggan.SelectedIndexChanged += new System.EventHandler(this.cmbPelanggan_SelectedIndexChanged);
            // 
            // lblJudulPelanggan
            // 
            this.lblJudulPelanggan.AutoSize = true;
            this.lblJudulPelanggan.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudulPelanggan.Location = new System.Drawing.Point(20, 20);
            this.lblJudulPelanggan.Name = "lblJudulPelanggan";
            this.lblJudulPelanggan.Size = new System.Drawing.Size(136, 20);
            this.lblJudulPelanggan.TabIndex = 0;
            this.lblJudulPelanggan.Text = "1. Data Pelanggan";
            // 
            // FormKasir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1807, 816);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FormKasir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAUNDRYZKY - Kasir";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormKasir_FormClosed);
            this.Load += new System.EventHandler(this.FormKasir_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIconLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconPelanggan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconTransaksi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIconPOS)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelPOS.ResumeLayout(false);
            this.panelStrukPOS.ResumeLayout(false);
            this.panelStrukPOS.PerformLayout();
            this.panelInputPOS.ResumeLayout(false);
            this.panelInputPOS.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnMenuTransaksi;
        private System.Windows.Forms.Button btnMenuPelanggan;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnMenuPOS;
        private System.Windows.Forms.PictureBox picIconPOS;
        private System.Windows.Forms.PictureBox picIconLogout;
        private System.Windows.Forms.PictureBox picIconPelanggan;
        private System.Windows.Forms.PictureBox picIconTransaksi;
        private System.Windows.Forms.Label lblNamaUser;
        private System.Windows.Forms.Label lblHalaman;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.Panel panelPOS;
        private System.Windows.Forms.Panel panelStrukPOS;
        private System.Windows.Forms.Label lblTotalBayarLive;
        private System.Windows.Forms.Label lblTitleTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStrukStatus;
        private System.Windows.Forms.Label lblStrukDetail;
        private System.Windows.Forms.Label lblStrukLayanan;
        private System.Windows.Forms.Label lblStrukPelanggan;
        private System.Windows.Forms.Label lblHeaderStruk;
        private System.Windows.Forms.Panel panelInputPOS;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSimpanPOS;
        private System.Windows.Forms.RadioButton rbBayarSekarang;
        private System.Windows.Forms.RadioButton rbBayarPasAmbil;
        private System.Windows.Forms.Label lblJudulPembayaran;
        private System.Windows.Forms.Label lblHargaPerKg;
        private System.Windows.Forms.TextBox txtBerat;
        private System.Windows.Forms.Label lblBeratText;
        private System.Windows.Forms.ComboBox cmbLayanan;
        private System.Windows.Forms.Label lblJudulLayanan;
        private System.Windows.Forms.Button btnTambahPelangganBaru;
        private System.Windows.Forms.ComboBox cmbPelanggan;
        private System.Windows.Forms.Label lblJudulPelanggan;
    }
}