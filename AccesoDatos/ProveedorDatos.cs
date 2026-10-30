using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace AccesoDatos
{
    public class ProveedorDatos
    {
        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(
                    "SELECT id_proveedor, nombre, descripcion,  cuit, telefono, email, activo " +
                    "FROM Proveedores WHERE activo = 1 order by nombre"
                );
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.IDProveedor = (int)datos.Lector["id_proveedor"];
                    aux.Nombre = datos.Lector["nombre"].ToString();
                    aux.Descripcion = datos.Lector["descripcion"] == DBNull.Value ? "" : datos.Lector["descripcion"].ToString();
                    aux.Cuit = datos.Lector["cuit"] == DBNull.Value ? "" : datos.Lector["cuit"].ToString();
                    aux.Telefono = datos.Lector["telefono"] == DBNull.Value ? "" : datos.Lector["telefono"].ToString();
                    aux.Email = datos.Lector["email"] == DBNull.Value ? "" : datos.Lector["email"].ToString();
                    aux.Activo = (bool)datos.Lector["activo"];
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
