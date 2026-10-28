using System.Collections.Generic;
using Dominio;
using AccesoDatos;   

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            ClienteDatos datos = new ClienteDatos();
            return datos.listar();
        }
    }
}