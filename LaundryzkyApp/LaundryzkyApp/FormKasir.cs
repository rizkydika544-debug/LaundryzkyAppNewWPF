using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LaundryzkyApp
{
    public partial class FormKasir : Form
    {
        private string namaUser;
        private int idUser;

        public FormKasir(string nama, int id)
        {
            InitializeComponent();
            namaUser = nama;
            idUser = id;
        }

        private void FormKasir_Load(object sender, EventArgs e)
        {
            this.Text = "Dashboard Kasir - " + namaUser;
            lblNamaUser.Text = "Halo, " + namaUser + " (Kasir)";
            lblTanggal.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy",
                new System.Globalization.CultureInfo("id-ID"));

            cmbPelanggan.Focus();

            MuatDataPelanggan();
            MuatDataLayanan();
            ResetFormPOS();

            TampilkanPOS();
        }

        #region --- HELPER WADAH SUB-FORM ---

        private void TampilkanForm(Form formBaru)
        {
            panelContent.Controls.Clear();
            formBaru.TopLevel = false;
            formBaru.FormBorderStyle = FormBorderStyle.None;
            formBaru.Dock = DockStyle.Fill;

            panelContent.Controls.Add(formBaru);
            panelContent.Tag = formBaru;
            formBaru.Show();
        }

        private void TampilkanPOS()
        {
            panelContent.Controls.Clear();
            panelContent.Controls.Add(panelPOS);
            panelPOS.Dock = DockStyle.Fill;
            panelPOS.Visible = true;
            panelPOS.BringToFront();
        }

        #endregion

        #region --- LOGIKA DATABASE & DATA LOADING POS ---

        private void MuatDataPelanggan()
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string query = "SELECT id_pelanggan, nama_pelanggan FROM tbl_pelanggan ORDER BY nama_pelanggan ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbPelanggan.DataSource = dt;
                    cmbPelanggan.DisplayMember = "nama_pelanggan";
                    cmbPelanggan.ValueMember = "id_pelanggan";
                    cmbPelanggan.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data pelanggan: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MuatDataLayanan()
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string query = "SELECT id_layanan, nama_layanan, harga_per_kg FROM tbl_jenis_layanan ORDER BY id_layanan ASC";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbLayanan.DataSource = dt;
                    cmbLayanan.DisplayMember = "nama_layanan";
                    cmbLayanan.ValueMember = "id_layanan";
                    cmbLayanan.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data layanan: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper untuk menghitung jumlah order aktif yang masih diproses/menunggu di database
        private int DapatkanJumlahOrderAktif()
        {
            int totalAktif = 0;
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) FROM tbl_transaksi_header 
                                     WHERE status IN ('menunggu', 'diproses')";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    totalAktif = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengecek kapasitas antrean: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return totalAktif;
        }

        #endregion

        #region --- LOGIKA HITUNG LIVE POS, ESTIMASI & STRUK ---

        // Algoritma waktu nyata pengerjaan laundry berdasarkan durasi proses, berat Kg, & kuota antrean harian
        private DateTime HitungEstimasiSelesai(int idLayanan, decimal beratKg)
        {
            DateTime skrg = DateTime.Now;
            double totalMenitProses = 0;

            switch (idLayanan)
            {
                case 1: // Cuci Reguler (9 mnt/kg + antrean 24 jam)
                    totalMenitProses = ((double)beratKg * 9) + (24 * 60);
                    break;
                case 2: // Cuci + Setrika (24 mnt/kg + antrean 24 jam)
                    totalMenitProses = ((double)beratKg * 24) + (24 * 60);
                    break;
                case 3: // Setrika Saja (15 mnt/kg + antrean 12 jam)
                    totalMenitProses = ((double)beratKg * 15) + (12 * 60);
                    break;
                case 4: // Express (24 mnt/kg + antrean 6 jam)
                    totalMenitProses = ((double)beratKg * 24) + (6 * 60);
                    break;
                case 5: // Super Express (Murni proses tanpa antrean + 1 jam penanganan)
                    totalMenitProses = ((double)beratKg * 24) + 60;
                    break;
                default:
                    totalMenitProses = 24 * 60;
                    break;
            }

            // Pengecekan Kapasitas Harian (Maksimal 20 Order Aktif)
            int orderAktif = DapatkanJumlahOrderAktif();
            if (orderAktif >= 20)
            {
                // Jika melebihi kuota 20 orderan, tambahkan delay +24 jam (1 hari) per kelipatan 20 order
                int hariDelay = (orderAktif / 20);
                totalMenitProses += (hariDelay * 24 * 60);
            }

            return skrg.AddMinutes(totalMenitProses);
        }

        private void HitungTotalLive()
        {
            if (cmbLayanan.SelectedIndex != -1 && !string.IsNullOrEmpty(txtBerat.Text))
            {
                if (decimal.TryParse(txtBerat.Text, out decimal berat) && berat > 0)
                {
                    if (berat > 50) berat = 50;

                    DataRowView row = (DataRowView)cmbLayanan.SelectedItem;
                    decimal hargaPerKg = Convert.ToDecimal(row["harga_per_kg"]);
                    int idLayanan = Convert.ToInt32(row["id_layanan"]);
                    decimal totalBayar = berat * hargaPerKg;

                    DateTime estimasi = HitungEstimasiSelesai(idLayanan, berat);
                    int orderAktif = DapatkanJumlahOrderAktif();

                    lblHargaPerKg.Text = "Rp " + hargaPerKg.ToString("N0") + " / Kg";
                    lblTotalBayarLive.Text = "Rp " + totalBayar.ToString("N0");

                    string infoOverCapacity = orderAktif >= 20
                        ? "\n\n⚠️ Status  : Antrean Penuh (+" + (orderAktif / 20) + " Hari)"
                        : "";

                    lblStrukDetail.Text = "Berat    : " + berat.ToString("N0") + " Kg @ Rp " + hargaPerKg.ToString("N0") +
                                         "\n\nEstimasi : " + estimasi.ToString("dd/MM/yyyy HH:mm") + infoOverCapacity;
                }
                else
                {
                    lblTotalBayarLive.Text = "Rp 0";
                    lblStrukDetail.Text = "Berat    : 0 Kg";
                }
            }
            else
            {
                lblTotalBayarLive.Text = "Rp 0";
                lblHargaPerKg.Text = "Rp 0 / Kg";
            }
        }

        private void cmbPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStrukPelanggan.Text = cmbPelanggan.SelectedIndex != -1
                ? "Pelanggan : " + cmbPelanggan.Text
                : "Pelanggan : -";
        }

        private void cmbLayanan_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblStrukLayanan.Text = cmbLayanan.SelectedIndex != -1
                ? "Layanan   : " + cmbLayanan.Text
                : "Layanan   : -";
            HitungTotalLive();
        }

        private void txtBerat_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtBerat.Text, out decimal berat))
            {
                if (berat > 50)
                {
                    MessageBox.Show("Maksimal berat pengerjaan adalah 50 Kg!", "Batas Maksimal", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtBerat.Text = "50";
                    txtBerat.SelectionStart = txtBerat.Text.Length;
                }
            }

            HitungTotalLive();
        }

        private void rbBayarPasAmbil_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBayarPasAmbil.Checked)
            {
                lblStrukStatus.Text = "Status   : BELUM LUNAS";
                lblStrukStatus.ForeColor = Color.Red;
            }
        }

        private void rbBayarSekarang_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBayarSekarang.Checked)
            {
                lblStrukStatus.Text = "Status   : LUNAS";
                lblStrukStatus.ForeColor = Color.Green;
            }
        }

        private void ResetFormPOS()
        {
            cmbPelanggan.SelectedIndex = -1;
            cmbLayanan.SelectedIndex = -1;
            txtBerat.Text = "1";
            rbBayarPasAmbil.Checked = true;
            lblStrukPelanggan.Text = "Pelanggan : -";
            lblStrukLayanan.Text = "Layanan   : -";
            lblStrukDetail.Text = "Berat     : 1 Kg @ Rp 0";
            lblStrukStatus.Text = "Status    : BELUM LUNAS";
            lblStrukStatus.ForeColor = Color.Red;
            lblTotalBayarLive.Text = "Rp 0";
            lblHargaPerKg.Text = "Rp 0 / Kg";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormPOS();
        }

        #endregion

        private bool CekPelangganPunyaOrderAktif(int idPelanggan)
        {
            bool adaOrderAktif = false;
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) FROM tbl_transaksi_header 
                             WHERE id_pelanggan = @idPel 
                             AND status IN ('menunggu', 'diproses')";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idPel", idPelanggan);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        adaOrderAktif = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengecek riwayat pelanggan: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return adaOrderAktif;
        }

        #region --- SIMPAN TRANSAKSI & CETAK NOTA ---

        private void btnSimpanPOS_Click(object sender, EventArgs e)
        {
            if (cmbPelanggan.SelectedIndex == -1)
            {
                MessageBox.Show("Silakan pilih pelanggan terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idPelanggan = Convert.ToInt32(cmbPelanggan.SelectedValue);

            // VALIDASI ORDER GANDA
            if (CekPelangganPunyaOrderAktif(idPelanggan))
            {
                MessageBox.Show("Pelanggan ini masih memiliki cucian yang sedang diproses atau dalam antrean!\n\nOrder baru tidak dapat dibuat sebelum pesanan sebelumnya SELESAI atau DIAMBIL.",
                                "Order Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (cmbLayanan.SelectedIndex == -1)
            {
                MessageBox.Show("Silakan pilih jenis layanan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtBerat.Text, out decimal berat) || berat <= 0)
            {
                MessageBox.Show("Masukkan jumlah berat (Kg) yang valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idLayanan = Convert.ToInt32(cmbLayanan.SelectedValue);
            DataRowView rowLayanan = (DataRowView)cmbLayanan.SelectedItem;
            decimal hargaPerKg = Convert.ToDecimal(rowLayanan["harga_per_kg"]);
            decimal totalBayar = berat * hargaPerKg;

            // Default Nilai Pembayaran (jika Belum Lunas)
            string statusBayar = "belum lunas";
            string metodeBayar = "Tunai";
            decimal uangBayar = 0;
            decimal uangKembali = 0;

            // JIKA KASIR MEMILIH "BAYAR SEKARANG", BUKA POP-UP FORM PEMBAYARAN!
            if (rbBayarSekarang.Checked)
            {
                FormPembayaran fBayar = new FormPembayaran(totalBayar);

                if (fBayar.ShowDialog() == DialogResult.OK)
                {
                    statusBayar = "lunas";
                    metodeBayar = fBayar.MetodePembayaran;
                    uangBayar = fBayar.UangBayar;
                    uangKembali = fBayar.UangKembali;
                }
                else
                {
                    MessageBox.Show("Transaksi dibatalkan karena proses pembayaran belum selesai.", "Transaksi Batal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DateTime estimasiSelesai = HitungEstimasiSelesai(idLayanan, berat);

            // =========================================================================
            // POP-UP KONFIRMASI DAHULU SEBELUM SIMPAN & CETAK NOTA
            // =========================================================================
            string pesanKonfirmasi = $"Apakah Anda yakin ingin menyimpan dan mencetak nota transaksi ini?\n\n" +
                                    $"• Pelanggan : {cmbPelanggan.Text}\n" +
                                    $"• Layanan    : {cmbLayanan.Text}\n" +
                                    $"• Berat      : {berat:N0} Kg\n" +
                                    $"• Total      : Rp {totalBayar:N0}\n" +
                                    $"• Status     : {statusBayar.ToUpper()} ({metodeBayar})\n" +
                                    $"• Estimasi   : {estimasiSelesai:dd/MM/yyyy HH:mm}";

            DialogResult dialogResult = MessageBox.Show(pesanKonfirmasi, "Konfirmasi Simpan Transaksi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
            {
                return; // Batal simpan jika kasir memilih 'No'
            }

            // =========================================================================
            // PROSES SIMPAN KE DATABASE MYSQL
            // =========================================================================
            using (MySqlConnection conn = Koneksi.GetConn())
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string queryHeader = @"INSERT INTO tbl_transaksi_header 
                                  (id_pelanggan, id_user, tanggal_masuk, estimasi_selesai, status, status_pembayaran, metode_pembayaran, bayar, kembali) 
                                  VALUES 
                                  (@idPel, @idUser, NOW(), @estimasi, 'menunggu', @statusBayar, @metode, @bayar, @kembali);
                                  SELECT LAST_INSERT_ID();";

                    long newIdTransaksi = 0;

                    using (MySqlCommand cmdHeader = new MySqlCommand(queryHeader, conn, trans))
                    {
                        cmdHeader.Parameters.AddWithValue("@idPel", idPelanggan);
                        cmdHeader.Parameters.AddWithValue("@idUser", idUser);
                        cmdHeader.Parameters.AddWithValue("@estimasi", estimasiSelesai);
                        cmdHeader.Parameters.AddWithValue("@statusBayar", statusBayar);
                        cmdHeader.Parameters.AddWithValue("@metode", metodeBayar);
                        cmdHeader.Parameters.AddWithValue("@bayar", uangBayar);
                        cmdHeader.Parameters.AddWithValue("@kembali", uangKembali);
                        newIdTransaksi = Convert.ToInt64(cmdHeader.ExecuteScalar());
                    }

                    string queryDetail = @"INSERT INTO tbl_transaksi_detail 
                                  (id_transaksi, id_layanan, berat_kg, harga_per_kg, subtotal) 
                                  VALUES 
                                  (@idTrans, @idLay, @berat, @harga, @subtotal)";

                    using (MySqlCommand cmdDetail = new MySqlCommand(queryDetail, conn, trans))
                    {
                        cmdDetail.Parameters.AddWithValue("@idTrans", newIdTransaksi);
                        cmdDetail.Parameters.AddWithValue("@idLay", idLayanan);
                        cmdDetail.Parameters.AddWithValue("@berat", berat);
                        cmdDetail.Parameters.AddWithValue("@harga", hargaPerKg);
                        cmdDetail.Parameters.AddWithValue("@subtotal", totalBayar);
                        cmdDetail.ExecuteNonQuery();
                    }

                    trans.Commit();

                    string kodeNota = "TRX-" + newIdTransaksi.ToString("D4");
                    MessageBox.Show("Transaksi berhasil disimpan!\nKode: " + kodeNota + "\nEstimasi Selesai: " + estimasiSelesai.ToString("dd/MM/yyyy HH:mm"), "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cetak Nota PDF
                    CetakNotaPDF(kodeNota, cmbPelanggan.Text, cmbLayanan.Text, berat, totalBayar, statusBayar, estimasiSelesai);
                    ResetFormPOS();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Gagal menyimpan transaksi: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CetakNotaPDF(string kode, string pelanggan, string layanan, decimal berat, decimal total, string statusBayar, DateTime estimasi)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                // Font khas nota kasir
                Font fontTitle = new Font("Courier New", 14, FontStyle.Bold);
                Font fontHeader = new Font("Courier New", 10, FontStyle.Bold);
                Font fontBody = new Font("Courier New", 10, FontStyle.Regular);
                Font fontTotal = new Font("Segoe UI", 13, FontStyle.Bold);
                Brush brush = Brushes.Black;

                float pageWidth = ev.PageBounds.Width;
                float notaWidth = 320; // Lebar nota thermal standar
                float startX = (pageWidth - notaWidth) / 2;
                float y = 40;
                float lineOffset = 22;

                StringFormat formatCenter = new StringFormat { Alignment = StringAlignment.Center };

                // HEADER
                ev.Graphics.DrawString("LAUNDRYZKY", fontTitle, brush, pageWidth / 2, y, formatCenter);
                y += lineOffset + 2;
                ev.Graphics.DrawString("Jl. Cimindi Tengah No. 15, Cimahi", fontBody, brush, pageWidth / 2, y, formatCenter);
                y += lineOffset;
                ev.Graphics.DrawString("==================================", fontHeader, brush, startX, y);
                y += lineOffset;

                // DETAIL TRANSAKSI (Gunakan padding string RAPIH dan SEJAJAR)
                ev.Graphics.DrawString("Kode TRX   : " + kode, fontBody, brush, startX, y);
                y += lineOffset;
                ev.Graphics.DrawString("Tgl Masuk  : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontBody, brush, startX, y);
                y += lineOffset;
                ev.Graphics.DrawString("Pelanggan  : " + pelanggan, fontBody, brush, startX, y);
                y += lineOffset;
                ev.Graphics.DrawString("----------------------------------", fontHeader, brush, startX, y);
                y += lineOffset;

                // DETAIL ITEM & LAYANAN
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

                // TOTAL BAYAR & FOOTER
                Brush colorStatus = statusBayar == "lunas" ? Brushes.Green : Brushes.Red;
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

        private void btnTambahPelangganBaru_Click(object sender, EventArgs e)
        {
            FormTambahPelanggan formTambah = new FormTambahPelanggan();
            if (formTambah.ShowDialog() == DialogResult.OK)
            {
                MuatDataPelanggan();
            }
        }

        #endregion

        #region --- NAVIGASI BAR & MENU ---

        private void btnMenuPOS_Click(object sender, EventArgs e)
        {
            lblHalaman.Text = "Kasir (POS Live)";
            TampilkanPOS();
        }

        private void btnMenuTransaksi_Click(object sender, EventArgs e)
        {
            lblHalaman.Text = "Daftar Transaksi";
            TampilkanForm(new FormDaftarTransaksi());
        }

        private void btnMenuPelanggan_Click(object sender, EventArgs e)
        {
            lblHalaman.Text = "Data Pelanggan";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
            }
        }

        private void FormKasir_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}