create database CHPT
use CHPT

--Tao bang Loai hang
create table LOAIHANG 
(
	MaLH	char(5),
	TenLH	nvarchar(50) not null,
	primary key(MaLH)
)
go

--Tao bang Hang
create table HANG
(
	MaH		char(5),
	TenH	nvarchar(50) not null,
	DonVi	nvarchar(10) not null,
	HangSX	nvarchar(50), 
	HangTonKho int,
	DonGiaNhap numeric(15,0) not null,
	DonGiaBan numeric(15,0) not null,
	MaLH	char(5) not null,
	primary key(MaH),
	foreign key(MaLH) references LOAIHANG 
)
go

--Tao bang Nhan vien
create table NHANVIEN 
(
	MaNV	char(5),
	TenNV	nvarchar(50) not null,
	NgaySinh date not null,
	DiaChi	nvarchar(150),
	DienThoai varchar(12),
	primary key(MaNV)
)
go

--Tao bang Khach hang
create table KHACHHANG 
(
	MaKH	char(5),
	TenKH	nvarchar(50) not null,
	DiaChi	nvarchar(150),
	DienThoai varchar(12),
	primary key(MaKH)
)
go

--Tao bang Hoa don
create table HOADON 
(
	MaHD	char(5), 
	MaKH	char(5) not null, 
	MaNV	char(5) not null, 
	NgayBan date not null,
	TongCong numeric(15,0),
	primary key(MaHD),
	foreign key(MaKH) references KHACHHANG,
	foreign key(MaNV) references NHANVIEN
)
go

--Tao bang Chi tiet Hoa don
create table CHITIET_HD 
(
	MaCTHD	char(5), 
	MaH		char(5), 
	SoLuongBan int not null, 
	ThanhTien numeric(15,0),
	primary key(MaCTHD, MaH),
	foreign key(MaCTHD)references HOADON(MaHD),
	foreign key(MaH) references HANG 
)
go

--Tao bang Nha cung cap
create table NHACC 
(
	MaNCC	char(5), 
	TenNCC	nvarchar(50) not null, 
	DienThoaiNCC varchar(12) not null, 
	DiaChiNCC nvarchar(150) not null,
	primary key(MaNCC)
)
go

--Tao bang Phieu nhap
create table PHIEUNHAP 
(
	MaPNH	char(5), 
	MaNV	char(5) not null, 
	MaNCC	char(5) not null, 
	NgayNhap date not null, 
	VAT		numeric(15,0), 
	TongTien numeric(15,0), 
	TongCong numeric(15,0),
	primary key(MaPNH),
	foreign key(MaNV) references NHANVIEN,
	foreign key(MaNCC) references NHACC
)
go

--Tao bang Chi tiet Phieu nhap
create table CHITIET_PN 
(
	MaCTPNH	char(5),
	MaH		char(5) not null,
	SoLuongNhap int not null,
	ThanhTien numeric(15,0),
	primary key(MaCTPNH, MaH),
	foreign key(MaCTPNH) references PHIEUNHAP(MaPNH),
	foreign key(MaH) references HANG
)
go

--insert data
insert into LOAIHANG values ('LH001',N'Phụ tùng xe ô tô')
insert into LOAIHANG values ('LH002',N'Phụ tùng xe bán tải')
insert into LOAIHANG values ('LH003',N'Phụ tùng xe khách')
insert into LOAIHANG values ('LH004',N'Phụ tùng xe tải chở hàng')
insert into LOAIHANG values ('LH005',N'Phụ tùng xe chuyên dụng')

