using System.Collections.Generic;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            UsuarioDatos datos = new UsuarioDatos();
            return datos.listar();
        }
    }
}