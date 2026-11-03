using System.Collections.Generic;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            MarcaDatos datos = new MarcaDatos();
            return datos.listar();
        }

        public Marca listarPorId(int id)
        {
            MarcaDatos datos = new MarcaDatos();
            return datos.listarPorId(id);
        }

        public void agregar(Marca nueva)
        {
            MarcaDatos datos = new MarcaDatos();
            datos.agregar(nueva);
        }

        public void modificar(Marca marca)
        {
            MarcaDatos datos = new MarcaDatos();
            datos.modificar(marca);
        }

        public void eliminar(int id)
        {
            MarcaDatos datos = new MarcaDatos();
            datos.eliminar(id);
        }
    }
}