insert into HANG values ('H0001',N'Lọc gió',N'chiếc',N'Việt Nam',100,1200000,14500000,'LH001')
insert into HANG values ('H0002',N'Hộp số',N'bộ',N'Nhật Bản',100,631000,700000,'LH002')
insert into HANG values ('H0003',N'Kính gió sau',N'tấm',N'Singapore',100,150000,200000,'LH003')
insert into HANG values ('H0004',N'Đèn pha',N'chiếc',N'Đài Loan',100,337000,370000,'LH004')
insert into HANG values ('H0005',N'Kính gió sau',N'tấm',N'Hoa Kỳ',100,148000,160000,'LH005')
insert into HANG values ('H0006',N'Kính chắn gió',N'tấm',N'Việt Nam',100,1500000,17500000,'LH001')
insert into HANG values ('H0007',N'Cổ góp hút',N'chiếc',N'Nhật Bản',100,111000,140000,'LH002')
insert into HANG values ('H0008',N'Kính an toàn',N'tấm',N'Singapore',100,150000,180000,'LH003')
insert into HANG values ('H0009',N'Kính an toàn',N'tấm',N'Đài Loan',100,100000,130000,'LH004')
insert into HANG values ('H0010',N'Kính chiếu hậu',N'chiếc',N'Indo',100,70000,80000,'LH005')
insert into HANG values ('H0011',N'Con trở điều hòa',N'con',N'Việt Nam',100,120000,1450000,'LH002')
insert into HANG values ('H0012',N'Dàn lạnh',N'bộ',N'Nhật Bản',100,710000,750000,'LH002')
insert into HANG values ('H0013',N'Dàn nóng',N'bộ',N'Singapore',100,750000,800000,'LH003')
insert into HANG values ('H0014',N'Két nước',N'chiếc',N'Đài Loan',100,300000,350000,'LH003')
insert into HANG values ('H0015',N'Giảm xốc',N'cái',N'Indo',100,148000,160000,'LH005')
insert into HANG values ('H0016',N'Lọc ga điều hòa',N'cái',N'Thái Lan',100,172000,190000,'LH001')
insert into HANG values ('H0017',N'Lốc điều hòa',N'cái',N'Việt Nam',100,800000,900000,'LH002')
insert into HANG values ('H0018',N'Chắn bùn gầm',N'cái',N'Trung Quốc',100,550000,700000,'LH003')
insert into HANG values ('H0019',N'Gioăng',N'chiếc',N'Việt Nam',100,174000,190000,'LH004')
insert into HANG values ('H0020',N'Cản biến vị trí cốt máy',N'cái',N'Indo',100,400000,500000,'LH005')
insert into HANG values ('H0021',N'Kèn Sò',N'chiếc',N'Việt Nam',100,105000,150000,'LH001')
insert into HANG values ('H0022',N'Vỏ xe',N'chiếc',N'Nhật Bản',100,91000,120000,'LH002')
insert into HANG values ('H0023',N'Ác quy khô',N'chiếc',N'Thái Lan',100,150000,170000,'LH003')
insert into HANG values ('H0024',N'Rotuyn cân bằng',N'cái',N'Đài Loan',100,130000,170000,'LH004')
insert into HANG values ('H0025',N'Kính gió sau',N'tấm',N'Việt Nam',100,148000,160000,'LH005')

insert into NHANVIEN values ('NV001',N'Trần Đỗ Hòa','2001/07/09',N'84 Nguyễn Phúc Nguyên, Hương Hòa, Thành phố Huế, Thừa Thiên Huế','0762548324')
insert into NHANVIEN values ('NV002',N'Chế Thị Nhã Quyên','2001/07/31' ,N'Tổ dân phố An Đô, Hương Chữ, Hương Trà, Thừa Thiên Huế' ,'0344463107')
insert into NHANVIEN values ('NV003',N'Nguyễn Thị Ngọc','2001/09/17',N'21 Phan Hành Sơn, Mỹ An, Ngũ Hành Sơn, Đà Nẵng','0795199987')
insert into NHANVIEN values ('NV004',N'Nguyễn Thị My La','2001/03/24' ,N'20 Chu Văn An, Hoàn Lão, Bố Trạch, Quảng Bình','0826342403')
insert into NHANVIEN values ('NV005',N'Đặng Thị Mỹ Duyên','2001/04/06',N'05 Văn Cao, Ba Đồn, Quảng Trạch, Quảng Bình','0948466929')

