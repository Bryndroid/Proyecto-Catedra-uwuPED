Use TropiKong
select * from Venta_Productos
--Manejare las existencias en el programa 
insert into Producto values
(0001, 'Torta de Res', 3.50, 'Producto a base de pan, carne de res y complementos'),
(0002, 'Torta Mixta', 4.50, 'Producto a base de pan, carne de res, pollo, quesos y complementos'),
(0003, 'Torta de Pollo', 3.50, 'Producto a base de pan, pollo y complementos'),
(0004, 'Torta de Jamon', 3.50, 'Producto a base de pan, embutidos y complementos'),
(0011, 'Tacos Clasicos', 3.00, 'Producto a base de maiz, carne de res, complementos y salsa'),
(0012, 'Tacos al pastor', 3.50, 'Producto a base de maiz, carne de trompo, complementos y salsas'),
(0013, 'Tacos de Birria', 4.25, 'Producto a base de maiz, carne adobada, complementos, quesos y salsa'),
(0014, 'Torta de Bistec', 3.50, 'Producto a base de maiz, carne de res, complementos y salsas'),
(0015, 'Torta de Cochinita', 5.75, 'Producto a base de maiz, carne adobada, compelementos, quesos, salsa y vegetales'),
(0111, 'Burritos Clasicos',6.25, 'Producto a base de harina, carne de res,pollo, complementos, quesos y aderezo'),
(0112, 'Burritos Norte�os', 6.25, 'Producto a base de pan, carne de res, complementos, quesos y salsas'),
(1000, 'Agua', 0.75, 'Producto enlatado'),
(1100, 'Bicarbonatada', 1.00, 'Producto enlatado'),
(1200, 'Cerveza', 1.75, 'Producto enlatado'),
(1300, 'CocaCola', 1.00, 'Producto enlatado')

--Para existencias
use TropiKong
select * from existencias
--Solamente dos inserciones, solo ocupo mostrar el funcionamiento del Heap (ABB)
insert into existencias values(1,2,'Facil', 'TomateHolandes', 1.20, 45,'2024-06-12'),
(2,2,'Mediano', 'PanBimbo', 2.20, 150,'2024-11-02'),
