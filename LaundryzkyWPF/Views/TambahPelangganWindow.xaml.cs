using System;
using System.Windows;
using MySql.Data.MySqlClient;

namespace LaundryzkyWPF.Views
{
    public partial class TambahPelangganWindow : Window
    {
        public TambahPelangganWindow()
        {
            InitializeComponent();
        }

        private void BtnBatal_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void NoHp_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            // Hanya mengizinkan angka dan tanda tambah '+' di awal
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[0-9+]+$");
        }

        private void BtnSimpan_Click(object sender, RoutedEventArgs e)
        {
            string nama = txtNamaPelanggan.Text.Trim();
            string noHp = txtNoHp.Text.Trim();
            string alamat = txtAlamat.Text.Trim();

            if (string.IsNullOrEmpty(nama))
            {
                MessageBox.Show("Nama pelanggan tidak boleh kosong!", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string q = "INSERT INTO tbl_pelanggan (nama_pelanggan, no_hp, alamat) VALUES (@nama, @hp, @alamat)";
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@hp", noHp);
                        cmd.Parameters.AddWithValue("@alamat", alamat);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Pelanggan baru berhasil ditambahkan!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan data pelanggan: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