insert into KHACHHANG values ('KH001',N'Lê Kim Quốc Chung',N'Nguyễn Tất Thành, Thủy Phương, Hương Thủy, Thừa Thiên Huế','0359959518')
insert into KHACHHANG values ('KH002',N'Nguyễn Văn Thanh Hiếu',N'Mai An Tiêm, Cửa Đại, Hội An, Quảng Nam', '0787547020')
insert into KHACHHANG values ('KH003',N'Phạm Văn Hiếu',N'50 đường 22 tháng 4, Minh Lão, Bố Trạch, Quảng Bình', '0703587314')
insert into KHACHHANG values ('KH004',N'Nguyễn Thị Yến Phượng',N'62 Đào Duy Từ, Ba Đồn, Quảng Trạch, Quảng Bình', '0704230112')
insert into KHACHHANG values ('KH005',N'Nguyễn Hồng Sơn',N'5 Nguyễn Trường Tộ, Phước Vĩnh, Thành phố Huế, Thừa Thiên Huế', '0366067051')
insert into KHACHHANG values ('KH006',N'Nguyễn Đình Tín',N'334 Quang Trung, Ba Đồn, Quảng Trạch, Quảng Bình' , '0906209570')
insert into KHACHHANG values ('KH007',N'Nguyễn Hồ Anh Thư',N'1 Nguyễn Văn Linh, Hoàn Lão, Bố Trạch, Quảng Bình', '0334259809')
insert into KHACHHANG values ('KH008',N'Ngô Thị Hồng Vân',N'725 Quang Trung, Tân Hà, Lâm Hà, Lâm Đồng','0898908304')
insert into KHACHHANG values ('KH009',N'Trần Văn Vũ',N'19 đường số 1, Điện Quang, Điện Bàn, Quảng Nam','0377991755')
insert into KHACHHANG values ('KH010',N'Hồ Huỳnh Thảo Vy',N'294 Huỳnh Thúc Kháng, An Xuân, Tam Kỳ, Quảng Nam','0394769357')
insert into KHACHHANG values ('KH011',N'Ngô Thị Tú Trinh',N'K79/4 Thanh Thủy, Hải Châu, Đà Nẵng', '0905397177')
insert into KHACHHANG values ('KH012',N'Nguyễn Tiến Dưỡng',N'Tổ dân phố 4, Nam Lý, Đồng Hới, Quảng Bình','0935637523')
insert into KHACHHANG values ('KH013',N'Nguyễn Thanh Thảo',N'Khu vực Vạn Thuận, Nhơn Thành, An Nhơn, Bình Định','0899310465')
insert into KHACHHANG values ('KH014',N'Đỗ Như Quỳnh',N'16 Lý Thánh Tông, Đồng Hới, Quảng Bình', '0765207419')
insert into KHACHHANG values ('KH015',N'Nguyễn Văn Hoàng Nhã',N'412 Cách mạng tháng 8, quận Cẩm Lệ, Đà Nẵng','0965975060')
insert into KHACHHANG values ('KH016',N'Vũ Thị Việt Trinh',N'Tổ 27A, Nại Hiên Đông, Sơn Trà, Đà Nẵng','0934939308')
insert into KHACHHANG values ('KH017',N'Mai Xuân Tỵ',N'67 Trần Văn Dư, Mỹ An, Ngũ Hành Sơn, Đà Nẵng','0905927196')
insert into KHACHHANG values ('KH018',N'Hà Thị Thanh Thảo',N'Kiệt 38 Tôn Thất Sơn, Thủy Phương, Hương Thủy, Thừa Thiên Huế','0967177830')
insert into KHACHHANG values ('KH019',N'Phan Tùng Thanh',N'Huỳnh Hùng, Hòa Phong, Krông Bông, Đăk Lăk','0964564784')
insert into KHACHHANG values ('KH020',N'Lê Trần Tú Vy',N'Đội 1, Phan Xá, Xuân Thủy, Lệ Thủy, Quảng Bình','0976665343')

insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD001','KH001','NV001','2021/08/08')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD002','KH003','NV004','2021/09/07')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD003','KH009','NV005','2021/03/24')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD004','KH010','NV002','2021/10/08')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD005','KH008','NV004','2021/07/12')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD006','KH007','NV005','2021/06/15')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD007','KH019','NV002','2021/12/12')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD008','KH002','NV003','2021/12/15')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD009','KH005','NV001','2021/02/03')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD010','KH020','NV004','2021/07/05')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD011','KH016','NV001','2021/08/04')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD012','KH013','NV004','2021/09/07')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD013','KH015','NV005','2021/03/26')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD014','KH011','NV002','2021/08/10')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD015','KH018','NV004','2021/01/16')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD016','KH004','NV005','2021/12/06')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD017','KH015','NV002','2021/09/17')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD018','KH014','NV003','2021/11/15')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD019','KH016','NV001','2021/10/11')
insert into HOADON (MaHD,MaKH,MaNV,NgayBan) values ('HD020','KH020','NV004','2021/11/11')

insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD001','H0006',2)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD002','H0006',3)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD003','H0010',1)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD003','H0011',1)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD004','H0009',1)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD005','H0008',2)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD006','H0003',3)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD007','H0001',2)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD008','H0004',1)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD009','H0005',2)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD010','H0002',2)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD011','H0017',2)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD012','H0020',3)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD013','H0021',1)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD013','H0025',3)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD015','H0008',2)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD016','H0015',3)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD017','H0011',2)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD018','H0014',1)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD019','H0018',2)
insert into CHITIET_HD (MaCTHD,MaH,SoLuongBan) values ('HD020','H0022',2)

insert into NHACC values ('NCC01',N'Công ty CP Đầu tư TM và DV ô tô Liên Việt','0918340288',N'Lô số 1 CCN Lai Xá, Kim Chung, Hoài Đức, Hà Nội')
insert into NHACC values ('NCC02',N'Công ty TNHH Thương mại và dịch vụ Dương Duy','0903874225',N'212A3 Nguyễn Trãi, Nguyễn Cư Trinh, Quận 1, Hồ Chí Minh')
insert into NHACC values ('NCC03',N'Công ty cổ phần KENT Việt Nam','0948100055',N'Số 779, Tầng 2, Tòa CT3, KĐT Mỹ Đình,Hà Nội')
insert into NHACC values ('NCC04',N'Công Ty TNHH Kính An Toàn Kinh Thành','02743757757',N'18/8 KP. Đông, Vĩnh Phú, Thuận An, Bình Dương')
insert into NHACC values ('NCC05',N'Công Ty TNHH Đắc Yến','0903703124',N'420 Tôn Đức Thắng, Hòa Minh, Liên Chiểu, Đà Nẵng')

insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN001','NV001','NCC03','2020/03/01')
insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN002','NV004','NCC02','2020/09/02')
insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN003','NV005','NCC05','2021/02/01')
insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN004','NV002','NCC03','2019/06/12')
insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN005','NV004','NCC04','2020/02/21')
insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN006','NV003','NCC02','2020/06/18')
insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN007','NV004','NCC01','2018/04/06')
insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN008','NV001','NCC01','2019/05/20')
insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN009','NV002','NCC03','2021/04/09')
insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN010','NV003','NCC02','2020/03/24')
insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN011','NV004','NCC05','2020/06/18')
insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN012','NV005','NCC04','2018/03/03')
insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN013','NV001','NCC04','2019/02/20')
insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN014','NV003','NCC03','2021/05/05')
insert into PHIEUNHAP (MaPNH,MaNV,MaNCC,NgayNhap) values ('PN015','NV002','NCC02','2020/01/24')

insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN001','H0001',5)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN001','H0002',7)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN002','H0003',6)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN002','H0004',8)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN003','H0005',6)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN003','H0006',5)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN004','H0009',7)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN005','H0010',8)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN006','H0010',8)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN007','H0010',8)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN008','H0010',8)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN009','H0011',5)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN010','H0010',8)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN011','H0012',6)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN011','H0008',5)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN012','H0007',7)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN013','H0013',8)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN014','H0021',5)
insert into CHITIET_PN (MaCTPNH,MaH,SoLuongNhap) values ('PN015','H0014',6)

