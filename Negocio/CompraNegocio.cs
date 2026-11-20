using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class CompraNegocio
    {
        public List <Compra> Listar()
        {
            CompraDatos datos = new CompraDatos();
            return datos.Listar();
        }

        public void CancelarCompra(int IdCompra)
        {
            CompraDatos datos = new CompraDatos();
            datos.Cancelar(IdCompra);
        }
    }
}
