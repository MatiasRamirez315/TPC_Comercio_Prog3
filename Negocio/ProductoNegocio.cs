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
       
    }
}
