using System.Collections.Generic;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listar()
        {
            ProveedorDatos datos = new ProveedorDatos();
            return datos.listar();
        }

        public Proveedor listarPorId(int id)
        {
            ProveedorDatos datos = new ProveedorDatos();
            return datos.listarPorId(id);
        }

        public void agregar(Proveedor nuevo)
        {
            ProveedorDatos datos = new ProveedorDatos();
            datos.agregar(nuevo);
        }

        public void modificar(Proveedor proveedor)
        {
            ProveedorDatos datos = new ProveedorDatos();
            datos.modificar(proveedor);
        }

        public void eliminar(int id)
        {
            ProveedorDatos datos = new ProveedorDatos();
            datos.eliminar(id);
        }
    }
}