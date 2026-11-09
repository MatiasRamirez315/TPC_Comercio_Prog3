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

        public Usuario listarPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ObtenerUsuario");
                datos.setearParametro("@id_usuario", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IDUsuario = (int)datos.Lector["id_usuario"];
                    aux.NombreUsuario = datos.Lector["usuario"].ToString();
                    aux.Rol = datos.Lector["rol"].ToString();
                    aux.Activo = (bool)datos.Lector["activo"];
                    // Contrasena no se mapea (el SP no la devuelve)
                    return aux;
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AltaUsuario");
                datos.setearParametro("@usuario", nuevo.NombreUsuario);
                datos.setearParametro("@password", nuevo.Contrasena);   // ya viene hasheada desde Negocio
                datos.setearParametro("@rol", nuevo.Rol);
                datos.EjecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ModificarUsuario");
                datos.setearParametro("@id_usuario", usuario.IDUsuario);
                datos.setearParametro("@usuario", usuario.NombreUsuario);

                // Si Contrasena está vacía o null, el SP mantiene la anterior (CASE interno).
                if (string.IsNullOrWhiteSpace(usuario.Contrasena))
                    datos.setearParametro("@password", DBNull.Value);
                else
                    datos.setearParametro("@password", usuario.Contrasena);

                datos.setearParametro("@rol", usuario.Rol);
                datos.setearParametro("@activo", usuario.Activo);
                datos.EjecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_EliminarUsuario");
                datos.setearParametro("@id_usuario", id);
                datos.EjecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Usuario buscarPorNombre(string nombreUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_Login");
                datos.setearParametro("@usuario", nombreUsuario);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IDUsuario = (int)datos.Lector["id_usuario"];
                    aux.NombreUsuario = datos.Lector["usuario"].ToString();
                    aux.Contrasena = datos.Lector["password"].ToString(); 
                    aux.Rol = datos.Lector["rol"].ToString();
                    aux.Activo = (bool)datos.Lector["activo"];
                    return aux;
                }

                return null;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}