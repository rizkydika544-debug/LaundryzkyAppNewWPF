using System;
using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using LaundryzkyWPF.Models;

namespace LaundryzkyWPF.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Password.Trim();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                lblError.Text = "Username dan Password wajib diisi!";
                lblError.Visibility = Visibility.Visible;
                return;
            }

            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string query = @"SELECT id_user, nama_user, username, role, status 
                                     FROM tbl_user 
                                     WHERE username = @user AND password = @pass 
                                     LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", user);
                        cmd.Parameters.AddWithValue("@pass", pass);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string status = reader["status"].ToString() ?? "aktif";
                                if (status.Equals("nonaktif", StringComparison.OrdinalIgnoreCase))
                                {
                                    lblError.Text = "Akun Anda telah dinonaktifkan! Hubungi Administrator.";
                                    lblError.Visibility = Visibility.Visible;
                                    return;
                                }

                                User currentUser = new User
                                {
                                    IdUser = Convert.ToInt32(reader["id_user"]),
                                    NamaUser = reader["nama_user"].ToString() ?? "",
                                    Username = reader["username"].ToString() ?? "",
                                    Role = reader["role"].ToString() ?? "",
                                    Status = status
                                };

                                OpenDashboard(currentUser);
                                this.Close();
                            }
                            else
                            {
                                lblError.Text = "Username atau Password salah!";
                                lblError.Visibility = Visibility.Visible;
                                txtPassword.Clear();
                                txtPassword.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Koneksi database gagal: " + ex.Message;
                lblError.Visibility = Visibility.Visible;
            }
        }

        private void OpenDashboard(User user)
        {
            string role = user.Role.ToLower().Trim();

            if (role == "admin")
            {
                var adminWin = new AdminWindow(user);
                adminWin.Show();
            }
            else if (role == "kasir")
            {
                var kasirWin = new KasirWindow(user);
                kasirWin.Show();
            }
            else if (role == "cuci" || role == "setrika")
            {
                var pekerjaWin = new PekerjaWindow(user);
                pekerjaWin.Show();
            }
            else
            {
                // Fallback default
                MessageBox.Show($"Role '{user.Role}' tidak dikenali.", "Info Role", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
