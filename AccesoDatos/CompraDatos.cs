using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace AccesoDatos
{
    public class CompraDatos
    {
        public List<Compra> Listar()
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_ListarCompras");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Compra aux = new Compra();
                    aux.IDCompra = (int)datos.Lector["id_compra"];
                    aux.Fecha = (DateTime)datos.Lector["fecha"];
                    aux.NumeroFactura = datos.Lector["numero_factura"].ToString();
                    

                    aux.IDProveedor = new Proveedor();
                    aux.IDProveedor.IDProveedor = (int)datos.Lector["id_proveedor"];
                    //aux.IDProveedor.Nombre= datos.Lector["proveedor"].ToString();
                    aux.NombreProveedor = datos.Lector["proveedor"].ToString();

                    aux.IDUsuario = new Usuario();
                    aux.IDUsuario.IDUsuario = (int)datos.Lector["id_usuario"];
                    aux.IDUsuario.NombreUsuario = datos.Lector["usuario"].ToString();

                    aux.Estado = (EstadoCompra)(int)datos.Lector["estado"];
                    aux.Total = (decimal)datos.Lector["total"];
                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;
        }

        public void Cancelar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_CancelarCompra");
                datos.setearParametro("@id_compra", id);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int AgregarCompra (Compra compra)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AgregarCompra");
                datos.setearParametro("@id_proveedor", compra.IDProveedor.IDProveedor);
                datos.setearParametro("@id_usuario", compra.IDUsuario.IDUsuario);
                datos.setearParametro("@numero_factura", compra.NumeroFactura);
                datos.setearParametro("@total", compra.Total);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return Convert.ToInt32(datos.Lector["id_compra"]);
                }

                return 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AgregarDetalleCompra (CompraDetalle detalle)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AgregarDetalleCompra");
                datos.setearParametro("@id_compra", detalle.IDCompra);
                datos.setearParametro("@id_producto", detalle.IDProducto);
                datos.setearParametro("@cantidad", detalle.Cantidad);
                datos.setearParametro("@precio_unitario", detalle.PrecioCompra);
                datos.setearParametro("@subtotal", detalle.Subtotal);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Compra ObtenerCompra(int id)
        {
            Compra compra = new Compra();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ObtenerCompra");
                datos.setearParametro("@id_compra", id);
                datos.ejecutarLectura();

                if(datos.Lector.Read())
                {
                    compra.IDCompra = (int)datos.Lector["id_compra"];
                    compra.IDProveedor = new Proveedor();
                    compra.IDProveedor.IDProveedor = (int)datos.Lector["id_proveedor"];
                    compra.NombreProveedor = datos.Lector["nombre_proveedor"].ToString();
                    compra.Fecha = (DateTime)datos.Lector["fecha"];
                    compra.IDProveedor.Cuit = datos.Lector["cuit"].ToString();
                    compra.NumeroFactura = datos.Lector["numero_factura"].ToString();
                    compra.Total = (decimal)datos.Lector["total"];
                    compra.Estado = (EstadoCompra)datos.Lector["estado"];

                    return compra;
                }

                return null;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<CompraDetalle> ListarDetalles(int id)
        {
            List<CompraDetalle> lista = new List<CompraDetalle>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarDetalleCompra");
                datos.setearParametro("@id_compra", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    CompraDetalle aux = new CompraDetalle();
                    aux.IDCompraDetalle = (int)datos.Lector["id_compra_detalle"];
                    aux.IDCompra = (int)datos.Lector["id_compra"];
                    aux.NombreProducto = datos.Lector["nombre_producto"].ToString();
                    aux.IDProducto = (int)datos.Lector["id_producto"];
                    aux.CodigoProducto = datos.Lector["codigo"].ToString();
                    aux.Cantidad = (int)datos.Lector["cantidad"];
                    aux.PrecioCompra = (decimal)datos.Lector["precio_compra_ultimo"];
                    aux.Subtotal = (decimal)datos.Lector["subtotal"];
                    lista.Add(aux);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();

            }
            return lista;
        }
    }
}
