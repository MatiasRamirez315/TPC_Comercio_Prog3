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

        public Cliente listarPorId(int id)
        {
            ClienteDatos datos = new ClienteDatos();
            return datos.listarPorId(id);
        }

        public void agregar(Cliente nuevo)
        {
            ClienteDatos datos = new ClienteDatos();
            datos.agregar(nuevo);
        }

        public void modificar(Cliente cliente)
        {
            ClienteDatos datos = new ClienteDatos();
            datos.modificar(cliente);
        }
    }
}