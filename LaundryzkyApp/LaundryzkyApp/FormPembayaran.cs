using System;
using System.Drawing;
using System.Windows.Forms;

namespace LaundryzkyApp
{
    public partial class FormPembayaran : Form
    {
        // Property publik untuk diambil oleh FormAdmin / FormKasir
        public decimal TotalTagihan { get; private set; }
        public string MetodePembayaran { get; private set; } = "Tunai";
        public decimal UangBayar { get; private set; }
        public decimal UangKembali { get; private set; }

        // Constructor dengan parameter total tagihan
        public FormPembayaran(decimal total)
        {
            InitializeComponent();
            TotalTagihan = total;
        }

        private void FormPembayaran_Load(object sender, EventArgs e)
        {
            lblTotalHeader.Text = "Rp " + TotalTagihan.ToString("N0");

            // Gunakan posisi & ukuran asli dari Designer
            rbTunai.Checked = true;
            TampilkanPanelTunai();

            txtUangBayar.MaxLength = 10;
            txtUangBayar.Text = TotalTagihan.ToString("N0"); // Default diisi uang pas
            HitungKembalian();
        }

        private void FormPembayaran_Shown(object sender, EventArgs e)
        {
            if (rbTunai.Checked)
            {
                txtUangBayar.Focus();
                txtUangBayar.SelectAll();
            }
        }

        private void TampilkanPanelTunai()
        {
            MetodePembayaran = "Tunai";
            panelQRIS.Visible = false;
            panelTunai.Visible = true;
            panelTunai.BringToFront();
        }

        private void TampilkanPanelQRIS()
        {
            MetodePembayaran = "QRIS";
            panelTunai.Visible = false;
            panelQRIS.Visible = true;
            panelQRIS.BringToFront();

            // Pembayaran QRIS otomatis dianggap uang pas
            UangBayar = TotalTagihan;
            UangKembali = 0;
        }

        private void rbTunai_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTunai.Checked)
            {
                TampilkanPanelTunai();
                txtUangBayar.Focus();
                txtUangBayar.SelectAll();
                HitungKembalian();
            }
        }

        private void rbQRIS_CheckedChanged(object sender, EventArgs e)
        {
            if (rbQRIS.Checked)
            {
                TampilkanPanelQRIS();
            }
        }

        private void txtUangBayar_TextChanged(object sender, EventArgs e)
        {
            HitungKembalian();
        }

        private void HitungKembalian()
        {
            string input = txtUangBayar.Text.Replace(".", "").Replace(",", "").Trim();

            if (decimal.TryParse(input, out decimal bayar))
            {
                if (bayar > 1000000000m)
                {
                    bayar = 1000000000m;
                    txtUangBayar.Text = "1000000000";
                    txtUangBayar.SelectionStart = txtUangBayar.Text.Length;
                }

                UangBayar = bayar;
                UangKembali = UangBayar - TotalTagihan;

                if (UangKembali >= 0)
                {
                    lblKembalian.Text = "Rp " + UangKembali.ToString("N0");
                    lblKembalian.ForeColor = Color.Green;
                }
                else
                {
                    lblKembalian.Text = "Kurang Rp " + Math.Abs(UangKembali).ToString("N0");
                    lblKembalian.ForeColor = Color.Red;
                }
            }
            else
            {
                UangBayar = 0;
                UangKembali = -TotalTagihan;
                lblKembalian.Text = "Rp 0";
                lblKembalian.ForeColor = Color.Black;
            }
        }

        // Event Tombol Cepat Nominal
        private void btn10k_Click(object sender, EventArgs e) => txtUangBayar.Text = "10000";
        private void btn20k_Click(object sender, EventArgs e) => txtUangBayar.Text = "20000";
        private void btn50k_Click(object sender, EventArgs e) => txtUangBayar.Text = "50000";
        private void btn100k_Click(object sender, EventArgs e) => txtUangBayar.Text = "100000";

        private void btnKonfirmasi_Click(object sender, EventArgs e)
        {
            if (MetodePembayaran == "Tunai" && UangBayar < TotalTagihan)
            {
                MessageBox.Show("Uang pembayaran masih kurang dari total tagihan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUangBayar.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtUangBayar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void panelQRIS_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picQRIS_Click(object sender, EventArgs e)
        {

        }
    }
}