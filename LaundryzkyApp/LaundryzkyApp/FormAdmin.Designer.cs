namespace LaundryzkyApp
{
    partial class FormAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdmin));
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnMenuLogout = new System.Windows.Forms.Button();
            this.btnMenuKelola = new System.Windows.Forms.Button();
            this.btnMenuLaporan = new System.Windows.Forms.Button();
            this.btnMenuTransaksi = new System.Windows.Forms.Button();
            this.btnMenuPembayaran = new System.Windows.Forms.Button();
            this.btnMenuPelanggan = new System.Windows.Forms.Button();
            this.btnMenuBeranda = new System.Windows.Forms.Button();
            this.panelGarisSidebar = new System.Windows.Forms.Panel();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.lblNamaUser = new System.Windows.Forms.Label();
            this.lblHalaman = new System.Windows.Forms.Label();
            this.panelUtama = new System.Windows.Forms.Panel();
            this.panelKonten = new System.Windows.Forms.Panel();
            this.panelKelolaUser = new System.Windows.Forms.Panel();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.colNoUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNamaUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAksiUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblJudulKelola = new System.Windows.Forms.Label();
            this.panelLaporan = new System.Windows.Forms.Panel();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.colNoLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoTrxLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNamaLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLayanan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeratLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTglLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRingkasan = new System.Windows.Forms.Panel();
            this.lblTotalLunas = new System.Windows.Forms.Label();
            this.lblTotalPendapatan = new System.Windows.Forms.Label();
            this.lblTotalTransaksi = new System.Windows.Forms.Label();
            this.btnExportLaporan = new System.Windows.Forms.Button();
            this.btnTampilLaporan = new System.Windows.Forms.Button();
            this.dtpSampai = new System.Windows.Forms.DateTimePicker();
            this.lblSampai = new System.Windows.Forms.Label();
            this.dtpDari = new System.Windows.Forms.DateTimePicker();
            this.lblDari = new System.Windows.Forms.Label();
            this.lblJudulLaporan = new System.Windows.Forms.Label();
            this.panelPembayaran = new System.Windows.Forms.Panel();
            this.dgvPembayaran = new System.Windows.Forms.DataGridView();
            this.colNoBayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoTrxBayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNamaBayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatusBayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAksiBayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblJudulPembayaran = new System.Windows.Forms.Label();
            this.panelPelanggan = new System.Windows.Forms.Panel();
            this.dgvPelanggan = new System.Windows.Forms.DataGridView();
            this.colNoPel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNamaPel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHPPel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlamat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAksiPel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblJudulPelanggan = new System.Windows.Forms.Label();
            this.panelTransaksi = new System.Windows.Forms.Panel();
            this.dgvTransaksi = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoTrx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPembayaran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAksi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFDiambil = new System.Windows.Forms.Button();
            this.btnFSelesai = new System.Windows.Forms.Button();
            this.btnFDiproses = new System.Windows.Forms.Button();
            this.btnFMenunggu = new System.Windows.Forms.Button();
            this.btnFSemua = new System.Windows.Forms.Button();
            this.lblJudulTransaksi = new System.Windows.Forms.Label();
            this.panelBeranda = new System.Windows.Forms.Panel();
            this.cardOrder = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDiproses = new System.Windows.Forms.Label();
            this.lblAngkaOrder = new System.Windows.Forms.Label();
            this.dgvTransaksiTerbaru = new System.Windows.Forms.DataGridView();
            this.colBrdNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrdKode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrdPelanggan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrdTanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrdStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrdPembayaran = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardProses = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblNamaProses = new System.Windows.Forms.Label();
            this.lblAngkaProses = new System.Windows.Forms.Label();
            this.cardPendapatan = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblNamaPendapatan = new System.Windows.Forms.Label();
            this.lblAngkaPendapatan = new System.Windows.Forms.Label();
            this.cardSelesai = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblNamaSelesai = new System.Windows.Forms.Label();
            this.lblAngkaSelesai = new System.Windows.Forms.Label();
            this.txtSearchGlobal = new System.Windows.Forms.TextBox();
            this.btnSearchGlobal = new System.Windows.Forms.Button();
            this.panelSidebar.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelUtama.SuspendLayout();
            this.panelKonten.SuspendLayout();
            this.panelKelolaUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.panelLaporan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.panelRingkasan.SuspendLayout();
            this.panelPembayaran.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaran)).BeginInit();
            this.panelPelanggan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPelanggan)).BeginInit();
            this.panelTransaksi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksi)).BeginInit();
            this.panelBeranda.SuspendLayout();
            this.cardOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksiTerbaru)).BeginInit();
            this.cardProses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.cardPendapatan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.cardSelesai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.panelSidebar.Controls.Add(this.btnMenuLogout);
            this.panelSidebar.Controls.Add(this.btnMenuKelola);
            this.panelSidebar.Controls.Add(this.btnMenuLaporan);
            this.panelSidebar.Controls.Add(this.btnMenuTransaksi);
            this.panelSidebar.Controls.Add(this.btnMenuPembayaran);
            this.panelSidebar.Controls.Add(this.btnMenuPelanggan);
            this.panelSidebar.Controls.Add(this.btnMenuBeranda);
            this.panelSidebar.Controls.Add(this.panelGarisSidebar);
            this.panelSidebar.Controls.Add(this.lblRole);
            this.panelSidebar.Controls.Add(this.lblAppName);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 795);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnMenuLogout
            // 
            this.btnMenuLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuLogout.FlatAppearance.BorderSize = 0;
            this.btnMenuLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuLogout.ForeColor = System.Drawing.Color.White;
            this.btnMenuLogout.Location = new System.Drawing.Point(0, 368);
            this.btnMenuLogout.Name = "btnMenuLogout";
            this.btnMenuLogout.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuLogout.Size = new System.Drawing.Size(220, 45);
            this.btnMenuLogout.TabIndex = 9;
            this.btnMenuLogout.Text = "🚪  Logout";
            this.btnMenuLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuLogout.UseVisualStyleBackColor = true;
            this.btnMenuLogout.Click += new System.EventHandler(this.btnMenuLogout_Click);
            // 
            // btnMenuKelola
            // 
            this.btnMenuKelola.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuKelola.FlatAppearance.BorderSize = 0;
            this.btnMenuKelola.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuKelola.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuKelola.ForeColor = System.Drawing.Color.White;
            this.btnMenuKelola.Location = new System.Drawing.Point(0, 320);
            this.btnMenuKelola.Name = "btnMenuKelola";
            this.btnMenuKelola.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuKelola.Size = new System.Drawing.Size(220, 45);
            this.btnMenuKelola.TabIndex = 8;
            this.btnMenuKelola.Text = "⚙️  Kelola User";
            this.btnMenuKelola.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuKelola.UseVisualStyleBackColor = true;
            this.btnMenuKelola.Click += new System.EventHandler(this.btnMenuKelola_Click);
            // 
            // btnMenuLaporan
            // 
            this.btnMenuLaporan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuLaporan.FlatAppearance.BorderSize = 0;
            this.btnMenuLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuLaporan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuLaporan.ForeColor = System.Drawing.Color.White;
            this.btnMenuLaporan.Location = new System.Drawing.Point(0, 275);
            this.btnMenuLaporan.Name = "btnMenuLaporan";
            this.btnMenuLaporan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuLaporan.Size = new System.Drawing.Size(220, 45);
            this.btnMenuLaporan.TabIndex = 7;
            this.btnMenuLaporan.Text = "📊  Laporan";
            this.btnMenuLaporan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuLaporan.UseVisualStyleBackColor = true;
            this.btnMenuLaporan.Click += new System.EventHandler(this.btnMenuLaporan_Click);
            // 
            // btnMenuTransaksi
            // 
            this.btnMenuTransaksi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuTransaksi.FlatAppearance.BorderSize = 0;
            this.btnMenuTransaksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuTransaksi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuTransaksi.ForeColor = System.Drawing.Color.White;
            this.btnMenuTransaksi.Location = new System.Drawing.Point(0, 140);
            this.btnMenuTransaksi.Name = "btnMenuTransaksi";
            this.btnMenuTransaksi.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuTransaksi.Size = new System.Drawing.Size(220, 45);
            this.btnMenuTransaksi.TabIndex = 6;
            this.btnMenuTransaksi.Text = "🧺  Transaksi";
            this.btnMenuTransaksi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuTransaksi.UseVisualStyleBackColor = true;
            this.btnMenuTransaksi.Click += new System.EventHandler(this.btnMenuTransaksi_Click);
            // 
            // btnMenuPembayaran
            // 
            this.btnMenuPembayaran.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuPembayaran.FlatAppearance.BorderSize = 0;
            this.btnMenuPembayaran.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPembayaran.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuPembayaran.ForeColor = System.Drawing.Color.White;
            this.btnMenuPembayaran.Location = new System.Drawing.Point(0, 230);
            this.btnMenuPembayaran.Name = "btnMenuPembayaran";
            this.btnMenuPembayaran.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuPembayaran.Size = new System.Drawing.Size(220, 45);
            this.btnMenuPembayaran.TabIndex = 5;
            this.btnMenuPembayaran.Text = "💳  Pembayaran";
            this.btnMenuPembayaran.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuPembayaran.UseVisualStyleBackColor = true;
            this.btnMenuPembayaran.Click += new System.EventHandler(this.btnMenuPembayaran_Click);
            // 
            // btnMenuPelanggan
            // 
            this.btnMenuPelanggan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuPelanggan.FlatAppearance.BorderSize = 0;
            this.btnMenuPelanggan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuPelanggan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuPelanggan.ForeColor = System.Drawing.Color.White;
            this.btnMenuPelanggan.Location = new System.Drawing.Point(0, 185);
            this.btnMenuPelanggan.Name = "btnMenuPelanggan";
            this.btnMenuPelanggan.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuPelanggan.Size = new System.Drawing.Size(220, 45);
            this.btnMenuPelanggan.TabIndex = 4;
            this.btnMenuPelanggan.Text = "👥  Pelanggan";
            this.btnMenuPelanggan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuPelanggan.UseVisualStyleBackColor = true;
            this.btnMenuPelanggan.Click += new System.EventHandler(this.btnMenuPelanggan_Click);
            // 
            // btnMenuBeranda
            // 
            this.btnMenuBeranda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuBeranda.FlatAppearance.BorderSize = 0;
            this.btnMenuBeranda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuBeranda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuBeranda.ForeColor = System.Drawing.Color.White;
            this.btnMenuBeranda.Location = new System.Drawing.Point(0, 95);
            this.btnMenuBeranda.Name = "btnMenuBeranda";
            this.btnMenuBeranda.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMenuBeranda.Size = new System.Drawing.Size(220, 45);
            this.btnMenuBeranda.TabIndex = 3;
            this.btnMenuBeranda.Text = "🏠  Beranda";
            this.btnMenuBeranda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuBeranda.UseVisualStyleBackColor = true;
            this.btnMenuBeranda.Click += new System.EventHandler(this.btnMenuBeranda_Click);
            // 
            // panelGarisSidebar
            // 
            this.panelGarisSidebar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelGarisSidebar.Location = new System.Drawing.Point(20, 80);
            this.panelGarisSidebar.Name = "panelGarisSidebar";
            this.panelGarisSidebar.Size = new System.Drawing.Size(180, 1);
            this.panelGarisSidebar.TabIndex = 2;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.BackColor = System.Drawing.Color.Transparent;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.LightBlue;
            this.lblRole.Location = new System.Drawing.Point(10, 52);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(71, 13);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "Admin Panel";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.BackColor = System.Drawing.Color.Transparent;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(10, 20);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(138, 25);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "LAUNDRYZKY";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnSearchGlobal);
            this.panelHeader.Controls.Add(this.txtSearchGlobal);
            this.panelHeader.Controls.Add(this.lblTanggal);
            this.panelHeader.Controls.Add(this.lblNamaUser);
            this.panelHeader.Controls.Add(this.lblHalaman);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(220, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1507, 65);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.BackColor = System.Drawing.Color.Transparent;
            this.lblTanggal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTanggal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblTanggal.Location = new System.Drawing.Point(1220, 38);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(106, 13);
            this.lblTanggal.TabIndex = 2;
            this.lblTanggal.Text = "Rabu, 29 April 2026";
            this.lblTanggal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNamaUser
            // 
            this.lblNamaUser.AutoSize = true;
            this.lblNamaUser.BackColor = System.Drawing.Color.Transparent;
            this.lblNamaUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.lblNamaUser.Location = new System.Drawing.Point(1220, 16);
            this.lblNamaUser.Name = "lblNamaUser";
            this.lblNamaUser.Size = new System.Drawing.Size(74, 15);
            this.lblNamaUser.TabIndex = 1;
            this.lblNamaUser.Text = "Halo, Admin";
            this.lblNamaUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHalaman
            // 
            this.lblHalaman.AutoSize = true;
            this.lblHalaman.BackColor = System.Drawing.Color.Transparent;
            this.lblHalaman.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHalaman.Location = new System.Drawing.Point(20, 10);
            this.lblHalaman.Name = "lblHalaman";
            this.lblHalaman.Size = new System.Drawing.Size(93, 30);
            this.lblHalaman.TabIndex = 0;
            this.lblHalaman.Text = "Beranda";
            // 
            // panelUtama
            // 
            this.panelUtama.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUtama.Controls.Add(this.panelKonten);
            this.panelUtama.Location = new System.Drawing.Point(220, 65);
            this.panelUtama.Name = "panelUtama";
            this.panelUtama.Size = new System.Drawing.Size(1507, 730);
            this.panelUtama.TabIndex = 5;
            // 
            // panelKonten
            // 
            this.panelKonten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelKonten.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.panelKonten.Controls.Add(this.panelKelolaUser);
            this.panelKonten.Controls.Add(this.panelLaporan);
            this.panelKonten.Controls.Add(this.panelPembayaran);
            this.panelKonten.Controls.Add(this.panelPelanggan);
            this.panelKonten.Controls.Add(this.panelTransaksi);
            this.panelKonten.Controls.Add(this.panelBeranda);
            this.panelKonten.Location = new System.Drawing.Point(0, 0);
            this.panelKonten.Name = "panelKonten";
            this.panelKonten.Size = new System.Drawing.Size(1507, 730);
            this.panelKonten.TabIndex = 7;
            // 
            // panelKelolaUser
            // 
            this.panelKelolaUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelKelolaUser.Controls.Add(this.dgvUser);
            this.panelKelolaUser.Controls.Add(this.lblJudulKelola);
            this.panelKelolaUser.Location = new System.Drawing.Point(0, 0);
            this.panelKelolaUser.Name = "panelKelolaUser";
            this.panelKelolaUser.Size = new System.Drawing.Size(1507, 727);
            this.panelKelolaUser.TabIndex = 0;
            this.panelKelolaUser.Visible = false;
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUser.BackgroundColor = System.Drawing.Color.White;
            this.dgvUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUser.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNoUser,
            this.colNamaUser,
            this.colUsername,
            this.colRole,
            this.colStatusUser,
            this.colAksiUser});
            this.dgvUser.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.dgvUser.Location = new System.Drawing.Point(25, 65);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.Size = new System.Drawing.Size(1460, 618);
            this.dgvUser.TabIndex = 2;
            this.dgvUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellClick);
            // 
            // colNoUser
            // 
            this.colNoUser.FillWeight = 30F;
            this.colNoUser.HeaderText = "No";
            this.colNoUser.Name = "colNoUser";
            this.colNoUser.ReadOnly = true;
            // 
            // colNamaUser
            // 
            this.colNamaUser.HeaderText = "Nama User";
            this.colNamaUser.Name = "colNamaUser";
            this.colNamaUser.ReadOnly = true;
            // 
            // colUsername
            // 
            this.colUsername.FillWeight = 120F;
            this.colUsername.HeaderText = "Username";
            this.colUsername.Name = "colUsername";
            this.colUsername.ReadOnly = true;
            // 
            // colRole
            // 
            this.colRole.FillWeight = 80F;
            this.colRole.HeaderText = "Role";
            this.colRole.Name = "colRole";
            this.colRole.ReadOnly = true;
            // 
            // colStatusUser
            // 
            this.colStatusUser.FillWeight = 80F;
            this.colStatusUser.HeaderText = "Status";
            this.colStatusUser.Name = "colStatusUser";
            this.colStatusUser.ReadOnly = true;
            // 
            // colAksiUser
            // 
            this.colAksiUser.HeaderText = "Aksi";
            this.colAksiUser.Name = "colAksiUser";
            this.colAksiUser.ReadOnly = true;
            // 
            // lblJudulKelola
            // 
            this.lblJudulKelola.AutoSize = true;
            this.lblJudulKelola.BackColor = System.Drawing.Color.Transparent;
            this.lblJudulKelola.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudulKelola.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblJudulKelola.Location = new System.Drawing.Point(25, 20);
            this.lblJudulKelola.Name = "lblJudulKelola";
            this.lblJudulKelola.Size = new System.Drawing.Size(123, 30);
            this.lblJudulKelola.TabIndex = 0;
            this.lblJudulKelola.Text = "Kelola User";
            // 
            // panelLaporan
            // 
            this.panelLaporan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLaporan.Controls.Add(this.dgvLaporan);
            this.panelLaporan.Controls.Add(this.panelRingkasan);
            this.panelLaporan.Controls.Add(this.btnExportLaporan);
            this.panelLaporan.Controls.Add(this.btnTampilLaporan);
            this.panelLaporan.Controls.Add(this.dtpSampai);
            this.panelLaporan.Controls.Add(this.lblSampai);
            this.panelLaporan.Controls.Add(this.dtpDari);
            this.panelLaporan.Controls.Add(this.lblDari);
            this.panelLaporan.Controls.Add(this.lblJudulLaporan);
            this.panelLaporan.Location = new System.Drawing.Point(0, 0);
            this.panelLaporan.Name = "panelLaporan";
            this.panelLaporan.Size = new System.Drawing.Size(1507, 727);
            this.panelLaporan.TabIndex = 11;
            this.panelLaporan.Visible = false;
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.AllowUserToAddRows = false;
            this.dgvLaporan.AllowUserToDeleteRows = false;
            this.dgvLaporan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLaporan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLaporan.BackgroundColor = System.Drawing.Color.White;
            this.dgvLaporan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLaporan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNoLap,
            this.colNoTrxLap,
            this.colNamaLap,
            this.colLayanan,
            this.colBeratLap,
            this.colTotalLap,
            this.colStatusLap,
            this.colTglLap});
            this.dgvLaporan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.dgvLaporan.Location = new System.Drawing.Point(25, 200);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.ReadOnly = true;
            this.dgvLaporan.RowHeadersVisible = false;
            this.dgvLaporan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLaporan.Size = new System.Drawing.Size(1437, 555);
            this.dgvLaporan.TabIndex = 8;
            // 
            // colNoLap
            // 
            this.colNoLap.FillWeight = 30F;
            this.colNoLap.HeaderText = "No";
            this.colNoLap.Name = "colNoLap";
            this.colNoLap.ReadOnly = true;
            // 
            // colNoTrxLap
            // 
            this.colNoTrxLap.FillWeight = 80F;
            this.colNoTrxLap.HeaderText = "No Transaksi";
            this.colNoTrxLap.Name = "colNoTrxLap";
            this.colNoTrxLap.ReadOnly = true;
            // 
            // colNamaLap
            // 
            this.colNamaLap.FillWeight = 160F;
            this.colNamaLap.HeaderText = "Nama Pelanggan";
            this.colNamaLap.Name = "colNamaLap";
            this.colNamaLap.ReadOnly = true;
            // 
            // colLayanan
            // 
            this.colLayanan.FillWeight = 120F;
            this.colLayanan.HeaderText = "Layanan";
            this.colLayanan.Name = "colLayanan";
            this.colLayanan.ReadOnly = true;
            // 
            // colBeratLap
            // 
            this.colBeratLap.FillWeight = 70F;
            this.colBeratLap.HeaderText = "Berat (Kg)";
            this.colBeratLap.Name = "colBeratLap";
            this.colBeratLap.ReadOnly = true;
            // 
            // colTotalLap
            // 
            this.colTotalLap.HeaderText = "Total";
            this.colTotalLap.Name = "colTotalLap";
            this.colTotalLap.ReadOnly = true;
            // 
            // colStatusLap
            // 
            this.colStatusLap.FillWeight = 80F;
            this.colStatusLap.HeaderText = "Status";
            this.colStatusLap.Name = "colStatusLap";
            this.colStatusLap.ReadOnly = true;
            // 
            // colTglLap
            // 
            this.colTglLap.FillWeight = 90F;
            this.colTglLap.HeaderText = "Tgl Masuk";
            this.colTglLap.Name = "colTglLap";
            this.colTglLap.ReadOnly = true;
            // 
            // panelRingkasan
            // 
            this.panelRingkasan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRingkasan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.panelRingkasan.Controls.Add(this.lblTotalLunas);
            this.panelRingkasan.Controls.Add(this.lblTotalPendapatan);
            this.panelRingkasan.Controls.Add(this.lblTotalTransaksi);
            this.panelRingkasan.Location = new System.Drawing.Point(25, 130);
            this.panelRingkasan.Name = "panelRingkasan";
            this.panelRingkasan.Size = new System.Drawing.Size(1437, 502);
            this.panelRingkasan.TabIndex = 7;
            // 
            // lblTotalLunas
            // 
            this.lblTotalLunas.AutoSize = true;
            this.lblTotalLunas.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalLunas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLunas.ForeColor = System.Drawing.Color.LightBlue;
            this.lblTotalLunas.Location = new System.Drawing.Point(560, 10);
            this.lblTotalLunas.Name = "lblTotalLunas";
            this.lblTotalLunas.Size = new System.Drawing.Size(111, 19);
            this.lblTotalLunas.TabIndex = 2;
            this.lblTotalLunas.Text = "Sudah Lunas : 0";
            // 
            // lblTotalPendapatan
            // 
            this.lblTotalPendapatan.AutoSize = true;
            this.lblTotalPendapatan.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPendapatan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPendapatan.ForeColor = System.Drawing.Color.White;
            this.lblTotalPendapatan.Location = new System.Drawing.Point(280, 10);
            this.lblTotalPendapatan.Name = "lblTotalPendapatan";
            this.lblTotalPendapatan.Size = new System.Drawing.Size(168, 19);
            this.lblTotalPendapatan.TabIndex = 1;
            this.lblTotalPendapatan.Text = "Total Pendapatan : Rp 0";
            // 
            // lblTotalTransaksi
            // 
            this.lblTotalTransaksi.AutoSize = true;
            this.lblTotalTransaksi.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalTransaksi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTransaksi.ForeColor = System.Drawing.Color.White;
            this.lblTotalTransaksi.Location = new System.Drawing.Point(20, 10);
            this.lblTotalTransaksi.Name = "lblTotalTransaksi";
            this.lblTotalTransaksi.Size = new System.Drawing.Size(127, 19);
            this.lblTotalTransaksi.TabIndex = 0;
            this.lblTotalTransaksi.Text = "Total Transaksi : 0";
            // 
            // btnExportLaporan
            // 
            this.btnExportLaporan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnExportLaporan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportLaporan.FlatAppearance.BorderSize = 0;
            this.btnExportLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportLaporan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportLaporan.ForeColor = System.Drawing.Color.White;
            this.btnExportLaporan.Location = new System.Drawing.Point(1362, 88);
            this.btnExportLaporan.Name = "btnExportLaporan";
            this.btnExportLaporan.Size = new System.Drawing.Size(100, 32);
            this.btnExportLaporan.TabIndex = 6;
            this.btnExportLaporan.Text = "Export PDF";
            this.btnExportLaporan.UseVisualStyleBackColor = false;
            this.btnExportLaporan.Click += new System.EventHandler(this.btnExportLaporan_Click);
            // 
            // btnTampilLaporan
            // 
            this.btnTampilLaporan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnTampilLaporan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTampilLaporan.FlatAppearance.BorderSize = 0;
            this.btnTampilLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTampilLaporan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTampilLaporan.ForeColor = System.Drawing.Color.White;
            this.btnTampilLaporan.Location = new System.Drawing.Point(1223, 88);
            this.btnTampilLaporan.Name = "btnTampilLaporan";
            this.btnTampilLaporan.Size = new System.Drawing.Size(100, 32);
            this.btnTampilLaporan.TabIndex = 5;
            this.btnTampilLaporan.Text = "Tampilkan";
            this.btnTampilLaporan.UseVisualStyleBackColor = false;
            this.btnTampilLaporan.Click += new System.EventHandler(this.btnTampilLaporan_Click);
            // 
            // dtpSampai
            // 
            this.dtpSampai.CustomFormat = "dd-MM-yyyy";
            this.dtpSampai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSampai.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSampai.Location = new System.Drawing.Point(200, 88);
            this.dtpSampai.Name = "dtpSampai";
            this.dtpSampai.Size = new System.Drawing.Size(160, 25);
            this.dtpSampai.TabIndex = 4;
            // 
            // lblSampai
            // 
            this.lblSampai.AutoSize = true;
            this.lblSampai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSampai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblSampai.Location = new System.Drawing.Point(200, 65);
            this.lblSampai.Name = "lblSampai";
            this.lblSampai.Size = new System.Drawing.Size(92, 15);
            this.lblSampai.TabIndex = 3;
            this.lblSampai.Text = "Sampai Tanggal";
            // 
            // dtpDari
            // 
            this.dtpDari.CustomFormat = "dd-MM-yyyy";
            this.dtpDari.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDari.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDari.Location = new System.Drawing.Point(25, 88);
            this.dtpDari.Name = "dtpDari";
            this.dtpDari.Size = new System.Drawing.Size(160, 25);
            this.dtpDari.TabIndex = 2;
            // 
            // lblDari
            // 
            this.lblDari.AutoSize = true;
            this.lblDari.BackColor = System.Drawing.Color.Transparent;
            this.lblDari.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDari.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblDari.Location = new System.Drawing.Point(25, 65);
            this.lblDari.Name = "lblDari";
            this.lblDari.Size = new System.Drawing.Size(75, 15);
            this.lblDari.TabIndex = 1;
            this.lblDari.Text = "Dari Tanggal";
            // 
            // lblJudulLaporan
            // 
            this.lblJudulLaporan.AutoSize = true;
            this.lblJudulLaporan.BackColor = System.Drawing.Color.Transparent;
            this.lblJudulLaporan.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudulLaporan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblJudulLaporan.Location = new System.Drawing.Point(25, 20);
            this.lblJudulLaporan.Name = "lblJudulLaporan";
            this.lblJudulLaporan.Size = new System.Drawing.Size(93, 30);
            this.lblJudulLaporan.TabIndex = 0;
            this.lblJudulLaporan.Text = "Laporan";
            // 
            // panelPembayaran
            // 
            this.panelPembayaran.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPembayaran.Controls.Add(this.dgvPembayaran);
            this.panelPembayaran.Controls.Add(this.lblJudulPembayaran);
            this.panelPembayaran.Location = new System.Drawing.Point(0, 0);
            this.panelPembayaran.Name = "panelPembayaran";
            this.panelPembayaran.Size = new System.Drawing.Size(1507, 727);
            this.panelPembayaran.TabIndex = 10;
            this.panelPembayaran.Visible = false;
            // 
            // dgvPembayaran
            // 
            this.dgvPembayaran.AllowUserToAddRows = false;
            this.dgvPembayaran.AllowUserToDeleteRows = false;
            this.dgvPembayaran.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPembayaran.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPembayaran.BackgroundColor = System.Drawing.Color.White;
            this.dgvPembayaran.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPembayaran.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPembayaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPembayaran.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNoBayar,
            this.colNoTrxBayar,
            this.colNamaBayar,
            this.colTotal,
            this.colStatusBayar,
            this.colAksiBayar});
            this.dgvPembayaran.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.dgvPembayaran.Location = new System.Drawing.Point(25, 65);
            this.dgvPembayaran.Name = "dgvPembayaran";
            this.dgvPembayaran.ReadOnly = true;
            this.dgvPembayaran.RowHeadersVisible = false;
            this.dgvPembayaran.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPembayaran.Size = new System.Drawing.Size(1437, 612);
            this.dgvPembayaran.TabIndex = 1;
            this.dgvPembayaran.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPembayaran_CellClick);
            // 
            // colNoBayar
            // 
            this.colNoBayar.FillWeight = 30F;
            this.colNoBayar.HeaderText = "No";
            this.colNoBayar.Name = "colNoBayar";
            this.colNoBayar.ReadOnly = true;
            // 
            // colNoTrxBayar
            // 
            this.colNoTrxBayar.FillWeight = 80F;
            this.colNoTrxBayar.HeaderText = "No Transaksi";
            this.colNoTrxBayar.Name = "colNoTrxBayar";
            this.colNoTrxBayar.ReadOnly = true;
            // 
            // colNamaBayar
            // 
            this.colNamaBayar.HeaderText = "Nama Pelanggan";
            this.colNamaBayar.Name = "colNamaBayar";
            this.colNamaBayar.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // colStatusBayar
            // 
            this.colStatusBayar.HeaderText = "Status Bayar";
            this.colStatusBayar.Name = "colStatusBayar";
            this.colStatusBayar.ReadOnly = true;
            // 
            // colAksiBayar
            // 
            this.colAksiBayar.FillWeight = 80F;
            this.colAksiBayar.HeaderText = "Aksi";
            this.colAksiBayar.Name = "colAksiBayar";
            this.colAksiBayar.ReadOnly = true;
            // 
            // lblJudulPembayaran
            // 
            this.lblJudulPembayaran.AutoSize = true;
            this.lblJudulPembayaran.BackColor = System.Drawing.Color.Transparent;
            this.lblJudulPembayaran.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudulPembayaran.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblJudulPembayaran.Location = new System.Drawing.Point(25, 20);
            this.lblJudulPembayaran.Name = "lblJudulPembayaran";
            this.lblJudulPembayaran.Size = new System.Drawing.Size(133, 30);
            this.lblJudulPembayaran.TabIndex = 0;
            this.lblJudulPembayaran.Text = "Pembayaran";
            // 
            // panelPelanggan
            // 
            this.panelPelanggan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPelanggan.Controls.Add(this.dgvPelanggan);
            this.panelPelanggan.Controls.Add(this.lblJudulPelanggan);
            this.panelPelanggan.Location = new System.Drawing.Point(0, 0);
            this.panelPelanggan.Name = "panelPelanggan";
            this.panelPelanggan.Size = new System.Drawing.Size(1507, 727);
            this.panelPelanggan.TabIndex = 0;
            this.panelPelanggan.Visible = false;
            // 
            // dgvPelanggan
            // 
            this.dgvPelanggan.AllowUserToAddRows = false;
            this.dgvPelanggan.AllowUserToDeleteRows = false;
            this.dgvPelanggan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPelanggan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPelanggan.BackgroundColor = System.Drawing.Color.White;
            this.dgvPelanggan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPelanggan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPelanggan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPelanggan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNoPel,
            this.colNamaPel,
            this.colHPPel,
            this.colAlamat,
            this.colAksiPel});
            this.dgvPelanggan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.dgvPelanggan.Location = new System.Drawing.Point(25, 65);
            this.dgvPelanggan.Name = "dgvPelanggan";
            this.dgvPelanggan.ReadOnly = true;
            this.dgvPelanggan.RowHeadersVisible = false;
            this.dgvPelanggan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPelanggan.Size = new System.Drawing.Size(1437, 612);
            this.dgvPelanggan.TabIndex = 2;
            this.dgvPelanggan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPelanggan_CellClick);
            // 
            // colNoPel
            // 
            this.colNoPel.FillWeight = 30F;
            this.colNoPel.HeaderText = "No";
            this.colNoPel.Name = "colNoPel";
            this.colNoPel.ReadOnly = true;
            // 
            // colNamaPel
            // 
            this.colNamaPel.FillWeight = 200F;
            this.colNamaPel.HeaderText = "Nama Pelanggan";
            this.colNamaPel.Name = "colNamaPel";
            this.colNamaPel.ReadOnly = true;
            // 
            // colHPPel
            // 
            this.colHPPel.HeaderText = "No HP";
            this.colHPPel.Name = "colHPPel";
            this.colHPPel.ReadOnly = true;
            // 
            // colAlamat
            // 
            this.colAlamat.FillWeight = 200F;
            this.colAlamat.HeaderText = "Alamat";
            this.colAlamat.Name = "colAlamat";
            this.colAlamat.ReadOnly = true;
            // 
            // colAksiPel
            // 
            this.colAksiPel.FillWeight = 80F;
            this.colAksiPel.HeaderText = "Aksi";
            this.colAksiPel.Name = "colAksiPel";
            this.colAksiPel.ReadOnly = true;
            // 
            // lblJudulPelanggan
            // 
            this.lblJudulPelanggan.AutoSize = true;
            this.lblJudulPelanggan.BackColor = System.Drawing.Color.Transparent;
            this.lblJudulPelanggan.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudulPelanggan.Location = new System.Drawing.Point(25, 20);
            this.lblJudulPelanggan.Name = "lblJudulPelanggan";
            this.lblJudulPelanggan.Size = new System.Drawing.Size(116, 30);
            this.lblJudulPelanggan.TabIndex = 0;
            this.lblJudulPelanggan.Text = "Pelanggan";
            // 
            // panelTransaksi
            // 
            this.panelTransaksi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTransaksi.Controls.Add(this.dgvTransaksi);
            this.panelTransaksi.Controls.Add(this.btnFDiambil);
            this.panelTransaksi.Controls.Add(this.btnFSelesai);
            this.panelTransaksi.Controls.Add(this.btnFDiproses);
            this.panelTransaksi.Controls.Add(this.btnFMenunggu);
            this.panelTransaksi.Controls.Add(this.btnFSemua);
            this.panelTransaksi.Controls.Add(this.lblJudulTransaksi);
            this.panelTransaksi.Location = new System.Drawing.Point(0, 0);
            this.panelTransaksi.Name = "panelTransaksi";
            this.panelTransaksi.Size = new System.Drawing.Size(1507, 727);
            this.panelTransaksi.TabIndex = 9;
            // 
            // dgvTransaksi
            // 
            this.dgvTransaksi.AllowUserToAddRows = false;
            this.dgvTransaksi.AllowUserToDeleteRows = false;
            this.dgvTransaksi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransaksi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransaksi.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransaksi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransaksi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransaksi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colNoTrx,
            this.colNama,
            this.colTanggal,
            this.colStatus,
            this.colPembayaran,
            this.colAksi});
            this.dgvTransaksi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.dgvTransaksi.Location = new System.Drawing.Point(25, 108);
            this.dgvTransaksi.Name = "dgvTransaksi";
            this.dgvTransaksi.ReadOnly = true;
            this.dgvTransaksi.RowHeadersVisible = false;
            this.dgvTransaksi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransaksi.Size = new System.Drawing.Size(1437, 572);
            this.dgvTransaksi.TabIndex = 6;
            this.dgvTransaksi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransaksi_CellClick);
            // 
            // colNo
            // 
            this.colNo.FillWeight = 30F;
            this.colNo.HeaderText = "No";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            // 
            // colNoTrx
            // 
            this.colNoTrx.FillWeight = 80F;
            this.colNoTrx.HeaderText = "No Transaksi";
            this.colNoTrx.Name = "colNoTrx";
            this.colNoTrx.ReadOnly = true;
            // 
            // colNama
            // 
            this.colNama.HeaderText = "Nama Pelanggan";
            this.colNama.Name = "colNama";
            this.colNama.ReadOnly = true;
            // 
            // colTanggal
            // 
            this.colTanggal.HeaderText = "Tanggal Masuk";
            this.colTanggal.Name = "colTanggal";
            this.colTanggal.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.FillWeight = 80F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colPembayaran
            // 
            this.colPembayaran.FillWeight = 80F;
            this.colPembayaran.HeaderText = "Pembayaran";
            this.colPembayaran.Name = "colPembayaran";
            this.colPembayaran.ReadOnly = true;
            // 
            // colAksi
            // 
            this.colAksi.FillWeight = 50F;
            this.colAksi.HeaderText = "Aksi";
            this.colAksi.Name = "colAksi";
            this.colAksi.ReadOnly = true;
            // 
            // btnFDiambil
            // 
            this.btnFDiambil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnFDiambil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFDiambil.FlatAppearance.BorderSize = 0;
            this.btnFDiambil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFDiambil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFDiambil.ForeColor = System.Drawing.Color.White;
            this.btnFDiambil.Location = new System.Drawing.Point(362, 68);
            this.btnFDiambil.Name = "btnFDiambil";
            this.btnFDiambil.Size = new System.Drawing.Size(75, 28);
            this.btnFDiambil.TabIndex = 5;
            this.btnFDiambil.Text = "Diambil";
            this.btnFDiambil.UseVisualStyleBackColor = false;
            this.btnFDiambil.Click += new System.EventHandler(this.btnFDiambil_Click);
            // 
            // btnFSelesai
            // 
            this.btnFSelesai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnFSelesai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFSelesai.FlatAppearance.BorderSize = 0;
            this.btnFSelesai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFSelesai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFSelesai.ForeColor = System.Drawing.Color.White;
            this.btnFSelesai.Location = new System.Drawing.Point(279, 68);
            this.btnFSelesai.Name = "btnFSelesai";
            this.btnFSelesai.Size = new System.Drawing.Size(75, 28);
            this.btnFSelesai.TabIndex = 4;
            this.btnFSelesai.Text = "Selesai";
            this.btnFSelesai.UseVisualStyleBackColor = false;
            this.btnFSelesai.Click += new System.EventHandler(this.btnFSelesai_Click);
            // 
            // btnFDiproses
            // 
            this.btnFDiproses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnFDiproses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFDiproses.FlatAppearance.BorderSize = 0;
            this.btnFDiproses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFDiproses.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFDiproses.ForeColor = System.Drawing.Color.White;
            this.btnFDiproses.Location = new System.Drawing.Point(196, 68);
            this.btnFDiproses.Name = "btnFDiproses";
            this.btnFDiproses.Size = new System.Drawing.Size(75, 28);
            this.btnFDiproses.TabIndex = 3;
            this.btnFDiproses.Text = "Diproses";
            this.btnFDiproses.UseVisualStyleBackColor = false;
            this.btnFDiproses.Click += new System.EventHandler(this.btnFDiproses_Click);
            // 
            // btnFMenunggu
            // 
            this.btnFMenunggu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnFMenunggu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFMenunggu.FlatAppearance.BorderSize = 0;
            this.btnFMenunggu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFMenunggu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFMenunggu.ForeColor = System.Drawing.Color.White;
            this.btnFMenunggu.Location = new System.Drawing.Point(108, 68);
            this.btnFMenunggu.Name = "btnFMenunggu";
            this.btnFMenunggu.Size = new System.Drawing.Size(80, 28);
            this.btnFMenunggu.TabIndex = 2;
            this.btnFMenunggu.Text = "Menunggu";
            this.btnFMenunggu.UseVisualStyleBackColor = false;
            this.btnFMenunggu.Click += new System.EventHandler(this.btnFMenunggu_Click);
            // 
            // btnFSemua
            // 
            this.btnFSemua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(55)))), ((int)(((byte)(150)))));
            this.btnFSemua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFSemua.FlatAppearance.BorderSize = 0;
            this.btnFSemua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFSemua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFSemua.ForeColor = System.Drawing.Color.White;
            this.btnFSemua.Location = new System.Drawing.Point(25, 68);
            this.btnFSemua.Name = "btnFSemua";
            this.btnFSemua.Size = new System.Drawing.Size(75, 28);
            this.btnFSemua.TabIndex = 0;
            this.btnFSemua.Text = "Semua";
            this.btnFSemua.UseVisualStyleBackColor = false;
            this.btnFSemua.Click += new System.EventHandler(this.btnFSemua_Click);
            // 
            // lblJudulTransaksi
            // 
            this.lblJudulTransaksi.AutoSize = true;
            this.lblJudulTransaksi.BackColor = System.Drawing.Color.Transparent;
            this.lblJudulTransaksi.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudulTransaksi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblJudulTransaksi.Location = new System.Drawing.Point(25, 20);
            this.lblJudulTransaksi.Name = "lblJudulTransaksi";
            this.lblJudulTransaksi.Size = new System.Drawing.Size(102, 30);
            this.lblJudulTransaksi.TabIndex = 0;
            this.lblJudulTransaksi.Text = "Transaksi";
            // 
            // panelBeranda
            // 
            this.panelBeranda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBeranda.Controls.Add(this.cardOrder);
            this.panelBeranda.Controls.Add(this.dgvTransaksiTerbaru);
            this.panelBeranda.Controls.Add(this.cardProses);
            this.panelBeranda.Controls.Add(this.cardPendapatan);
            this.panelBeranda.Controls.Add(this.cardSelesai);
            this.panelBeranda.Location = new System.Drawing.Point(0, 0);
            this.panelBeranda.Name = "panelBeranda";
            this.panelBeranda.Size = new System.Drawing.Size(1504, 730);
            this.panelBeranda.TabIndex = 0;
            // 
            // cardOrder
            // 
            this.cardOrder.BackColor = System.Drawing.Color.DodgerBlue;
            this.cardOrder.Controls.Add(this.pictureBox1);
            this.cardOrder.Controls.Add(this.lblDiproses);
            this.cardOrder.Controls.Add(this.lblAngkaOrder);
            this.cardOrder.Location = new System.Drawing.Point(25, 20);
            this.cardOrder.Name = "cardOrder";
            this.cardOrder.Size = new System.Drawing.Size(320, 150);
            this.cardOrder.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(35, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblDiproses
            // 
            this.lblDiproses.AutoSize = true;
            this.lblDiproses.BackColor = System.Drawing.Color.Transparent;
            this.lblDiproses.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiproses.ForeColor = System.Drawing.Color.White;
            this.lblDiproses.Location = new System.Drawing.Point(10, 65);
            this.lblDiproses.Name = "lblDiproses";
            this.lblDiproses.Size = new System.Drawing.Size(43, 17);
            this.lblDiproses.TabIndex = 2;
            this.lblDiproses.Text = "Order";
            this.lblDiproses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAngkaOrder
            // 
            this.lblAngkaOrder.AutoSize = true;
            this.lblAngkaOrder.BackColor = System.Drawing.Color.Transparent;
            this.lblAngkaOrder.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAngkaOrder.ForeColor = System.Drawing.Color.White;
            this.lblAngkaOrder.Location = new System.Drawing.Point(10, 15);
            this.lblAngkaOrder.Name = "lblAngkaOrder";
            this.lblAngkaOrder.Size = new System.Drawing.Size(40, 47);
            this.lblAngkaOrder.TabIndex = 2;
            this.lblAngkaOrder.Text = "0";
            this.lblAngkaOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvTransaksiTerbaru
            // 
            this.dgvTransaksiTerbaru.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransaksiTerbaru.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransaksiTerbaru.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransaksiTerbaru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransaksiTerbaru.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBrdNo,
            this.colBrdKode,
            this.colBrdPelanggan,
            this.colBrdTanggal,
            this.colBrdStatus,
            this.colBrdPembayaran});
            this.dgvTransaksiTerbaru.Location = new System.Drawing.Point(25, 232);
            this.dgvTransaksiTerbaru.Name = "dgvTransaksiTerbaru";
            this.dgvTransaksiTerbaru.Size = new System.Drawing.Size(1340, 480);
            this.dgvTransaksiTerbaru.TabIndex = 14;
            // 
            // colBrdNo
            // 
            this.colBrdNo.HeaderText = "No";
            this.colBrdNo.Name = "colBrdNo";
            // 
            // colBrdKode
            // 
            this.colBrdKode.HeaderText = "Kode Transaksi";
            this.colBrdKode.Name = "colBrdKode";
            // 
            // colBrdPelanggan
            // 
            this.colBrdPelanggan.HeaderText = "Nama Pelanggan";
            this.colBrdPelanggan.Name = "colBrdPelanggan";
            // 
            // colBrdTanggal
            // 
            this.colBrdTanggal.HeaderText = "Tanggal Masuk";
            this.colBrdTanggal.Name = "colBrdTanggal";
            // 
            // colBrdStatus
            // 
            this.colBrdStatus.HeaderText = "Status Order";
            this.colBrdStatus.Name = "colBrdStatus";
            // 
            // colBrdPembayaran
            // 
            this.colBrdPembayaran.HeaderText = "Status Bayar";
            this.colBrdPembayaran.Name = "colBrdPembayaran";
            // 
            // cardProses
            // 
            this.cardProses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(38)))));
            this.cardProses.Controls.Add(this.pictureBox2);
            this.cardProses.Controls.Add(this.lblNamaProses);
            this.cardProses.Controls.Add(this.lblAngkaProses);
            this.cardProses.Location = new System.Drawing.Point(365, 20);
            this.cardProses.Name = "cardProses";
            this.cardProses.Size = new System.Drawing.Size(320, 150);
            this.cardProses.TabIndex = 11;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(35, 180);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // lblNamaProses
            // 
            this.lblNamaProses.AutoSize = true;
            this.lblNamaProses.BackColor = System.Drawing.Color.Transparent;
            this.lblNamaProses.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaProses.ForeColor = System.Drawing.Color.White;
            this.lblNamaProses.Location = new System.Drawing.Point(10, 65);
            this.lblNamaProses.Name = "lblNamaProses";
            this.lblNamaProses.Size = new System.Drawing.Size(62, 17);
            this.lblNamaProses.TabIndex = 2;
            this.lblNamaProses.Text = "Diproses";
            this.lblNamaProses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAngkaProses
            // 
            this.lblAngkaProses.AutoSize = true;
            this.lblAngkaProses.BackColor = System.Drawing.Color.Transparent;
            this.lblAngkaProses.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAngkaProses.ForeColor = System.Drawing.Color.White;
            this.lblAngkaProses.Location = new System.Drawing.Point(10, 15);
            this.lblAngkaProses.Name = "lblAngkaProses";
            this.lblAngkaProses.Size = new System.Drawing.Size(40, 47);
            this.lblAngkaProses.TabIndex = 2;
            this.lblAngkaProses.Text = "0";
            this.lblAngkaProses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardPendapatan
            // 
            this.cardPendapatan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.cardPendapatan.Controls.Add(this.pictureBox4);
            this.cardPendapatan.Controls.Add(this.lblNamaPendapatan);
            this.cardPendapatan.Controls.Add(this.lblAngkaPendapatan);
            this.cardPendapatan.Location = new System.Drawing.Point(1045, 20);
            this.cardPendapatan.Name = "cardPendapatan";
            this.cardPendapatan.Size = new System.Drawing.Size(320, 150);
            this.cardPendapatan.TabIndex = 13;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(35, 180);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 100);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 5;
            this.pictureBox4.TabStop = false;
            // 
            // lblNamaPendapatan
            // 
            this.lblNamaPendapatan.AutoSize = true;
            this.lblNamaPendapatan.BackColor = System.Drawing.Color.Transparent;
            this.lblNamaPendapatan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaPendapatan.ForeColor = System.Drawing.Color.White;
            this.lblNamaPendapatan.Location = new System.Drawing.Point(10, 65);
            this.lblNamaPendapatan.Name = "lblNamaPendapatan";
            this.lblNamaPendapatan.Size = new System.Drawing.Size(81, 17);
            this.lblNamaPendapatan.TabIndex = 3;
            this.lblNamaPendapatan.Text = "Pendapatan";
            this.lblNamaPendapatan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAngkaPendapatan
            // 
            this.lblAngkaPendapatan.AutoSize = true;
            this.lblAngkaPendapatan.BackColor = System.Drawing.Color.Transparent;
            this.lblAngkaPendapatan.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAngkaPendapatan.ForeColor = System.Drawing.Color.White;
            this.lblAngkaPendapatan.Location = new System.Drawing.Point(10, 15);
            this.lblAngkaPendapatan.MaximumSize = new System.Drawing.Size(210, 0);
            this.lblAngkaPendapatan.Name = "lblAngkaPendapatan";
            this.lblAngkaPendapatan.Size = new System.Drawing.Size(33, 37);
            this.lblAngkaPendapatan.TabIndex = 3;
            this.lblAngkaPendapatan.Text = "0";
            this.lblAngkaPendapatan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardSelesai
            // 
            this.cardSelesai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.cardSelesai.Controls.Add(this.pictureBox3);
            this.cardSelesai.Controls.Add(this.lblNamaSelesai);
            this.cardSelesai.Controls.Add(this.lblAngkaSelesai);
            this.cardSelesai.Location = new System.Drawing.Point(705, 20);
            this.cardSelesai.Name = "cardSelesai";
            this.cardSelesai.Size = new System.Drawing.Size(320, 150);
            this.cardSelesai.TabIndex = 12;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(35, 180);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 100);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // lblNamaSelesai
            // 
            this.lblNamaSelesai.AutoSize = true;
            this.lblNamaSelesai.BackColor = System.Drawing.Color.Transparent;
            this.lblNamaSelesai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaSelesai.ForeColor = System.Drawing.Color.White;
            this.lblNamaSelesai.Location = new System.Drawing.Point(10, 65);
            this.lblNamaSelesai.Name = "lblNamaSelesai";
            this.lblNamaSelesai.Size = new System.Drawing.Size(50, 17);
            this.lblNamaSelesai.TabIndex = 3;
            this.lblNamaSelesai.Text = "Selesai";
            this.lblNamaSelesai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAngkaSelesai
            // 
            this.lblAngkaSelesai.AutoSize = true;
            this.lblAngkaSelesai.BackColor = System.Drawing.Color.Transparent;
            this.lblAngkaSelesai.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAngkaSelesai.ForeColor = System.Drawing.Color.White;
            this.lblAngkaSelesai.Location = new System.Drawing.Point(10, 15);
            this.lblAngkaSelesai.Name = "lblAngkaSelesai";
            this.lblAngkaSelesai.Size = new System.Drawing.Size(40, 47);
            this.lblAngkaSelesai.TabIndex = 3;
            this.lblAngkaSelesai.Text = "0";
            this.lblAngkaSelesai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearchGlobal
            // 
            this.txtSearchGlobal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchGlobal.Location = new System.Drawing.Point(269, 20);
            this.txtSearchGlobal.Name = "txtSearchGlobal";
            this.txtSearchGlobal.Size = new System.Drawing.Size(395, 25);
            this.txtSearchGlobal.TabIndex = 3;
            this.txtSearchGlobal.TextChanged += new System.EventHandler(this.txtSearchGlobal_TextChanged);
            // 
            // btnSearchGlobal
            // 
            this.btnSearchGlobal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(86)))), ((int)(((byte)(196)))));
            this.btnSearchGlobal.FlatAppearance.BorderSize = 0;
            this.btnSearchGlobal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchGlobal.ForeColor = System.Drawing.Color.White;
            this.btnSearchGlobal.Location = new System.Drawing.Point(176, 22);
            this.btnSearchGlobal.Name = "btnSearchGlobal";
            this.btnSearchGlobal.Size = new System.Drawing.Size(75, 23);
            this.btnSearchGlobal.TabIndex = 4;
            this.btnSearchGlobal.Text = "🔍 Cari";
            this.btnSearchGlobal.UseVisualStyleBackColor = false;
            this.btnSearchGlobal.Click += new System.EventHandler(this.btnSearchGlobal_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1727, 795);
            this.Controls.Add(this.panelUtama);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAUNDRYZKY - Admin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAdmin_FormClosed);
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelUtama.ResumeLayout(false);
            this.panelKonten.ResumeLayout(false);
            this.panelKelolaUser.ResumeLayout(false);
            this.panelKelolaUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.panelLaporan.ResumeLayout(false);
            this.panelLaporan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.panelRingkasan.ResumeLayout(false);
            this.panelRingkasan.PerformLayout();
            this.panelPembayaran.ResumeLayout(false);
            this.panelPembayaran.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaran)).EndInit();
            this.panelPelanggan.ResumeLayout(false);
            this.panelPelanggan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPelanggan)).EndInit();
            this.panelTransaksi.ResumeLayout(false);
            this.panelTransaksi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksi)).EndInit();
            this.panelBeranda.ResumeLayout(false);
            this.cardOrder.ResumeLayout(false);
            this.cardOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransaksiTerbaru)).EndInit();
            this.cardProses.ResumeLayout(false);
            this.cardProses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.cardPendapatan.ResumeLayout(false);
            this.cardPendapatan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.cardSelesai.ResumeLayout(false);
            this.cardSelesai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelGarisSidebar;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Button btnMenuBeranda;
        private System.Windows.Forms.Button btnMenuTransaksi;
        private System.Windows.Forms.Button btnMenuPembayaran;
        private System.Windows.Forms.Button btnMenuPelanggan;
        private System.Windows.Forms.Button btnMenuLogout;
        private System.Windows.Forms.Button btnMenuKelola;
        private System.Windows.Forms.Button btnMenuLaporan;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblNamaUser;
        private System.Windows.Forms.Label lblHalaman;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.Panel panelUtama;
        private System.Windows.Forms.Panel panelKonten;
        private System.Windows.Forms.Panel panelKelolaUser;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNamaUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAksiUser;
        private System.Windows.Forms.Label lblJudulKelola;
        private System.Windows.Forms.Panel panelLaporan;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoTrxLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNamaLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLayanan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeratLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTglLap;
        private System.Windows.Forms.Panel panelRingkasan;
        private System.Windows.Forms.Label lblTotalLunas;
        private System.Windows.Forms.Label lblTotalPendapatan;
        private System.Windows.Forms.Label lblTotalTransaksi;
        private System.Windows.Forms.Button btnExportLaporan;
        private System.Windows.Forms.Button btnTampilLaporan;
        private System.Windows.Forms.DateTimePicker dtpSampai;
        private System.Windows.Forms.Label lblSampai;
        private System.Windows.Forms.DateTimePicker dtpDari;
        private System.Windows.Forms.Label lblDari;
        private System.Windows.Forms.Label lblJudulLaporan;
        private System.Windows.Forms.Panel panelPembayaran;
        private System.Windows.Forms.DataGridView dgvPembayaran;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoBayar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoTrxBayar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNamaBayar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatusBayar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAksiBayar;
        private System.Windows.Forms.Label lblJudulPembayaran;
        private System.Windows.Forms.Panel panelPelanggan;
        private System.Windows.Forms.DataGridView dgvPelanggan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoPel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNamaPel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHPPel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlamat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAksiPel;
        private System.Windows.Forms.Label lblJudulPelanggan;
        private System.Windows.Forms.Panel panelTransaksi;
        private System.Windows.Forms.DataGridView dgvTransaksi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoTrx;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNama;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPembayaran;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAksi;
        private System.Windows.Forms.Button btnFDiambil;
        private System.Windows.Forms.Button btnFSelesai;
        private System.Windows.Forms.Button btnFDiproses;
        private System.Windows.Forms.Button btnFMenunggu;
        private System.Windows.Forms.Button btnFSemua;
        private System.Windows.Forms.Label lblJudulTransaksi;
        private System.Windows.Forms.Panel panelBeranda;
        private System.Windows.Forms.DataGridView dgvTransaksiTerbaru;
        private System.Windows.Forms.Panel cardProses;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblNamaProses;
        private System.Windows.Forms.Label lblAngkaProses;
        private System.Windows.Forms.Panel cardPendapatan;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblNamaPendapatan;
        private System.Windows.Forms.Label lblAngkaPendapatan;
        private System.Windows.Forms.Panel cardSelesai;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblNamaSelesai;
        private System.Windows.Forms.Label lblAngkaSelesai;
        private System.Windows.Forms.Panel cardOrder;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDiproses;
        private System.Windows.Forms.Label lblAngkaOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrdNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrdKode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrdPelanggan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrdTanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrdStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrdPembayaran;
        private System.Windows.Forms.Button btnSearchGlobal;
        private System.Windows.Forms.TextBox txtSearchGlobal;
    }
}
