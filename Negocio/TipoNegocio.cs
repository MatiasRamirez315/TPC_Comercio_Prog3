using System.Collections.Generic;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class TipoNegocio
    {
        public List<Tipo> listar()
        {
            TipoDatos datos = new TipoDatos();
            return datos.listar();
        }

        public Tipo listarPorId(int id)
        {
            TipoDatos datos = new TipoDatos();
            return datos.listarPorId(id);
        }

        public void agregar(Tipo nuevo)
        {
            TipoDatos datos = new TipoDatos();
            datos.agregar(nuevo);
        }

        public void modificar(Tipo tipo)
        {
            TipoDatos datos = new TipoDatos();
            datos.modificar(tipo);
        }

        public void eliminar(int id)
        {
            TipoDatos datos = new TipoDatos();
            datos.eliminar(id);
        }
    }
}