using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int IDVenta { get; set; }
        public int IDCliente { get; set; }
        public string ClienteNombre { get; set; }
        public int IDUsuario { get; set; }
        public string VendedorNombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }      
        public decimal Total { get; set; }
        public string MetodoPago { get; set; }
    }
}
