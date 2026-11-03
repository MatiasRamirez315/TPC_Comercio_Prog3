using System.Collections.Generic;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            CategoriaDatos datos = new CategoriaDatos();
            return datos.listar();
        }

        public Categoria listarPorId(int id)
        {
            CategoriaDatos datos = new CategoriaDatos();
            return datos.listarPorId(id);
        }

        public void agregar(Categoria nueva)
        {
            CategoriaDatos datos = new CategoriaDatos();
            datos.agregar(nueva);
        }

        public void modificar(Categoria categoria)
        {
            CategoriaDatos datos = new CategoriaDatos();
            datos.modificar(categoria);
        }

        public void eliminar(int id)
        {
            CategoriaDatos datos = new CategoriaDatos();
            datos.eliminar(id);
        }
    }
}