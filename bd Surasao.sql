create database SurasaoDB

use SurasaoDB

--En la tabla de producto, podemos tener campos coomo 'nombre', 'precio', 'descripcion' y 'id_producto' como llave primaria.
 CREATE TABLE producto (
    id_producto INT PRIMARY KEY,
    nombre VARCHAR(100),
    precio DECIMAL(10, 2),
    descripcion VARCHAR(255)
);
GO 

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
--En la tabla de venta, podemos agregar campos como 'fecha', 'total', 'id_venta' como llave primaria, 'id_cliente' como llave for�nea
--que hace referencia a la tabla de cliente y 'id_producto' como llave for�nea que hace referencia a la tabla de producto
CREATE TABLE venta (
    id_venta INT PRIMARY KEY,
    fecha DATE,
    total DECIMAL(10, 2),
    id_cliente INT,
    id_producto INT,
    FOREIGN KEY (id_cliente) REFERENCES cliente(id_cliente),
    FOREIGN KEY (id_producto) REFERENCES producto(id_producto)
);

GO 


--y por ultimo  en la tabla de cliente, podemos agregar campos como 'nombre', 'apellido', 'direccion', 'email', 'id_cliente' como llave primaria
CREATE TABLE cliente (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    direccion VARCHAR(255),
	telefono varchar(10),
	edad varchar(3),
    email VARCHAR(100)
);


GO

