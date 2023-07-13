create database reparaciones
use reparaciones


create table usuarios(
cedula int primary key,
nombre nvarchar(20) not null,
apellido nvarchar(20) not null,
telefono nvarchar(20) not null,
modelo nvarchar(20) not null,
marca nvarchar(20) not null,
estado nvarchar(20) not null,
comentarios nvarchar(20) not null,
fechai date
)


insert into usuarios values('1036657519','wilson','estrada','3053564685','poco x3','xiaomi','malo','camara mala','2022-08-23')

CREATE TABLE repuestos(
referencia nvarchar(20) not null,
nombre nvarchar(20) not null,
cantidad int not null,
disponible nvarchar(2) not null,
fechai date
)

insert into repuestos values('2030','display',2,'si','2022-08-23')

select * from repuestos