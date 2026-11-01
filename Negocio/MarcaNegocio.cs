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
    }
}