using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CompraDetalle
    {
        public int IDCompraDetalle { get; set; }
        public int IDCompra { get; set; }
        public int IDProducto { get; set; }
        public string CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal Subtotal { get; set; }
    }
}
