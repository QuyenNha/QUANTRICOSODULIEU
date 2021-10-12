CREATE DATABASE HDBH
USE HDBH

CREATE TABLE HANG
(MaH char (15), TenH nvarchar(50), DonVi char(5), HangSX nvarchar (50), DonGiaNhap numeric(15,0), DonGiaBan numeric(15,0), MaLH char(15),
primary key(MaH),
foreign key(MaLH) references LOAIHANG 
)
INSERT INTO HANG (MaH, TenH, DonVi, HangSX, DonGiaNhap, DonGiaBan, MaLH)
VALUES
('LG01' , 'Lọc gió' , 'Chiếc' , 'Hyundai' , 1200000 , 14500000 , 'LGOTT'),
('LG02' , 'Lọc gió' , 'Chiếc' , 'Vinfast' , 631000 , 700000 , 'LGOTC'),
('LGDH01' , 'Lọc gió điều hòa' , 'Chiếc' , 'Honda' , 150000 , 200000 , 'LGĐHOTT'),
('LGDH02' , 'Lọc gió điều hòa' , 'Chiếc' , 'Vinfast' , 337000 , 370000 ,'LGĐHOTC'),
('GX01' , 'Giảm xốc' , 'Cái' , 'Honda' , 1480000 , 1600000 , 'GXOTT'),
('GX02' , 'Giảm xốc' , 'Cái' , 'Vinfast' , 1729000 , 1900000 , 'GXOTC'),
('CBG01' , 'Chắn bùn gầm' , 'Cái' , 'Hyundai' , 800000 , 1000000 , 'CBGOTT'),
('CBG02' , 'Chắn bùn gầm' , 'Cái' , 'Honda' , 550000 , 700000 , 'CBGOTC'),
('G01' , 'Gioăng' , 'Chiếc' , 'Vinfast' , 174000 , 190000 , 'GOTC'),
('G02' , 'Gioăng' , 'Cái' , 'Hyundai' , 400000 , 500000 , 'GOTT')
------------------------------------------------------------------------------------------------
CREATE TABLE LOAIHANG 
(MaLH char(15), TenLH nvarchar(50),
primary key(MaLH)
)
INSERT INTO LOAIHANG (MaLH, TenLH)
VALUES
('LGOTT' , 'Lọc gió ô tô tải'),
('LGOTC' , 'Lọc gió ô tô con'),
('LGĐHOTT' , 'Lọc gió điều hòa ô tô tải'),
('LGĐHOTC' , 'Lọc gió điều hòa ô tô con'),
('GXOTT' , 'Giảm xốc ô tô tải'),
('GXOTC' , 'Giảm xốc ô tô con'),
('CBGOTT' , 'Chắn bùn gầm ô tô tải'),
('CBGOTC' , 'Chắn bùn gầm ô tô con'),
('GOTT' , 'Gioăng ô tô con'),
('GOTC' , 'Gioăng ô tô tải')

