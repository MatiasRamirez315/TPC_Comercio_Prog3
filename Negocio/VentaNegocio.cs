using System.Collections.Generic;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class VentaNegocio
    {
        public List<Venta> listar()
        {
            VentaDatos datos = new VentaDatos();
            return datos.listar();
        }

        public Venta obtener(int idVenta)
        {
            VentaDatos datos = new VentaDatos();
            return datos.obtener(idVenta);
        }

        public List<VentaDetalle> listarDetalle(int idVenta)
        {
            VentaDatos datos = new VentaDatos();
            return datos.listarDetalle(idVenta);
        }

        public int registrar(Venta venta, List<VentaDetalle> detalles)
        {
            VentaDatos datos = new VentaDatos();
            return datos.alta(venta, detalles);
        }

        public void cancelar(int idVenta)
        {
            VentaDatos datos = new VentaDatos();
            datos.cancelar(idVenta);
        }
    }
}