using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

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
    }
}
