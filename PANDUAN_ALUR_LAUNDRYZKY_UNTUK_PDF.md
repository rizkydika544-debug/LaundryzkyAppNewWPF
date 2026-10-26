# 📑 DOKUMEN KOMPREHENSIF ALUR OPERASIONAL & ARSITEKTUR LAUNDRYZKY
> *Briefing Note & Blueprint Teknis untuk Pembuatan Laporan / Presentasi PDF Eksekutif via Claude*

---

## 1. 🏢 Profil & Konsep Sistem

- **Nama Aplikasi**: Laundryzky Management System (WPF Edition)
- **Kategori**: Enterprise Desktop POS & Operational Floor Management
- **Target Pengguna**: Usaha Laundry Kiloan & Satuan Modern (Kasir, Petugas Cuci, Petugas Setrika, Pemilik / Administrator)
- **Teknologi Utama**:
  - **Bahasa & Framework**: C# .NET 10.0 dengan Windows Presentation Foundation (WPF & XAML)
  - **Database**: MySQL 8.0 / MariaDB (Engine InnoDB, Relational Foreign Keys, Cascade Integrity)
  - **Library Pendukung**: `MySql.Data`, Native WPF Printing Engine, CSV Exporter
  - **Arsitektur**: Role-Based Access Control (RBAC) dengan State Machine Workflow Tracking terintegrasi

---

## 2. 🎯 Permasalahan Bisnis & Solusi yang Dihadirkan

| Masalah Klasik Laundry Konvensional | Solusi Sistem Laundryzky |
| :--- | :--- |
| Pakaian pelanggan tertukar atau hilang di gudang tanpa jejak petugas yang bertanggung jawab. | **Multi-Role Floor Tracking**: Setiap fase cuci dan setrika mencatat ID & nama petugas secara eksplisit di database. |
| Klaim kehilangan barang berharga yang tertinggal di saku pakaian. | **Pocket Note System (Cek Saku)**: Petugas cuci memiliki form khusus untuk mendokumentasikan barang temuan saku sebelum dicuci. |
| Karyawan curang menandai cucian "Selesai" padahal belum dikerjakan. | **Workstation Anti-Cheat**: Tombol *Tandai Selesai* terkunci sampai petugas mengklik *Ambil & Mulai Pengerjaan* (`sedang_cuci` / `sedang_setrika`). |
| Mesin cuci rusak karena kelebihan muatan (*overcapacity*) & antrean membludak. | **Defensive Limit**: Batas maksimal **50 Kg per transaksi** dan **WIP Limit 20 transaksi aktif**. |
| Piutang menumpuk akibat pelanggan memesan cucian baru padahal cucian lama belum lunas. | **1 Order Aktif per Pelanggan**: Sistem menolak transaksi baru jika pelanggan masih memiliki order aktif. |
| Uang pelanggan tidak dikembalikan saat pesanan dibatalkan. | **Refund Safeguard**: Validasi pembatalan otomatis mendeteksi status bayar dan mewajibkan kasir mereturn kas (`dikembalikan`). |

---

## 3. 👥 Alur Kerja Multi-Role (Role-Based Access Control)

### A. Peran Administrator (Owner / Manajer)
1. **Business Intelligence Dashboard**:
   - Menampilkan metrik real-time: Total Transaksi Kumulatif, Pesanan Sedang Diproses, Pesanan Selesai, dan Akumulasi Omset Uang Masuk.
2. **Monitoring Transparansi Produksi**:
   - Memantau tabel transaksi global yang memperlihatkan siapa kasir yang menerima, siapa petugas yang mencuci, siapa yang menyetrika, dan catatan saku.
3. **Manajemen Karyawan (User Management)**:
   - Tambah akun karyawan baru (Role: Kasir, Cuci, Setrika).
   - Mengubah status akun (`Aktif` vs `Nonaktif`) dengan proteksi keamanan (akun Admin utama tidak dapat dinonaktifkan).
4. **Laporan Keuangan & Audit**:
   - Filter tanggal fleksibel (*Date Range*).
   - Ekspor laporan ke **Excel Spreadsheet (.CSV)** untuk pembukuan akuntansi.
   - Cetak dokumen laporan fisik/digital ke format **PDF**.
5. **Emergency Database Reset**:
   - Fitur reset transaksi & pelanggan dengan dialog konfirmasi ganda aman untuk memulai periode pembukuan baru.

---

### B. Peran Kasir (Front Office POS)
1. **Pendaftaran & Pencarian Pelanggan**:
   - Pencarian instan (*real-time filter*) berdasarkan nama atau nomor WhatsApp.
   - Pendaftaran pelanggan baru secara cepat tanpa keluar dari form transaksi.
