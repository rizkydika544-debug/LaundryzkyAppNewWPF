using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using LaundryzkyWPF.Models;

namespace LaundryzkyWPF.Views
{
    public partial class TambahUserWindow : Window
    {
        private readonly User? _editUser;

        public TambahUserWindow()
        {
            InitializeComponent();
        }

        public TambahUserWindow(User user) : this()
        {
            _editUser = user;
            lblJudul.Text = "Edit Karyawan / User";
            txtNamaUser.Text = user.NamaUser;
            txtUsername.Text = user.Username;
            txtPassword.Text = user.Password;

            // Set ComboBox role
            bool roleFound = false;
            foreach (ComboBoxItem item in cmbRole.Items)
            {
                if (item.Content.ToString()?.Equals(user.Role, StringComparison.OrdinalIgnoreCase) == true)
                {
                    item.IsSelected = true;
                    roleFound = true;
                    break;
                }
            }

            // Jika user yang diedit adalah admin utama, tambahkan item admin dan kunci role-nya
            if (!roleFound && user.Role.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                var adminItem = new ComboBoxItem { Content = "admin", IsSelected = true };
                cmbRole.Items.Add(adminItem);
                cmbRole.IsEnabled = false; // Admin utama tidak dapat diubah rolenya
            }

            // Set ComboBox status
            foreach (ComboBoxItem item in cmbStatus.Items)
            {
                if (item.Content.ToString()?.Equals(user.Status, StringComparison.OrdinalIgnoreCase) == true)
                {
                    item.IsSelected = true;
                    break;
                }
            }
        }

        private void BtnBatal_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void BtnSimpan_Click(object sender, RoutedEventArgs e)
        {
            string nama = txtNamaUser.Text.Trim();
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();
            string role = (cmbRole.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "kasir";
            string status = (cmbStatus.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "aktif";

            if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Semua bidang wajib diisi!", "Peringatan", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();

                    if (_editUser == null)
                    {
                        // Insert new user
                        string q = "INSERT INTO tbl_user (nama_user, username, password, role, status) VALUES (@nama, @user, @pass, @role, @status)";
                        using (MySqlCommand cmd = new MySqlCommand(q, conn))
                        {
                            cmd.Parameters.AddWithValue("@nama", nama);
                            cmd.Parameters.AddWithValue("@user", user);
                            cmd.Parameters.AddWithValue("@pass", pass);
                            cmd.Parameters.AddWithValue("@role", role);
                            cmd.Parameters.AddWithValue("@status", status);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Karyawan baru berhasil ditambahkan!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        // Update existing user
                        string q = "UPDATE tbl_user SET nama_user = @nama, username = @user, password = @pass, role = @role, status = @status WHERE id_user = @id";
                        using (MySqlCommand cmd = new MySqlCommand(q, conn))
                        {
                            cmd.Parameters.AddWithValue("@nama", nama);
                            cmd.Parameters.AddWithValue("@user", user);
                            cmd.Parameters.AddWithValue("@pass", pass);
                            cmd.Parameters.AddWithValue("@role", role);
                            cmd.Parameters.AddWithValue("@status", status);
                            cmd.Parameters.AddWithValue("@id", _editUser.IdUser);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Data karyawan berhasil diperbarui!", "Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan user: " + ex.Message, "Error Database", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
