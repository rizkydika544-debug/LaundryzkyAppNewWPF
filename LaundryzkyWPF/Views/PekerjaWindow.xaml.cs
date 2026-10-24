using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using LaundryzkyWPF.Models;

namespace LaundryzkyWPF.Views
{
    public partial class PekerjaWindow : Window
    {
        private readonly User _currentUser;
        private readonly bool _isCuci;
        private List<Transaksi> _listTransaksi = new List<Transaksi>();
        private List<Transaksi> _currentTampilanList = new List<Transaksi>();

        public PekerjaWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;
            _isCuci = user.Role.Equals("cuci", StringComparison.OrdinalIgnoreCase);

            lblNamaUser.Text = _currentUser.NamaUser;
            lblTanggal.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", new System.Globalization.CultureInfo("id-ID"));

            if (_isCuci)
            {
                txtRoleBadge.Text = "STASIUN PENCUCIAN (CUCI)";
                lblRoleDetail.Text = "Bagian Mesin Cuci";
                txtRoleNotice.Text = "1. Anda bertugas mencuci pakaian dan mengecek setiap saku. Segala uang / barang yang tertinggal di saku menjadi tanggung jawab pencatat.\n2. Anda dapat melihat progres bagian setrika, tetapi TIDAK BISA mengubah status setrika.";
            }
            else
            {
                txtRoleBadge.Text = "STASIUN PENYETRIKAAN (SETRIKA)";
                lblRoleDetail.Text = "Bagian Penyetrikaan & Finishing";
                txtRoleNotice.Text = "1. Anda dapat menyetrika pakaian yang sudah selesai dicuci.\n2. Setelah setrika selesai, Anda dapat mengubah statusnya menjadi 'Selesai'.\n3. Anda dapat melihat catatan saku/barang bawaan dari bagian cuci.";
            }

            MuatData();
        }

        private bool _isMonitorAllMode = false;