--Update hàng tồn kho
update Hang
set HangTonKho=SoLuongNhap-SoLuongBan
from CHITIET_PN join CHITIET_HD on CHITIET_PN.MaH=CHITIET_HD.MaH

--Update cot thanh tien bang Chi tiet Hoa don
update CHITIET_HD
set ThanhTien = SoLuongBan * DonGiaBan
from CHITIET_HD join HANG on CHITIET_HD.MaH = HANG.MaH
select * from CHITIET_HD

--Update cot thanh tien bang Chi tiet Phieu nhap
update CHITIET_PN 
set ThanhTien = SoLuongNhap * DonGiaNhap
from CHITIET_PN join HANG on CHITIET_PN.MaH = HANG.MaH
select * from CHITIET_PN

-- Update VAT = 10
update PHIEUNHAP
set VAT = 10
--Update cột tổng tiền của bảng phiếu nhập
update PHIEUNHAP 
set TongTien = (select SUM(ThanhTien) from CHITIET_PN where MaCTPNH = PHIEUNHAP.MaPNH)
from PHIEUNHAP join CHITIET_PN on PHIEUNHAP.MaPNH = CHITIET_PN.MaCTPNH
--Update tổng cộng của bảng phiếu nhập
update PHIEUNHAP
set TongCong = (Tongtien * VAT/100) + Tongtien;


-- Update cột Tổng cộng của bảng hóa đơn
update HOADON 
set TongCong = (select SUM(ThanhTien) from CHITIET_HD where MaCTHD = HOADON.MaHD)
from HOADON join CHITIET_HD on HOADON.MaHD = CHITIET_HD.MaCTHD
--
select * from HANG
select * from KHACHHANG
select * from HOADON
select * from LOAIHANG
select * from PHIEUNHAP
select * from CHITIET_PN

--Tao Index--
Create NonClustered Index idx_TenKH on KHACHHANG(TenKH)
Create NonClustered Index idx_MaHD on CHITIET_HD(MaCTHD)

-- Trigger thêm, sửa xóa  bảng chi tiết phiếu nhập
-- Tự động update Hàng tồn kho 
go
create trigger trg_CTPN_HTKIns
on CHITIET_PN
after insert 
as
begin
	update HANG
	set HangTonKho = HangTonKho + (select SoLuongNhap from inserted where MaH = HANG.MaH)
	from HANG join inserted on HANG.MaH = inserted.MaH
end
go

go
create trigger trg_CTPN_HTKDel
on CHITIET_PN
after delete
as 
begin
	update HANG
	set HangTonKho = HangTonKho - (select SoLuongNhap from deleted where MaH = HANG.MaH)
	from HANG join deleted on HANG.MaH = deleted.MaH
end
go

go
create trigger trg_CTPN_HTKUpd
on CHITIET_PN 
after update
as
begin
   update HANG 
   set HangTonKho = HangTonKho + 
					(select SoLuongNhap from inserted where MaH = HANG.MaH) -
					(select SoLuongNhap from deleted where MaH = HANG.MaH)
   from HANG join deleted on HANG.MaH = deleted.MaH
end
go

-- Trigger thêm, sửa xóa  bảng chi tiết hóa đơn
-- Tự động update Hàng tồn kho 
go
create trigger trg_BanHang 
on CHITIET_HD 
after insert 
as 
begin
	update HANG
	set HangTonKho = HangTonKho - (select SoLuongBan from inserted where MaH = HANG.MaH)
	from HANG join inserted on HANG.MaH = inserted.MaH
end
go

go
create trigger trg_HuyBanHang 
on CHITIET_HD 
after delete
as
begin
	update HANG
	set HangTonKho = HangTonKho + (select SoLuongBan from deleted where MaH = HANG.MaH)
	from HANG join deleted  on HANG.MaH = deleted.MaH
