create database PTTKHDT

use PTTKHDT

create table PhanQuyen
(
	ID int IDENTITY(1,1) PRIMARY KEY,
	TenPhanQuyen nvarchar(50),
)

create table TaiKhoan
(
	IDTaiKhoan int IDENTITY(1,1) PRIMARY KEY,
	TenTaiKhoan nvarchar(50) NOT NULL,
	MatKhau nvarchar(50) NOT NULL,
	Email nvarchar(50) NOT NULL,
	SDT int,
	NgaySinh date,
	GioiTinh bit,
	Visible bit,
	ID int, 
	FOREIGN KEY (ID) REFERENCES PhanQuyen(ID), 
)


create table KhachHang
(
	IDKhachHang int IDENTITY(1,1) PRIMARY KEY,
	TenKhachHang nvarchar(100),
	SDT int,
	Email nvarchar(50),
	NgaySinh date,
	SoTienDaMua int,
	CapBac nvarchar(50),
	GioiTinh bit,
)

create table HoaDon
(
	IDHoaDon int IDENTITY(1,1) PRIMARY KEY,
	NgayInHoaDon date,
	GioInHoaDon time,
	TongTien int,
	IDTaiKhoan int,
	IDKhachHang int,
	FOREIGN KEY (IDTaiKhoan) REFERENCES TaiKhoan(IDTaiKhoan),
	FOREIGN KEY (IDKhachHang) REFERENCES KhachHang(IDKhachHang),
)


create table Sach
(
	IDSach int IDENTITY(1,1) PRIMARY KEY,
	TenSach nvarchar(50) NOT NULL,
	NXB nvarchar(50) NOT NULL,
	TenTacGia nvarchar(50) NOT NULL,
	Gia float(2),
	SoLuong int NOT NULL,
)

create table ChiTietHoaDon
(
	IDChiTietHoaDon int IDENTITY(1,1) PRIMARY KEY,
	SoLuong int,
	IDHoaDon int,
	IDSach int,
	FOREIGN KEY (IDHoaDon) REFERENCES HoaDon(IDHoaDon),
	FOREIGN KEY (IDSach) REFERENCES Sach(IDSach),
)

create table LuuID
(
	IDChiTietHoaDon int IDENTITY(1,1) PRIMARY KEY,
	IDStaff int,
)
insert into LuuID values(1)
insert into Sach values(N'123ã123456','cx@com',N'lakjnv',12000,15)
--Dữ liệu bảng Phân Quyền
insert into PhanQuyen values(N'Quản Lý')
insert into PhanQuyen values(N'Nhân Viên')
select * from KhachHang
--Dữ liệu bảng Tài Khoản
insert into TaiKhoan(TenTaiKhoan,MatKhau,Email,ID) values(N'TuanUra','123456','nat@gmail.com',1)
insert into TaiKhoan(TenTaiKhoan,MatKhau,Email,ID) values(N'Ivantim','123456','ivamtim@gmail.com',2)
insert into TaiKhoan(TenTaiKhoan,MatKhau,Email,ID) values(N'TuBeo','123456','tubeo@gmail.com',2)
update TaiKhoan set SDT=012356 where IDTaiKhoan=4
--Dữ liệu bảng Khách Hàng
insert into KhachHang(TenKhachHang,SDT,Email,SoTienDaMua) values(N'Phi Quân','0123456789','phiquan@gmail.com',150000)
insert into KhachHang(TenKhachHang,SDT,Email,SoTienDaMua) values(N'Sỹ Khá','0123456987','sykha@gmail.com',1000000)

 delete from TaiKhoan where IDTaiKhoan=2
 SELECT IDTaiKhoan FROM TaiKhoan WHERE SDT=1235

 select Top(1) IDHoaDon
 from HoaDon
 order by IDHoaDon DESC

 select ChiTietHoaDon.IDChiTietHoaDon as 'ID', Sach.TenSach as N'Tên Sách', ChiTietHoaDon.SoLuong as N'Số Lượng'
 from ChiTietHoaDon, Sach, HoaDon
 where HoaDon.IDHoaDon = ChiTietHoaDon.IDHoaDon and ChiTietHoaDon.IDSach = Sach.IDSach and ChiTietHoaDon.IDHoaDon = 13

 insert into ChiTietHoaDon(IDSach,IDHoaDon,SoLuong) values(,,1)
 delete from ChiTietHoaDon where IDChiTietHoaDon=2

 update HoaDon set TongTien=123 where IDHoaDon=12
 update HoaDon set TongTien=123, IDKhachHang=1 where IDHoaDon=12
 update KhachHang set TenKhachHang=N'', Email=N'', SDT='' where IDKhachHang=
 select CapBac
 from KhachHang
 where TenKhachHang=N'Sỹ Khá'

 select Sum(TongTien)
 from HoaDon
 where IDKhachHang=1 and TongTien > 0

 update KhachHang set CapBac='' where IDKhachHang=

 update KhachHang set SoTienDaMua=SoTienDaMua + 12 where IDKhachHang=
 update KhachHang set CapBac='Bac' where IDKhachHang=1

 select HoaDon.NgayInHoaDon, Sum(HoaDon.TongTien)
 from HoaDon
 where HoaDon.NgayInHoaDon>='2022-01-01'
 group by HoaDon.NgayInHoaDon

 select *
 from HoaDon