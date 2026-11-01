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
        public void agregar(Cliente nuevo)
        {
            ClienteDatos datos = new ClienteDatos();
            datos.agregar(nuevo);
        }
    }
}