end
go

go
Create trigger trg_CapNhatDatHang 
on CHITIET_HD 
after update 
as
begin
   update HANG 
   set HangTonKho = HangTonKho -
					(select SoLuongBan from inserted where MaH = HANG.MaH) +
					(select SoLuongBan from deleted where MaH = HANG.MaH)
   from HANG join deleted on HANG.MaH = deleted.MaH
end


-- Trigger tự động tính tổng cộng của bảng CHITIET_HD 
Create trigger trg_TongcongHoaDon1
on CHITIET_HD 
after update,delete
as
begin
   update HoaDon 
   set Tongcong = (select SUM(ThanhTien) from CHITIET_HD where MaCTHD = deleted.MaCTHD)
   from HOADON join deleted on HOADON.MaHD = deleted.MaCTHD
end

Create trigger trg_TongcongHoaDon2
on CHITIET_HD 
after insert
as
begin
   update HoaDon 
   set Tongcong = (select SUM(ThanhTien) from CHITIET_HD where MaCTHD = inserted.MaCTHD)
   from HOADON join inserted on HOADON.MaHD = inserted.MaCTHD
end


--Trigger tự động tính tổng cộng của bảng CHITIET_PN 
Create trigger trg_TongcongPN1
on CHITIET_PN
after update,delete
as
begin
   update PHIEUNHAP 
   set TongTien = (select SUM(ThanhTien) from CHITIET_PN where MaCTPNH = deleted.MaCTPNH)
   from PHIEUNHAP join deleted on PHIEUNHAP.MaPNH = deleted.MaCTPNH

   update PHIEUNHAP 
   set TongCong = (Tongtien * VAT/100) + Tongtien;
end

Create trigger trg_TongcongPN2
on CHITIET_PN
after insert
as
begin
   update PHIEUNHAP 
   set TongTien = (select SUM(ThanhTien) from CHITIET_PN where MaCTPNH = inserted.MaCTPNH)
   from PHIEUNHAP join inserted on PHIEUNHAP.MaPNH = inserted.MaCTPNH

   update PHIEUNHAP 
   set TongCong = (Tongtien * VAT/100) + Tongtien;
end


-- Trigger kiểm tra số lượng để bán
create trigger ktsoluong 
on CHITIET_HD
for update, insert
as
begin
	declare @a int
	set @a = (select HangTonKho from Hang join inserted on Hang.MaH = inserted.MaH
	where Hang.MaH = inserted.MaH)
	if (@a < 0) 
		begin
			print N'Vượt quá số lượng hàng tồn kho!'
			rollback
		end
end

select * from HOADON
select * from PHIEUNHAP
select * from CHITIET_HD
select * from HANG

--Backup
-- Full Backup --
--Thực hiện full backup vào thời điểm 20:58:00 ngày 25/11/2021
backup database CHPT to disk = 'F:\BACKUP\CHPT_Full.bak' with init 

--Thêm mới 1 bản ghi cho bảng HANG 
insert into HANG values ('H0026',N'Kính gió sau',N'tấm',N'Việt Nam',100,150000,165000,'LH005')

-- Diferential Backup --
--Thực hiện different backup vào thời điểm 8:15:00 ngày 26/11/2021
backup database CHPT to disk = 'F:\BACKUP\CHPT_Diff.bak' with init,  differential

--Tiếp tục thêm mới 1 bản ghi thứ 2 cho bảng HANG 
insert into HANG values ('H0027',N'Gioăng',N'chiếc',N'Việt Nam',100,100000,130000,'LH001')

--Thực hiện transaction log backup vào các 2 thời điểm 10:26:00 và 10:45:00 ngày 26/11/2021
--10:26
backup log CHPT to disk = 'F:\BACKUP\CHPT_Log.trn' with init

--Tiếp tục thêm mới 1 bản ghi thứ 3 cho bảng HANG 
insert into HANG values ('H0028',N'Gương chiếu hậu',N'chiếc',N'Việt Nam',100,100000,120000,'LH002')