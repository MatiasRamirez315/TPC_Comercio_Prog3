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
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}
