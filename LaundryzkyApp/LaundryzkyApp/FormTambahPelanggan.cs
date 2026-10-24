using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LaundryzkyApp
{
    public partial class FormTambahPelanggan : Form
    {
        private string idEdit = null;

        // Constructor tambah baru
        public FormTambahPelanggan()
        {
            InitializeComponent();
            idEdit = null;
        }

        // Constructor edit
        public FormTambahPelanggan(string id)
        {
            InitializeComponent();
            idEdit = id;
        }

        private void FormTambahPelanggan_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (idEdit != null)
            {
                // Mode edit - muat data lama
                lblJudul.Text = "Edit Pelanggan";
                MuatDataEdit();
            }
            else
            {
                lblJudul.Text = "Tambah Pelanggan";
            }
        }

        private void MuatDataEdit()
        {
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();
                    string query = @"SELECT nama_pelanggan, no_hp, alamat 
                                     FROM tbl_pelanggan 
                                     WHERE id_pelanggan = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idEdit);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNama.Text = reader["nama_pelanggan"].ToString();
                                txtHP.Text = reader["no_hp"].ToString();
                                txtAlamat.Text = reader["alamat"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal muat data: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper untuk mengecek duplikasi nama atau nomor HP di database
        private bool CekPelangganDuplikat(string nama, string noHp)
        {
            bool isExist = false;
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();

                    // Query mengecek nama/no_hp duplikat (abaikan ID jika sedang dalam mode Edit)
                    string query = @"SELECT COUNT(*) FROM tbl_pelanggan 
                                     WHERE (LOWER(nama_pelanggan) = LOWER(@nama) OR no_hp = @hp)";

                    if (idEdit != null)
                    {
                        query += " AND id_pelanggan != @idEdit";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nama", nama);
                        cmd.Parameters.AddWithValue("@hp", noHp);
                        if (idEdit != null)
                        {
                            cmd.Parameters.AddWithValue("@idEdit", idEdit);
                        }

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            isExist = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memeriksa data duplikat: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isExist;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            string nama = txtNama.Text.Trim();
            string hp = txtHP.Text.Trim();
            string alamat = txtAlamat.Text.Trim();

            // 1. Validasi Input Kosong
            if (string.IsNullOrWhiteSpace(nama))
            {
                lblError.Text = "Nama pelanggan wajib diisi!";
                lblError.Visible = true;
                txtNama.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(hp))
            {
                lblError.Text = "No HP wajib diisi!";
                lblError.Visible = true;
                txtHP.Focus();
                return;
            }

            // 2. Validasi Anti Duplikat Pelanggan
            if (CekPelangganDuplikat(nama, hp))
            {
                lblError.Text = "Nama atau Nomor HP sudah terdaftar!";
                lblError.Visible = true;
                MessageBox.Show("Pelanggan dengan Nama atau Nomor HP tersebut SUDAH TERDAFTAR!\n\nSilakan gunakan nama atau nomor HP yang berbeda.",
                                "Data Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtNama.Focus();
                return;
            }

            // =========================================================================
            // 3. PEMBERITAHUAN KONFIRMASI ULANG DATA PELANGGAN
            // =========================================================================
            string aksiText = idEdit == null ? "menambahkan" : "memperbarui";
            string pesanKonfirmasi = $"Apakah Anda yakin data pelanggan berikut sudah benar?\n\n" +
                                     $"• Nama Pelanggan : {nama}\n" +
                                     $"• No. HP / WA    : {hp}\n" +
                                     $"• Alamat          : {(string.IsNullOrWhiteSpace(alamat) ? "-" : alamat)}\n\n" +
                                     $"Tekan YES untuk {aksiText} data.";

            DialogResult dialogResult = MessageBox.Show(pesanKonfirmasi, "Konfirmasi Data Pelanggan",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes)
            {
                txtNama.Focus();
                return; // Batal simpan jika ragu / memilih 'No'
            }

            // 4. Eksekusi Simpan (Insert / Update)
            try
            {
                using (MySqlConnection conn = Koneksi.GetConn())
                {
                    conn.Open();

                    if (idEdit == null)
                    {
                        // INSERT BARU
                        string query = @"INSERT INTO tbl_pelanggan (nama_pelanggan, no_hp, alamat)
                                         VALUES (@nama, @hp, @alamat)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nama", nama);
                            cmd.Parameters.AddWithValue("@hp", hp);
                            cmd.Parameters.AddWithValue("@alamat", alamat);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Pelanggan berhasil ditambahkan!", "Berhasil",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // UPDATE DATA
                        string query = @"UPDATE tbl_pelanggan SET
                                         nama_pelanggan = @nama,
                                         no_hp          = @hp,
                                         alamat         = @alamat
                                         WHERE id_pelanggan = @id";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nama", nama);
                            cmd.Parameters.AddWithValue("@hp", hp);
                            cmd.Parameters.AddWithValue("@alamat", alamat);
                            cmd.Parameters.AddWithValue("@id", idEdit);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Pelanggan berhasil diupdate!", "Berhasil",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = "Gagal simpan: " + ex.Message;
                lblError.Visible = true;
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}