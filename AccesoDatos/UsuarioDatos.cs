using System;
using System.Collections.Generic;
using Dominio;

namespace AccesoDatos
{
    public class UsuarioDatos
    {
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ListarUsuarios");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IDUsuario = (int)datos.Lector["id_usuario"];
                    aux.NombreUsuario = datos.Lector["usuario"].ToString();
                    aux.Rol = datos.Lector["rol"].ToString();
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
    }
}