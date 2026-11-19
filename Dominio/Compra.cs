using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum EstadoCompra
    {
        Cancelado = 0,
        Pendiente = 1,
        Recibido = 2
    }
    public class Compra
    {
        public int IDCompra { get; set; }
        public Proveedor IDProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public Usuario IDUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public string NumeroFactura { get; set; }
        public decimal Total { get; set; }
        public EstadoCompra Estado { get; set; }

    }
}