2. **Input Order & Validasi Tarif**:
   - Memilih jenis layanan: *Cuci Komplit (Cuci + Setrika)*, *Cuci Saja*, *Setrika Saja*, *Bedcover*, atau *Express*.
   - Input berat cucian dengan proteksi angka positif murni (maksimal 50 Kg).
   - Penentuan tanggal estimasi selesai pakaian.
   - Input catatan bawaan awal dari pelanggan.
3. **Fleksibilitas Sistem Pembayaran**:
   - **Opsi Waktu**:
     - *Bayar Sekarang (Lunas)*: Wajib memasukkan nominal bayar setara atau lebih dari total tagihan.
     - *Bayar Saat Ambil*: Status pembayaran dicatat `belum_bayar` dengan nominal bayar Rp 0.
   - **Metode Pembayaran**:
     - **💵 Tunai (Cash)**: Kalkulasi uang kembalian instan, indikator status "Uang Pas", dan proteksi pesan error jika uang kurang.
     - **📱 QRIS (All Payment)**: Integrasi barcode QRIS resmi (GoPay / BCA / DANA / OVO) yang dapat di-klik untuk memunculkan modal pop-up layar penuh agar mudah di-scan smartphone pelanggan.
4. **Nota Digital & Cetak Fisik**:
   - Preview nota otomatis bergaya *Thermal Receipt* (80mm) yang rapi dan siap cetak.
5. **Pemisahan Logika Pelunasan vs Penyerahan Fisik**:
   - **Skenario Pelunasan Awal**: Jika pelanggan datang melunasi saat baju masih dalam proses cuci/setrika, sistem merubah status bayar menjadi `lunas`, namun fisik baju **tidak diserahkan** (status tetap `diproses`).
   - **Skenario Penyerahan Akhir**: Tombol penyerahan pakaian (`diambil`) hanya aktif jika pakaian sudah berstatus fisik `selesai`.
6. **Pembatalan Transaksi & Refund**:
   - Kasir dapat membatalkan pesanan (`❌ Batal`) hanya jika proses cuci/setrika belum dimulai di lantai produksi.
   - Jika pesanan sudah dibayar, kasir diinstruksikan mengembalikan uang tunai ke pelanggan dan status pembayaran diubah menjadi `dikembalikan`.

---

### C. Peran Petugas Cuci (Washing Department)
1. **Filter Antrean Cucian Bersih**:
   - Hanya menampilkan cucian yang membutuhkan proses cuci (`status_cuci != 'tidak_perlu'`).
2. **Anti-Cheat Task Claiming**:
   - Status awal: `menunggu`.
   - Petugas **wajib** menekan tombol *"Ambil & Mulai Pengerjaan"*. Status berubah menjadi `sedang_cuci`, dan nama petugas langsung terikat ke transaksi.
   - Tombol *"Tandai Selesai"* terkunci selama status masih `menunggu`.
3. **Pencatatan Temuan Saku (Pocket Check)**:
   - Petugas memeriksa saku celana/baju pelanggan sebelum masuk tabung mesin cuci.
   - Jika ditemukan uang tunai, perhiasan, kuitansi, atau benda penting, petugas menginput *"Catatan Saku"* yang langsung tersimpan permanen dan tercetak di riwayat transaksi.
4. **Penyelesaian Cuci**:
   - Setelah cucian selesai dicuci dan dikeringkan, petugas menekan *"Tandai Selesai"*. Status cuci menjadi `selesai`.
   - Jika layanan hanya *Cuci Saja*, sistem secara otomatis mengubah status pesanan global menjadi `selesai` (siap diambil).

---

### D. Peran Petugas Setrika (Ironing & Finishing Department)
1. **Service-Aware Dependency Logic**:
   - Jika layanan adalah *Setrika Saja*, pakaian langsung masuk antrean setrika dengan status cuci `tidak_perlu`.
   - Jika layanan adalah *Cuci & Setrika*, pakaian di antrean setrika **tidak dapat diselesaikan** jika status cuci belum `selesai`.
2. **Anti-Cheat Penyetrikaan**:
   - Petugas setrika wajib menekan *"Ambil & Mulai Pengerjaan"* (`sedang_setrika`) sebelum menyelesaikan pengerjaan.
3. **Quality Control & Packaging**:
   - Petugas menyetrika, melipat rapi, menyemprotkan parfum laundry, dan membungkus plastik (*packaging*).
   - Petugas menekan *"Tandai Selesai"*. Status setrika menjadi `selesai`, dan status pesanan global menjadi `selesai` (notifikasi siap diambil kasir).
