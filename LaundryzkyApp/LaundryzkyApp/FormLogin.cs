using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LaundryzkyApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private bool showPass = false;

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Sembunyikan password secara default menggunakan PasswordChar '*'
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.PasswordChar = '*';

            lblError.Visible = false;
            txtUsername.Focus();
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            showPass = !showPass;

            if (showPass)
            {
                // Tampilkan teks password (hapus karakter mask)
                txtPassword.PasswordChar = '\0';
                btnShowPass.Text = "🙈";
            }
            else
            {
                // Sembunyikan kembali menjadi titik-titik '*'
                txtPassword.PasswordChar = '*';
                btnShowPass.Text = "👁️";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            // Validasi input kosong
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                lblError.Text = "Username dan Password wajib diisi!";
                lblError.Visible = true;
                MessageBox.Show("Username dan Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();

                    string query = @"SELECT id_user, nama_user, role, status 
                                     FROM tbl_user 
                                     WHERE username = @user 
                                     AND password  = @pass 
                                     LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader["role"].ToString();
                            string nama = reader["nama_user"].ToString();
                            string status = reader["status"].ToString();
                            int idUser = Convert.ToInt32(reader["id_user"]);

                            // Cek status aktif akun
                            if (status.Equals("nonaktif", StringComparison.OrdinalIgnoreCase))
                            {
                                lblError.Text = "Akun ini dinonaktifkan!";
                                lblError.Visible = true;
                                MessageBox.Show("Akun Anda telah dinonaktifkan! Silakan hubungi Administrator.", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            lblError.Visible = false;

                            // Arahkan ke Form sesuai Role
                            if (role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                            {
                                FormAdmin fAdmin = new FormAdmin(nama, idUser);
                                fAdmin.Show();
                                this.Hide();
                            }
                            else if (role.Equals("kasir", StringComparison.OrdinalIgnoreCase))
                            {
                                FormKasir fKasir = new FormKasir(nama, idUser);
                                fKasir.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            // Pop-up jika Username atau Password salah
                            lblError.Text = "Username atau Password salah!";
                            lblError.Visible = true;
                            MessageBox.Show("Username atau Password yang Anda masukkan salah!", "Gagal Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            txtPassword.Clear();
                            txtPassword.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Koneksi gagal: " + ex.Message;
                lblError.Visible = true;
                MessageBox.Show("Gagal terhubung ke database!\n\nDetail: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
