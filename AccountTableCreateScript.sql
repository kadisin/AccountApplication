CREATE TABLE Account
(
	Id int not null identity(1,1) primary key,
	Name nvarchar(255) not null,
	Login nvarchar(255) not null unique,
	Password nvarchar(255) not null
)

INSERT INTO Account
values
('Marcin','Login1','Password1'),
('Dominik','Login2','Password2'),
('Andrzej','Login3','Password3')
