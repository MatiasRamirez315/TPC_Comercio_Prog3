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

create procedure SP_EliminarCliente
  (
    @id_cliente int
  )
  as begin
    delete from clientes where id_cliente = @id_cliente
  end

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

create procedure SP_EliminarProveedor
(
  @id_proveedor int
)
as begin
  delete from proveedores where id_proveedor = @id_proveedor
  end

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
