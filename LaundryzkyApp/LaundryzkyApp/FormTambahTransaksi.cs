using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LaundryzkyApp
{
    public partial class FormTambahTransaksi : Form
    {
        private DataTable dtLayanan;

        public FormTambahTransaksi()
        {
            InitializeComponent();
        }

        private void FormTambahTransaksi_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;

            // Load data ComboBox dari Database
            MuatPelanggan();
            MuatLayanan();

            // Format Status Pembayaran
            cmbBayar.Items.Clear();
            cmbBayar.Items.Add("Belum Lunas");
            cmbBayar.Items.Add("Lunas");
            cmbBayar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBayar.SelectedIndex = 0;

            // Batasi nilai NumericUpDown di level interface (Min: 1, Max: 50)
            nudBerat.Minimum = 0;
            nudBerat.Maximum = 50;
            nudBerat.Value = 1;

            // Hitung subtotal awal
            HitungSubtotal();
        }

        private void MuatPelanggan()
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string query = "SELECT id_pelanggan, nama_pelanggan FROM tbl_pelanggan ORDER BY nama_pelanggan ASC";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbPelanggan.DataSource = dt;
                    cmbPelanggan.DisplayMember = "nama_pelanggan";
                    cmbPelanggan.ValueMember = "id_pelanggan";
                    cmbPelanggan.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbPelanggan.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat pelanggan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MuatLayanan()
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string query = "SELECT id_layanan, nama_layanan, harga_per_kg FROM tbl_jenis_layanan ORDER BY nama_layanan ASC";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    dtLayanan = new DataTable();
                    da.Fill(dtLayanan);

                    cmbLayanan.DataSource = dtLayanan;
                    cmbLayanan.DisplayMember = "nama_layanan";
                    cmbLayanan.ValueMember = "id_layanan";
                    cmbLayanan.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmbLayanan.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat layanan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HitungSubtotal()
        {
            if (cmbLayanan.SelectedValue != null && dtLayanan != null && dtLayanan.Rows.Count > 0)
            {
                if (cmbLayanan.SelectedItem is DataRowView selectedRow)
                {
                    decimal hargaPerKg = Convert.ToDecimal(selectedRow["harga_per_kg"]);
                    decimal berat = nudBerat.Value;

                    // Validasi Live Berat
                    if (berat > 50)
                    {
                        berat = 50;
                        nudBerat.Value = 50;
                    }

                    decimal total = hargaPerKg * berat;

                    lblTotal.Text = "Rp " + total.ToString("N0");
                    lblTotal.Tag = total;
                }
            }
            else
            {
                lblTotal.Text = "Rp 0";
                lblTotal.Tag = 0m;
            }
        }

        private void cmbLayanan_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
            HitungSubtotal();
        }

        private void nudBerat_ValueChanged(object sender, EventArgs e)
        {
            // Auto correct jika diisi minus/nol atau lebih dari 50
            if (nudBerat.Value > 50)
            {
                MessageBox.Show("Maksimal berat cucian per transaksi adalah 50 Kg!", "Batas Maksimal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudBerat.Value = 50;
            }
            else if (nudBerat.Value <= 0)
            {
                nudBerat.Value = 1;
            }

            HitungSubtotal();
        }

        private void cmbPelanggan_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void cmbBayar_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        // Helper Cek Order Aktif Pelanggan
        private bool CekPelangganPunyaOrderAktif(int idPelanggan)
        {
            bool adaOrderAktif = false;
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) FROM tbl_transaksi_header 
                                     WHERE id_pelanggan = @idPel AND status IN ('menunggu', 'diproses')";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idPel", idPelanggan);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0) adaOrderAktif = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengecek order aktif: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return adaOrderAktif;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // 1. Validasi Pelanggan
            if (cmbPelanggan.SelectedValue == null)
            {
                lblError.Text = "Pilih pelanggan terlebih dahulu!";
                lblError.Visible = true;
                cmbPelanggan.Focus();
                return;
            }

            int idPelanggan = Convert.ToInt32(cmbPelanggan.SelectedValue);

            // Validasi Order Ganda
            if (CekPelangganPunyaOrderAktif(idPelanggan))
            {
                lblError.Text = "Pelanggan ini masih punya transaksi aktif!";
                lblError.Visible = true;
                MessageBox.Show("Pelanggan ini masih memiliki cucian yang sedang diproses atau dalam antrean!\n\nOrder baru tidak dapat dibuat sebelum pesanan sebelumnya SELESAI atau DIAMBIL.",
                                "Order Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // 2. Validasi Layanan
            if (cmbLayanan.SelectedValue == null)
            {
                lblError.Text = "Pilih jenis layanan!";
                lblError.Visible = true;
                cmbLayanan.Focus();
                return;
            }

            // 3. Validasi Berat (Anti Minus / Nol & Maksimal 50 Kg)
            decimal berat = nudBerat.Value;
            if (berat <= 0)
            {
                lblError.Text = "Berat laundry tidak boleh nol atau minus!";
                lblError.Visible = true;
                nudBerat.Value = 1;
                nudBerat.Focus();
                return;
            }

            if (berat > 50)
            {
                lblError.Text = "Maksimal berat cucian adalah 50 Kg!";
                lblError.Visible = true;
                nudBerat.Value = 50;
                nudBerat.Focus();
                return;
            }

            decimal totalBiaya = lblTotal.Tag != null ? Convert.ToDecimal(lblTotal.Tag) : 0m;
            string statusBayar = cmbBayar.SelectedItem.ToString();

            // 4. Pop-up Konfirmasi Sebelum Simpan
            string pesanKonfirmasi = $"Apakah Anda yakin ingin menyimpan transaksi ini?\n\n" +
                                     $"• Pelanggan : {cmbPelanggan.Text}\n" +
                                     $"• Layanan    : {cmbLayanan.Text}\n" +
                                     $"• Berat      : {berat:N0} Kg\n" +
                                     $"• Total      : Rp {totalBiaya:N0}\n" +
                                     $"• Status     : {statusBayar.ToUpper()}";

            if (MessageBox.Show(pesanKonfirmasi, "Konfirmasi Transaksi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            // 5. Simpan ke Database
            using (MySqlConnection conn = Koneksi.GetConn())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insert Header Transaksi
                    string queryHeader = @"INSERT INTO tbl_transaksi_header 
                                          (id_pelanggan, tanggal_masuk, status, status_pembayaran) 
                                          VALUES (@idPelanggan, @tgl, 'Menunggu', @bayar);
                                          SELECT LAST_INSERT_ID();";

                    MySqlCommand cmdHeader = new MySqlCommand(queryHeader, conn, transaction);
                    cmdHeader.Parameters.AddWithValue("@idPelanggan", idPelanggan);
                    cmdHeader.Parameters.AddWithValue("@tgl", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmdHeader.Parameters.AddWithValue("@bayar", statusBayar);

                    long idTrxBaru = Convert.ToInt64(cmdHeader.ExecuteScalar());

                    // Insert Detail Transaksi
                    string queryDetail = @"INSERT INTO tbl_transaksi_detail 
                                          (id_transaksi, id_layanan, berat_kg, subtotal) 
                                          VALUES (@idTrx, @idLayanan, @berat, @subtotal)";

                    MySqlCommand cmdDetail = new MySqlCommand(queryDetail, conn, transaction);
                    cmdDetail.Parameters.AddWithValue("@idTrx", idTrxBaru);
                    cmdDetail.Parameters.AddWithValue("@idLayanan", cmbLayanan.SelectedValue);
                    cmdDetail.Parameters.AddWithValue("@berat", berat);
                    cmdDetail.Parameters.AddWithValue("@subtotal", totalBiaya);

                    cmdDetail.ExecuteNonQuery();

                    // Commit Transaction
                    transaction.Commit();

                    MessageBox.Show($"Transaksi TRX-{idTrxBaru:D4} berhasil ditambahkan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    lblError.Text = "Gagal simpan transaksi: " + ex.Message;
                    lblError.Visible = true;
                }
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}