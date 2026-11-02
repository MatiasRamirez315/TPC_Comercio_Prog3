create procedure SP_AltaCliente
(
  @nombre varchar (100),
  @cuit varchar (20),
  @telefono varchar (20),
  @email varchar (100),
  @direccion varchar (200)
)
as
begin 
  insert into clientes (nombre, cuit, telefono, email, direccion, activo)
  values (@nombre, @cuit, @telefono, @email, @direccion, 1)
end

GO

create procedure SP_ModificarCliente
(
  @id_cliente int,
  @nombre varchar (100),
  @cuit varchar (20),
  @telefono varchar (20),
  @email varchar (100),
  @direccion varchar (200),
  @activo bit
)
as begin
update clientes
set nombre = @nombre,
    cuit = @cuit,
    telefono = @telefono,
    email = @email,
    direccion = @direccion,
    activo = @activo
    where id_cliente = @id_cliente
end

GO 

CREATE PROCEDURE SP_EliminarCliente
(
    @id_cliente INT
)
AS
BEGIN
    UPDATE clientes SET activo = 0 WHERE id_cliente = @id_cliente
END
GO

  create procedure SP_AltaProveedor
  (
    @nombre VARCHAR(150),
    @descripcion VARCHAR(300),
    @cuit VARCHAR(20),
    @telefono VARCHAR(50),
    @email VARCHAR(150),
    @activo bit
  )
  as BEGIN
  insert into proveedores (nombre,descripcion,cuit,telefono,email,activo)
  values (@nombre,@descripcion,@cuit,@telefono,@email,1)
END

GO

create procedure SP_ModificarProveedor
(
  @id_proveedor int,
  @nombre varchar (150),
  @descripcion varchar (300),
  @cuit varchar (20),
  @telefono varchar (50),
  @email varchar (150),
  @activo bit
)
as begin
update proveedores
  
set nombre = @nombre,
    descripcion = @descripcion,
    cuit = @cuit,
    telefono = @telefono,
    email = @email,
    activo = @activo
    where id_proveedor = @id_proveedor
  end

GO

CREATE PROCEDURE SP_EliminarProveedor
(
    @id_proveedor INT
)
AS
BEGIN
    UPDATE proveedores SET activo = 0 WHERE id_proveedor = @id_proveedor
END

GO

create procedure SP_AltaProducto
  (
    @codigo VARCHAR(20),
    @nombre VARCHAR(150),
    @id_marca INT,
    @id_categoria INT,
    @id_tipo INT,
    @porcentaje_ganancia DECIMAL(5,2),
    @precio_compra_ultimo DECIMAL(10,2),
    @stock_actual INT,
    @stock_minimo INT,
    @activo BIT
  )
  as Begin
  insert into productos (codigo,nombre,id_marca,id_categoria,id_tipo,porcentaje_ganancia,precio_compra_ultimo,stock_actual,stock_minimo,activo)
  values(@codigo,@nombre,@id_marca,@id_categoria,@id_tipo,@porcentaje_ganancia,@precio_compra_ultimo,@stock_actual,@stock_minimo,1)
  End

GO

create procedure SP_ModificarProducto(
  @id_producto int,
  @codigo varchar (20),
  @nombre varchar (150),
  @id_marca int,
  @id_categoria int,
  @id_tipo int,
  @porcentaje_ganancia decimal(5,2),
  @precio_compra_ultimo decimal(10,2),
  @stock_actual int,
  @stock_minimo int,
  @activo bit
)
as begin
 update productos
 set codigo = @codigo,
     nombre = @nombre,
     id_marca = @id_marca,
     id_categoria = @id_categoria,
     id_tipo = @id_tipo,
     porcentaje_ganancia = @porcentaje_ganancia,
     precio_compra_ultimo = @precio_compra_ultimo,
     stock_actual = @stock_actual,
     stock_minimo = @stock_minimo,
     activo = @activo
     where id_producto = @id_producto
   end
GO

CREATE PROCEDURE SP_ListarClientes
AS
BEGIN
    SELECT id_cliente, nombre, cuit, telefono, email, direccion, activo
    FROM clientes
    ORDER BY nombre
END
GO

CREATE PROCEDURE SP_ListarProveedores
AS
BEGIN
    SELECT id_proveedor, nombre, descripcion, cuit, telefono, email, activo
    FROM proveedores
    ORDER BY nombre
END
GO

CREATE PROCEDURE SP_ListarMarcas
AS
BEGIN
    SELECT id_marca, descripcion, activo
    FROM marcas
    ORDER BY descripcion
END
GO

CREATE PROCEDURE SP_ListarCategorias
AS
BEGIN
    SELECT id_categoria, descripcion, activo
    FROM categorias
    ORDER BY descripcion
END
GO

CREATE PROCEDURE SP_ListarTipos
AS
BEGIN
    SELECT id_tipo, descripcion, activo
    FROM tipos
    ORDER BY descripcion
END
GO

CREATE PROCEDURE SP_ListarUsuarios
AS
BEGIN
    SELECT id_usuario, usuario, rol, activo
    FROM usuarios
    ORDER BY usuario
END
GO

CREATE PROCEDURE SP_ListarProductos
AS
BEGIN
    SELECT
        p.id_producto,
        p.codigo,
        p.nombre,
        p.id_marca,
        m.descripcion  AS marca,
        p.id_categoria,
        c.descripcion  AS categoria,
        p.id_tipo,
        t.descripcion  AS tipo,
        p.porcentaje_ganancia,
        p.precio_compra_ultimo,
        p.stock_actual,
        p.stock_minimo,
        p.activo
    FROM productos p
    INNER JOIN marcas     m ON m.id_marca     = p.id_marca
    INNER JOIN categorias c ON c.id_categoria = p.id_categoria
    INNER JOIN tipos      t ON t.id_tipo      = p.id_tipo
    ORDER BY p.nombre
END
GO

CREATE PROCEDURE SP_ListarVentas
AS
BEGIN
    SELECT
        v.id_venta,
        v.fecha,
        v.id_cliente,
        cl.nombre       AS cliente,
        v.id_usuario,
        u.usuario       AS vendedor,
        v.estado,
        v.total,
        v.metodo_pago
    FROM ventas v
    INNER JOIN clientes cl ON cl.id_cliente = v.id_cliente
    INNER JOIN usuarios u  ON u.id_usuario  = v.id_usuario
    ORDER BY v.fecha DESC
END
GO

CREATE PROCEDURE SP_ListarCompras
AS
BEGIN
    SELECT
        c.id_compra,
        c.fecha,
        c.id_proveedor,
        p.nombre        AS proveedor,
        c.id_usuario,
        u.usuario       AS usuario,
        c.numero_factura,
        c.total
    FROM compras c
    INNER JOIN proveedores p ON p.id_proveedor = c.id_proveedor
    INNER JOIN usuarios u    ON u.id_usuario   = c.id_usuario
    ORDER BY c.fecha DESC
END
GO

CREATE PROCEDURE SP_ObtenerCliente
(
    @id_cliente INT
)
AS
BEGIN
    SELECT id_cliente, nombre, cuit, telefono, email, direccion, activo
    FROM clientes
    WHERE id_cliente = @id_cliente
END
GO