-----------------------------------------------------------------------------------------------
CREATE TABLE NHANVIEN 
(MaNV char (15), TenNV nvarchar(50), NgaySinh date , DiaChi nvarchar(50), DienThoai char(15),
primary key(MaNV)
)
INSERT INTO NHANVIEN (MaNV, TenNV, NgaySinh, DiaChi, DienThoai)
VALUES 
('NV01' , 'Trần Đỗ Hòa' , '09-07-2001' , 'Huế' , '0762548324'),
('NV02' , 'Chế Thị Nhã Quyên' , '31-07-2001' , 'Huế' , '0344463107'),
('NV03' , 'Nguyễn Thị Ngọc' , '17-09-2001' , 'Đà Nẵng' , '0795199987'),
('NV04' , 'Nguyễn Thị My La' , '24-03-2001' , 'Quảng Bình' , '0826342403'),
('NV05' , 'Đặng Thị Mỹ Duyên' , '06-04-2001' , 'Quảng Bình' , '0948466929'),
('NV06' , 'Ngô Thị Tú Trinh' , '15-01-2001' , 'Đà Nẵng' , '0905397177'),
('NV07' , 'Nguyễn Tiến Dưỡng' , '11-12-2001' , 'Quảng Nam' , '0935637523'),
('NV08' , 'Nguyễn Thanh Thảo' , '19-07-2001' , 'Quảng Nam' , '0899310465'),
('NV09' , 'Đỗ Như Quỳnh' , '17-07-2001' , 'Đà Nẵng' , '0765207419'),
('NV10' , 'Nguyễn Sinh Hùng' , '02-10-2001' , 'Hà Tĩnh' , '0367123568')
-----------------------------------------------------------------------------------------------
CREATE TABLE KHACHHANG 
(MaKH char (15), TenKH nvarchar(50), DiaChi nvarchar(50), DienThoai char(15),
primary key(MaKH)
)
INSERT INTO KHACHHANG (MaKH, TenKH, DiaChi, DienThoai)
VALUES
('KH01' , 'Lê Kim Quốc Chung' , 'Huế' , '0359959518'),
('KH02' , 'Nguyễn Văn Thanh Hiếu' , 'Quảng Nam' , '0787547020'),
('KH03' , 'Phạm Văn Hiếu' , 'Đà Nẵng' , '0703587314'),
('KH04' , 'Nguyễn Thị Yến Phượng' , 'Quảng Nam' , '0704230112'),
('KH05' , 'Nguyễn Hồng Sơn' , 'Huế' , '0366067051'),
('KH06' , 'Nguyễn Đình Tín' , 'Đà Nẵng' , '0906209570'),
('KH07' , 'Nguyễn Hồ Anh Thư' , 'Quảng Ngãi' , '0334259809'),
('KH08' , 'Ngô Thị Hồng Vân' , 'Lâm Đồng' , '0898908304'),
('KH09' , 'Trần Văn Vũ' , 'Quảng Nam' , '0377991755'),
('KH10' , 'Hồ Huỳnh Thảo Vy' , 'Quảng Nam' , '0394769357')

-----------------------------------------------------------------------------------------------
CREATE TABLE HOADON 
(MaHD char (15), MaKH char(15), MaNV char (15), NgayBan date,
primary key(MaHD),
foreign key(MaKH) references KHACHHANG,
foreign key(MaNV) references NHANVIEN
)
INSERT INTO HOADON(MaHD, MaKH, MaNV, NgayBan)
VALUES
('1001' , 'KH01' , 'NV01' , '08-08-2021'),
('1002' , 'KH03' , 'NV04' , '07-09-2021'),
('1003' , 'KH09' , 'NV05' , '24-03-2021'),
('1004' , 'KH10' , 'NV06' , '08-10-2021'),
('1005' , 'KH08' , 'NV09' , '12-07-2021'),
('1006' , 'KH07' , 'NV10' , '15-06-2021'),
('1007' , 'KH06' , 'NV02' , '12-12-2021'),
('1008' , 'KH02' , 'NV03' , '15-12-2021'),
('1009' , 'KH05' , 'NV08' , '03-02-2021'),
('1010' , 'KH04' , 'NV07' , '05-07-2021')
-----------------------------------------------------------------------------------------------
CREATE TABLE CHITIET_HD 
(MaHD char (15), MaH char (15), SoLuongBan char(5), ThanhTien numeric(15,0),
primary key(MaHD),
foreign key(MaH) references HANG 
)
INSERT INTO CHITIET_HD (MaHD, MaH, SoLuongBan, ThanhTien)
VALUES
('HD001' , 'LG01' , 2 , 2900000),
('HD002' , 'LG02' , 3 , 2100000),
('HD003' , 'LGDH01' , 1 , 200000),
('HD004' , 'LGDH02' , 1 , 370000),
('HD005' , 'GX01' , 2 , 3200000),
('HD006' , 'GX02' , 3 , 5700000),
('HD007' , 'CBG01' , 2 , 2000000),
('HD008' , 'CBG02' , 1 , 700000),
('HD009' , 'G01' , 2 , 380000),
('HD010' , 'G02' , 2 , 1000000)
-----------------------------------------------------------------------------------------------
CREATE TABLE PHIEUNHAP 
(MaPNH char (15), MaNV char (15), MaNCC char (15), NgayNhap date , TongTien numeric(15,0), VAT numeric(5,2), TongCong numeric(15,0),
primary key(MaPNH),
foreign key(MaNV) references NHANVIEN,
foreign key(MaNCC) references HANG
)
INSERT INTO PHIEUNHAP (MaPNH, MaNV, MaNCC, NgayNhap, TongTien, VAT, TongCong)
VALUES
('PNH01' , 'NV01' , 'NCC03' , '01-03-2020' , 6000000 , 1.0 , 6600000 ),
('PNH02' , 'NV04' , 'NCC02' , '02-09-2020' , 6500000 , 1.5 , 7475000  ),
('PNH03' , 'NV05' , 'NCC05' , '01-02-2021' , 10000000 , 1.0 , 11000000),
('PNH04' , 'NV02' , 'NCC07' , '12-06-2019' , 15000000 , 1.7 , 17550000),
('PNH05' , 'NV07' , 'NCC04' , '21-02-2020' , 7000000 , 1.2 , 7840000),
('PNH06' , 'NV08' , 'NCC08' , '18-06-2020' , 9000000 , 1.5 , 10350000),
('PNH07' , 'NV10' , 'NCC10' , '06-04-2018' , 9400000 , 1.0 , 10340000),
('PNH08' , 'NV09' , 'NCC09' , '20-05-2019' , 3240000 , 0.9 , 3531600),
('PNH09' , 'NV03' , 'NCC06' , '09-04-2021' , 15120000 , 1.0 , 16632000 ),
('PNH10' , 'NV06' , 'NCC01' , '24-03-2020' , 32000000 , 1.2 , 35840000 )

