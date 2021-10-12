create database HDBH
use HDBH

Create Table HANG
(
MaH char (15), TenH nvarchar(50), DonVi char(5), HangSX nvarchar (50), DonGiaNhap numeric(15,0), DonGiaBan numeric(15,0), MaLH char(15),
primary key(MaH),
foreign key(MaLH) references LOAIHANG 
)

Create Table LOAIHANG 
(
MaLH char(15), TenLH nvarchar(50),
primary key(MaLH)
)

Create Table NHANVIEN 
(
MaNV char (15), TenNV nvarchar(50), NgaySinh date , DiaChi nvarchar(50), DienThoai char(15),
primary key(MaNV)
)

Create Table KHACHHANG 
(
MaKH char (15), TenKH nvarchar(50), DiaChi nvarchar(50), DienThoai char(15),
primary key(MaKH)
)

Create Table HOADON 
(
MaHD char (15), MaKH char(15), MaNV char (15), NgayBan date,
primary key(MaHD),
foreign key(MaKH) references KHACHHANG,
foreign key(MaNV) references NHANVIEN
)

Create Table CHITIET_HD 
(
MaHD char (15), MaH char (15), SoLuongBan char(5), ThanhTien numeric(15,0),
primary key(MaHD),
foreign key(MaH) references HANG 
)

Create Table PHIEUNHAP 
(
MaPNH char (15), MaNV char (15), MaNCC char (15), NgayNhap date , TongTien numeric(15,0), VAT numeric(15,0), TongCong numeric(15,0),
primary key(MaPNH),
foreign key(MaNV) references NHANVIEN,
foreign key(MaNCC) references HANG
)

Create Table CHITIET_PN 
(
MaPNH char (15), MaH char (15), SoLuongNhap char(5), ThanhTien numeric(15,0),
primary key(MaPNH, MaH)
)

Create Table NHACC 
(
MaNCC char (15), TenNCC nvarchar(50), DienThoaiNCC char(15), DiaChiNCC nvarchar(50),
primary key(MaNCC)
)

