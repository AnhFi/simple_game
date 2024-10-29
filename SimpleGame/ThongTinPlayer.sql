Create Table
Player(
	STT int,
	MaNguoiChoi varchar(5),
	TenNguoiChoi varchar(20),
	Diem int,
	constraint Player_MNC_PK Primary Key(MaNguoiChoi)
);