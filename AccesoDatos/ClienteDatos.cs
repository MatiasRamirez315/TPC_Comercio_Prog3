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
                datos.setearProcedimiento("SP_ListarClientes");
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
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        public void agregar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AltaCliente");
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@cuit", ValorONull(nuevo.Cuit));
                datos.setearParametro("@telefono", ValorONull(nuevo.Telefono));
                datos.setearParametro("@email", ValorONull(nuevo.Email));
                datos.setearParametro("@direccion", ValorONull(nuevo.Direccion));
                datos.EjecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private object ValorONull(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return DBNull.Value;
            return valor.Trim();
        }
    }
}