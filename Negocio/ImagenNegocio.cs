using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class ImagenNegocio
    {
        public void Agregar(Dominio.Imagen nuevaImg)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_AltaImagen");
                datos.setearParametro("@id_producto", nuevaImg.IDProducto);
                datos.setearParametro("@url", nuevaImg.URLImagen);
                datos.ejecutarAccionScalar();
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

        public List<Dominio.Imagen> ListarPorProducto(int idProducto)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            List<Dominio.Imagen> lista = new List<Dominio.Imagen>();
            try
            {
                datos.setearProcedimiento("SP_ListarImagenesPorProducto");
                datos.setearParametro("@id_producto", idProducto);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Dominio.Imagen img = new Dominio.Imagen();
                    img.IDImagen = (int)datos.Lector["id_imagen"];
                    img.IDProducto = (int)datos.Lector["id_producto"];
                    img.URLImagen = (string)datos.Lector["url"];
                    lista.Add(img);
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

        public void ModificarImagen(Imagen img)
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ModificarImagen");
                datos.setearParametro("@id_producto", img.IDProducto);
                datos.setearParametro("@url", img.URLImagen);

                datos.ejecutarLectura();

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
