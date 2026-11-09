using AccesoDatos;
using Dominio;
using System;
using System.Collections.Generic;
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

        public Usuario validarLogin(string nombreUsuario, string passwordPlano)
        {
            UsuarioDatos datos = new UsuarioDatos();
            Usuario usuario = datos.buscarPorNombre(nombreUsuario);

            if (usuario == null)
                throw new Exception("Usuario o contraseña incorrectos.");

            if (!usuario.Activo)
                throw new Exception("Tu cuenta está deshabilitada. Contactá al administrador.");

            if (!BC.Verify(passwordPlano, usuario.Contrasena))
                throw new Exception("Usuario o contraseña incorrectos.");

            usuario.Contrasena = null;
            return usuario;
        }
    }
}