-----------------------------------------------------------------------------------------------
CREATE TABLE CHITIET_PN 
(MaPNH char (15), MaH char (15), SoLuongNhap char(5), ThanhTien numeric(15,0),
primary key(MaPNH, MaH)
)
INSERT INTO CHITIET_PN (MaPNH, MaH, SoLuongNhap, ThanhTien)
VALUES
('PNH01' , 'LG01' , 5 , 6000000),
('PNH02' , 'LG02' , 7 , 4417000),
('PNH03' , 'LGDH01' , 6 , 900000),
('PNH04' , 'LGDH02' , 8 , 2696000),
('PNH05' , 'GX01' , 6 , 8880000),
('PNH06' , 'GX02' , 5 , 8645000),
('PNH07' , 'CBG01' , 7 , 5600000),
('PNH08' , 'CBG02' , 8 , 4400000),
('PNH09' , 'G01' , 5 , 870000),
('PNH10' , 'G02' , 6 , 2400000)
-----------------------------------------------------------------------------------------------
CREATE TABLE NHACC 
(MaNCC char (15), TenNCC nvarchar(50), DienThoaiNCC char(15), DiaChiNCC nvarchar(50),
primary key(MaNCC)
)
INSERT INTO NHACC (MaNCC, TenNCC, DienThoaiNCC, DiaChiNCC)
VALUES
('NCC01' , 'Công ty CP Đầu tư thương mại và dịch vụ ô tô Liên Việt' , '0918 340 288' , 'Thành phố Hà Nội'),
('NCC02' , 'Công ty TNHH Thương mại và dịch vụ Dương Duy' , '0903 874 225' , 'Thành phố Hồ Chí Minh'),
('NCC03' , 'Công ty cổ phần KENT Việt Nam' , '0948 101 055' , 'Thành phố Hà Nội'),
('NCC04' , 'Công ty cổ phần thiết bị Tân Phát' , '0971 950 792' , 'Thành phố Hà Nội'),
('NCC05' , 'Vỏ xe Thanh Long - Công ty TNHH Thanh Long' , '0903 703 124' , 'Thành phố Hồ Chí Minh'),
('NCC06' , 'Công ty TNHH XNK ô tô Đại Đô Thành' , '028 39117788' , 'Thành phố Hồ Chí Minh'),
('NCC07' , 'Công ty máy lạnh ô tô Thành Đạt' , '0913 019 791' , 'Thành phố Hà Nội'),
('NCC08' , 'Công ty TNHH XNK Quốc Tế Duy Tân' , '0974 908 502' , 'Thành phố Hà Nội'),
('NCC09' , 'Công ty TNHH MTV Thương mại dịch vụ ô tô Sáu Thanh' , '0902710374' , 'Tỉnh Bình Dương'),
('NCC10' , 'Công ty TNHH Thiên Mẫn' , '0398832449' , 'Thành phố Hồ Chí Minh')
