using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LaundryzkyApp
{
    public partial class FormTambahUser : Form
    {
        private string idEdit = null;

        public FormTambahUser()
        {
            InitializeComponent();
            idEdit = null;
        }

        public FormTambahUser(string id)
        {
            InitializeComponent();
            idEdit = id;
        }

        private void FormTambahUser_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            cmbRole.Items.Clear();
            cmbRole.Items.Add("kasir");
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("aktif");
            cmbStatus.Items.Add("nonaktif");
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.SelectedIndex = 0;

            if (idEdit != null)
            {
                lblJudul.Text = "Edit User";
                MuatDataEdit();
            }
            else
            {
                lblJudul.Text = "Tambah User";
                cmbRole.SelectedIndex = 0;
            }
        }

        private void MuatDataEdit()
        {
            try
            {
                MySqlConnection conn = Koneksi.GetConn();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(
                    @"SELECT nama_user, username, role, status
                      FROM tbl_user WHERE id_user = @id", conn);
                cmd.Parameters.AddWithValue("@id", idEdit);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtNama.Text     = reader["nama_user"].ToString();
                    txtUsername.Text = reader["username"].ToString();
                    cmbRole.Text     = reader["role"].ToString();
                    cmbStatus.Text   = reader["status"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat: " + ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text    = "Semua field wajib diisi!";
                lblError.Visible = true;
                return;
            }

            try
            {
                MySqlConnection conn = Koneksi.GetConn();
                conn.Open();

                if (idEdit == null)
                {
                    MySqlCommand cmd = new MySqlCommand(
                        @"INSERT INTO tbl_user
                          (nama_user, username, password, role, status)
                          VALUES (@nama, @user, @pass, @role, @status)",
                        conn);
                    cmd.Parameters.AddWithValue("@nama",   txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@user",   txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass",   txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@role",   cmbRole.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User berhasil ditambahkan!", "Berhasil",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand(
                        @"UPDATE tbl_user SET
                          nama_user = @nama,
                          username  = @user,
                          password  = @pass,
                          role      = @role,
                          status    = @status
                          WHERE id_user = @id",
                        conn);
                    cmd.Parameters.AddWithValue("@nama",   txtNama.Text.Trim());
                    cmd.Parameters.AddWithValue("@user",   txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass",   txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@role",   cmbRole.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@id",     idEdit);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("User berhasil diupdate!", "Berhasil",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conn.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                lblError.Text    = "Gagal simpan: " + ex.Message;
                lblError.Visible = true;
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
