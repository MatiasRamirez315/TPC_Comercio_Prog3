using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class VentaDetalle
    {
        public int IDVentaDetalle { get; set; }
        public int IDVenta { get; set; }
        public int IDProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompraAplicado { get; set; }
        public decimal PorcentajeGananciaAplicado { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
