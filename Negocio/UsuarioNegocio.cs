using System.Collections.Generic;
using Dominio;
using AccesoDatos;
using BC = BCrypt.Net.BCrypt;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            UsuarioDatos datos = new UsuarioDatos();
            return datos.listar();
        }

        public Usuario listarPorId(int id)
        {
            UsuarioDatos datos = new UsuarioDatos();
            return datos.listarPorId(id);
        }

        public void agregar(Usuario nuevo, string passwordPlano)
        {
            nuevo.Contrasena = BC.HashPassword(passwordPlano);
            UsuarioDatos datos = new UsuarioDatos();
            datos.agregar(nuevo);
        }

        public void modificar(Usuario usuario, string passwordPlano)
        {
            // Si passwordPlano está vacío, Contrasena queda null
            // y el SP mantiene el hash anterior (CASE interno del SP).
            if (!string.IsNullOrWhiteSpace(passwordPlano))
                usuario.Contrasena = BC.HashPassword(passwordPlano);

            UsuarioDatos datos = new UsuarioDatos();
            datos.modificar(usuario);
        }

        public void eliminar(int id)
        {
            UsuarioDatos datos = new UsuarioDatos();
            datos.eliminar(id);
        }
    }
}