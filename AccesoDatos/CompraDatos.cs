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
    }
}
