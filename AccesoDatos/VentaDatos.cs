using System;
using System.Collections.Generic;
using Dominio;

namespace AccesoDatos
{
    public class VentaDatos
    {
        public List<Venta> listar()
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarVentas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.IDVenta = (int)datos.Lector["id_venta"];
                    aux.Fecha = (DateTime)datos.Lector["fecha"];
                    aux.IDCliente = (int)datos.Lector["id_cliente"];
                    aux.ClienteNombre = datos.Lector["cliente"].ToString();
                    aux.IDUsuario = (int)datos.Lector["id_usuario"];
                    aux.VendedorNombre = datos.Lector["vendedor"].ToString();
                    aux.Estado = datos.Lector["estado"].ToString();
                    aux.Total = (decimal)datos.Lector["total"];
                    aux.MetodoPago = datos.Lector["metodo_pago"] == DBNull.Value ? "" : datos.Lector["metodo_pago"].ToString();
                    lista.Add(aux);
                }
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        public Venta obtener(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ObtenerVenta");
                datos.setearParametro("@id_venta", idVenta);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.IDVenta = (int)datos.Lector["id_venta"];
                    aux.Fecha = (DateTime)datos.Lector["fecha"];
                    aux.IDCliente = (int)datos.Lector["id_cliente"];
                    aux.ClienteNombre = datos.Lector["cliente"].ToString();
                    aux.IDUsuario = (int)datos.Lector["id_usuario"];
                    aux.VendedorNombre = datos.Lector["vendedor"].ToString();
                    aux.Estado = datos.Lector["estado"].ToString();
                    aux.Total = (decimal)datos.Lector["total"];
                    aux.MetodoPago = datos.Lector["metodo_pago"] == DBNull.Value ? "" : datos.Lector["metodo_pago"].ToString();
                    return aux;
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<VentaDetalle> listarDetalle(int idVenta)
        {
            List<VentaDetalle> lista = new List<VentaDetalle>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarVentaDetalle");
                datos.setearParametro("@id_venta", idVenta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    VentaDetalle aux = new VentaDetalle();
                    aux.IDVentaDetalle = (int)datos.Lector["id_venta_detalle"];
                    aux.IDVenta = idVenta;
                    aux.IDProducto = (int)datos.Lector["id_producto"];
                    aux.CodigoProducto = datos.Lector["codigo"].ToString();
                    aux.NombreProducto = datos.Lector["producto"].ToString();
                    aux.Cantidad = (int)datos.Lector["cantidad"];
                    aux.PrecioCompraAplicado = (decimal)datos.Lector["precio_compra_aplicado"];
                    aux.PorcentajeGananciaAplicado = (decimal)datos.Lector["porcentaje_ganancia_aplicado"];
                    aux.PrecioUnitario = (decimal)datos.Lector["precio_unitario"];
                    aux.Subtotal = (decimal)datos.Lector["subtotal"];
                    lista.Add(aux);
                }
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        public int alta(Venta venta, List<VentaDetalle> detalles)
        {
            AccesoDatos datos = new AccesoDatos();
            int idVenta = 0;

            try
            {
                datos.iniciarTransaccion();

                datos.setearProcedimiento("SP_AltaVenta");
                datos.setearParametro("@id_cliente", venta.IDCliente);
                datos.setearParametro("@id_usuario", venta.IDUsuario);
                datos.setearParametro("@metodo_pago", venta.MetodoPago);
                datos.setearParametro("@total", venta.Total);
                idVenta = datos.ejecutarAccionScalarTransaccion();

                foreach (VentaDetalle linea in detalles)
                {
                    datos.setearProcedimiento("SP_AltaVentaDetalle");
                    datos.setearParametro("@id_venta", idVenta);
                    datos.setearParametro("@id_producto", linea.IDProducto);
                    datos.setearParametro("@cantidad", linea.Cantidad);
                    datos.setearParametro("@precio_compra_aplicado", linea.PrecioCompraAplicado);
                    datos.setearParametro("@porcentaje_ganancia_aplicado", linea.PorcentajeGananciaAplicado);
                    datos.setearParametro("@precio_unitario", linea.PrecioUnitario);
                    datos.setearParametro("@subtotal", linea.Subtotal);
                    datos.ejecutarAccionTransaccion();

                    datos.setearProcedimiento("SP_DescontarStockVenta");
                    datos.setearParametro("@id_producto", linea.IDProducto);
                    datos.setearParametro("@cantidad", linea.Cantidad);
                    datos.ejecutarAccionTransaccion();
                }

                datos.confirmarTransaccion();
                return idVenta;
            }
            catch
            {
                datos.cancelarTransaccion();
                throw;
            }
        }

        public void cancelar(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_CancelarVenta");
                datos.setearParametro("@id_venta", idVenta);
                datos.EjecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}