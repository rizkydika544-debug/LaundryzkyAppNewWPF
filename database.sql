-- ========================================================
-- Database Schema: laundryzky
-- Aplikasi: Laundryzky WPF Desktop Management System
-- Database Engine: MySQL / MariaDB (InnoDB)
-- ========================================================

CREATE DATABASE IF NOT EXISTS `laundryzky` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `laundryzky`;

SET FOREIGN_KEY_CHECKS = 0;
DROP TABLE IF EXISTS `tbl_transaksi_detail`;
DROP TABLE IF EXISTS `tbl_transaksi_header`;
DROP TABLE IF EXISTS `tbl_jenis_layanan`;
DROP TABLE IF EXISTS `tbl_pelanggan`;
DROP TABLE IF EXISTS `tbl_user`;
SET FOREIGN_KEY_CHECKS = 1;

-- --------------------------------------------------------
-- 1. Table structure for `tbl_user` (Manajemen Akun Karyawan & RBAC)
-- --------------------------------------------------------
CREATE TABLE `tbl_user` (
  `id_user` INT(11) NOT NULL AUTO_INCREMENT,
  `nama_user` VARCHAR(100) NOT NULL,
  `username` VARCHAR(50) NOT NULL UNIQUE,
  `password` VARCHAR(255) NOT NULL,
  `role` ENUM('admin', 'kasir', 'cuci', 'setrika') NOT NULL DEFAULT 'kasir',
  `status` ENUM('aktif', 'nonaktif') NOT NULL DEFAULT 'aktif',
  PRIMARY KEY (`id_user`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------
-- 2. Table structure for `tbl_pelanggan` (Master Data Pelanggan)
-- --------------------------------------------------------
CREATE TABLE `tbl_pelanggan` (
  `id_pelanggan` INT(11) NOT NULL AUTO_INCREMENT,
  `nama_pelanggan` VARCHAR(100) NOT NULL,
  `no_hp` VARCHAR(20) NOT NULL,
  `alamat` TEXT DEFAULT NULL,
  PRIMARY KEY (`id_pelanggan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------
-- 3. Table structure for `tbl_jenis_layanan` (Master Tarif & Layanan)
-- --------------------------------------------------------
CREATE TABLE `tbl_jenis_layanan` (
  `id_layanan` INT(11) NOT NULL AUTO_INCREMENT,
  `nama_layanan` VARCHAR(100) NOT NULL,
  `harga_per_kg` INT(11) NOT NULL,
  PRIMARY KEY (`id_layanan`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------
-- 4. Table structure for `tbl_transaksi_header` (Header Pesanan & Pelacakan Produksi)
-- --------------------------------------------------------
CREATE TABLE `tbl_transaksi_header` (
  `id_transaksi` INT(11) NOT NULL AUTO_INCREMENT,
  `id_pelanggan` INT(11) NOT NULL,
  `id_user` INT(11) NULL COMMENT 'Kasir yang memproses pesanan',
  `tanggal_masuk` DATETIME NOT NULL,
  `estimasi_selesai` DATE DEFAULT NULL,
  `status` ENUM('menunggu', 'diproses', 'selesai', 'diambil') NOT NULL DEFAULT 'menunggu',
  `status_pembayaran` ENUM('belum', 'lunas') NOT NULL DEFAULT 'belum',
  `metode_pembayaran` VARCHAR(50) NOT NULL DEFAULT 'Tunai',
  `bayar` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `kembali` DECIMAL(12,2) NOT NULL DEFAULT 0.00,
  `status_cuci` ENUM('menunggu', 'sedang_cuci', 'selesai', 'tidak_perlu') NOT NULL DEFAULT 'menunggu',
  `id_petugas_cuci` INT(11) DEFAULT NULL,
  `status_setrika` ENUM('menunggu', 'sedang_setrika', 'selesai', 'tidak_perlu') NOT NULL DEFAULT 'menunggu',
  `id_petugas_setrika` INT(11) DEFAULT NULL,
  `catatan_saku` TEXT DEFAULT NULL,
  PRIMARY KEY (`id_transaksi`),
  KEY `fk_trx_pelanggan` (`id_pelanggan`),
  KEY `fk_trx_kasir` (`id_user`),
  KEY `fk_trx_cuci` (`id_petugas_cuci`),
  KEY `fk_trx_setrika` (`id_petugas_setrika`),
  CONSTRAINT `fk_trx_pelanggan` FOREIGN KEY (`id_pelanggan`) REFERENCES `tbl_pelanggan` (`id_pelanggan`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_trx_kasir` FOREIGN KEY (`id_user`) REFERENCES `tbl_user` (`id_user`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_trx_cuci` FOREIGN KEY (`id_petugas_cuci`) REFERENCES `tbl_user` (`id_user`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_trx_setrika` FOREIGN KEY (`id_petugas_setrika`) REFERENCES `tbl_user` (`id_user`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------
-- 5. Table structure for `tbl_transaksi_detail` (Detail Item Transaksi)
-- --------------------------------------------------------
CREATE TABLE `tbl_transaksi_detail` (
  `id_detail` INT(11) NOT NULL AUTO_INCREMENT,
  `id_transaksi` INT(11) NOT NULL,
  `id_layanan` INT(11) NOT NULL,
  `berat_kg` DECIMAL(6,2) NOT NULL,
  `harga_per_kg` INT(11) NOT NULL,
  `subtotal` DECIMAL(12,2) NOT NULL,
  PRIMARY KEY (`id_detail`),
  KEY `fk_detail_trx` (`id_transaksi`),
  KEY `fk_detail_layanan` (`id_layanan`),
  CONSTRAINT `fk_detail_trx` FOREIGN KEY (`id_transaksi`) REFERENCES `tbl_transaksi_header` (`id_transaksi`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_detail_layanan` FOREIGN KEY (`id_layanan`) REFERENCES `tbl_jenis_layanan` (`id_layanan`) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ========================================================
-- DATA SEEDING AWAL (Akun Default & Master Layanan)
-- ========================================================

-- Akun Pengguna Default untuk Testing Setiap Role
INSERT INTO `tbl_user` (`id_user`, `nama_user`, `username`, `password`, `role`, `status`) VALUES
(1, 'Administrator Utama', 'admin', 'admin123', 'admin', 'aktif'),
(2, 'Siti Kasir', 'kasir', 'kasir123', 'kasir', 'aktif'),
(3, 'Budi Cuci', 'cuci', 'cuci123', 'cuci', 'aktif'),
(4, 'Rani Setrika', 'setrika', 'setrika123', 'setrika', 'aktif');

-- Master Daftar Layanan Laundry
INSERT INTO `tbl_jenis_layanan` (`id_layanan`, `nama_layanan`, `harga_per_kg`) VALUES
(1, 'Cuci + Kering + Setrika', 8000),
(2, 'Cuci + Kering', 6000),
(3, 'Setrika Saja', 5000),
(4, 'Express (1 Hari Selesai)', 12000),
(5, 'Bed Cover / Selimut Besar', 15000);

-- Data Contoh Pelanggan Awal
INSERT INTO `tbl_pelanggan` (`id_pelanggan`, `nama_pelanggan`, `no_hp`, `alamat`) VALUES
(1, 'Ahmad Subagyo', '081234567890', 'Jl. Merdeka No. 45, Kota Baru'),
(2, 'Dewi Lestari', '085712345678', 'Komplek Permata Hijau B3/12'),
(3, 'Rizky Pratama', '089698765432', 'Jl. Cempaka Putih No. 10');
