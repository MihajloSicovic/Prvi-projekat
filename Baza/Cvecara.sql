create database Cvecara
use Cvecara

/*
drop table cvet
*/

create table cvet
(
	Id int Primary Key Identity(1, 1),
	Naziv nvarchar(100),
	Boja nvarchar (100),
	Cena decimal(18, 2)
)

SELECT * FROM cvet