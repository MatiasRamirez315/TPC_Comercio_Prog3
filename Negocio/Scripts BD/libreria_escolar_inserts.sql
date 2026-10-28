USE libreria_escolar;
GO

-- =========================================
-- USUARIOS (5: 1 admin, 4 vendedores)
-- Contraseña de todos: "password" (hash bcrypt)
-- =========================================
INSERT INTO usuarios (usuario, password, rol, activo) VALUES
('admin',        '$2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92ldGxad68LJZdL17lhWy', 'ADMIN',    1),
('juan.perez',   '$2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92ldGxad68LJZdL17lhWy', 'VENDEDOR', 1),
('maria.gomez',  '$2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92ldGxad68LJZdL17lhWy', 'VENDEDOR', 1),
('carlos.lopez', '$2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92ldGxad68LJZdL17lhWy', 'VENDEDOR', 1),
('ana.martinez', '$2a$10$N9qo8uLOickgx2ZMRZoMyeIjZAgcfl7p92ldGxad68LJZdL17lhWy', 'VENDEDOR', 1);
GO

-- =========================================
-- CLIENTES (10)
-- =========================================
INSERT INTO clientes (nombre, cuit, telefono, email, direccion, activo) VALUES
('Escuela Primaria N°12',         '30-71234567-1', '011-4555-1001', 'contacto@ep12.edu.ar',         'Av. Rivadavia 1200, CABA',  1),
('Colegio San José',              '30-70987654-2', '011-4555-1002', 'admin@colegiosanjose.edu.ar',  'Belgrano 456, CABA',        1),
('Librería El Sol',               '30-71456789-3', '011-4555-1003', 'ventas@libreriaelsol.com',     'Corrientes 890, CABA',      1),
('Distribuidora Norte SRL',       '30-71654321-4', '011-4555-1004', 'compras@distnorte.com.ar',     'Mitre 330, Vicente López',  1),
('Escuela Técnica N°5',           '30-71098765-5', '011-4555-1005', 'secretaria@et5.edu.ar',        'San Martín 780, Lanús',     1),
('Jardín de Infantes Arcoíris',   '30-71345678-6', '011-4555-1006', 'info@jardinarcoiris.com',      'Rivadavia 3400, CABA',      1),
('Papelería Central',             '30-71765432-7', '011-4555-1007', 'papeleriacentral@gmail.com',   'Callao 1500, CABA',         1),
('Instituto Belgrano',            '30-71234500-8', '011-4555-1008', 'compras@instbelgrano.edu.ar',  'Av. Cabildo 2100, CABA',    1),
('Librería La Plaza',             '30-71543210-9', '011-4555-1009', 'libreriaplaza@hotmail.com',    'Plaza Italia 45, La Plata', 1),
('Colegio Nacional Buenos Aires', '30-71876543-0', '011-4555-1010', 'admin@cnba.edu.ar',            'Bolívar 263, CABA',         1);
GO

-- =========================================
-- PROVEEDORES (10)
-- =========================================
INSERT INTO proveedores (nombre, descripcion, cuit, telefono, email, activo) VALUES
('Distribuidora Rivadavia', 'Cuadernos y agendas Rivadavia',          '30-61023456-1', '0800-111-0001', 'ventas@rivadavia.com.ar',      1),
('Faber-Castell Argentina', 'Lápices, lapiceras y artística',          '30-61023456-2', '0800-111-0002', 'pedidos@faber-castell.com.ar',  1),
('Bic Argentina',           'Bolígrafos, encendedores y afeitadoras',  '30-61023456-3', '0800-111-0003', 'ventas@bic.com.ar',            1),
('Papelera del Sur',        'Papel, blocks y repuestos',               '30-61023456-4', '0800-111-0004', 'pedidos@papeleradelsur.com',   1),
('Mooving',                 'Mochilas y bolsos escolares',             '30-61023456-5', '0800-111-0005', 'contacto@mooving.com.ar',      1),
('Maped',                   'Geometría, tijeras y accesorios',         '30-61023456-6', '0800-111-0006', 'ventas@maped.com.ar',          1),
('Pelikan',                 'Artística y marcadores',                  '30-61023456-7', '0800-111-0007', 'pedidos@pelikan.com.ar',       1),
('Alba',                    'Carpetas, adhesivos y papelería',         '30-61023456-8', '0800-111-0008', 'ventas@alba.com.ar',           1),
('Simball',                 'Blocks y hojas',                          '30-61023456-9', '0800-111-0009', 'contacto@simball.com.ar',      1),
('Filgo',                   'Cuadernos y productos escolares',         '30-61023456-0', '0800-111-0010', 'ventas@filgo.com.ar',          1);
GO

-- =========================================
-- MARCAS (10)
-- =========================================
INSERT INTO marcas (descripcion, activo) VALUES
('Rivadavia',      1),
('Faber-Castell',  1),
('Bic',            1),
('Maped',          1),
('Pelikan',        1),
('Alba',           1),
('Simball',        1),
('Filgo',          1),
('Mooving',        1),
('Stabilo',        1);
GO

