using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Negocio
{
    public class ProductoNegocio 
    {
        public List<Producto> Listar()
        {
            AccesoDatos.ProductoDatos datos = new AccesoDatos.ProductoDatos();
            return datos.Listar();
        }

        public int Agregar(Producto nuevo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AltaProducto");

                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@id_marca", nuevo.Marca.IDMarca);
                datos.setearParametro("@id_categoria", nuevo.Categoria.IDCategoria);
                datos.setearParametro("@id_tipo", nuevo.Tipo.IDTipo);
                datos.setearParametro("@porcentaje_ganancia", nuevo.PorcentajeGanancia);
                datos.setearParametro("@precio_compra_ultimo", nuevo.PrecioCompraUltimo);
                datos.setearParametro("@stock_actual", nuevo.StockActual);
                datos.setearParametro("@stock_minimo", nuevo.StockMinimo);
                

                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally{
                datos.cerrarConexion();
            }
        }

        public Producto ObtenerPorID(int idProductoModificado)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            Producto prod = null;

            try
            {
                datos.setearProcedimiento("SP_BuscarProductoPorID");
                
                datos.setearParametro("@id_producto", idProductoModificado);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    prod = new Producto();
                    prod.IDProducto = (int)datos.Lector["id_producto"];
                    prod.Codigo = (string)datos.Lector["Codigo"];
                    prod.Nombre = (string)datos.Lector["Nombre"];

                    prod.Marca = new Marca();
                    prod.Marca.IDMarca = (int)datos.Lector["id_marca"];

                    prod.Categoria = new Categoria();
                    prod.Categoria.IDCategoria = (int)datos.Lector["id_categoria"];

                    prod.Tipo = new Tipo();
                    prod.Tipo.IDTipo = (int)datos.Lector["id_tipo"];
                   
                    prod.PorcentajeGanancia = (decimal)datos.Lector["porcentaje_ganancia"];
                    prod.PrecioCompraUltimo = (decimal)datos.Lector["precio_compra_ultimo"];

                    prod.StockActual = (int)datos.Lector["stock_actual"];
                    prod.StockMinimo = (int)datos.Lector["stock_minimo"];

                }
                if (prod != null)
                {
                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    prod.Imagenes = imagenNegocio.ListarPorProducto(prod.IDProducto);
                }

                return prod;

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

        public void Modificar(Producto modificar)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ModificarProducto");
                datos.setearParametro("@id_producto",modificar.IDProducto);
                datos.setearParametro("@codigo", modificar.Codigo);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@id_marca", modificar.Marca.IDMarca);
                datos.setearParametro("@id_categoria", modificar.Categoria.IDCategoria);
                datos.setearParametro("@id_tipo", modificar.Tipo.IDTipo);
                datos.setearParametro("@porcentaje_ganancia", modificar.PorcentajeGanancia);
                datos.setearParametro("@precio_compra_ultimo", modificar.PrecioCompraUltimo);
                datos.setearParametro("@stock_actual", modificar.StockActual);
                datos.setearParametro("@stock_minimo", modificar.StockMinimo);
                datos.setearParametro("@activo", true); 

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

        public void EliminarProducto(Producto prod)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_EliminarProducto");
                datos.setearParametro("@id_producto", prod.IDProducto );
              

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

        public bool ExisteCodigoProducto(string codigo)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_VerificarCodigoProducto");
                datos.setearParametro("@codigo", codigo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidad = int.Parse(datos.Lector[0].ToString());
                    return cantidad > 0;
                }
                return false;

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
       
    }
}
