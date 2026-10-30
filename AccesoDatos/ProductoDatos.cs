using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace AccesoDatos
{
    public class ProductoDatos
    {
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta
                    ("select p.id_producto, p.codigo, p.nombre, m.id_marca, m.descripcion as desc_marca , c.id_categoria, c.descripcion as desc_categoria,t.id_tipo , t.descripcion as desc_tipo, " + 
                    "p.precio_compra_ultimo, p.stock_actual, p.activo  from productos p  left join marcas m on p.id_marca = m.id_marca " + 
                    "left join categorias c on p.id_categoria = c.id_categoria left join tipos t on p.id_tipo = t.id_tipo " + 
                    "where p.activo = 1 order by p.nombre");
                
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.IDProducto = (int)datos.Lector["id_producto"];
                    aux.Codigo = datos.Lector["codigo"].ToString();
                    aux.Nombre = datos.Lector["nombre"].ToString();
                    aux.Marca = new Marca();
                    aux.Marca.IDMarca = (int)datos.Lector["id_marca"];
                    aux.Marca.Nombre = datos.Lector["desc_marca"].ToString();
                    aux.Categoria = new Categoria();
                    aux.Categoria.IDCategoria = (int)datos.Lector["id_categoria"];
                    aux.Categoria.Descripcion = datos.Lector["desc_categoria"].ToString();
                    aux.Tipo = new Tipo();
                    aux.Tipo.IDTipo = (int)datos.Lector["id_tipo"];
                    aux.Tipo.Descripcion = datos.Lector["desc_tipo"].ToString();
                    aux.PrecioCompraUltimo = (decimal)datos.Lector["precio_compra_ultimo"];
                    aux.StockActual = (int)datos.Lector["stock_actual"];
                    aux.Activo = (bool)datos.Lector["activo"];
                    lista.Add(aux);
                }

                return lista;
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