-- =========================================
-- CATEGORIAS (10)
-- =========================================
INSERT INTO categorias (descripcion, activo) VALUES
('Cuadernos',               1),
('Escritura',               1),
('Mochilas y bolsos',       1),
('Papelería',               1),
('Artística',               1),
('Geometría',               1),
('Libros',                  1),
('Agendas',                 1),
('Adhesivos y cintas',      1),
('Carpetas y archivadores', 1);
GO

-- =========================================
-- TIPOS (10)
-- =========================================
INSERT INTO tipos (descripcion, activo) VALUES
('A4',          1),
('A5',          1),
('Oficio',      1),
('Unitario',    1),
('Pack x6',     1),
('Pack x12',    1),
('Tapa dura',   1),
('Tapa blanda', 1),
('Espiral',     1),
('Anillado',    1);
GO

-- =========================================
-- PRODUCTOS (20)
-- =========================================
INSERT INTO productos (codigo, nombre, id_marca, id_categoria, id_tipo, porcentaje_ganancia, precio_compra_ultimo, stock_actual, stock_minimo, activo) VALUES
('LIB-001', 'Cuaderno Rivadavia A4 tapa dura 100 hojas',  1,  1,  1, 30.00,   500.00,  90, 10, 1),
('LIB-002', 'Cuaderno Rivadavia A4 tapa blanda 80 hojas', 1,  1,  1, 30.00,   400.00,  50, 10, 1),
('LIB-003', 'Cuaderno Filgo A4 espiral 84 hojas',         8,  1,  1, 30.00,   450.00,  40, 10, 1),
('LIB-004', 'Lápiz negro Faber-Castell HB',               2,  2,  4, 30.00,    80.00, 100, 20, 1),
('LIB-005', 'Bolígrafo Bic Cristal azul',                 3,  2,  4, 30.00,    60.00, 200, 30, 1),
('LIB-006', 'Set lápices de color Faber-Castell x12',     2,  5,  6, 30.00,  1200.00,  25,  5, 1),
('LIB-007', 'Mochila Mooving azul',                       9,  3,  4, 30.00,  8000.00,  12,  3, 1),
('LIB-008', 'Mochila Mooving con ruedas',                 9,  3,  4, 30.00, 15000.00,   8,  2, 1),
('LIB-009', 'Regla Maped 30cm',                           4,  6,  4, 30.00,   350.00,  25,  5, 1),
('LIB-010', 'Escuadra Maped 45°',                         4,  6,  4, 30.00,   400.00,  30,  5, 1),
('LIB-011', 'Carpeta Alba A4 con elástico',               6, 10,  1, 30.00,   300.00,  50, 10, 1),
('LIB-012', 'Carpeta Alba oficio',                        6, 10,  3, 30.00,   350.00,  40, 10, 1),
('LIB-013', 'Marcadores Pelikan x6',                      5,  5,  5, 30.00,   900.00,  20,  5, 1),
('LIB-014', 'Resaltadores Stabilo x6',                   10,  2,  5, 30.00,  1500.00,  15,  3, 1),
('LIB-015', 'Agenda Rivadavia 2026',                      1,  8,  2, 30.00,  1800.00,  30,  5, 1),
('LIB-016', 'Block de hojas Simball A4',                  7,  4,  1, 30.00,   700.00,  60, 10, 1),
('LIB-017', 'Cinta adhesiva Filgo',                       8,  9,  4, 30.00,   150.00,  80, 15, 1),
('LIB-018', 'Plasticola Alba 250g',                       6,  5,  4, 30.00,   500.00,  40,  8, 1),
('LIB-019', 'Cuaderno Rivadavia A5 espiral',              1,  1,  2, 30.00,   380.00,  45, 10, 1),
('LIB-020', 'Set geometría Maped x5',                     4,  6,  4, 30.00,  2000.00,  18,  4, 1);
GO

-- =========================================
-- IMAGENES (5)
-- =========================================
INSERT INTO imagenes (id_producto, url) VALUES
(1,  'https://placehold.co/400x400?text=Cuaderno+Rivadavia'),
(4,  'https://placehold.co/400x400?text=Lapiz+Faber-Castell'),
(5,  'https://placehold.co/400x400?text=Bic+Cristal'),
(7,  'https://placehold.co/400x400?text=Mochila+Mooving'),
(13, 'https://placehold.co/400x400?text=Marcadores+Pelikan');
GO

