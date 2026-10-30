using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> Listar()
        {
            AccesoDatos.ProductoDatos datos = new AccesoDatos.ProductoDatos();
            return datos.Listar();
        }
    }
}
