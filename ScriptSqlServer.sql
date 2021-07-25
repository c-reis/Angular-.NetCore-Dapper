create database dbentrevista;
go

use dbentrevista;

create table pessoa(
	idpessoa int primary key identity,
	nomecompleto varchar(60),
	idade smallint not null,
	cpf varchar(11) not null,
	rua_endereco varchar(60) not null,
	num_endereco int not null,
	bairro_endereco varchar(50) not null,
	cidade varchar(50) not null
);
go

insert into pessoa(nomecompleto, idade, cpf, rua_endereco, num_endereco, bairro_endereco, cidade) values('Vinicius',24,'12345678912','Rua Pedro',285,'Vila Carrão','São Paulo');
insert into pessoa(nomecompleto, idade, cpf, rua_endereco, num_endereco, bairro_endereco, cidade) values('Maria',35,'98765432198','Av. Limão',1145,'Barra Funda','Campinas');
insert into pessoa(nomecompleto, idade, cpf, rua_endereco, num_endereco, bairro_endereco, cidade) values('Pedro',27,'21348521344','Rua Barão',418,'Primavera','Ituverava');
insert into pessoa(nomecompleto, idade, cpf, rua_endereco, num_endereco, bairro_endereco, cidade) values('Camila',42,'12345752133','Av. Faria Lima',725,'Vitoria','Catanduva');
insert into pessoa(nomecompleto, idade, cpf, rua_endereco, num_endereco, bairro_endereco, cidade) values('João',58,'42135647522','Rua Celso Garcia',642,'Lapa','Osasco');

go

select * from pessoa;
