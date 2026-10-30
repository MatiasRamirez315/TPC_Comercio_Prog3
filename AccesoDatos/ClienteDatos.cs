using System;
using System.Collections.Generic;
using Dominio;

namespace AccesoDatos
{
    public class ClienteDatos
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "SELECT id_cliente, nombre, cuit, telefono, email, direccion, activo " +
                    "FROM clientes ORDER BY nombre"
                );
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.IDCliente = (int)datos.Lector["id_cliente"];
                    aux.Nombre = datos.Lector["nombre"].ToString();
                    aux.Cuit = datos.Lector["cuit"] == DBNull.Value ? "" : datos.Lector["cuit"].ToString();
                    aux.Telefono = datos.Lector["telefono"] == DBNull.Value ? "" : datos.Lector["telefono"].ToString();
                    aux.Email = datos.Lector["email"] == DBNull.Value ? "" : datos.Lector["email"].ToString();
                    aux.Direccion = datos.Lector["direccion"] == DBNull.Value ? "" : datos.Lector["direccion"].ToString();
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