-- =========================================
-- PRODUCTO_PROVEEDOR (1 por cada proveedor = 10)
-- =========================================
INSERT INTO producto_proveedor (id_producto, id_proveedor) VALUES
(1,  1),   -- Cuaderno Rivadavia  -> Distribuidora Rivadavia
(4,  2),   -- Lápiz Faber-Castell -> Faber-Castell
(5,  3),   -- Bolígrafo Bic       -> Bic
(16, 4),   -- Block Simball       -> Papelera del Sur
(7,  5),   -- Mochila Mooving     -> Mooving
(9,  6),   -- Regla Maped         -> Maped
(13, 7),   -- Marcadores Pelikan  -> Pelikan
(11, 8),   -- Carpeta Alba        -> Alba
(16, 9),   -- Block Simball       -> Simball
(3, 10);   -- Cuaderno Filgo      -> Filgo
GO

-- =========================================
-- COMPRAS (10) - todas con detalle
-- =========================================
INSERT INTO compras (id_proveedor, id_usuario, fecha, numero_factura, total) VALUES
(1,  1, '2025-08-01 10:30:00', 'A-0001-00000123',  25000.00),
(2,  1, '2025-08-05 09:15:00', 'A-0002-00000456',   8000.00),
(3,  2, '2025-08-10 14:00:00', 'B-0003-00000789',  12000.00),
(5,  1, '2025-08-15 11:20:00', 'A-0005-00000111', 120000.00),
(6,  2, '2025-08-20 16:45:00', 'A-0006-00000222',  10500.00),
(4,  1, '2025-09-01 10:00:00', 'A-0004-00000333',  18000.00),
(7,  3, '2025-09-05 13:30:00', 'B-0007-00000444',  27000.00),
(8,  1, '2025-09-10 09:00:00', 'A-0008-00000555',  15000.00),
(9,  2, '2025-09-15 15:15:00', 'A-0009-00000666',  14000.00),
(10, 1, '2025-09-20 11:00:00', 'A-0010-00000777',  22500.00);
GO

-- =========================================
-- COMPRA_DETALLE (10) - 1 línea por compra
-- =========================================
INSERT INTO compra_detalle (id_compra, id_producto, cantidad, precio_unitario, subtotal) VALUES
(1,   1,  50,   500.00,  25000.00),
(2,   4, 100,    80.00,   8000.00),
(3,   5, 200,    60.00,  12000.00),
(4,   7,  15,  8000.00, 120000.00),
(5,   9,  30,   350.00,  10500.00),
(6,  16,  25,   720.00,  18000.00),
(7,  13,  30,   900.00,  27000.00),
(8,  11,  50,   300.00,  15000.00),
(9,  16,  20,   700.00,  14000.00),
(10,  3,  50,   450.00,  22500.00);
GO

-- =========================================
-- VENTAS (10) - todas con detalle
-- =========================================
INSERT INTO ventas (id_cliente, id_usuario, fecha, estado, total, metodo_pago) VALUES
(1,  2, '2025-09-01 11:00:00', 'CONFIRMADA',   6500.00, 'EFECTIVO'),
(2,  3, '2025-09-03 10:30:00', 'CONFIRMADA',   2080.00, 'TRANSFERENCIA'),
(3,  2, '2025-09-05 15:00:00', 'CONFIRMADA',   3900.00, 'TARJETA'),
(4,  4, '2025-09-08 12:15:00', 'CONFIRMADA',  31200.00, 'TRANSFERENCIA'),
(5,  3, '2025-09-10 09:45:00', 'CONFIRMADA',   2275.00, 'EFECTIVO'),
(6,  2, '2025-09-12 14:20:00', 'CONFIRMADA',   4550.00, 'TARJETA'),
(7,  5, '2025-09-15 10:00:00', 'CONFIRMADA',   1820.00, 'EFECTIVO'),
(8,  2, '2025-09-18 16:30:00', 'CONFIRMADA',   2600.00, 'TRANSFERENCIA'),
(9,  3, '2025-09-20 11:10:00', 'CANCELADA',    1950.00, NULL),
(10, 4, '2025-09-22 13:40:00', 'CONFIRMADA',   3120.00, 'TARJETA');
GO

-- =========================================
-- VENTA_DETALLE (10) - 1 línea por venta
-- precio_unitario = precio_compra_aplicado * 1.30
-- =========================================
INSERT INTO venta_detalle (id_venta, id_producto, cantidad, precio_compra_aplicado, porcentaje_ganancia_aplicado, precio_unitario, subtotal) VALUES
(1,   1, 10,   500.00, 30.00,   650.00,   6500.00),
(2,   4, 20,    80.00, 30.00,   104.00,   2080.00),
(3,   5, 50,    60.00, 30.00,    78.00,   3900.00),
(4,   7,  3,  8000.00, 30.00, 10400.00,  31200.00),
(5,   9,  5,   350.00, 30.00,   455.00,   2275.00),
(6,  16,  5,   700.00, 30.00,   910.00,   4550.00),
(7,   9,  4,   350.00, 30.00,   455.00,   1820.00),
(8,   2,  5,   400.00, 30.00,   520.00,   2600.00),
(9,  14,  1,  1500.00, 30.00,  1950.00,   1950.00),
(10,  6,  2,  1200.00, 30.00,  1560.00,   3120.00);
GO