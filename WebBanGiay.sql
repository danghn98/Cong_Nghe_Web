USE [master]
GO
/****** Object:  Database [WebBanGiay]    Script Date: 21/03/2019 9:16:13 AM ******/
CREATE DATABASE [WebBanGiay]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WebBanGiay', FILENAME = N'D:\Năm 3 kì 2\Thực tập nhóm\SQL\WebBanGiay.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WebBanGiay_log', FILENAME = N'D:\Năm 3 kì 2\Thực tập nhóm\SQL\WebBanGiay_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

use [WebBanGiay]
GO

CREATE TABLE NhaCungCap(
	Manhacc int identity primary key,
	Tennhacc nvarchar(50),
	Diachi nvarchar(50),
	Sdt varchar(20),
	Website nvarchar(50)
)

CREATE TABLE NhaSanXuat(
	Manhasx int identity primary key,
	Tennhasx nvarchar(50),
	Diachi nvarchar(50),
	Sdt varchar(20) ,
	Website nvarchar(50)
)

CREATE TABLE LoaiGiay(
	Maloaigiay int identity primary key,
	Tenloaigiay nvarchar(50),
)

CREATE TABLE DonHang(
	Madh int identity primary key,
	Tendh nvarchar(50),
	Tenkh nvarchar(50),
	Email varchar(50),
	Sdt varchar(20),
	Diachi nvarchar(500),
	Ngaydat datetime,
	Ngaygiao datetime,
	Tinhtranggh nvarchar(50),
	Dathanhtoan int,
)

CREATE TABLE Giay(
	Magiay int identity primary key,
	Manhacc int references NhaCungCap(Manhacc),
	Manhasx int references NhaSanXuat(Manhasx),
	Maloaigiay int references LoaiGiay(MaLoaigiay),
	Tengiay nvarchar(50),
	Soluongton int,
	Giaban decimal(18,0),
	Hinhanh nvarchar(50),
	Mota nvarchar(4000),
)

CREATE TABLE ChiTietDonHang(
	Madh int references DonHang(Madh),
	Magiay int references Giay(Magiay),
	SoLuong int,
	Dongia decimal(18,0),
	primary key(Madh,Magiay),	
)

create table Size(
	Masize int identity primary key,
	Sosize int,
)

create table Mau(
	Mamau int identity primary key,
	Tenmau nvarchar(50)
)

CREATE TABLE ChiTietSize(
	Masize int references Size(Masize),
	Magiay int references Giay(Magiay),
	Ghichu nvarchar(50),
	primary key (Masize, Magiay),
)

CREATE TABLE ChiTietMau(
	Mamau int references Mau(Mamau),
	Magiay int references Giay(Magiay),
	Ghichu nvarchar(50),
	primary key (Mamau, Magiay),
)

create table TaiKhoan(
	Matk int identity primary key,
	Tentk varchar(50),
	Matkhau varchar(50),
)

insert into TaiKhoan values('dang98', 'dang')


-- insert LoaiGiay
insert into LoaiGiay values(N'Nam')
insert into LoaiGiay values(N'Nữ')
insert into LoaiGiay values(N'Trẻ em')

-- insert NhaSanXuat
insert into NhaSanXuat values('Nike', 'Los Angerles', '0987654321', 'nike.com')
insert into NhaSanXuat values('Adidas', 'Paris', '0987654321', 'adidas.com')
insert into NhaSanXuat values('Convert', 'Moscow', '0987654321', 'convert.com')
insert into NhaSanXuat values('Bitis', N'Việt Nam', '0987654321', 'bitis.com.vn')
insert into NhaSanXuat values(N'Không', N'Việt Nam', null, null)

-- insert NhaCungCap
insert into NhaCungCap values(N'Chợ Đen', N'Hà Nội, Việt Nam', '0943578234', null)
insert into NhaCungCap values(N'Công ty TNHH Bitis VN', N'Hà Nội, Việt Nam', '0943578234', 'bitis.com.vn')
insert into NhaCungCap values(N'Công ty TNHH Adidas VN', N'Hà Nội, Việt Nam', '0943514234', 'adidas.com.vn')
insert into NhaCungCap values(N'Công ty TNHH Nike VN', N'Hà Nội, Việt Nam', '0943128234', 'nike.com.vn')
insert into NhaCungCap values(N'Công ty TNHH Convert VN', N'Hà Nội, Việt Nam', '0943579834', 'nike.com.vn')

