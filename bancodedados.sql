create database locadoraclassic;
use locadoraclassic;
create table categoria(
id int primary key auto_increment not null,
nome varchar(60) not null
);
insert into categoria(nome)values('comédia');
 insert into categoria(nome)values('drama');
 select*from genero;

CREATE TABLE Cliente (
  id INT PRIMARY KEY AUTO_INCREMENT,
  nome_do_cliente VARCHAR(100) NOT NULL,
  endereço VARCHAR(200) NOT NULL,
  whatsapp VARCHAR(20) NOT NULL,
  cpf VARCHAR(14) NOT NULL,
  rg VARCHAR(12) NOT NULL
);

 select*from cliente;
delete from genero where id=3