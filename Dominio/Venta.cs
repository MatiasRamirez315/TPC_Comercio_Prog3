using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Venta
    {
        public int IDVenta { get; set; }
        public Cliente IDCliente { get; set; }
        public Usuario IDUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; }

    }
}