--insert Giay
insert into Giay values(1, 2, 1, N'Giày  Adidas Ultra Boost ST S80616 1', 20, 500000, N'giay_1.png', null)
insert into Giay values(1, 5, 2, N'Adidas 2', 12, 600000, N'giay_2.jpg', null)
insert into Giay values(1, 5, 1, N'Adidas 3', 7, 700000, N'giay_3.jpg', null)
insert into Giay values(1, 5, 3, N'Adidas 4', 18, 800000, N'giay_4.jpg', null)
insert into Giay values(1, 5, 1, N'Adidas 5', 20, 750000, N'giay_5.jpg', null)
insert into Giay values(2, 4, 1, N'Bitis 1', 12, 625000, N'giay_6.jpg', null)
insert into Giay values(2, 4, 1, N'Bitis 2', 24, 400000, N'giay_7.jpg', null)
insert into Giay values(2, 4, 2, N'Bitis 3', 12, 550000, N'giay_8.jpg', null)
insert into Giay values(2, 4, 3, N'Bitis 4', 16, 900000, N'giay_9.jpg', null)
insert into Giay values(2, 4, 2, N'Bitis 5', 6, 2000000, N'giay_10.jpg', null)
insert into Giay values(4, 1, 1, N'Nike 1', 12, 1150000, N'giay_11.jpg', null)
insert into Giay values(4, 1, 1, N'Nike 2', 12, 2500000, N'giay_12.jpg', null)
insert into Giay values(4, 1, 1, N'Nike 3', 13, 1490000, N'giay_13.jpg', null)
insert into Giay values(4, 1, 2, N'Nike 4', 11, 999000, N'giay_14.jpg', null)
insert into Giay values(4, 1, 3, N'Nike 5', 17, 890000, N'giay_15.jpg', null)

-- insert Mau
insert into Mau values(N'Xanh')
insert into Mau values(N'Đỏ')
insert into Mau values(N'Tím')
insert into Mau values(N'Vàng')
insert into Mau values(N'Nâu')
insert into Mau values(N'Đen')
insert into Mau values(N'Trắng')

-- insert Size
insert into Size values(14)
insert into Size values(15)
insert into Size values(16)
insert into Size values(34)
insert into Size values(35)
insert into Size values(36)
insert into Size values(37)
insert into Size values(38)
insert into Size values(39)
insert into Size values(40)
insert into Size values(41)
insert into Size values(42)
insert into Size values(43)
insert into Size values(44)

-- insert ChiTietMau
insert into ChiTietMau values (1,1,null)
insert into ChiTietMau values (1,2,null)
insert into ChiTietMau values (1,3,null)
insert into ChiTietMau values (1,4,null)
insert into ChiTietMau values (2,1,null)
insert into ChiTietMau values (1,9,null)
insert into ChiTietMau values (2,8,null)
insert into ChiTietMau values (2,4,null)
insert into ChiTietMau values (3,1,null)
insert into ChiTietMau values (4,7,null)
insert into ChiTietMau values (6,1,null)
insert into ChiTietMau values (3,10,null)
insert into ChiTietMau values (7,12,null)
insert into ChiTietMau values (1,6,null)
insert into ChiTietMau values (4,1,null)

-- insert ChiTietSize
insert into ChiTietSize values (1, 1,null)
insert into ChiTietSize values (1, 2,null)
insert into ChiTietSize values (2, 1,null)
insert into ChiTietSize values (3, 3,null)
insert into ChiTietSize values (4, 4,null)
insert into ChiTietSize values (14, 5,null)
insert into ChiTietSize values (6, 6,null)
insert into ChiTietSize values (1, 8,null)
insert into ChiTietSize values (8, 9,null)
insert into ChiTietSize values (6, 10,null)
insert into ChiTietSize values (12, 11,null)
insert into ChiTietSize values (3, 15,null)
insert into ChiTietSize values (1, 7,null)
insert into ChiTietSize values (9, 2,null)
insert into ChiTietSize values (10, 7,null)
