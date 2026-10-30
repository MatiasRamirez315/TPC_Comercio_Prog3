using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
