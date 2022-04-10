create database Tome;
go
use Tome;
go
create table [Collection]
(
	Id int primary key identity(1,1) not null,
	Title nvarchar(50) not null
)

create table MerchType
(
	Id int primary key identity(1,1) not null,
	Title nvarchar(50) not null 
)

create table Size
(
	Id int primary key identity(1,1) not null,
	Title nvarchar(10) not null
)

create table Product
(
	Id int primary key identity(1,1) not null,
	Title nvarchar(100) not null,
	Photo nvarchar(1000),
	MerchTypeId int not null references MerchType(Id) on delete cascade,
	Description nvarchar(250),
	Price money not null

)

create table ProductCollection
(
	ProductID int not null references Product(Id) on delete cascade,
	CollectionID int not null references Collection(Id) on delete cascade,
)

create table ProductSize
(
	ProductID int not null references Product(Id) on delete cascade,
	SizeID int not null references Size(Id) on delete cascade,
	QuantityInStock int not null
)


insert into [dbo].[Collection] values ('Новинка'), ('Скидки'), ('Спорт'), ('Музыка')

insert into MerchType values ('Футболка'), ('Худи'), ('Свитшот'), ('Бейсболка')

insert into Size values ('XS'), ('S'), ('M'), ('L'), ('XL'), ('XXL'), ('XXXL'), ('XXXXL')

insert into Product(Title, MerchTypeId, Price, Photo) values 
--Футболки
('456', '1', '2400', '\products\456.jpg'), ('Pilot', '1', '1260', '\products\Pilot.jpg'), ('ZagGas', '1', '3200', ''), ('Piplo', '1', '2690', ''),
--Худи
('546', '2', '2900', ''), ('111', '2', '1990', ''), ('CrabGames', '2', '2080', '\products\crabgames2.jpg'), ('Piblo', '2', '3070', ''),
--Свитшоты
('Tipci', '3', '2300', '\products\tipci.jpg'), ('Planet', '3', '2354', ''), ('SerGa', '3', '2690', ''), ('Argent', '3', '3890', ''),
--Бейсболки
('Modninki', '4', '1200', ''), ('Killa', '4', '980', ''), ('Gvozd', '4', '1760', ''), ('RePack', '4', '2040', '')

insert into ProductCollection values ('1', '2'), ('1', '1'), ('2', '3'), ('2', '1'), ('3', '1'), ('3', '4'), ('5', '1'), ('5', '2'), ('6', '1'), ('6', '4'),
('7', '2'), ('7', '2'), ('8', '1'), ('8', '3'), ('8', '2'), ('9', '1'), ('9', '2'), ('10', '2'), ('10', '3'), ('11', '4'), ('11', '2'),
('12', '3'), ('12', '2'), ('13', '1'), ('13', '4'), ('14', '4'), ('14', '2'), ('15', '1'), ('15', '2'), ('16', '2'), ('16', '4'), ('16', '1')

insert into ProductSize values ('1', '2', '10'), ('1', '3', '12'), ('5', '2', '10'), ('9', '5', '10'), ('13', '2', '156')
