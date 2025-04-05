Use master

create database TropiKong
--

Use TropiKong
--Posible inserciones manuales, Supervisor seran solo tres Bryan, Eduardo y Matias

--Bryan el supervisor de Empleado ventas, Eduardo el supervisor de recursos humanos y Matias el supervisor de los de Almacenamiento
create table Supervisor
(
id_Supervisor int PRIMARY KEY,
Nombre varchar(300),
Apellido varchar(300),
)
--Posible inserciones C#
--Para identificar que empleado trabaja en ventas, almacenamiento o en recursos humanos, el ID empleado empezara por
-- VN#### este para ventas, AM#### este para almacenamiento, RH##### este para recursos humanos.
create table Empleado
(
id_DB int identity(1,1),
id_Empleado varchar(150) PRIMARY KEY,
Nombre varchar(300),
Apellido varchar(300),
Sucursal varchar(150),
id_Supervisor int

foreign key (id_Supervisor) REFERENCES Supervisor(id_Supervisor)

)
--Posible inserciones manual y en c#
create table Producto
(
id_Produc int Primary Key,
Nombre varchar(340),
precio decimal(10,2),
descripcion varchar(500)
)
--Posible inserciones c#
create table Cliente 
(
id_Cli int IDENTITY(1,1) PRIMARY KEY,
Nombre varchar(300),
Apellido varchar(300)
)

--Posible no inserciones (probablemente si)
create table Venta
(
id_Venta int PRIMARY KEY,
id_Cli int IDENTITY(1,1), 
total int,
fecha date,
descripcion varchar(450) null,
foreign key(id_Cli) references Cliente(id_Cli)
)

--Aqui iran las ventas que tengan bastante vaina de producto
create table Venta_Productos
(
id_VentaIDEN int IDENTITY(1,1)PRIMARY KEY,
id_Venta int,
id_Produc int,
cantidad varchar(150),
foreign key(id_Venta) references Venta(id_Venta),
foreign key(id_Produc) references Producto(id_Produc)
)


drop table Venta_Productos
drop table Venta