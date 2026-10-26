using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using LaundryzkyWPF.Models;

namespace LaundryzkyWPF.Views
{
    public partial class KasirWindow : Window
    {
        private readonly User _currentUser;
        private List<Pelanggan> _listPelanggan = new List<Pelanggan>();
        private List<Layanan> _listLayanan = new List<Layanan>();
        private List<Transaksi> _listRiwayat = new List<Transaksi>();

        private decimal _totalTagihan = 0;
        private decimal _hargaPerKg = 0;

        public KasirWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;
            lblNamaKasir.Text = _currentUser.NamaUser;
            lblTanggal.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", new System.Globalization.CultureInfo("id-ID"));
            dpEstimasi.SelectedDate = DateTime.Now.AddDays(2);

            MuatMasterPelanggan();
            MuatMasterLayanan();
        }

        private void MuatMasterPelanggan()
        {
            _listPelanggan.Clear();
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string q = "SELECT id_pelanggan, nama_pelanggan, no_hp, alamat FROM tbl_pelanggan ORDER BY nama_pelanggan ASC";
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            _listPelanggan.Add(new Pelanggan
                            {
                                IdPelanggan = Convert.ToInt32(r["id_pelanggan"]),
                                NamaPelanggan = r["nama_pelanggan"].ToString() ?? "",
                                NoHp = r["no_hp"].ToString() ?? "",
                                Alamat = r["alamat"].ToString() ?? ""
                            });
                        }
                    }
                }

                cmbPelanggan.ItemsSource = null;
                cmbPelanggan.ItemsSource = _listPelanggan;

                dgvPelanggan.ItemsSource = null;
                dgvPelanggan.ItemsSource = _listPelanggan;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat data pelanggan: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MuatMasterLayanan()
        {
            _listLayanan.Clear();
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string q = "SELECT id_layanan, nama_layanan, harga_per_kg FROM tbl_jenis_layanan ORDER BY id_layanan ASC";
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            _listLayanan.Add(new Layanan
                            {
                                IdLayanan = Convert.ToInt32(r["id_layanan"]),
                                NamaLayanan = r["nama_layanan"].ToString() ?? "",
                                HargaPerKg = Convert.ToInt32(r["harga_per_kg"])
                            });
                        }
                    }
                }

                cmbLayanan.ItemsSource = null;
                cmbLayanan.ItemsSource = _listLayanan;
                if (_listLayanan.Count > 0)
                    cmbLayanan.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat layanan: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MuatRiwayatTransaksi()
        {
            _listRiwayat.Clear();
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            th.id_transaksi,
                            th.id_pelanggan,
                            p.nama_pelanggan,
                            p.no_hp,
                            th.tanggal_masuk,
                            th.estimasi_selesai,
                            th.status,
                            th.status_pembayaran,
                            IFNULL(th.metode_pembayaran, 'Tunai') AS metode_pembayaran,
                            th.bayar,
                            th.kembali,
                            th.status_cuci,
                            th.status_setrika,
                            th.catatan_saku,
                            IFNULL(l.nama_layanan, '-') AS nama_layanan,
                            IFNULL(td.harga_per_kg, 0) AS harga_per_kg,
                            IFNULL(td.berat_kg, 0) AS berat_kg,
                            IFNULL(td.subtotal, 0) AS subtotal
                        FROM tbl_transaksi_header th
                        JOIN tbl_pelanggan p ON th.id_pelanggan = p.id_pelanggan
                        LEFT JOIN tbl_transaksi_detail td ON th.id_transaksi = td.id_transaksi
                        LEFT JOIN tbl_jenis_layanan l ON td.id_layanan = l.id_layanan
                        ORDER BY th.id_transaksi DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            _listRiwayat.Add(new Transaksi
                            {
                                IdTransaksi = Convert.ToInt32(r["id_transaksi"]),
                                IdPelanggan = Convert.ToInt32(r["id_pelanggan"]),
                                NamaPelanggan = r["nama_pelanggan"].ToString() ?? "",
                                NoHp = r["no_hp"].ToString() ?? "",
                                TanggalMasuk = Convert.ToDateTime(r["tanggal_masuk"]),
                                EstimasiSelesai = r["estimasi_selesai"] == DBNull.Value ? null : Convert.ToDateTime(r["estimasi_selesai"]),
                                Status = r["status"].ToString() ?? "menunggu",
                                StatusPembayaran = r["status_pembayaran"].ToString() ?? "belum",
                                MetodePembayaran = r["metode_pembayaran"].ToString() ?? "Tunai",
                                Bayar = Convert.ToDecimal(r["bayar"]),
                                Kembali = Convert.ToDecimal(r["kembali"]),
                                StatusCuci = r["status_cuci"].ToString() ?? "menunggu",
                                StatusSetrika = r["status_setrika"].ToString() ?? "menunggu",
                                CatatanSaku = r["catatan_saku"] == DBNull.Value ? "" : r["catatan_saku"].ToString(),
                                NamaLayanan = r["nama_layanan"].ToString() ?? "",
                                HargaPerKg = Convert.ToDecimal(r["harga_per_kg"]),
                                BeratKg = Convert.ToDecimal(r["berat_kg"]),
                                Subtotal = Convert.ToDecimal(r["subtotal"])
                            });
                        }
                    }
                }

                dgvRiwayatTrx.ItemsSource = null;
                dgvRiwayatTrx.ItemsSource = _listRiwayat;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat riwayat: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void HitungTagihan()
        {
            if (txtBerat == null || lblStrukBerat == null || lblStrukTotal == null)
                return;

            if (decimal.TryParse(txtBerat.Text, out decimal berat))
            {
                if (berat > 50)
                {
                    MessageBox.Show("Maksimal cucian di Laundryzky adalah 50 Kg per transaksi!", "Batas Maksimal", MessageBoxButton.OK, MessageBoxImage.Warning);
                    berat = 50;
                    txtBerat.Text = "50";
                    txtBerat.CaretIndex = txtBerat.Text.Length;
                }

                if (berat > 0)
                {
                    _totalTagihan = berat * _hargaPerKg;
                    lblStrukBerat.Text = $"{berat} Kg";
                    lblStrukTotal.Text = $"Rp {_totalTagihan:N0}";
                }
                else
                {
                    _totalTagihan = 0;
                    lblStrukBerat.Text = "0 Kg";
                    lblStrukTotal.Text = "Rp 0";
                }
            }
            else
            {
                _totalTagihan = 0;
                lblStrukBerat.Text = "0 Kg";
                lblStrukTotal.Text = "Rp 0";
            }

            // Jika QRIS dipilih, otomatis isi nominal pas sesuai total tagihan
            if (rbMetodeQris != null && rbMetodeQris.IsChecked == true && rbBayarSekarang != null && rbBayarSekarang.IsChecked == true)
            {
                txtUangBayar.Text = ((long)_totalTagihan).ToString();
            }

            HitungKembalian();
        }

        private void HitungKembalian()
        {
            if (txtUangBayar == null || lblStrukBayar == null || lblStrukKembali == null)
                return;

            bool isBayarNanti = rbBayarNanti != null && rbBayarNanti.IsChecked == true;
            bool isQris = rbMetodeQris != null && rbMetodeQris.IsChecked == true;

            if (lblStrukMetode != null)
            {
                if (isBayarNanti)
                    lblStrukMetode.Text = "Bayar Saat Pengambilan";
                else if (isQris)
                    lblStrukMetode.Text = "QRIS (All Payment)";
                else
                    lblStrukMetode.Text = "Tunai (Cash)";
            }

            if (isBayarNanti)
            {
                lblStrukBayar.Text = "Rp 0 (Saat Ambil)";
                lblStrukKembali.Text = "Belum Bayar";
                lblStrukKembali.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 38, 38)); // Merah
                return;
            }

            if (isQris)
            {
                lblStrukBayar.Text = $"Rp {_totalTagihan:N0} (QRIS)";
                lblStrukKembali.Text = "Rp 0 (Uang Pas)";
                lblStrukKembali.Foreground = (System.Windows.Media.Brush)FindResource("SuccessBrush"); // Hijau
                return;
            }

            if (decimal.TryParse(txtUangBayar.Text, out decimal bayar))
            {
                lblStrukBayar.Text = $"Rp {bayar:N0}";

                if (_totalTagihan <= 0)
                {
                    lblStrukKembali.Text = "Rp 0";
                    lblStrukKembali.Foreground = (System.Windows.Media.Brush)FindResource("MutedTextBrush");
                    return;
                }

                decimal selisih = bayar - _totalTagihan;
                if (selisih > 0)
                {
                    lblStrukKembali.Text = $"Rp {selisih:N0}";
                    lblStrukKembali.Foreground = (System.Windows.Media.Brush)FindResource("SuccessBrush"); // Hijau
                }
                else if (selisih == 0)
                {
                    lblStrukKembali.Text = "Rp 0 (Uang Pas)";
                    lblStrukKembali.Foreground = (System.Windows.Media.Brush)FindResource("SuccessBrush"); // Hijau
                }
                else
                {
                    decimal kurang = Math.Abs(selisih);
                    lblStrukKembali.Text = $"-Rp {kurang:N0} (Kurang)";
                    lblStrukKembali.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 38, 38)); // Merah
                }
            }
            else
            {
                lblStrukBayar.Text = "Rp 0";
                if (_totalTagihan > 0)
                {
                    lblStrukKembali.Text = $"-Rp {_totalTagihan:N0} (Kurang)";
                    lblStrukKembali.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 38, 38)); // Merah
                }
                else
                {
                    lblStrukKembali.Text = "Rp 0";
                    lblStrukKembali.Foreground = (System.Windows.Media.Brush)FindResource("MutedTextBrush");
                }
            }
        }

        private void RbOpsiBayar_Changed(object sender, RoutedEventArgs e)
        {
            if (txtUangBayar == null || panelMetodeBayar == null) return;

            if (rbBayarNanti.IsChecked == true)
            {
                panelMetodeBayar.Visibility = Visibility.Collapsed;
                if (borderQrisInfo != null) borderQrisInfo.Visibility = Visibility.Collapsed;
                if (panelInputBayar != null) panelInputBayar.Visibility = Visibility.Collapsed;
                txtUangBayar.Text = "0";
            }
            else
            {
                panelMetodeBayar.Visibility = Visibility.Visible;
                UpdateMetodeBayarView();
            }

            HitungKembalian();
        }

        private void RbMetodeBayar_Changed(object sender, RoutedEventArgs e)
        {
            UpdateMetodeBayarView();
            HitungKembalian();
        }

        private void UpdateMetodeBayarView()
        {
            if (rbMetodeQris == null || borderQrisInfo == null || panelInputBayar == null) return;

            if (rbMetodeQris.IsChecked == true)
            {
                // Mode QRIS All Payment
                borderQrisInfo.Visibility = Visibility.Visible;
                panelInputBayar.Visibility = Visibility.Collapsed;
                txtUangBayar.Text = ((long)_totalTagihan).ToString();
            }
            else
            {
                // Mode Tunai (Cash)
                borderQrisInfo.Visibility = Visibility.Collapsed;
                panelInputBayar.Visibility = Visibility.Visible;
                txtUangBayar.IsEnabled = true;
            }
        }

        private void CmbPelanggan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPelanggan.SelectedItem is Pelanggan pel)
            {
                lblStrukPelanggan.Text = pel.NamaPelanggan;
            }
        }

        private void CmbLayanan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbLayanan.SelectedItem is Layanan lay)
            {
                _hargaPerKg = lay.HargaPerKg;
                lblStrukLayanan.Text = lay.NamaLayanan;
                lblStrukTarif.Text = $"Rp {lay.HargaPerKg:N0} /Kg";
                HitungTagihan();
            }
        }

        private void NumberOnly_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Hanya mengizinkan digit angka 0-9 dan titik/koma desimal, tidak boleh minus '-' atau huruf
            var tb = sender as TextBox;
            string currentText = tb?.Text ?? "";
            
            // Cek apakah karakter baru adalah digit
            if (char.IsDigit(e.Text, 0))
            {
                e.Handled = false;
                return;
            }

            // Izinkan 1 titik/koma desimal
            if ((e.Text == "." || e.Text == ",") && !currentText.Contains(".") && !currentText.Contains(","))
            {
                e.Handled = false;
                return;
            }

            // Tolak selain itu (huruf, minus, simbol)
            e.Handled = true;
        }

        private void DigitsOnly_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Hanya mengizinkan digit angka positif (0-9) tanpa minus atau huruf
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[0-9]+$");
        }

        private void TxtBerat_TextChanged(object sender, TextChangedEventArgs e)
        {
            HitungTagihan();
        }

        private void TxtUangBayar_TextChanged(object sender, TextChangedEventArgs e)
        {
            HitungKembalian();
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            txtBerat.Text = "1";
            txtUangBayar.Text = "0";
            txtCatatanKasir.Clear();
            cmbPelanggan.SelectedIndex = -1;
            lblStrukPelanggan.Text = "-";
            HitungTagihan();
        }

        private void BtnSimpanTransaksi_Click(object sender, RoutedEventArgs e)
        {
            if (cmbPelanggan.SelectedItem is not Pelanggan pel)
            {
                MessageBox.Show("Silakan pilih pelanggan terlebih dahulu!", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (cmbLayanan.SelectedItem is not Layanan lay)
            {
                MessageBox.Show("Silakan pilih layanan terlebih dahulu!", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(txtBerat.Text, out decimal berat) || berat <= 0)
            {
                MessageBox.Show("Berat cucian tidak valid!", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (berat > 50)
            {
                MessageBox.Show("Maksimal cucian di Laundryzky adalah 50 Kg per transaksi!", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            decimal.TryParse(txtUangBayar.Text, out decimal bayar);
            bool isLunas = rbBayarSekarang.IsChecked == true;

            // Validasi Logika Pembayaran:
            if (isLunas)
            {
                if (bayar <= 0)
                {
                    MessageBox.Show(
                        "Opsi pembayaran 'Bayar Sekarang (Lunas)' dipilih, tetapi uang yang diterima masih Rp 0!\n\n" +
                        "Silakan masukkan jumlah uang yang dibayarkan pelanggan di kolom 'Jumlah Uang Diterima',\n" +
                        "atau pilih opsi 'Bayar Saat Ambil' jika pelanggan belum membayar sekarang.",
                        "Uang Pembayaran Belum Diinput", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtUangBayar.Focus();
                    return;
                }

                if (bayar < _totalTagihan)
                {
                    decimal kurang = _totalTagihan - bayar;
                    MessageBox.Show(
                        $"Uang pembayaran kurang Rp {kurang:N0}!\n\n" +
                        $"Total Tagihan: Rp {_totalTagihan:N0}\n" +
                        $"Uang Diterima: Rp {bayar:N0}\n\n" +
                        "Uang harus pas atau lebih untuk opsi 'Bayar Sekarang (Lunas)', atau pilih opsi 'Bayar Saat Ambil'.",
                        "Uang Pembayaran Kurang", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtUangBayar.Focus();
                    return;
                }
            }

            string statusBayar = isLunas ? "lunas" : "belum";
            decimal kembali = isLunas && bayar >= _totalTagihan ? (bayar - _totalTagihan) : 0;
            string catatan = txtCatatanKasir.Text.Trim();
            DateTime estimasi = dpEstimasi.SelectedDate ?? DateTime.Now.AddDays(2);
            DateTime tglMasuk = DateTime.Now;

            string infoUang = isLunas 
                ? $"\nBayar: Rp {bayar:N0}\nKembalian: Rp {kembali:N0}" 
                : "\n(Bayar Saat Pengambilan Pakaian)";

            var konfirmasi = MessageBox.Show(
                $"Simpan transaksi ini?\n\nPelanggan: {pel.NamaPelanggan}\nLayanan: {lay.NamaLayanan}\nBerat: {berat} Kg\nTotal Tagihan: Rp {_totalTagihan:N0}\nStatus Pembayaran: {(isLunas ? "Lunas" : "Belum Bayar")}{infoUang}",
                "Konfirmasi Simpan Transaksi",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (konfirmasi != MessageBoxResult.Yes) return;

            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();

                    // Aturan 1: Batas maksimal 20 orang/antrean cucian yang sedang diproses
                    string qCekKapasitas = "SELECT COUNT(*) FROM tbl_transaksi_header WHERE status != 'diambil'";
                    using (MySqlCommand cmdKapasitas = new MySqlCommand(qCekKapasitas, conn))
                    {
                        long totalAktif = Convert.ToInt64(cmdKapasitas.ExecuteScalar());
                        if (totalAktif >= 20)
                        {
                            MessageBox.Show($"Kapasitas mesin cuci penuh ({totalAktif}/20 antrean sedang dicuci/diproses)!\nHarap tunggu cucian yang sedang diproses selesai atau diambil terlebih dahulu.", "Kapasitas Penuh", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }

                    // Aturan 2: 1 Pelanggan tidak boleh input cucian baru jika cucian sebelumnya belum selesai/belum diambil
                    string qCekPelanggan = "SELECT COUNT(*) FROM tbl_transaksi_header WHERE id_pelanggan = @idPel AND status != 'diambil'";
                    using (MySqlCommand cmdCekPel = new MySqlCommand(qCekPelanggan, conn))
                    {
                        cmdCekPel.Parameters.AddWithValue("@idPel", pel.IdPelanggan);
                        long orderBelumSelesai = Convert.ToInt64(cmdCekPel.ExecuteScalar());
                        if (orderBelumSelesai > 0)
                        {
                            MessageBox.Show($"Pelanggan '{pel.NamaPelanggan}' masih memiliki cucian yang sedang diproses atau belum diambil!\nDemi keadilan antrean pelanggan lain, cucian sebelumnya harus selesai dan diambil terlebih dahulu sebelum mencuci kembali.", "Antrean Dibatasi", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }

                    using (MySqlTransaction tr = conn.BeginTransaction())
                    {
                        try
                        {
                            // Tentukan status awal berdasarkan jenis layanan
                            string namaLayananLower = lay.NamaLayanan.ToLower();
                            bool isSetrikaSaja = namaLayananLower.Contains("setrika") && !namaLayananLower.Contains("cuci");
                            bool isCuciSaja = (namaLayananLower.Contains("cuci") || namaLayananLower.Contains("kering")) && !namaLayananLower.Contains("setrika");

                            string initStatusCuci = isSetrikaSaja ? "tidak_perlu" : "menunggu";
                            string initStatusSetrika = isCuciSaja ? "tidak_perlu" : "menunggu";

                            string metodeBayarDB = "Tunai";
                            if (isLunas)
                            {
                                metodeBayarDB = (rbMetodeQris != null && rbMetodeQris.IsChecked == true) ? "QRIS" : "Tunai";
                            }
                            else
                            {
                                metodeBayarDB = "-";
                            }

                            // 1. Insert header
                            string qHeader = @"INSERT INTO tbl_transaksi_header 
                                (id_pelanggan, id_user, tanggal_masuk, estimasi_selesai, status, status_pembayaran, metode_pembayaran, bayar, kembali, status_cuci, status_setrika, catatan_saku)
                                VALUES 
                                (@pel, @user, @tgl, @est, 'menunggu', @sb, @metode, @byr, @kmb, @sc, @ss, @cat);
                                SELECT LAST_INSERT_ID();";

                            int newIdTrx;
                            using (MySqlCommand cmdH = new MySqlCommand(qHeader, conn, tr))
                            {
                                cmdH.Parameters.AddWithValue("@pel", pel.IdPelanggan);
                                cmdH.Parameters.AddWithValue("@user", _currentUser.IdUser);
                                cmdH.Parameters.AddWithValue("@tgl", tglMasuk.ToString("yyyy-MM-dd HH:mm:ss"));
                                cmdH.Parameters.AddWithValue("@est", estimasi.ToString("yyyy-MM-dd"));
                                cmdH.Parameters.AddWithValue("@sb", statusBayar);
                                cmdH.Parameters.AddWithValue("@metode", metodeBayarDB);
                                cmdH.Parameters.AddWithValue("@byr", isLunas ? bayar : 0);
                                cmdH.Parameters.AddWithValue("@kmb", kembali);
                                cmdH.Parameters.AddWithValue("@sc", initStatusCuci);
                                cmdH.Parameters.AddWithValue("@ss", initStatusSetrika);
                                cmdH.Parameters.AddWithValue("@cat", catatan);

                                newIdTrx = Convert.ToInt32(cmdH.ExecuteScalar());
                            }

                            // 2. Insert detail
                            string qDetail = @"INSERT INTO tbl_transaksi_detail (id_transaksi, id_layanan, berat_kg, harga_per_kg, subtotal)
                                               VALUES (@trx, @lay, @berat, @harga, @subtotal)";
                            using (MySqlCommand cmdD = new MySqlCommand(qDetail, conn, tr))
                            {
                                cmdD.Parameters.AddWithValue("@trx", newIdTrx);
                                cmdD.Parameters.AddWithValue("@lay", lay.IdLayanan);
                                cmdD.Parameters.AddWithValue("@berat", berat);
                                cmdD.Parameters.AddWithValue("@harga", lay.HargaPerKg);
                                cmdD.Parameters.AddWithValue("@subtotal", Convert.ToInt32(_totalTagihan));
                                cmdD.ExecuteNonQuery();
                            }

                            tr.Commit();

                            string kodeTrx = $"TRX-{newIdTrx:D4}";

                            MessageBox.Show($"Transaksi {kodeTrx} berhasil disimpan!\nStatus Pengerjaan: Menunggu Bagian Cuci & Setrika.\nNota transaksi akan otomatis dibuka.", "Transaksi Sukses", MessageBoxButton.OK, MessageBoxImage.Information);

                            // Tampilkan Nota Window otomatis
                            var notaWin = new NotaWindow(
                                kodeTrx,
                                pel.NamaPelanggan,
                                pel.NoHp,
                                lay.NamaLayanan,
                                lay.HargaPerKg,
                                berat,
                                _totalTagihan,
                                statusBayar,
                                metodeBayarDB,
                                bayar,
                                kembali,
                                _currentUser.NamaUser,
                                tglMasuk,
                                estimasi,
                                catatan
                            );
                            notaWin.ShowDialog();

                            BtnReset_Click(sender, e);
                        }
                        catch
                        {
                            tr.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan transaksi: " + ex.Message, "Error Database", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnTambahPelangganBaru_Click(object sender, RoutedEventArgs e)
        {
            var formPel = new TambahPelangganWindow();
            if (formPel.ShowDialog() == true)
            {
                MuatMasterPelanggan();
            }
        }

        private void BtnMenuKasirPOS_Click(object sender, RoutedEventArgs e)
        {
            lblHeaderTitle.Text = "Kasir Point of Sales";
            panelPOS.Visibility = Visibility.Visible;
            panelDaftarTransaksi.Visibility = Visibility.Collapsed;
            panelPelanggan.Visibility = Visibility.Collapsed;
        }

        private void BtnMenuDaftarTransaksi_Click(object sender, RoutedEventArgs e)
        {
            lblHeaderTitle.Text = "Riwayat Transaksi";
            panelPOS.Visibility = Visibility.Collapsed;
            panelDaftarTransaksi.Visibility = Visibility.Visible;
            panelPelanggan.Visibility = Visibility.Collapsed;
            MuatRiwayatTransaksi();
        }

        private void BtnMenuPelanggan_Click(object sender, RoutedEventArgs e)
        {
            lblHeaderTitle.Text = "Data Pelanggan";
            panelPOS.Visibility = Visibility.Collapsed;
            panelDaftarTransaksi.Visibility = Visibility.Collapsed;
            panelPelanggan.Visibility = Visibility.Visible;
            MuatMasterPelanggan();
        }

        private void BtnRefreshTrx_Click(object sender, RoutedEventArgs e)
        {
            txtCariTrx.Clear();
            MuatRiwayatTransaksi();
        }

        private void TxtCariTrx_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = txtCariTrx.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgvRiwayatTrx.ItemsSource = _listRiwayat;
                return;
            }

            var hasil = _listRiwayat.FindAll(t =>
                t.KodeTransaksi.ToLower().Contains(keyword) ||
                t.NamaPelanggan.ToLower().Contains(keyword) ||
                t.NoHp.Contains(keyword) ||
                t.Status.ToLower().Contains(keyword) ||
                t.StatusPembayaran.ToLower().Contains(keyword) ||
                (t.CatatanSaku != null && t.CatatanSaku.ToLower().Contains(keyword))
            );

            dgvRiwayatTrx.ItemsSource = null;
            dgvRiwayatTrx.ItemsSource = hasil;
        }

        private void TxtCariPelanggan_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = txtCariPelanggan.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgvPelanggan.ItemsSource = _listPelanggan;
                return;
            }

            var hasil = _listPelanggan.FindAll(p =>
                p.NamaPelanggan.ToLower().Contains(keyword) ||
                p.NoHp.Contains(keyword) ||
                p.Alamat.ToLower().Contains(keyword)
            );

            dgvPelanggan.ItemsSource = null;
            dgvPelanggan.ItemsSource = hasil;
        }

        private void BtnCetakNotaRiwayat_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is Transaksi trx)
            {
                var notaWin = new NotaWindow(
                    trx.KodeTransaksi,
                    trx.NamaPelanggan,
                    trx.NoHp,
                    trx.NamaLayanan,
                    trx.HargaPerKg,
                    trx.BeratKg,
                    trx.Subtotal,
                    trx.StatusPembayaran,
                    trx.MetodePembayaran,
                    trx.Bayar,
                    trx.Kembali,
                    _currentUser.NamaUser,
                    trx.TanggalMasuk,
                    trx.EstimasiSelesai ?? trx.TanggalMasuk.AddDays(2),
                    trx.CatatanSaku ?? ""
                );
                notaWin.ShowDialog();
            }
        }

        private Transaksi? _selectedTrxPelunasan = null;

        private void BtnBayarAmbilRiwayat_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is not Transaksi trx) return;

            _selectedTrxPelunasan = trx;
            lblModalKodeTrx.Text = trx.KodeTransaksi;
            lblModalPelanggan.Text = trx.NamaPelanggan;
            lblModalLayanan.Text = $"{trx.NamaLayanan} ({trx.BeratKg} Kg)";
            lblModalTotalTagihan.Text = $"Rp {trx.Subtotal:N0}";
            lblModalStatusPengerjaan.Text = trx.StatusDisplay;

            bool isSudahLunas = trx.IsLunas;
            bool isSudahDiambil = trx.IsSudahDiambil;

            bool isSudahSelesaiDikerjakan = trx.IsSelesaiDikerjakan;

            if (isSudahDiambil)
            {
                MessageBox.Show($"Cucian {trx.KodeTransaksi} sudah pernah diserahkan/diambil sebelumnya!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (isSudahLunas)
            {
                // Sudah lunas tapi mau diambil
                if (!isSudahSelesaiDikerjakan)
                {
                    MessageBox.Show(
                        $"Cucian {trx.KodeTransaksi} sudah LUNAS, namun status pengerjaannya saat ini masih '{trx.StatusDisplay}'!\n\n" +
                        "Pakaian belum selesai dikerjakan oleh bagian cuci/setrika sehingga belum bisa diserahkan ke pelanggan.",
                        "Cucian Belum Selesai", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                lblModalPelunasanTitle.Text = "Penyerahan Cucian";
                lblModalPelunasanSub.Text = "Pakaian sudah berstatus LUNAS dan SELESAI, siap diserahkan ke pelanggan";
                lblModalStatusBayar.Text = "LUNAS";
                lblModalStatusBayar.Foreground = (System.Windows.Media.Brush)FindResource("SuccessBrush");
                panelInputPelunasan.Visibility = Visibility.Collapsed;
                btnSimpanPelunasan.Content = "✓ Serahkan Cucian ke Pelanggan";
            }
            else
            {
                // Belum lunas
                if (isSudahSelesaiDikerjakan)
                {
                    lblModalPelunasanTitle.Text = "Pelunasan & Penyerahan Cucian";
                    lblModalPelunasanSub.Text = "Cucian sudah SELESAI. Lunasi tagihan sebelum pakaian diserahkan ke pelanggan.";
                    btnSimpanPelunasan.Content = "✓ Lunasi & Serahkan Pakaian";
                }
                else
                {
                    lblModalPelunasanTitle.Text = "Pelunasan Tagihan (Cucian Sedang Diproses)";
                    lblModalPelunasanSub.Text = $"Cucian masih '{trx.StatusDisplay}'. Hanya melunasi tagihan (Pakaian TIDAK diserahkan sekarang).";
                    btnSimpanPelunasan.Content = "✓ Lunasi Pembayaran";
                }

                lblModalStatusBayar.Text = "BELUM LUNAS";
                lblModalStatusBayar.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 38, 38));
                panelInputPelunasan.Visibility = Visibility.Visible;
                rbModalTunai.IsChecked = true;
                txtModalUangBayar.Text = "0";
                lblModalKembali.Text = $"-Rp {trx.Subtotal:N0} (Kurang)";
                lblModalKembali.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 38, 38));
                borderModalQris.Visibility = Visibility.Collapsed;
                panelModalInputUang.Visibility = Visibility.Visible;
            }

            modalPelunasan.Visibility = Visibility.Visible;
        }

        private void RbModalMetode_Changed(object sender, RoutedEventArgs e)
        {
            if (_selectedTrxPelunasan == null || borderModalQris == null || panelModalInputUang == null) return;

            if (rbModalQris.IsChecked == true)
            {
                borderModalQris.Visibility = Visibility.Visible;
                panelModalInputUang.Visibility = Visibility.Collapsed;
                lblModalKembali.Text = "Rp 0 (Uang Pas)";
                lblModalKembali.Foreground = (System.Windows.Media.Brush)FindResource("SuccessBrush");
            }
            else
            {
                borderModalQris.Visibility = Visibility.Collapsed;
                panelModalInputUang.Visibility = Visibility.Visible;
                HitungModalKembalian();
            }
        }

        private void TxtModalUangBayar_TextChanged(object sender, TextChangedEventArgs e)
        {
            HitungModalKembalian();
        }

        private void HitungModalKembalian()
        {
            if (_selectedTrxPelunasan == null || lblModalKembali == null || txtModalUangBayar == null) return;

            decimal tagihan = _selectedTrxPelunasan.Subtotal;
            if (decimal.TryParse(txtModalUangBayar.Text, out decimal bayar))
            {
                decimal selisih = bayar - tagihan;
                if (selisih > 0)
                {
                    lblModalKembali.Text = $"Rp {selisih:N0}";
                    lblModalKembali.Foreground = (System.Windows.Media.Brush)FindResource("SuccessBrush");
                }
                else if (selisih == 0)
                {
                    lblModalKembali.Text = "Rp 0 (Uang Pas)";
                    lblModalKembali.Foreground = (System.Windows.Media.Brush)FindResource("SuccessBrush");
                }
                else
                {
                    decimal kurang = Math.Abs(selisih);
                    lblModalKembali.Text = $"-Rp {kurang:N0} (Kurang)";
                    lblModalKembali.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 38, 38));
                }
            }
            else
            {
                lblModalKembali.Text = $"-Rp {tagihan:N0} (Kurang)";
                lblModalKembali.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(220, 38, 38));
            }
        }

        private void BtnBatalPelunasan_Click(object sender, RoutedEventArgs e)
        {
            modalPelunasan.Visibility = Visibility.Collapsed;
            _selectedTrxPelunasan = null;
        }

        private void BtnSimpanPelunasan_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedTrxPelunasan == null) return;

            decimal totalTagihan = _selectedTrxPelunasan.Subtotal;
            bool isSudahLunas = _selectedTrxPelunasan.IsLunas;
            bool isSudahSelesai = _selectedTrxPelunasan.IsSelesaiDikerjakan;
            string metodeBayar = isSudahLunas ? _selectedTrxPelunasan.MetodePembayaran : "Tunai";
            decimal bayar = _selectedTrxPelunasan.Bayar;
            decimal kembali = _selectedTrxPelunasan.Kembali;

            // Tentukan status akhir:
            // Jika cucian sudah selesai dikerjakan, maka diserahkan ('diambil').
            // Jika cucian masih dicuci/disetrika, status transaksi tetap sama (status pengerjaan tidak berubah), hanya status pembayaran jadi 'lunas'.
            string targetStatusHeader = isSudahSelesai ? "diambil" : _selectedTrxPelunasan.Status;

            if (!isSudahLunas)
            {
                if (rbModalQris.IsChecked == true)
                {
                    metodeBayar = "QRIS";
                    bayar = totalTagihan;
                    kembali = 0;
                }
                else
                {
                    metodeBayar = "Tunai";
                    if (!decimal.TryParse(txtModalUangBayar.Text, out bayar) || bayar <= 0)
                    {
                        MessageBox.Show("Uang yang diterima belum diisi atau masih Rp 0!", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                        txtModalUangBayar.Focus();
                        return;
                    }

                    if (bayar < totalTagihan)
                    {
                        decimal kurang = totalTagihan - bayar;
                        MessageBox.Show($"Uang yang diterima kurang Rp {kurang:N0}!", "Uang Kurang", MessageBoxButton.OK, MessageBoxImage.Warning);
                        txtModalUangBayar.Focus();
                        return;
                    }

                    kembali = bayar - totalTagihan;
                }
            }

            string pesanAksi = isSudahSelesai 
                ? "Apakah pembayaran valid dan pakaian diserahkan ke pelanggan sekarang?" 
                : "Cucian saat ini masih dalam proses pengerjaan. Pelanggan hanya membayar tagihan (pakaian belum diserahkan). Lanjutkan pelunasan?";

            var konfirm = MessageBox.Show(
                $"Konfirmasi Transaksi:\n\n" +
                $"Kode: {_selectedTrxPelunasan.KodeTransaksi}\n" +
                $"Pelanggan: {_selectedTrxPelunasan.NamaPelanggan}\n" +
                $"Status Pengerjaan: {_selectedTrxPelunasan.StatusDisplay}\n" +
                $"Metode: {metodeBayar}\n" +
                $"Total: Rp {totalTagihan:N0}\n" +
                (isSudahLunas ? "(Cucian Sudah Lunas Sebelumnya)\n" : $"Bayar: Rp {bayar:N0}\nKembalian: Rp {kembali:N0}\n") +
                $"\n{pesanAksi}",
                "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (konfirm != MessageBoxResult.Yes) return;

            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string q = @"UPDATE tbl_transaksi_header 
                                 SET status = @sh, 
                                     status_pembayaran = 'lunas', 
                                     metode_pembayaran = @metode, 
                                     bayar = @byr, 
                                     kembali = @kmb
                                 WHERE id_transaksi = @id";

                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@sh", targetStatusHeader);
                        cmd.Parameters.AddWithValue("@metode", metodeBayar);
                        cmd.Parameters.AddWithValue("@byr", bayar);
                        cmd.Parameters.AddWithValue("@kmb", kembali);
                        cmd.Parameters.AddWithValue("@id", _selectedTrxPelunasan.IdTransaksi);
                        cmd.ExecuteNonQuery();
                    }
                }

                if (isSudahSelesai)
                {
                    MessageBox.Show($"Transaksi {_selectedTrxPelunasan.KodeTransaksi} telah LUNAS dan pakaian telah diserahkan (Status: Sudah Diambil)!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show($"Pembayaran untuk transaksi {_selectedTrxPelunasan.KodeTransaksi} berhasil LUNAS!\nStatus pengerjaan tetap '{_selectedTrxPelunasan.StatusDisplay}' menunggu selesai dikerjakan.", "Pelunasan Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                // Otomatis buka nota lunas terbaru
                var nota = new NotaWindow(
                    _selectedTrxPelunasan.KodeTransaksi,
                    _selectedTrxPelunasan.NamaPelanggan,
                    _selectedTrxPelunasan.NoHp,
                    _selectedTrxPelunasan.NamaLayanan,
                    _selectedTrxPelunasan.HargaPerKg,
                    _selectedTrxPelunasan.BeratKg,
                    totalTagihan,
                    "lunas",
                    metodeBayar,
                    bayar,
                    kembali,
                    _currentUser.NamaUser,
                    _selectedTrxPelunasan.TanggalMasuk,
                    DateTime.Now,
                    _selectedTrxPelunasan.CatatanSaku ?? ""
                );
                nota.ShowDialog();

                modalPelunasan.Visibility = Visibility.Collapsed;
                _selectedTrxPelunasan = null;
                MuatRiwayatTransaksi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update pelunasan transaksi: " + ex.Message, "Error Database", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void QrisImage_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (modalQrisZoom != null)
            {
                modalQrisZoom.Visibility = Visibility.Visible;
            }
        }

        private void BtnTutupModalQris_Click(object sender, RoutedEventArgs e)
        {
            if (modalQrisZoom != null)
            {
                modalQrisZoom.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            var konfirmasi = MessageBox.Show(
                "Apakah Anda yakin ingin keluar / logout dari akun Kasir?",
                "Konfirmasi Logout",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (konfirmasi != MessageBoxResult.Yes) return;

            var login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}
