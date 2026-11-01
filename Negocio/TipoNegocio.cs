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
    }
}