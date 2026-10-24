using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using LaundryzkyWPF.Models;

namespace LaundryzkyWPF.Views
{
    public partial class AdminWindow : Window
    {
        private readonly User _currentUser;
        private List<User> _listUser = new List<User>();
        private List<Transaksi> _listAllTrx = new List<Transaksi>();
        private List<Transaksi> _listLaporan = new List<Transaksi>();

        public AdminWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;
            lblNamaAdmin.Text = _currentUser.NamaUser;
            lblTanggal.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", new System.Globalization.CultureInfo("id-ID"));

            dtpDari.SelectedDate = DateTime.Now.AddDays(-30);
            dtpSampai.SelectedDate = DateTime.Now;

            MuatDataUser();
        }

        private void MuatDataUser()
        {
            _listUser.Clear();
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string q = "SELECT id_user, nama_user, username, password, role, status FROM tbl_user ORDER BY role, nama_user";
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            _listUser.Add(new User
                            {
                                IdUser = Convert.ToInt32(r["id_user"]),
                                NamaUser = r["nama_user"].ToString() ?? "",
                                Username = r["username"].ToString() ?? "",
                                Password = r["password"].ToString() ?? "",
                                Role = r["role"].ToString() ?? "",
                                Status = r["status"].ToString() ?? "aktif"
                            });
                        }
                    }
                }

                dgvUser.ItemsSource = null;
                dgvUser.ItemsSource = _listUser;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat user: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MuatSemuaTransaksi()
        {
            _listAllTrx.Clear();
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
                            th.tanggal_masuk,
                            th.status,
                            th.status_pembayaran,
                            th.status_cuci,
                            th.id_petugas_cuci,
                            u_cuci.nama_user AS nama_petugas_cuci,
                            th.status_setrika,
                            th.id_petugas_setrika,
                            u_setrika.nama_user AS nama_petugas_setrika,
                            th.catatan_saku,
                            IFNULL(td.subtotal, 0) AS subtotal
                        FROM tbl_transaksi_header th
                        JOIN tbl_pelanggan p ON th.id_pelanggan = p.id_pelanggan
                        LEFT JOIN tbl_transaksi_detail td ON th.id_transaksi = td.id_transaksi
                        LEFT JOIN tbl_user u_cuci ON th.id_petugas_cuci = u_cuci.id_user
                        LEFT JOIN tbl_user u_setrika ON th.id_petugas_setrika = u_setrika.id_user
                        ORDER BY th.id_transaksi DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            _listAllTrx.Add(new Transaksi
                            {
                                IdTransaksi = Convert.ToInt32(r["id_transaksi"]),
                                IdPelanggan = Convert.ToInt32(r["id_pelanggan"]),
                                NamaPelanggan = r["nama_pelanggan"].ToString() ?? "",
                                TanggalMasuk = Convert.ToDateTime(r["tanggal_masuk"]),
                                Status = r["status"].ToString() ?? "menunggu",
                                StatusPembayaran = r["status_pembayaran"].ToString() ?? "belum",
                                StatusCuci = r["status_cuci"].ToString() ?? "menunggu",
                                PetugasCuci = r["nama_petugas_cuci"] == DBNull.Value ? "-" : r["nama_petugas_cuci"].ToString()!,
                                StatusSetrika = r["status_setrika"].ToString() ?? "menunggu",
                                PetugasSetrika = r["nama_petugas_setrika"] == DBNull.Value ? "-" : r["nama_petugas_setrika"].ToString()!,
                                CatatanSaku = r["catatan_saku"] == DBNull.Value ? "" : r["catatan_saku"].ToString(),
                                Subtotal = Convert.ToDecimal(r["subtotal"])
                            });
                        }
                    }
                }

                dgvSemuaTrx.ItemsSource = null;
                dgvSemuaTrx.ItemsSource = _listAllTrx;

                dgvLaporan.ItemsSource = null;
                dgvLaporan.ItemsSource = _listAllTrx;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat transaksi: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MuatStatistikBeranda()
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM tbl_transaksi_header", conn))
                        lblStatTotalTrx.Text = cmd.ExecuteScalar()?.ToString() ?? "0";

                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM tbl_transaksi_header WHERE status = 'diproses'", conn))
                        lblStatDiproses.Text = cmd.ExecuteScalar()?.ToString() ?? "0";

                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM tbl_transaksi_header WHERE status = 'selesai'", conn))
                        lblStatSelesai.Text = cmd.ExecuteScalar()?.ToString() ?? "0";

                    using (MySqlCommand cmd = new MySqlCommand("SELECT IFNULL(SUM(td.subtotal), 0) FROM tbl_transaksi_detail td JOIN tbl_transaksi_header th ON td.id_transaksi = th.id_transaksi WHERE th.status_pembayaran = 'lunas'", conn))
                    {
                        decimal pend = Convert.ToDecimal(cmd.ExecuteScalar() ?? 0);
                        lblStatPendapatan.Text = $"Rp {pend:N0}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat statistik: " + ex.Message);
            }
        }

        private void BtnTambahUser_Click(object sender, RoutedEventArgs e)
        {
            var form = new TambahUserWindow();
            if (form.ShowDialog() == true)
            {
                MuatDataUser();
            }
        }

        private void BtnEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is User user)
            {
                var form = new TambahUserWindow(user);
                if (form.ShowDialog() == true)
                {
                    MuatDataUser();
                }
            }
        }

        private void BtnToggleStatusUser_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is User user)
            {
                if (user.Role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Akun Administrator utama tidak dapat dinonaktifkan!", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string newStatus = user.Status == "aktif" ? "nonaktif" : "aktif";
                var konfirmasi = MessageBox.Show(
                    $"Apakah Anda yakin ingin mengubah status akun '{user.NamaUser}' menjadi '{newStatus}'?",
                    "Konfirmasi Ubah Status",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (konfirmasi != MessageBoxResult.Yes) return;

                try
                {
                    using (MySqlConnection conn = Koneksi.GetConn())
                    {
                        conn.Open();
                        string q = "UPDATE tbl_user SET status = @st WHERE id_user = @id";
                        using (MySqlCommand cmd = new MySqlCommand(q, conn))
                        {
                            cmd.Parameters.AddWithValue("@st", newStatus);
                            cmd.Parameters.AddWithValue("@id", user.IdUser);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show($"Status akun '{user.NamaUser}' berhasil diubah menjadi '{newStatus}'!", "Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
                    MuatDataUser();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal ubah status: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnRefreshUser_Click(object sender, RoutedEventArgs e)
        {
            txtCariUser.Clear();
            MuatDataUser();
        }

        private void BtnRefreshSemuaTrx_Click(object sender, RoutedEventArgs e)
        {
            txtCariSemuaTrx.Clear();
            MuatSemuaTransaksi();
        }

        private void TxtCariUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = txtCariUser.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgvUser.ItemsSource = null;
                dgvUser.ItemsSource = _listUser;
                return;
            }

            var hasil = _listUser.FindAll(u =>
                u.NamaUser.ToLower().Contains(keyword) ||
                u.Username.ToLower().Contains(keyword) ||
                u.Role.ToLower().Contains(keyword) ||
                u.Status.ToLower().Contains(keyword)
            );

            dgvUser.ItemsSource = null;
            dgvUser.ItemsSource = hasil;
        }

        private void TxtCariSemuaTrx_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = txtCariSemuaTrx.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgvSemuaTrx.ItemsSource = null;
                dgvSemuaTrx.ItemsSource = _listAllTrx;
                return;
            }

            var hasil = _listAllTrx.FindAll(t =>
                t.KodeTransaksi.ToLower().Contains(keyword) ||
                t.NamaPelanggan.ToLower().Contains(keyword) ||
                t.Status.ToLower().Contains(keyword) ||
                t.StatusCuci.ToLower().Contains(keyword) ||
                t.StatusSetrika.ToLower().Contains(keyword) ||
                (t.PetugasCuci != null && t.PetugasCuci.ToLower().Contains(keyword)) ||
                (t.PetugasSetrika != null && t.PetugasSetrika.ToLower().Contains(keyword)) ||
                (t.CatatanSaku != null && t.CatatanSaku.ToLower().Contains(keyword))
            );

            dgvSemuaTrx.ItemsSource = null;
            dgvSemuaTrx.ItemsSource = hasil;
        }
        private void BtnFilterLaporan_Click(object sender, RoutedEventArgs e)
        {
            DateTime? dari = dtpDari.SelectedDate;
            DateTime? sampai = dtpSampai.SelectedDate;

            MuatSemuaTransaksi();

            if (dari.HasValue && sampai.HasValue && _listAllTrx.Count > 0)
            {
                _listLaporan = _listAllTrx.FindAll(t => t.TanggalMasuk.Date >= dari.Value.Date && t.TanggalMasuk.Date <= sampai.Value.Date);
            }
            else
            {
                _listLaporan = new List<Transaksi>(_listAllTrx);
            }

            txtCariLaporan.Clear();
            dgvLaporan.ItemsSource = null;
            dgvLaporan.ItemsSource = _listLaporan;
        }

        private void TxtCariLaporan_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = txtCariLaporan.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgvLaporan.ItemsSource = null;
                dgvLaporan.ItemsSource = _listLaporan;
                return;
            }

            var hasil = _listLaporan.FindAll(t =>
                t.KodeTransaksi.ToLower().Contains(keyword) ||
                t.NamaPelanggan.ToLower().Contains(keyword) ||
                t.Status.ToLower().Contains(keyword) ||
                t.StatusPembayaran.ToLower().Contains(keyword)
            );

            dgvLaporan.ItemsSource = null;
            dgvLaporan.ItemsSource = hasil;
        }

        private void BtnResetDatabase_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Apakah Anda yakin ingin MENGHAPUS SEMUA DATA TRANSAKSI & PELANGGAN agar kembali kosong semula?\n\n(Akun login karyawan & jenis layanan akan tetap aman tersimpan)",
                "Konfirmasi Reset Data",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes) return;

            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(@"
                        SET FOREIGN_KEY_CHECKS = 0;
                        TRUNCATE TABLE tbl_transaksi_detail;
                        TRUNCATE TABLE tbl_transaksi_header;
                        TRUNCATE TABLE tbl_pelanggan;
                        SET FOREIGN_KEY_CHECKS = 1;", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Semua data transaksi dan data pelanggan berhasil dibersihkan! Anda sekarang dapat mengisi data baru dari awal.", "Reset Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
                MuatSemuaTransaksi();
                MuatStatistikBeranda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mereset database: " + ex.Message, "Error Database", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCetakLaporanPdf_Click(object sender, RoutedEventArgs e)
        {
            var data = dgvLaporan.ItemsSource as System.Collections.IEnumerable;
            if (data == null)
            {
                MessageBox.Show("Tidak ada data laporan untuk dicetak!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                System.Windows.Controls.PrintDialog pd = new System.Windows.Controls.PrintDialog();
                if (pd.ShowDialog() == true)
                {
                    // Render laporan rapi ke Visual dokumen
                    var border = new System.Windows.Controls.Border
                    {
                        Background = System.Windows.Media.Brushes.White,
                        Padding = new Thickness(40),
                        Width = 800
                    };

                    var sp = new System.Windows.Controls.StackPanel();
                    var judul = new System.Windows.Controls.TextBlock
                    {
                        Text = "LAPORAN KEUANGAN & TRANSAKSI LAUNDRYZKY",
                        FontSize = 18,
                        FontWeight = FontWeights.Bold,
                        Foreground = (System.Windows.Media.Brush)FindResource("PrimaryBlueBrush"),
                        HorizontalAlignment = HorizontalAlignment.Center
                    };
                    var sub = new System.Windows.Controls.TextBlock
                    {
                        Text = $"Periode: {(dtpDari.SelectedDate?.ToString("dd-MM-yyyy") ?? "-")} s/d {(dtpSampai.SelectedDate?.ToString("dd-MM-yyyy") ?? "-")} | Dicetak: {DateTime.Now:dd-MM-yyyy HH:mm}",
                        FontSize = 11,
                        Foreground = System.Windows.Media.Brushes.Gray,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Margin = new Thickness(0, 4, 0, 20)
                    };

                    sp.Children.Add(judul);
                    sp.Children.Add(sub);

                    // Grid Tabel Header
                    var gridTabel = new System.Windows.Controls.Grid();
                    gridTabel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
                    gridTabel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(140) });
                    gridTabel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
                    gridTabel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(110) });
                    gridTabel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
                    gridTabel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                    string[] headers = { "Kode TRX", "Pelanggan", "Tgl Masuk", "Total", "Pembayaran", "Pengerjaan" };
                    var rowH = new RowDefinition { Height = GridLength.Auto };
                    gridTabel.RowDefinitions.Add(rowH);

                    for (int i = 0; i < headers.Length; i++)
                    {
                        var th = new System.Windows.Controls.TextBlock
                        {
                            Text = headers[i],
                            FontWeight = FontWeights.Bold,
                            FontSize = 11,
                            Margin = new Thickness(4, 6, 4, 6)
                        };
                        System.Windows.Controls.Grid.SetColumn(th, i);
                        System.Windows.Controls.Grid.SetRow(th, 0);
                        gridTabel.Children.Add(th);
                    }

                    int rIdx = 1;
                    decimal totalPendapatan = 0;
                    foreach (Transaksi t in data)
                    {
                        gridTabel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                        string[] vals = {
                            t.KodeTransaksi,
                            t.NamaPelanggan,
                            t.TanggalMasuk.ToString("dd-MM-yyyy"),
                            t.TotalFormatted,
                            t.StatusPembayaran,
                            t.Status
                        };

                        for (int c = 0; c < vals.Length; c++)
                        {
                            var tb = new System.Windows.Controls.TextBlock
                            {
                                Text = vals[c],
                                FontSize = 10,
                                Margin = new Thickness(4, 4, 4, 4)
                            };
                            System.Windows.Controls.Grid.SetColumn(tb, c);
                            System.Windows.Controls.Grid.SetRow(tb, rIdx);
                            gridTabel.Children.Add(tb);
                        }

                        if (t.StatusPembayaran.Equals("lunas", StringComparison.OrdinalIgnoreCase))
                            totalPendapatan += t.Subtotal;

                        rIdx++;
                    }

                    sp.Children.Add(gridTabel);

                    // Garis Pemisah & Total
                    var line = new System.Windows.Shapes.Rectangle
                    {
                        Height = 1,
                        Fill = System.Windows.Media.Brushes.Gray,
                        Margin = new Thickness(0, 15, 0, 10)
                    };
                    sp.Children.Add(line);

                    var totalText = new System.Windows.Controls.TextBlock
                    {
                        Text = $"TOTAL PENDAPATAN (LUNAS): Rp {totalPendapatan:N0}",
                        FontSize = 13,
                        FontWeight = FontWeights.Bold,
                        HorizontalAlignment = HorizontalAlignment.Right
                    };
                    sp.Children.Add(totalText);

                    border.Child = sp;
                    border.Measure(new Size(800, double.PositiveInfinity));
                    border.Arrange(new Rect(0, 0, 800, border.DesiredSize.Height));

                    pd.PrintVisual(border, "Laporan_Keuangan_Laundryzky");
                    MessageBox.Show("Laporan berhasil diproses cetak / diexport ke PDF!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencetak laporan: " + ex.Message, "Error Cetak", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnMenuKelolaUser_Click(object sender, RoutedEventArgs e)
        {
            lblHeaderTitle.Text = "Kelola Karyawan & Pembagian Role";
            lblHeaderDesc.Text = "Tambah dan atur hak akses user: Kasir, Bagian Cuci, dan Bagian Setrika";
            panelKelolaUser.Visibility = Visibility.Visible;
            panelBeranda.Visibility = Visibility.Collapsed;
            panelSemuaTrx.Visibility = Visibility.Collapsed;
            panelLaporan.Visibility = Visibility.Collapsed;
            MuatDataUser();
        }

        private void BtnMenuBeranda_Click(object sender, RoutedEventArgs e)
        {
            lblHeaderTitle.Text = "Beranda Ringkasan Laundryzky";
            lblHeaderDesc.Text = "Statistik performa laundry & overview operasional";
            panelKelolaUser.Visibility = Visibility.Collapsed;
            panelBeranda.Visibility = Visibility.Visible;
            panelSemuaTrx.Visibility = Visibility.Collapsed;
            panelLaporan.Visibility = Visibility.Collapsed;
            MuatStatistikBeranda();
        }

        private void BtnMenuSemuaTrx_Click(object sender, RoutedEventArgs e)
        {
            lblHeaderTitle.Text = "Daftar Transaksi & Pelacakan Petugas";
            lblHeaderDesc.Text = "Pantau siapa yang mencuci pakaian dan siapa yang menyetrika";
            panelKelolaUser.Visibility = Visibility.Collapsed;
            panelBeranda.Visibility = Visibility.Collapsed;
            panelSemuaTrx.Visibility = Visibility.Visible;
            panelLaporan.Visibility = Visibility.Collapsed;
            MuatSemuaTransaksi();
        }

        private void BtnMenuLaporan_Click(object sender, RoutedEventArgs e)
        {
            lblHeaderTitle.Text = "Laporan Pendapatan & Keuangan";
            lblHeaderDesc.Text = "Rekapitulasi transaksi laundry dan status pembayaran";
            panelKelolaUser.Visibility = Visibility.Collapsed;
            panelBeranda.Visibility = Visibility.Collapsed;
            panelSemuaTrx.Visibility = Visibility.Collapsed;
            panelLaporan.Visibility = Visibility.Visible;
            MuatSemuaTransaksi();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            var konfirmasi = MessageBox.Show(
                "Apakah Anda yakin ingin keluar / logout dari akun Administrator?",
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
