using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class Compra
    {
        public int IDCompra { get; set; }
        public Proveedor IDProveedor { get; set; }
        public Usuario IDUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroFactura { get; set; }
        public decimal Total { get; set; }
    }
}
