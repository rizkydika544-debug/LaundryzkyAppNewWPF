using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LaundryzkyWPF.Views
{
    public partial class NotaWindow : Window
    {
        public NotaWindow(
            string kodeTrx,
            string namaPelanggan,
            string noHp,
            string namaLayanan,
            decimal tarifPerKg,
            decimal beratKg,
            decimal totalTagihan,
            string statusBayar,
            decimal bayar,
            decimal kembali,
            string kasir,
            DateTime tglMasuk,
            DateTime estimasi,
            string catatan)
        {
            InitializeComponent();

            lblNoTrx.Text = kodeTrx;
            lblNamaPelanggan.Text = namaPelanggan;
            lblNoHp.Text = string.IsNullOrWhiteSpace(noHp) ? "-" : noHp;
            lblNamaLayanan.Text = namaLayanan;
            lblTarif.Text = $"Rp {tarifPerKg:N0} /Kg";
            lblBerat.Text = $"{beratKg} Kg";
            lblTotal.Text = $"Rp {totalTagihan:N0}";
            lblKasir.Text = kasir;
            lblTanggalMasuk.Text = tglMasuk.ToString("dd-MM-yyyy HH:mm");
            lblEstimasi.Text = estimasi.ToString("dd-MM-yyyy");
            lblCatatan.Text = string.IsNullOrWhiteSpace(catatan) ? "-" : catatan;

            bool isLunas = statusBayar.Equals("lunas", StringComparison.OrdinalIgnoreCase);
            if (isLunas)
            {
                lblStatusBayar.Text = "LUNAS";
                lblStatusBayar.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#03543F"));
                bdStatusBayar.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DEF7EC"));
                lblBayar.Text = $"Rp {bayar:N0}";
                lblKembali.Text = $"Rp {kembali:N0}";
            }
            else
            {
                lblStatusBayar.Text = "BELUM LUNAS (Bayar Saat Ambil)";
                lblStatusBayar.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#92400E"));
                bdStatusBayar.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FEF3C7"));
                lblBayar.Text = "Rp 0";
                lblKembali.Text = "Rp 0";
            }
        }

        private void BtnTutup_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnCetak_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintDialog pd = new PrintDialog();
                if (pd.ShowDialog() == true)
                {
                    // Pastikan visual nota diukur penuh sesuai konten aslinya agar tidak terpotong saat diprint/PDF
                    borderNota.Measure(new Size(borderNota.ActualWidth, double.PositiveInfinity));
                    borderNota.Arrange(new Rect(0, 0, borderNota.ActualWidth, borderNota.DesiredSize.Height));
                    borderNota.UpdateLayout();

                    pd.PrintVisual(borderNota, $"Nota_{lblNoTrx.Text}");
                    MessageBox.Show("Nota berhasil diproses cetak / disimpan sebagai PDF!", "Cetak Sukses", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mencetak: " + ex.Message, "Error Cetak", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
