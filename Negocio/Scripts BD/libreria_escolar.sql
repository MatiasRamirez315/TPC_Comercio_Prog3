CREATE DATABASE libreria_escolar;
GO

USE libreria_escolar;
GO

CREATE TABLE usuarios (
  id_usuario INT IDENTITY(1,1) PRIMARY KEY,
  usuario VARCHAR(50) NOT NULL UNIQUE,
  password VARCHAR(255) NOT NULL,
  rol VARCHAR(20) NOT NULL DEFAULT 'VENDEDOR'
      CHECK (rol IN ('ADMIN','VENDEDOR')),
  activo BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE clientes (
  id_cliente INT IDENTITY(1,1) PRIMARY KEY,
  nombre VARCHAR(150) NOT NULL,
  cuit VARCHAR(20) UNIQUE,
  telefono VARCHAR(50),
  email VARCHAR(150),
  direccion VARCHAR(200),
  activo BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE proveedores (
  id_proveedor INT IDENTITY(1,1) PRIMARY KEY,
  nombre VARCHAR(150) NOT NULL,
  descripcion VARCHAR(300),
  cuit VARCHAR(20) UNIQUE,
  telefono VARCHAR(50),
  email VARCHAR(150),
  activo BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE marcas (
  id_marca INT IDENTITY(1,1) PRIMARY KEY,
  descripcion VARCHAR(100) NOT NULL UNIQUE,
  activo BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE categorias (
  id_categoria INT IDENTITY(1,1) PRIMARY KEY,
  descripcion VARCHAR(100) NOT NULL UNIQUE,
  activo BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE tipos (
  id_tipo INT IDENTITY(1,1) PRIMARY KEY,
  descripcion VARCHAR(100) NOT NULL UNIQUE,
  activo BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE productos (
  id_producto INT IDENTITY(1,1) PRIMARY KEY,
  codigo VARCHAR(30) UNIQUE,
  nombre VARCHAR(150) NOT NULL,
  id_marca INT NOT NULL,
  id_categoria INT NOT NULL,
  id_tipo INT NOT NULL,
  porcentaje_ganancia DECIMAL(5,2) NOT NULL DEFAULT 30.00,
  precio_compra_ultimo DECIMAL(12,2) NOT NULL DEFAULT 0,
  stock_actual INT NOT NULL DEFAULT 0,
  stock_minimo INT NOT NULL DEFAULT 0,
  activo BIT NOT NULL DEFAULT 1,
  FOREIGN KEY (id_marca) REFERENCES marcas(id_marca),
  FOREIGN KEY (id_categoria) REFERENCES categorias(id_categoria),
  FOREIGN KEY (id_tipo) REFERENCES tipos(id_tipo)
);
GO

CREATE TABLE imagenes (
  id_imagen INT IDENTITY(1,1) PRIMARY KEY,
  id_producto INT NOT NULL,
  url VARCHAR(500) NOT NULL,
  FOREIGN KEY (id_producto) REFERENCES productos(id_producto)
);
GO

CREATE TABLE producto_proveedor (
  id_producto INT NOT NULL,
  id_proveedor INT NOT NULL,
  PRIMARY KEY (id_producto, id_proveedor),
  FOREIGN KEY (id_producto) REFERENCES productos(id_producto),
  FOREIGN KEY (id_proveedor) REFERENCES proveedores(id_proveedor)
);
GO

CREATE TABLE compras (
  id_compra INT IDENTITY(1,1) PRIMARY KEY,
  id_proveedor INT NOT NULL,
  id_usuario INT NOT NULL,
  fecha DATETIME NOT NULL DEFAULT GETDATE(),
  numero_factura VARCHAR(50),
  total DECIMAL(14,2) NOT NULL DEFAULT 0,
  FOREIGN KEY (id_proveedor) REFERENCES proveedores(id_proveedor),
  FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario)
);
GO

CREATE TABLE compra_detalle (
  id_compra_detalle INT IDENTITY(1,1) PRIMARY KEY,
  id_compra INT NOT NULL,
  id_producto INT NOT NULL,
  cantidad INT NOT NULL,
  precio_unitario DECIMAL(12,2) NOT NULL,
  subtotal DECIMAL(14,2) NOT NULL,
  FOREIGN KEY (id_compra) REFERENCES compras(id_compra),
  FOREIGN KEY (id_producto) REFERENCES productos(id_producto)
);
GO

CREATE TABLE ventas (
  id_venta INT IDENTITY(1,1) PRIMARY KEY,
  id_cliente INT NOT NULL,
  id_usuario INT NOT NULL,
  fecha DATETIME NOT NULL DEFAULT GETDATE(),
  estado VARCHAR(20) NOT NULL DEFAULT 'CONFIRMADA'
      CHECK (estado IN ('CONFIRMADA','CANCELADA')),
  total DECIMAL(14,2) NOT NULL DEFAULT 0,
  metodo_pago VARCHAR(30) NULL,
  FOREIGN KEY (id_cliente) REFERENCES clientes(id_cliente),
  FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario)
);
GO

CREATE TABLE venta_detalle (
  id_venta_detalle INT IDENTITY(1,1) PRIMARY KEY,
  id_venta INT NOT NULL,
  id_producto INT NOT NULL,
  cantidad INT NOT NULL,
  precio_compra_aplicado DECIMAL(12,2) NOT NULL,
  porcentaje_ganancia_aplicado DECIMAL(5,2) NOT NULL,
  precio_unitario DECIMAL(12,2) NOT NULL,
  subtotal DECIMAL(14,2) NOT NULL,
  FOREIGN KEY (id_venta) REFERENCES ventas(id_venta),
  FOREIGN KEY (id_producto) REFERENCES productos(id_producto)
);
GO