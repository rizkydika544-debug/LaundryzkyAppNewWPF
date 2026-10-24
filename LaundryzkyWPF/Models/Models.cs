using System;

namespace LaundryzkyWPF.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string NamaUser { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role { get; set; } = ""; // admin, kasir, cuci, setrika
        public string Status { get; set; } = "aktif"; // aktif, nonaktif
        public string StatusDisplay => (Status?.ToLower() switch
        {
            "aktif" => "Aktif",
            "nonaktif" => "Nonaktif",
            _ => Status
        }) ?? "";

        public string RoleDisplay => (Role?.ToLower() switch
        {
            "admin" => "Administrator",
            "kasir" => "Kasir",
            "cuci" => "Bagian Cuci",
            "setrika" => "Bagian Setrika",
            _ => Role
        }) ?? "";
    }

    public class Pelanggan
    {
        public int IdPelanggan { get; set; }
        public string NamaPelanggan { get; set; } = "";
        public string NoHp { get; set; } = "";
        public string Alamat { get; set; } = "";
    }

    public class Layanan
    {
        public int IdLayanan { get; set; }
        public string NamaLayanan { get; set; } = "";
        public int HargaPerKg { get; set; }
    }

    public class Transaksi
    {
        public int IdTransaksi { get; set; }
        public string KodeTransaksi => $"TRX-{IdTransaksi:D4}";
        public int IdPelanggan { get; set; }
        public string NamaPelanggan { get; set; } = "";
        public int? IdUser { get; set; }
        public string Kasir { get; set; } = "-";
        public DateTime TanggalMasuk { get; set; }
        public DateTime? EstimasiSelesai { get; set; }
        public string Status { get; set; } = "menunggu"; // menunggu, diproses, selesai, diambil
        public string StatusPembayaran { get; set; } = "belum"; // belum, lunas
        public string MetodePembayaran { get; set; } = "Tunai";
        public decimal Bayar { get; set; }
        public decimal Kembali { get; set; }

        // Kolom khusus Role Pekerja (Cuci & Setrika) & Tanggung Jawab Catatan Saku
        public string StatusCuci { get; set; } = "menunggu"; // menunggu, sedang_cuci, selesai, tidak_perlu
        public int? IdPetugasCuci { get; set; }
        public string PetugasCuci { get; set; } = "-";

        public string StatusSetrika { get; set; } = "menunggu"; // menunggu, sedang_setrika, selesai, tidak_perlu
        public int? IdPetugasSetrika { get; set; }
        public string PetugasSetrika { get; set; } = "-";

        public string? CatatanSaku { get; set; }

        // Detail Layanan & Kontak
        public string NoHp { get; set; } = "";
        public string NamaLayanan { get; set; } = "";
        public decimal HargaPerKg { get; set; }
        public decimal BeratKg { get; set; }
        public decimal Subtotal { get; set; }
        public string TotalFormatted => $"Rp {Subtotal:N0}";

        // Properti Display ramah pengguna (tanpa underscore)
        public string StatusDisplay => Status?.ToLower() switch
        {
            "menunggu" => "Menunggu",
            "diproses" => "Sedang Diproses",
            "selesai" => "Selesai",
            "diambil" => "Sudah Diambil",
            _ => Status?.Replace("_", " ") ?? ""
        };

        public string StatusCuciDisplay => StatusCuci?.ToLower() switch
        {
            "menunggu" => "Menunggu",
            "sedang_cuci" => "Sedang Dicuci",
            "selesai" => "Selesai",
            "tidak_perlu" => "Tidak Perlu",
            _ => StatusCuci?.Replace("_", " ") ?? ""
        };

        public string StatusSetrikaDisplay => StatusSetrika?.ToLower() switch
        {
            "menunggu" => "Menunggu",
            "sedang_setrika" => "Sedang Disetrika",
            "selesai" => "Selesai",
            "tidak_perlu" => "Tidak Perlu",
            _ => StatusSetrika?.Replace("_", " ") ?? ""
        };

        public string StatusPembayaranDisplay => StatusPembayaran?.ToLower() switch
        {
            "belum" => "Belum Bayar",
            "lunas" => "Lunas",
            _ => StatusPembayaran?.Replace("_", " ") ?? ""
        };
    }
}
