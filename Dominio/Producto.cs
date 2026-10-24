using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int IDProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public Tipo Tipo { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        public decimal PrecioCompraUltimo { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public bool Activo { get; set; }

    }
}
