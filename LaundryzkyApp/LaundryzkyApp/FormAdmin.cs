using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LaundryzkyApp
{
    public partial class FormAdmin : Form
    {
        private string namaUser;
        private int idUser;

        // Flag penanda logout
        private bool isLoggingOut = false;

        // Variable penanda halaman aktif untuk fitur Search
        private string halamanAktif = "Beranda";

        public FormAdmin(string nama, int id)
        {
            InitializeComponent();
            namaUser = nama;
            idUser = id;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            lblNamaUser.Text = "Halo, " + namaUser;
            lblTanggal.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy",
                new System.Globalization.CultureInfo("id-ID"));

            SetRadius(cardOrder, 15);
            SetRadius(cardProses, 15);
            SetRadius(cardSelesai, 15);
            SetRadius(cardPendapatan, 15);

            AturTampilanBeranda();
            TampilBeranda();
        }

        private void panelBeranda_Resize(object sender, EventArgs e)
        {
            AturTampilanBeranda();
        }

        // =========================================================================
        // LOGIKA PENCARIAN GLOBAL (PINTAR & OTOMATIS SESUAI HALAMAN)
        // =========================================================================
        private void txtSearchGlobal_TextChanged(object sender, EventArgs e)
        {
            CariDataGlobal(txtSearchGlobal.Text.Trim());
        }

        private void btnSearchGlobal_Click(object sender, EventArgs e)
        {
            CariDataGlobal(txtSearchGlobal.Text.Trim());
        }

        private void CariDataGlobal(string keyword)
        {
            if (halamanAktif == "Beranda")
            {
                FilterTabel(dgvTransaksiTerbaru, keyword);
            }
            else if (halamanAktif == "Transaksi")
            {
                FilterTabel(dgvTransaksi, keyword);
            }
            else if (halamanAktif == "Pelanggan")
            {
                FilterTabel(dgvPelanggan, keyword);
            }
            else if (halamanAktif == "Pembayaran")
            {
                FilterTabel(dgvPembayaran, keyword);
            }
            else if (halamanAktif == "Laporan")
            {
                FilterTabel(dgvLaporan, keyword);
            }
        }

        // Helper menyaring baris DataGridView secara instan tanpa reload database
        private void FilterTabel(DataGridView dgv, string keyword)
        {
            if (dgv.DataSource == null && dgv.Rows.Count == 0) return;

            CurrencyManager cm = (CurrencyManager)BindingContext[dgv.DataSource];
            if (cm != null) cm.SuspendBinding();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                bool isMatch = false;

                if (string.IsNullOrEmpty(keyword))
                {
                    isMatch = true;
                }
                else
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().ToLower().Contains(keyword.ToLower()))
                        {
                            isMatch = true;
                            break;
                        }
                    }
                }

                // Sembunyikan baris yang tidak cocok
                row.Visible = isMatch;
            }

            if (cm != null) cm.ResumeBinding();
        }

        private void AturSearchVisibilitas(bool status)
        {
            // Reset keyword saat pindah menu
            if (txtSearchGlobal != null)
            {
                txtSearchGlobal.Text = "";
                txtSearchGlobal.Visible = status;
            }
            if (btnSearchGlobal != null)
            {
                btnSearchGlobal.Visible = status;
            }
        }

        // ROUNDED HELPER
        private void SetRadius(Panel p, int r)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, r, r, 180, 90);
            path.AddArc(p.Width - r, 0, r, r, 270, 90);
            path.AddArc(p.Width - r, p.Height - r, r, r, 0, 90);
            path.AddArc(0, p.Height - r, r, r, 90, 90);
            path.CloseAllFigures();
            p.Region = new Region(path);
        }

        private void AturTampilanBeranda()
        {
            int marginKiri = 25;
            int marginAtas = 20;
            int tinggiCard = 150;
            int jarakCard = 20;

            int totalLebarTersedia = panelBeranda.Width - (marginKiri * 2);
            int lebarCard = (totalLebarTersedia - (jarakCard * 3)) / 4;

            if (lebarCard < 220) lebarCard = 220;

            Panel[] cards = { cardOrder, cardProses, cardSelesai, cardPendapatan };

            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].Size = new Size(lebarCard, tinggiCard);
                cards[i].Location = new Point(marginKiri + i * (lebarCard + jarakCard), marginAtas);
                SetRadius(cards[i], 15);
            }

            lblAngkaOrder.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblAngkaProses.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblAngkaSelesai.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblAngkaPendapatan.Font = new Font("Segoe UI", 18, FontStyle.Bold);

            int posYTable = marginAtas + tinggiCard + 20;
            dgvTransaksiTerbaru.Location = new Point(marginKiri, posYTable);
            dgvTransaksiTerbaru.Width = totalLebarTersedia;
            dgvTransaksiTerbaru.Height = panelBeranda.Height - posYTable - 25;
        }

        // HIGHLIGHT MENU AKTIF
        private void SetMenuAktif(Button btnAktif)
        {
            Button[] semuaMenu = {
                btnMenuBeranda, btnMenuTransaksi, btnMenuPelanggan,
                btnMenuPembayaran, btnMenuLaporan, btnMenuKelola
            };
            foreach (var btn in semuaMenu)
            {
                btn.BackColor = Color.FromArgb(26, 86, 196);
                btn.ForeColor = Color.White;
            }
            btnAktif.BackColor = Color.FromArgb(15, 55, 150);
            btnAktif.ForeColor = Color.LightCyan;
        }

        // TAMPIL PANEL
        private void SembunyikanSemua()
        {
            panelBeranda.Visible = false;
            panelTransaksi.Visible = false;
            panelPelanggan.Visible = false;
            panelPembayaran.Visible = false;
            panelLaporan.Visible = false;
            panelKelolaUser.Visible = false;
        }

        private void TampilBeranda()
        {
            SembunyikanSemua();
            panelBeranda.Visible = true;
            lblHalaman.Text = "Beranda";
            SetMenuAktif(btnMenuBeranda);

            halamanAktif = "Beranda";
            AturSearchVisibilitas(true); // Tampil Search

            MuatDataBeranda();
            StyleDGVTransaksiTerbaru();
            MuatTransaksiTerbaruBeranda();
        }

        private void TampilTransaksi()
        {
            SembunyikanSemua();
            panelTransaksi.Visible = true;
            lblHalaman.Text = "Transaksi";
            SetMenuAktif(btnMenuTransaksi);

            halamanAktif = "Transaksi";
            AturSearchVisibilitas(true); // Tampil Search

            StyleDGVTransaksi();
            MuatTransaksi("Semua");
        }

        private void TampilPelanggan()
        {
            SembunyikanSemua();
            panelPelanggan.Visible = true;
            lblHalaman.Text = "Pelanggan";
            SetMenuAktif(btnMenuPelanggan);

            halamanAktif = "Pelanggan";
            AturSearchVisibilitas(true); // Tampil Search

            StyleDGVPelanggan();
            MuatPelanggan();
        }

        private void TampilPembayaran()
        {
            SembunyikanSemua();
            panelPembayaran.Visible = true;
            lblHalaman.Text = "Pembayaran";
            SetMenuAktif(btnMenuPembayaran);

            halamanAktif = "Pembayaran";
            AturSearchVisibilitas(true); // Tampil Search

            StyleDGVPembayaran();
            MuatPembayaran();
        }

        private void TampilLaporan()
        {
            SembunyikanSemua();
            panelLaporan.Visible = true;
            lblHalaman.Text = "Laporan";
            SetMenuAktif(btnMenuLaporan);

            halamanAktif = "Laporan";
            AturSearchVisibilitas(true); // Tampil Search

            StyleDGVLaporan();

            dtpDari.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpSampai.Value = DateTime.Today;
            MuatLaporan(dtpDari.Value, dtpSampai.Value);
        }

        private void TampilKelolaUser()
        {
            SembunyikanSemua();
            panelKelolaUser.Visible = true;
            lblHalaman.Text = "Kelola User";
            SetMenuAktif(btnMenuKelola);

            halamanAktif = "KelolaUser";
            AturSearchVisibilitas(false); // Sembunyikan Search di Kelola User

            StyleDGVUser();
            MuatUser();
        }

        // TABEL BERANDA (TRANSAKSI TERBARU)
        private void StyleDGVTransaksiTerbaru()
        {
            dgvTransaksiTerbaru.EnableHeadersVisualStyles = false;
            dgvTransaksiTerbaru.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTransaksiTerbaru.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 86, 196);
            dgvTransaksiTerbaru.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransaksiTerbaru.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTransaksiTerbaru.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransaksiTerbaru.ColumnHeadersHeight = 40;

            dgvTransaksiTerbaru.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTransaksiTerbaru.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 228, 255);
            dgvTransaksiTerbaru.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTransaksiTerbaru.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransaksiTerbaru.RowTemplate.Height = 36;

            dgvTransaksiTerbaru.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);
        }

        private void MuatTransaksiTerbaruBeranda()
        {
            dgvTransaksiTerbaru.Rows.Clear();

            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();

                    string query = @"
                        SELECT th.id_transaksi, p.nama_pelanggan, 
                               th.tanggal_masuk, th.status, th.status_pembayaran
                        FROM tbl_transaksi_header th
                        JOIN tbl_pelanggan p ON th.id_pelanggan = p.id_pelanggan
                        ORDER BY th.id_transaksi DESC 
                        LIMIT 8";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int no = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        int idx = dgvTransaksiTerbaru.Rows.Add(
                            no++,
                            "TRX-" + row["id_transaksi"].ToString().PadLeft(4, '0'),
                            row["nama_pelanggan"].ToString(),
                            Convert.ToDateTime(row["tanggal_masuk"]).ToString("dd-MM-yyyy HH:mm"),
                            row["status"].ToString(),
                            row["status_pembayaran"].ToString()
                        );

                        string status = row["status"].ToString();
                        Color warnaStatus = status.Equals("Menunggu", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(26, 86, 196)
                                          : status.Equals("Diproses", StringComparison.OrdinalIgnoreCase) ? Color.Orange
                                          : status.Equals("Selesai", StringComparison.OrdinalIgnoreCase) ? Color.Green
                                          : Color.Gray;

                        dgvTransaksiTerbaru.Rows[idx].Cells["colBrdStatus"].Style.ForeColor = warnaStatus;
                        dgvTransaksiTerbaru.Rows[idx].Cells["colBrdStatus"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        string bayar = row["status_pembayaran"].ToString();
                        dgvTransaksiTerbaru.Rows[idx].Cells["colBrdPembayaran"].Style.ForeColor = bayar.Equals("Lunas", StringComparison.OrdinalIgnoreCase)
                            ? Color.Green
                            : Color.FromArgb(200, 100, 0);
                        dgvTransaksiTerbaru.Rows[idx].Cells["colBrdPembayaran"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat transaksi terbaru: " + ex.Message);
            }
        }

        // DATA BERANDA
        private void MuatDataBeranda()
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();

                    MySqlCommand cmd1 = new MySqlCommand("SELECT COUNT(*) FROM tbl_transaksi_header WHERE LOWER(status)='menunggu'", conn);
                    lblAngkaOrder.Text = cmd1.ExecuteScalar().ToString();

                    MySqlCommand cmd2 = new MySqlCommand("SELECT COUNT(*) FROM tbl_transaksi_header WHERE LOWER(status)='diproses'", conn);
                    lblAngkaProses.Text = cmd2.ExecuteScalar().ToString();

                    MySqlCommand cmd3 = new MySqlCommand("SELECT COUNT(*) FROM tbl_transaksi_header WHERE LOWER(status)='selesai'", conn);
                    lblAngkaSelesai.Text = cmd3.ExecuteScalar().ToString();

                    MySqlCommand cmd4 = new MySqlCommand(
                        @"SELECT IFNULL(SUM(td.subtotal), 0) 
                          FROM tbl_transaksi_detail td
                          JOIN tbl_transaksi_header th ON td.id_transaksi = th.id_transaksi
                          WHERE LOWER(th.status_pembayaran) = 'lunas'", conn);
                    decimal pendapatan = Convert.ToDecimal(cmd4.ExecuteScalar());
                    lblAngkaPendapatan.Text = "Rp " + pendapatan.ToString("N0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat beranda: " + ex.Message);
            }
        }

        // BUTTON MENU CLICK
        private void btnMenuBeranda_Click(object sender, EventArgs e) => TampilBeranda();
        private void btnMenuTransaksi_Click(object sender, EventArgs e) => TampilTransaksi();
        private void btnMenuPelanggan_Click(object sender, EventArgs e) => TampilPelanggan();
        private void btnMenuPembayaran_Click(object sender, EventArgs e) => TampilPembayaran();
        private void btnMenuLaporan_Click(object sender, EventArgs e) => TampilLaporan();
        private void btnMenuKelola_Click(object sender, EventArgs e) => TampilKelolaUser();

        // LOGOUT
        private void btnMenuLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                isLoggingOut = true;
                FormLogin fLogin = new FormLogin();
                fLogin.Show();
                this.Close();
            }
        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!isLoggingOut)
            {
                Application.Exit();
            }
        }

        // STYLE DGV TRANSAKSI
        private void StyleDGVTransaksi()
        {
            dgvTransaksi.EnableHeadersVisualStyles = false;
            dgvTransaksi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 86, 196);
            dgvTransaksi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTransaksi.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTransaksi.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransaksi.ColumnHeadersHeight = 40;
            dgvTransaksi.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTransaksi.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 228, 255);
            dgvTransaksi.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTransaksi.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransaksi.RowTemplate.Height = 38;
            dgvTransaksi.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);
        }

        // MUAT DATA TRANSAKSI
        private string filterAktif = "Semua";

        private void MuatTransaksi(string filter)
        {
            filterAktif = filter;
            HilightFilterTrx(filter);
            dgvTransaksi.Rows.Clear();

            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();

                    string where = filter == "Semua" ? "" : "WHERE LOWER(th.status) = LOWER(@status)";

                    string query = $@"
                    SELECT th.id_transaksi, p.nama_pelanggan, 
                           th.tanggal_masuk, th.status, th.status_pembayaran
                    FROM tbl_transaksi_header th
                    JOIN tbl_pelanggan p ON th.id_pelanggan = p.id_pelanggan
                    {where}
                    ORDER BY th.id_transaksi DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (filter != "Semua")
                        cmd.Parameters.AddWithValue("@status", filter);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int no = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        int idx = dgvTransaksi.Rows.Add(
                            no++,
                            "TRX-" + row["id_transaksi"].ToString().PadLeft(4, '0'),
                            row["nama_pelanggan"].ToString(),
                            Convert.ToDateTime(row["tanggal_masuk"]).ToString("dd-MM-yyyy"),
                            row["status"].ToString(),
                            row["status_pembayaran"].ToString(),
                            "Ubah Status"
                        );

                        string status = row["status"].ToString();
                        Color warnaStatus = status.Equals("Menunggu", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(26, 86, 196)
                                          : status.Equals("Diproses", StringComparison.OrdinalIgnoreCase) ? Color.Orange
                                          : status.Equals("Selesai", StringComparison.OrdinalIgnoreCase) ? Color.Green
                                          : Color.Gray;

                        dgvTransaksi.Rows[idx].Cells["colStatus"].Style.ForeColor = warnaStatus;
                        dgvTransaksi.Rows[idx].Cells["colStatus"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        string bayar = row["status_pembayaran"].ToString();
                        dgvTransaksi.Rows[idx].Cells["colPembayaran"].Style.ForeColor = bayar.Equals("Lunas", StringComparison.OrdinalIgnoreCase)
                            ? Color.Green : Color.FromArgb(200, 100, 0);
                        dgvTransaksi.Rows[idx].Cells["colPembayaran"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        dgvTransaksi.Rows[idx].Cells["colAksi"].Style.ForeColor = Color.FromArgb(26, 86, 196);
                        dgvTransaksi.Rows[idx].Cells["colAksi"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        dgvTransaksi.Rows[idx].Tag = row["id_transaksi"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat transaksi: " + ex.Message);
            }
        }

        private void HilightFilterTrx(string filter)
        {
            Color aktif = Color.FromArgb(15, 55, 150);
            Color nonAktif = Color.FromArgb(26, 86, 196);

            btnFSemua.BackColor = filter == "Semua" ? aktif : nonAktif;
            btnFMenunggu.BackColor = filter == "Menunggu" ? aktif : nonAktif;
            btnFDiproses.BackColor = filter == "Diproses" ? aktif : nonAktif;
            btnFSelesai.BackColor = filter == "Selesai" ? aktif : nonAktif;
            btnFDiambil.BackColor = filter == "Diambil" ? aktif : nonAktif;
        }

        private void btnFSemua_Click(object sender, EventArgs e) => MuatTransaksi("Semua");
        private void btnFMenunggu_Click(object sender, EventArgs e) => MuatTransaksi("Menunggu");
        private void btnFDiproses_Click(object sender, EventArgs e) => MuatTransaksi("Diproses");
        private void btnFSelesai_Click(object sender, EventArgs e) => MuatTransaksi("Selesai");
        private void btnFDiambil_Click(object sender, EventArgs e) => MuatTransaksi("Diambil");

        private void dgvTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvTransaksi.Columns["colStatus"].Index ||
                e.ColumnIndex == dgvTransaksi.Columns["colAksi"].Index)
            {
                string idTrx = dgvTransaksi.Rows[e.RowIndex].Tag?.ToString();
                string statusSaatIni = dgvTransaksi.Rows[e.RowIndex].Cells["colStatus"].Value?.ToString();

                UbahStatusTransaksi(idTrx, statusSaatIni);
            }
        }

        private void UbahStatusTransaksi(string idTransaksi, string statusSaatIni)
        {
            string statusBaru = "";
            string kodeTrx = "TRX-" + idTransaksi.PadLeft(4, '0');
            string statusLower = (statusSaatIni ?? "").ToLower().Trim();

            if (statusLower == "menunggu")
            {
                if (MessageBox.Show($"Mulai proses pengerjaan cucian untuk {kodeTrx}?\nStatus akan diubah dari 'menunggu' menjadi 'Diproses'.",
                    "Konfirmasi Proses", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    statusBaru = "Diproses";
                }
            }
            else if (statusLower == "diproses")
            {
                if (MessageBox.Show($"Selesaikan cucian untuk {kodeTrx}?\nStatus akan diubah dari 'Diproses' menjadi 'Selesai'.",
                    "Konfirmasi Selesai", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    statusBaru = "Selesai";
                }
            }
            else if (statusLower == "selesai")
            {
                if (MessageBox.Show($"Tandai cucian {kodeTrx} sudah diambil oleh pelanggan?\nStatus akan diubah dari 'Selesai' menjadi 'Diambil'.",
                    "Konfirmasi Diambil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    statusBaru = "Diambil";
                }
            }
            else if (statusLower == "diambil")
            {
                MessageBox.Show($"Transaksi {kodeTrx} sudah selesai sepenuhnya (Diambil).", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!string.IsNullOrEmpty(statusBaru))
            {
                UpdateStatusDatabase(idTransaksi, statusBaru);
            }
        }

        private void UpdateStatusDatabase(string idTransaksi, string statusBaru)
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string query = "UPDATE tbl_transaksi_header SET status = @status WHERE id_transaksi = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@status", statusBaru);
                    cmd.Parameters.AddWithValue("@id", idTransaksi);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Status transaksi berhasil diperbarui menjadi '{statusBaru}'!", "Berhasil",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                MuatTransaksi(filterAktif);
                MuatDataBeranda();
                MuatTransaksiTerbaruBeranda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengupdate status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // STYLE DGV PELANGGAN
        private void StyleDGVPelanggan()
        {
            dgvPelanggan.EnableHeadersVisualStyles = false;
            dgvPelanggan.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 86, 196);
            dgvPelanggan.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPelanggan.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvPelanggan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPelanggan.ColumnHeadersHeight = 40;
            dgvPelanggan.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvPelanggan.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 228, 255);
            dgvPelanggan.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPelanggan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPelanggan.RowTemplate.Height = 38;
            dgvPelanggan.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);
        }

        // MUAT DATA PELANGGAN
        private void MuatPelanggan()
        {
            dgvPelanggan.Rows.Clear();

            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT id_pelanggan, nama_pelanggan, no_hp, alamat FROM tbl_pelanggan ORDER BY nama_pelanggan ASC", conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int no = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        int idx = dgvPelanggan.Rows.Add(
                            no++,
                            row["nama_pelanggan"].ToString(),
                            row["no_hp"].ToString(),
                            row["alamat"].ToString(),
                            "Edit  |  Hapus"
                        );

                        dgvPelanggan.Rows[idx].Cells["colAksiPel"].Style.ForeColor = Color.FromArgb(26, 86, 196);
                        dgvPelanggan.Rows[idx].Cells["colAksiPel"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        dgvPelanggan.Rows[idx].Tag = row["id_pelanggan"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat pelanggan: " + ex.Message);
            }
        }

        private void dgvPelanggan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != dgvPelanggan.Columns["colAksiPel"].Index) return;

            string id = dgvPelanggan.Rows[e.RowIndex].Tag?.ToString();
            string nama = dgvPelanggan.Rows[e.RowIndex].Cells["colNamaPel"].Value?.ToString();

            var rect = dgvPelanggan.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            var mousePos = dgvPelanggan.PointToClient(Cursor.Position);

            if (mousePos.X < rect.X + rect.Width / 2)
            {
                FormTambahPelanggan fEdit = new FormTambahPelanggan(id);
                fEdit.ShowDialog();
                MuatPelanggan();
            }
            else
            {
                if (MessageBox.Show($"Yakin ingin menghapus pelanggan '{nama}'?", "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HapusPelanggan(id);
                }
            }
        }

        private void HapusPelanggan(string id)
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();

                    // 1. Cek apakah pelanggan punya riwayat transaksi
                    string queryCek = "SELECT COUNT(*) FROM tbl_transaksi_header WHERE id_pelanggan = @id";
                    using (MySqlCommand cmdCek = new MySqlCommand(queryCek, conn))
                    {
                        cmdCek.Parameters.AddWithValue("@id", id);
                        int jumlahTrx = Convert.ToInt32(cmdCek.ExecuteScalar());

                        if (jumlahTrx > 0)
                        {
                            MessageBox.Show(
                                $"Pelanggan ini tidak dapat dihapus karena memiliki {jumlahTrx} riwayat transaksi!\n\n" +
                                "Untuk menjaga integritas laporan keuangan, data pelanggan yang pernah melakukan transaksi tidak boleh dihapus.",
                                "Gagal Hapus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 2. Jika tidak ada transaksi, lakukan penghapusan
                    string queryHapus = "DELETE FROM tbl_pelanggan WHERE id_pelanggan = @id";
                    using (MySqlCommand cmdHapus = new MySqlCommand(queryHapus, conn))
                    {
                        cmdHapus.Parameters.AddWithValue("@id", id);
                        cmdHapus.ExecuteNonQuery();
                    }

                    MessageBox.Show("Pelanggan berhasil dihapus!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MuatPelanggan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal hapus pelanggan: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // STYLE DGV PEMBAYARAN
        private void StyleDGVPembayaran()
        {
            dgvPembayaran.EnableHeadersVisualStyles = false;
            dgvPembayaran.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 86, 196);
            dgvPembayaran.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPembayaran.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvPembayaran.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPembayaran.ColumnHeadersHeight = 40;
            dgvPembayaran.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvPembayaran.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 228, 255);
            dgvPembayaran.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvPembayaran.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPembayaran.RowTemplate.Height = 38;
            dgvPembayaran.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);
        }

        // MUAT DATA PEMBAYARAN
        private void MuatPembayaran()
        {
            dgvPembayaran.Rows.Clear();

            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();

                    string query = @"
                    SELECT 
                        th.id_transaksi,
                        p.nama_pelanggan,
                        IFNULL(SUM(td.subtotal), 0) AS total,
                        th.status_pembayaran
                    FROM tbl_transaksi_header th
                    JOIN tbl_pelanggan p ON th.id_pelanggan = p.id_pelanggan
                    LEFT JOIN tbl_transaksi_detail td ON th.id_transaksi = td.id_transaksi
                    GROUP BY th.id_transaksi
                    ORDER BY th.id_transaksi DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int no = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        decimal total = Convert.ToDecimal(row["total"]);
                        string bayar = row["status_pembayaran"].ToString();

                        int idx = dgvPembayaran.Rows.Add(
                            no++,
                            "TRX-" + row["id_transaksi"].ToString().PadLeft(4, '0'),
                            row["nama_pelanggan"].ToString(),
                            "Rp " + total.ToString("N0"),
                            bayar,
                            bayar.Equals("Lunas", StringComparison.OrdinalIgnoreCase) ? "Lunas" : "Bayar"
                        );

                        dgvPembayaran.Rows[idx].Cells["colStatusBayar"].Style.ForeColor = bayar.Equals("Lunas", StringComparison.OrdinalIgnoreCase)
                            ? Color.Green : Color.FromArgb(200, 100, 0);
                        dgvPembayaran.Rows[idx].Cells["colStatusBayar"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        dgvPembayaran.Rows[idx].Cells["colAksiBayar"].Style.ForeColor = bayar.Equals("Lunas", StringComparison.OrdinalIgnoreCase)
                            ? Color.Gray : Color.FromArgb(26, 86, 196);
                        dgvPembayaran.Rows[idx].Cells["colAksiBayar"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        dgvPembayaran.Rows[idx].Tag = row["id_transaksi"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat pembayaran: " + ex.Message);
            }
        }

        private void CetakNotaPDFAdmin(string idTransaksi)
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    th.id_transaksi,
                    p.nama_pelanggan,
                    j.nama_layanan,
                    td.berat_kg,
                    td.subtotal,
                    th.status_pembayaran,
                    th.metode_pembayaran,
                    th.bayar,
                    th.kembali,
                    th.estimasi_selesai,
                    th.tanggal_masuk
                FROM tbl_transaksi_header th
                JOIN tbl_pelanggan p ON th.id_pelanggan = p.id_pelanggan
                JOIN tbl_transaksi_detail td ON th.id_transaksi = td.id_transaksi
                JOIN tbl_jenis_layanan j ON td.id_layanan = j.id_layanan
                WHERE th.id_transaksi = @id LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idTransaksi);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string kode = "TRX-" + reader["id_transaksi"].ToString().PadLeft(4, '0');
                        string pelanggan = reader["nama_pelanggan"].ToString();
                        string layanan = reader["nama_layanan"].ToString();
                        decimal berat = Convert.ToDecimal(reader["berat_kg"]);
                        decimal total = Convert.ToDecimal(reader["subtotal"]);
                        string statusBayar = reader["status_pembayaran"].ToString();
                        DateTime estimasi = Convert.ToDateTime(reader["estimasi_selesai"]);
                        DateTime tglMasuk = Convert.ToDateTime(reader["tanggal_masuk"]);

                        reader.Close();

                        PrintDocument pd = new PrintDocument();
                        pd.PrintPage += (s, ev) =>
                        {
                            Font fontTitle = new Font("Courier New", 14, FontStyle.Bold);
                            Font fontHeader = new Font("Courier New", 10, FontStyle.Bold);
                            Font fontBody = new Font("Courier New", 10, FontStyle.Regular);
                            Font fontTotal = new Font("Segoe UI", 13, FontStyle.Bold);
                            Brush brush = Brushes.Black;

                            float pageWidth = ev.PageBounds.Width;
                            float notaWidth = 320;
                            float startX = (pageWidth - notaWidth) / 2;
                            float y = 40;
                            float lineOffset = 22;

                            StringFormat formatCenter = new StringFormat { Alignment = StringAlignment.Center };

                            ev.Graphics.DrawString("LAUNDRYZKY", fontTitle, brush, pageWidth / 2, y, formatCenter);
                            y += lineOffset + 2;
                            ev.Graphics.DrawString("Jl. Cimindi Tengah No. 15, Cimahi", fontBody, brush, pageWidth / 2, y, formatCenter);
                            y += lineOffset;
                            ev.Graphics.DrawString("==================================", fontHeader, brush, startX, y);
                            y += lineOffset;

                            ev.Graphics.DrawString("Kode TRX   : " + kode, fontBody, brush, startX, y);
                            y += lineOffset;
                            ev.Graphics.DrawString("Tgl Masuk  : " + tglMasuk.ToString("dd/MM/yyyy HH:mm"), fontBody, brush, startX, y);
                            y += lineOffset;
                            ev.Graphics.DrawString("Pelanggan  : " + pelanggan, fontBody, brush, startX, y);
                            y += lineOffset;
                            ev.Graphics.DrawString("----------------------------------", fontHeader, brush, startX, y);
                            y += lineOffset;

                            ev.Graphics.DrawString("Layanan    : " + layanan, fontBody, brush, startX, y);
                            y += lineOffset;
                            ev.Graphics.DrawString("Berat      : " + berat.ToString("N0") + " Kg", fontBody, brush, startX, y);
                            y += lineOffset;
                            ev.Graphics.DrawString("Estimasi   : " + estimasi.ToString("dd/MM/yyyy HH:mm"), fontBody, brush, startX, y);
                            y += lineOffset;
                            ev.Graphics.DrawString("Status     : " + statusBayar.ToUpper(), fontBody, brush, startX, y);
                            y += lineOffset;
                            ev.Graphics.DrawString("----------------------------------", fontHeader, brush, startX, y);
                            y += lineOffset + 5;

                            Brush colorStatus = statusBayar.Equals("Lunas", StringComparison.OrdinalIgnoreCase) ? Brushes.Green : Brushes.Red;
                            ev.Graphics.DrawString("TOTAL      : Rp " + total.ToString("N0"), fontTotal, colorStatus, startX, y);
                            y += lineOffset + 25;

                            ev.Graphics.DrawString("==================================", fontHeader, brush, startX, y);
                            y += lineOffset;
                            ev.Graphics.DrawString("Terima Kasih Atas Kepercayaan Anda!", fontBody, brush, pageWidth / 2, y, formatCenter);
                            y += lineOffset;
                            ev.Graphics.DrawString("Simpan Nota Ini Sebagai Bukti Ambil", fontBody, brush, pageWidth / 2, y, formatCenter);
                        };

                        PrintPreviewDialog preview = new PrintPreviewDialog { Document = pd };
                        preview.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencetak nota: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPembayaran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != dgvPembayaran.Columns["colAksiBayar"].Index) return;

            string id = dgvPembayaran.Rows[e.RowIndex].Tag?.ToString();
            string bayarStatus = dgvPembayaran.Rows[e.RowIndex].Cells["colStatusBayar"].Value?.ToString();

            if (bayarStatus.Equals("Lunas", StringComparison.OrdinalIgnoreCase))
            {
                if (MessageBox.Show("Transaksi ini sudah Lunas. Ingin cetak ulang nota bukti?", "Cetak Ulang Nota", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CetakNotaPDFAdmin(id);
                }
                return;
            }

            string stringTotal = dgvPembayaran.Rows[e.RowIndex].Cells["colTotal"].Value?.ToString() ?? "0";
            string cleanTotal = stringTotal.Replace("Rp", "").Replace(".", "").Replace(",", "").Trim();

            if (decimal.TryParse(cleanTotal, out decimal totalTagihan))
            {
                FormPembayaran fBayar = new FormPembayaran(totalTagihan);

                if (fBayar.ShowDialog() == DialogResult.OK)
                {
                    string metode = fBayar.MetodePembayaran;
                    decimal uangBayar = fBayar.UangBayar;
                    decimal uangKembali = fBayar.UangKembali;

                    BayarTransaksiRealistis(id, metode, uangBayar, uangKembali);
                }
            }
        }

        private void BayarTransaksiRealistis(string idTransaksi, string metode, decimal uangBayar, decimal uangKembali)
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string query = @"UPDATE tbl_transaksi_header 
                                     SET status_pembayaran = 'Lunas',
                                         metode_pembayaran = @metode,
                                         bayar = @bayar,
                                         kembali = @kembali
                                     WHERE id_transaksi = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@metode", metode);
                        cmd.Parameters.AddWithValue("@bayar", uangBayar);
                        cmd.Parameters.AddWithValue("@kembali", uangKembali);
                        cmd.Parameters.AddWithValue("@id", idTransaksi);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Pembayaran berhasil diproses!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CetakNotaPDFAdmin(idTransaksi);

                MuatPembayaran();
                MuatDataBeranda();
                MuatTransaksiTerbaruBeranda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memproses pembayaran: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BayarTransaksi(string id)
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE tbl_transaksi_header SET status_pembayaran = 'Lunas' WHERE id_transaksi = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Pembayaran berhasil dicatat!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MuatPembayaran();
                MuatDataBeranda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal bayar: " + ex.Message);
            }
        }

        // STYLE DGV LAPORAN
        private void StyleDGVLaporan()
        {
            dgvLaporan.EnableHeadersVisualStyles = false;
            dgvLaporan.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 86, 196);
            dgvLaporan.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLaporan.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvLaporan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLaporan.ColumnHeadersHeight = 40;
            dgvLaporan.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvLaporan.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 228, 255);
            dgvLaporan.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvLaporan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLaporan.RowTemplate.Height = 38;
            dgvLaporan.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);
        }

        // MUAT DATA LAPORAN
        private void MuatLaporan(DateTime dari, DateTime sampai)
        {
            dgvLaporan.Rows.Clear();

            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();

                    string query = @"
                    SELECT 
                        th.id_transaksi,
                        p.nama_pelanggan,
                        j.nama_layanan,
                        td.berat_kg,
                        td.subtotal,
                        th.status,
                        th.tanggal_masuk,
                        th.status_pembayaran
                    FROM tbl_transaksi_header th
                    JOIN tbl_pelanggan p ON th.id_pelanggan = p.id_pelanggan
                    JOIN tbl_transaksi_detail td ON th.id_transaksi = td.id_transaksi
                    JOIN tbl_jenis_layanan j ON td.id_layanan = j.id_layanan
                    WHERE th.tanggal_masuk BETWEEN @dari AND @sampai
                    ORDER BY th.id_transaksi DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@dari", dari.ToString("yyyy-MM-dd 00:00:00"));
                    cmd.Parameters.AddWithValue("@sampai", sampai.ToString("yyyy-MM-dd 23:59:59"));

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int no = 1;
                    int totalTrx = 0;
                    decimal totalPend = 0;
                    int totalLunas = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        decimal subtotal = Convert.ToDecimal(row["subtotal"]);
                        string status = row["status"].ToString();
                        string bayar = row["status_pembayaran"].ToString();

                        int idx = dgvLaporan.Rows.Add(
                            no++,
                            "TRX-" + row["id_transaksi"].ToString().PadLeft(4, '0'),
                            row["nama_pelanggan"].ToString(),
                            row["nama_layanan"].ToString(),
                            row["berat_kg"].ToString() + " Kg",
                            "Rp " + subtotal.ToString("N0"),
                            status,
                            Convert.ToDateTime(row["tanggal_masuk"]).ToString("dd-MM-yyyy")
                        );

                        Color warnaStatus = status.Equals("Menunggu", StringComparison.OrdinalIgnoreCase) ? Color.FromArgb(26, 86, 196)
                                          : status.Equals("Diproses", StringComparison.OrdinalIgnoreCase) ? Color.Orange
                                          : status.Equals("Selesai", StringComparison.OrdinalIgnoreCase) ? Color.Green
                                          : Color.Gray;

                        dgvLaporan.Rows[idx].Cells["colStatusLap"].Style.ForeColor = warnaStatus;
                        dgvLaporan.Rows[idx].Cells["colStatusLap"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        totalTrx++;
                        if (bayar.Equals("Lunas", StringComparison.OrdinalIgnoreCase))
                        {
                            totalPend += subtotal;
                            totalLunas++;
                        }
                    }

                    lblTotalTransaksi.Text = "Total Transaksi : " + totalTrx;
                    lblTotalPendapatan.Text = "Total Pendapatan : Rp " + totalPend.ToString("N0");
                    lblTotalLunas.Text = "Sudah Lunas : " + totalLunas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat laporan: " + ex.Message);
            }
        }

        private void btnTampilLaporan_Click(object sender, EventArgs e)
        {
            MuatLaporan(dtpDari.Value, dtpSampai.Value);
        }

        private void btnExportLaporan_Click(object sender, EventArgs e)
        {
            if (dgvLaporan.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data laporan untuk diexport!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF File (*.pdf)|*.pdf";
            sfd.FileName = $"Laporan_Laundry_{dtpDari.Value:yyyyMMdd}_sd_{dtpSampai.Value:yyyyMMdd}.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CetakKePDF(sfd.FileName);
                    MessageBox.Show("Laporan berhasil diexport ke PDF!", "Berhasil",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal export PDF: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CetakKePDF(string filePath)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            pd.PrinterSettings.PrintToFile = true;
            pd.PrinterSettings.PrintFileName = filePath;
            pd.DefaultPageSettings.Landscape = true;

            pd.PrintPage += (s, ev) =>
            {
                Font fontJudul = new Font("Segoe UI", 16, FontStyle.Bold);
                Font fontSub = new Font("Segoe UI", 10, FontStyle.Regular);
                Font fontHeader = new Font("Segoe UI", 9, FontStyle.Bold);
                Font fontIsi = new Font("Segoe UI", 9, FontStyle.Regular);

                Brush brushHitam = Brushes.Black;
                Pen penGaris = new Pen(Color.LightGray, 1);

                int startX = 40;
                int startY = 40;
                int offsetY = startY;

                ev.Graphics.DrawString("LAPORAN TRANSAKSI LAUNDRYZKY", fontJudul, brushHitam, startX, offsetY);
                offsetY += 30;
                ev.Graphics.DrawString($"Periode: {dtpDari.Value:dd-MM-yyyy} s/d {dtpSampai.Value:dd-MM-yyyy}", fontSub, brushHitam, startX, offsetY);
                offsetY += 20;
                ev.Graphics.DrawString($"{lblTotalTransaksi.Text}   |   {lblTotalPendapatan.Text}   |   {lblTotalLunas.Text}", fontSub, brushHitam, startX, offsetY);
                offsetY += 30;

                int[] colWidths = { 40, 100, 160, 130, 80, 100, 90, 100 };
                string[] headers = { "No", "No Transaksi", "Nama Pelanggan", "Layanan", "Berat", "Total", "Status", "Tgl Masuk" };

                int currX = startX;
                for (int i = 0; i < headers.Length; i++)
                {
                    ev.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(26, 86, 196)), currX, offsetY, colWidths[i], 25);
                    ev.Graphics.DrawString(headers[i], fontHeader, Brushes.White, currX + 5, offsetY + 5);
                    currX += colWidths[i];
                }
                offsetY += 25;

                foreach (DataGridViewRow row in dgvLaporan.Rows)
                {
                    if (row.IsNewRow) continue;

                    currX = startX;
                    for (int i = 0; i < colWidths.Length; i++)
                    {
                        string val = row.Cells[i].Value?.ToString() ?? "";
                        ev.Graphics.DrawRectangle(penGaris, currX, offsetY, colWidths[i], 22);
                        ev.Graphics.DrawString(val, fontIsi, brushHitam, currX + 5, offsetY + 3);
                        currX += colWidths[i];
                    }
                    offsetY += 22;
                }
            };

            pd.Print();
        }

        // STYLE DGV USER
        private void StyleDGVUser()
        {
            dgvUser.EnableHeadersVisualStyles = false;
            dgvUser.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 86, 196);
            dgvUser.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUser.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvUser.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUser.ColumnHeadersHeight = 40;
            dgvUser.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvUser.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 228, 255);
            dgvUser.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvUser.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUser.RowTemplate.Height = 38;
            dgvUser.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);
        }

        // MUAT DATA USER
        private void MuatUser()
        {
            dgvUser.Rows.Clear();

            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT id_user, nama_user, username, role, status FROM tbl_user ORDER BY role, nama_user", conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int no = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        string status = row["status"].ToString();
                        string role = row["role"].ToString();

                        string aksi = role.Equals("admin", StringComparison.OrdinalIgnoreCase)
                            ? "-"
                            : status.Equals("aktif", StringComparison.OrdinalIgnoreCase) ? "Edit  |  Nonaktif" : "Edit  |  Aktifkan";

                        int idx = dgvUser.Rows.Add(
                            no++,
                            row["nama_user"].ToString(),
                            row["username"].ToString(),
                            role.ToUpper(),
                            status.ToUpper(),
                            aksi
                        );

                        dgvUser.Rows[idx].Cells["colRole"].Style.ForeColor = role.Equals("admin", StringComparison.OrdinalIgnoreCase)
                            ? Color.FromArgb(26, 86, 196)
                            : Color.FromArgb(200, 100, 0);
                        dgvUser.Rows[idx].Cells["colRole"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        dgvUser.Rows[idx].Cells["colStatusUser"].Style.ForeColor = status.Equals("aktif", StringComparison.OrdinalIgnoreCase)
                            ? Color.Green : Color.Red;
                        dgvUser.Rows[idx].Cells["colStatusUser"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        dgvUser.Rows[idx].Cells["colAksiUser"].Style.ForeColor = Color.FromArgb(26, 86, 196);
                        dgvUser.Rows[idx].Cells["colAksiUser"].Style.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        dgvUser.Rows[idx].Tag = row["id_user"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat user: " + ex.Message);
            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != dgvUser.Columns["colAksiUser"].Index) return;

            string id = dgvUser.Rows[e.RowIndex].Tag?.ToString();
            string role = dgvUser.Rows[e.RowIndex].Cells["colRole"].Value?.ToString();
            string status = dgvUser.Rows[e.RowIndex].Cells["colStatusUser"].Value?.ToString();
            string nama = dgvUser.Rows[e.RowIndex].Cells["colNamaUser"].Value?.ToString();

            if (role == "ADMIN") return;

            var rect = dgvUser.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            var mousePos = dgvUser.PointToClient(Cursor.Position);

            if (mousePos.X < rect.X + rect.Width / 2)
            {
                FormTambahUser fEdit = new FormTambahUser(id);
                fEdit.ShowDialog();
                MuatUser();
            }
            else
            {
                string aksiStr = status == "AKTIF" ? "nonaktifkan" : "aktifkan";
                string statusBaru = status == "AKTIF" ? "nonaktif" : "aktif";

                if (MessageBox.Show($"Yakin ingin {aksiStr} user '{nama}'?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UbahStatusUser(id, statusBaru);
                }
            }
        }

        private void UbahStatusUser(string id, string statusBaru)
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE tbl_user SET status = @status WHERE id_user = @id", conn);
                    cmd.Parameters.AddWithValue("@status", statusBaru);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Status user berhasil diubah!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MuatUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal ubah status: " + ex.Message);
            }
        }
    }
}