        private void MuatData()
        {
            _listTransaksi.Clear();

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
                            th.status,
                            th.status_pembayaran,
                            th.status_cuci,
                            th.id_petugas_cuci,
                            u_cuci.nama_user AS nama_petugas_cuci,
                            th.status_setrika,
                            th.id_petugas_setrika,
                            u_setrika.nama_user AS nama_petugas_setrika,
                            th.catatan_saku,
                            IFNULL(j.nama_layanan, '-') AS nama_layanan,
                            IFNULL(td.berat_kg, 0) AS berat_kg,
                            IFNULL(td.subtotal, 0) AS subtotal
                        FROM tbl_transaksi_header th
                        JOIN tbl_pelanggan p ON th.id_pelanggan = p.id_pelanggan
                        LEFT JOIN tbl_transaksi_detail td ON th.id_transaksi = td.id_transaksi
                        LEFT JOIN tbl_jenis_layanan j ON td.id_layanan = j.id_layanan
                        LEFT JOIN tbl_user u_cuci ON th.id_petugas_cuci = u_cuci.id_user
                        LEFT JOIN tbl_user u_setrika ON th.id_petugas_setrika = u_setrika.id_user
                        ORDER BY th.id_transaksi DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                var t = new Transaksi
                                {
                                    IdTransaksi = Convert.ToInt32(r["id_transaksi"]),
                                    IdPelanggan = Convert.ToInt32(r["id_pelanggan"]),
                                    NamaPelanggan = r["nama_pelanggan"].ToString() ?? "",
                                    Status = r["status"].ToString() ?? "menunggu",
                                    StatusPembayaran = r["status_pembayaran"].ToString() ?? "belum",
                                    StatusCuci = r["status_cuci"].ToString() ?? "menunggu",
                                    PetugasCuci = r["nama_petugas_cuci"] == DBNull.Value ? "-" : r["nama_petugas_cuci"].ToString()!,
                                    StatusSetrika = r["status_setrika"].ToString() ?? "menunggu",
                                    PetugasSetrika = r["nama_petugas_setrika"] == DBNull.Value ? "-" : r["nama_petugas_setrika"].ToString()!,
                                    CatatanSaku = r["catatan_saku"] == DBNull.Value ? "" : r["catatan_saku"].ToString(),
                                    NamaLayanan = r["nama_layanan"].ToString() ?? "",
                                    BeratKg = Convert.ToDecimal(r["berat_kg"]),
                                    Subtotal = Convert.ToDecimal(r["subtotal"])
                                };

                                if (r["id_petugas_cuci"] != DBNull.Value)
                                    t.IdPetugasCuci = Convert.ToInt32(r["id_petugas_cuci"]);

                                if (r["id_petugas_setrika"] != DBNull.Value)
                                    t.IdPetugasSetrika = Convert.ToInt32(r["id_petugas_setrika"]);

                                _listTransaksi.Add(t);
                            }
                        }
                    }
                }

                // Terapkan filter berdasarkan mode menu yang sedang dibuka
                List<Transaksi> tampilanList;
                if (_isMonitorAllMode)
                {
                    // Tampilkan semua transaksi dan histori pengerjaan
                    tampilanList = new List<Transaksi>(_listTransaksi);
                    lblHeaderTitle.Text = "Monitor Semua Progres Laundryzky";
                    lblHeaderDesc.Text = "Melihat alur progres seluruh antrean cucian dari semua stasiun & petugas";
                    lblModeInfo.Text = "Mode: Monitoring Semua Progres Cucian (Read-Only)";
                }
                else
                {
                    // Menu 'Tugas Saya': Filter hanya antrean yang relevan dengan bagian/role pekerja saat ini
                    if (_isCuci)
                    {
                        // Bagian cuci: hanya tampilkan cucian yang perlu dicuci dan belum selesai/sedang dicuci
                        tampilanList = _listTransaksi.FindAll(t => 
                            t.StatusCuci != "tidak_perlu" && 
                            (t.StatusCuci == "menunggu" || t.StatusCuci == "sedang_cuci") &&
                            t.Status != "diambil");
                        lblHeaderTitle.Text = "Tugas Stasiun Pencucian (Antrean Cuci)";
                        lblHeaderDesc.Text = "Daftar pakaian yang siap atau sedang Anda cuci di mesin cuci";
                        lblModeInfo.Text = $"Mode: Antrean Tugas Pencucian Aktif ({tampilanList.Count} antrean)";
                    }
                    else
                    {
                        // Bagian setrika: hanya tampilkan cucian yang perlu disetrika dan siap disetrika
                        tampilanList = _listTransaksi.FindAll(t => 
                            t.StatusSetrika != "tidak_perlu" && 
                            (t.StatusSetrika == "menunggu" || t.StatusSetrika == "sedang_setrika") &&
                            t.Status != "diambil");
                        lblHeaderTitle.Text = "Tugas Stasiun Penyetrikaan (Antrean Setrika)";
                        lblHeaderDesc.Text = "Daftar pakaian yang siap atau sedang Anda setrika";
                        lblModeInfo.Text = $"Mode: Antrean Tugas Penyetrikaan Aktif ({tampilanList.Count} antrean)";
                    }
                }

                _currentTampilanList = tampilanList;
                if (txtCariTugas != null) txtCariTugas.Clear();
                dgvTugas.ItemsSource = null;
                dgvTugas.ItemsSource = tampilanList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat antrean transaksi: " + ex.Message, "Error Database", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DgvTugas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvTugas.SelectedItem is Transaksi selected)
            {
                txtCatatanSaku.Text = selected.CatatanSaku ?? "";
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtCariTugas.Clear();
            MuatData();
        }

        private void TxtCariTugas_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = txtCariTugas.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                dgvTugas.ItemsSource = null;
                dgvTugas.ItemsSource = _currentTampilanList;
                return;
            }

            var hasil = _currentTampilanList.FindAll(t =>
                t.KodeTransaksi.ToLower().Contains(keyword) ||
                t.NamaPelanggan.ToLower().Contains(keyword) ||
                t.NamaLayanan.ToLower().Contains(keyword) ||
                t.StatusCuci.ToLower().Contains(keyword) ||
                t.StatusSetrika.ToLower().Contains(keyword) ||
                (t.PetugasCuci != null && t.PetugasCuci.ToLower().Contains(keyword)) ||
                (t.PetugasSetrika != null && t.PetugasSetrika.ToLower().Contains(keyword)) ||
                (t.CatatanSaku != null && t.CatatanSaku.ToLower().Contains(keyword))
            );

            dgvTugas.ItemsSource = null;
            dgvTugas.ItemsSource = hasil;
        }

        private void BtnSimpanCatatan_Click(object sender, RoutedEventArgs e)
        {
            if (dgvTugas.SelectedItem is not Transaksi selected)
            {
                MessageBox.Show("Pilih transaksi terlebih dahulu dari tabel!", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string catatan = txtCatatanSaku.Text.Trim();

            var konfirmasi = MessageBox.Show(
                $"Simpan catatan saku / barang untuk transaksi {selected.KodeTransaksi}?",
                "Konfirmasi Catatan",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (konfirmasi != MessageBoxResult.Yes) return;

            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string q = "UPDATE tbl_transaksi_header SET catatan_saku = @catatan WHERE id_transaksi = @id";
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@catatan", catatan);
                        cmd.Parameters.AddWithValue("@id", selected.IdTransaksi);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Catatan saku/barang untuk {selected.KodeTransaksi} berhasil disimpan!\nDicatat oleh: {_currentUser.NamaUser}", "Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
                MuatData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan catatan: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAmbilTugas_Click(object sender, RoutedEventArgs e)
        {
            if (dgvTugas.SelectedItem is not Transaksi selected)
            {
                MessageBox.Show("Pilih cucian terlebih dahulu!", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string aksiTugas = _isCuci ? "Mencuci" : "Menyetrika";
            var konfirmasi = MessageBox.Show(
                $"Apakah Anda yakin ingin mengambil & mulai pengerjaan {aksiTugas} untuk transaksi {selected.KodeTransaksi} ({selected.NamaPelanggan})?",
                "Konfirmasi Ambil Tugas",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (konfirmasi != MessageBoxResult.Yes) return;

            string namaLayananLower = selected.NamaLayanan.ToLower();
            bool isSetrikaSaja = namaLayananLower.Contains("setrika") && !namaLayananLower.Contains("cuci");
            bool isCuciSaja = (namaLayananLower.Contains("cuci") || namaLayananLower.Contains("kering")) && !namaLayananLower.Contains("setrika");

            if (_isCuci)
            {
                // Role Cuci
                if (isSetrikaSaja || selected.StatusCuci == "tidak_perlu")
                {
                    MessageBox.Show("Pelanggan ini HANYA memesan layanan 'Setrika Saja'! Bagian pencucian tidak perlu dan tidak dapat mencuci pakaian ini.", "Bukan Tugas Pencucian", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (selected.StatusCuci == "selesai")
                {
                    MessageBox.Show("Cucian ini sudah selesai dicuci!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (selected.StatusCuci == "sedang_cuci" && selected.IdPetugasCuci != _currentUser.IdUser)
                {
                    MessageBox.Show($"Cucian ini sedang dikerjakan oleh petugas cuci lain ({selected.PetugasCuci})!", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                UpdateStatusCuci(selected.IdTransaksi, "sedang_cuci", selected.StatusSetrika);
            }
            else
            {
                // Role Setrika
                if (isCuciSaja || selected.StatusSetrika == "tidak_perlu")
                {
                    MessageBox.Show("Pelanggan ini HANYA memesan layanan 'Cuci Saja'! Bagian setrika tidak perlu menyetrika pakaian ini.", "Bukan Tugas Penyetrikaan", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Jika layanan memerlukan cuci (bukan Setrika Saja), maka harus tunggu cuci selesai
                if (!isSetrikaSaja && selected.StatusCuci != "selesai" && selected.StatusCuci != "tidak_perlu")
                {
                    MessageBox.Show("Cucian ini belum selesai dicuci oleh bagian pencucian! Harap tunggu proses cuci selesai terlebih dahulu.", "Peringatan Alur Kerja", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (selected.StatusSetrika == "selesai")
                {
                    MessageBox.Show("Penyetrikaan untuk pakaian ini sudah selesai!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                UpdateStatusSetrika(selected.IdTransaksi, "sedang_setrika");
            }
        }

        private void BtnSelesaiTugas_Click(object sender, RoutedEventArgs e)
        {
            if (dgvTugas.SelectedItem is not Transaksi selected)
            {
                MessageBox.Show("Pilih cucian terlebih dahulu!", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string aksiTugas = _isCuci ? "Pencucian" : "Penyetrikaan";
            var konfirmasi = MessageBox.Show(
                $"Apakah Anda yakin ingin menyelesaikan proses {aksiTugas} untuk transaksi {selected.KodeTransaksi} ({selected.NamaPelanggan})?",
                "Konfirmasi Selesai Tugas",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (konfirmasi != MessageBoxResult.Yes) return;

            string namaLayananLower = selected.NamaLayanan.ToLower();
            bool isSetrikaSaja = namaLayananLower.Contains("setrika") && !namaLayananLower.Contains("cuci");
            bool isCuciSaja = (namaLayananLower.Contains("cuci") || namaLayananLower.Contains("kering")) && !namaLayananLower.Contains("setrika");

            if (_isCuci)
            {
                if (isSetrikaSaja || selected.StatusCuci == "tidak_perlu")
                {
                    MessageBox.Show("Pelanggan ini memesan 'Setrika Saja', tidak ada proses pencucian untuk diselesaikan.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Bagian Cuci menyelesaikan cucian
                if (selected.StatusCuci == "selesai")
                {
                    MessageBox.Show("Proses pencucian sudah berstatus selesai!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                UpdateStatusCuci(selected.IdTransaksi, "selesai", selected.StatusSetrika);
            }
            else
            {
                if (isCuciSaja || selected.StatusSetrika == "tidak_perlu")
                {
                    MessageBox.Show("Pelanggan ini memesan 'Cuci Saja', tidak ada proses setrika untuk diselesaikan.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                // Bagian Setrika menyelesaikan setrika
                if (!isSetrikaSaja && selected.StatusCuci != "selesai" && selected.StatusCuci != "tidak_perlu")
                {
                    MessageBox.Show("Bagian cuci belum selesai! Anda tidak bisa menyelesaikan setrika.", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                UpdateStatusSetrika(selected.IdTransaksi, "selesai");
            }
        }

        private void UpdateStatusCuci(int idTransaksi, string statusCuci, string statusSetrika)
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    // Jika cuci selesai dan memang tidak perlu setrika, tandai transaksi utama 'selesai'
                    string statusHeader = (statusCuci == "selesai" && (statusSetrika == "tidak_perlu" || statusSetrika == "selesai")) 
                        ? "selesai" 
                        : "diproses";

                    string q = @"UPDATE tbl_transaksi_header 
                                 SET status_cuci = @sc, 
                                     id_petugas_cuci = @idUser,
                                     status = @sh
                                 WHERE id_transaksi = @id";

                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@sc", statusCuci);
                        cmd.Parameters.AddWithValue("@idUser", _currentUser.IdUser);
                        cmd.Parameters.AddWithValue("@sh", statusHeader);
                        cmd.Parameters.AddWithValue("@id", idTransaksi);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Status pencucian berhasil diubah menjadi: '{statusCuci}'!", "Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
                MuatData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update status cuci: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateStatusSetrika(int idTransaksi, string statusSetrika)
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();

                    // Jika setrika selesai, transaksi utama langsung menjadi 'selesai'
                    string statusHeader = statusSetrika == "selesai" ? "selesai" : "diproses";

                    string q = @"UPDATE tbl_transaksi_header 
                                 SET status_setrika = @ss, 
                                     id_petugas_setrika = @idUser,
                                     status = @sh
                                 WHERE id_transaksi = @id";

                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@ss", statusSetrika);
                        cmd.Parameters.AddWithValue("@idUser", _currentUser.IdUser);
                        cmd.Parameters.AddWithValue("@sh", statusHeader);
                        cmd.Parameters.AddWithValue("@id", idTransaksi);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"Status setrika berhasil diubah menjadi: '{statusSetrika}'!", "Berhasil", MessageBoxButton.OK, MessageBoxImage.Information);
                MuatData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update status setrika: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnMenuPekerjaan_Click(object sender, RoutedEventArgs e)
        {
            _isMonitorAllMode = false;
            MuatData();
        }

        private void BtnMenuSemuaProgres_Click(object sender, RoutedEventArgs e)
        {
            _isMonitorAllMode = true;
            MuatData();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            var konfirmasi = MessageBox.Show(
                $"Apakah Anda yakin ingin keluar / logout dari akun {_currentUser.NamaUser} ({(_isCuci ? "Bagian Cuci" : "Bagian Setrika")})?",
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