4. **Mode Monitor Progres Keseluruhan**:
   - Terdapat toggle monitor untuk melihat seluruh status antrean produksi tanpa merusak fokus antrean kerja pribadi.

---

## 4. 🔄 End-to-End Operational Lifecycle (Diagram Alur)

```
[ Pelanggan Datang ]
         │
         ▼
[ Kasir POS ] ─────────────────────────► Validasi Aturan Bisnis:
  - Pilih/Daftar Pelanggan               - Berat <= 50 Kg
  - Pilih Jenis Layanan                  - Total WIP Antrean <= 20
  - Cek Opsi Pembayaran                  - Pelanggan Tidak Memiliki Order Berjalan
         │
         ├───► Opsi A: Tunai (Hitung Kembalian)
         └───► Opsi B: QRIS (Scan Barcode Fullscreen Modal)
         │
         ▼
[ Order Masuk Antrean Database ]
         │
         ├─────────────────────────────────────────┐
         ▼ (Jika Butuh Cuci)                       ▼ (Jika Setrika Saja)
[ Departemen Cuci ]                                │
  1. Klik "Ambil & Mulai Pengerjaan"               │
  2. Cek Saku ──► Simpan "Catatan Saku"            │
  3. Proses Cuci & Pengeringan                     │
  4. Klik "Tandai Selesai"                         │
         │                                         │
         ▼                                         │
[ Departemen Setrika ] ◄───────────────────────────┘
  1. Validasi: Menunggu cuci selesai (jika paket komplit)
  2. Klik "Ambil & Mulai Pengerjaan"
  3. Penyetrikaan, Pewangi, & Packing Rapi
  4. Klik "Tandai Selesai"
         │
         ▼
[ Status Pesanan: SELESAI ]
         │
         ▼
[ Pelanggan Mengambil Pakaian di Kasir ]
  - Kasir Cek Status Pembayaran:
      • Jika Belum Bayar ──► Lunasi Tagihan (Tunai/QRIS)
      • Jika Sudah Lunas ──► Langsung Serahkan Pakaian
  - Status Pesanan Final ──► "DIAMBIL"
         │
         ▼
[ Rekapitulasi di Panel Admin ]
  - Omset Masuk Laporan Keuangan
  - Audit Trail Petugas Cuci & Setrika Tercatat Rapi
  - Ekspor CSV / Cetak PDF
```

---

## 5. 🗄️ Spesifikasi Database & Relasi (Data Dictionary)

Sistem menggunakan 5 tabel utama dengan relasi *Foreign Key Constraint*:

1. **`tbl_user`**:
   - Menyimpan kredensial autentikasi, role (`admin`, `kasir`, `cuci`, `setrika`), dan status aktif karyawan.
2. **`tbl_pelanggan`**:
   - Menyimpan master data pelanggan (nama, nomor kontak WA, alamat domisili).
3. **`tbl_jenis_layanan`**:
   - Menyimpan katalog layanan laundry beserta tarif harga per kilogram.
4. **`tbl_transaksi_header`**:
   - Menyimpan induk transaksi: kode transaksi unik, tanggal masuk, estimasi selesai, nominal bayar, kembalian, status pembayaran (`lunas`, `belum_bayar`, `dikembalikan`), status pengerjaan global (`menunggu`, `diproses`, `selesai`, `diambil`, `dibatalkan`), status cuci, petugas cuci, status setrika, petugas setrika, dan catatan saku.
5. **`tbl_transaksi_detail`**:
   - Menyimpan rincian layanan per transaksi, berat timbangan (Kg), tarif satuan, dan subtotal harga.

---

## 6. 💡 Highlight Nilai Tambah untuk Portofolio Software Engineering

Jika kamu memasukkan proyek ini ke portofolio atau dinilai oleh recruiter / penguji, soroti poin-poin berikut:
1. **Bukan Sekadar CRUD Sederhana**: Memiliki integrasi *State Machine* antar-divisi yang realistis sesuai SOP industri binatu komersial.
2. **Defensive Programming**: Dilengkapi validasi mencegah *invalid input*, *race conditions* penyelesaian tugas fiktif, serta *overcapacity protection*.
3. **Financial Integrity**: Memisahkan antara konsep pelunasan dana (*cash flow*) dan penyerahan barang (*fulfillment*), serta mencakup alur *refund* transaksi batal.
4. **Modern Clean UI**: Menggunakan palet warna HSL modern, tombol aksi dinamis, modal pop-up interaktif, serta tampilan status bebas *raw database underscore* (*Zero-Underscore Interface*).
5. **Audit Trail Accountability**: Setiap pakaian yang rusak atau ada barang temuan saku dapat ditelusuri siapa karyawan yang mencuci dan menyetrikanya.
