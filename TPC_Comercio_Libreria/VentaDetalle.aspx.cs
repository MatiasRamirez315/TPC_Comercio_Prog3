using System;
using System.Collections.Generic;
using Dominio;
using Negocio;
using VentaDetalleDominio = Dominio.VentaDetalle;  

namespace TPC_Comercio_Libreria
{
    public partial class VentaDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    Response.Redirect("Ventas.aspx");
                    return;
                }

                int id;
                if (!int.TryParse(Request.QueryString["id"], out id))
                {
                    Response.Redirect("Ventas.aspx");
                    return;
                }

                cargarVenta(id);
            }
        }

        private void cargarVenta(int id)
        {
            VentaNegocio negocio = new VentaNegocio();
            Venta venta = negocio.obtener(id);

            if (venta == null)
            {
                Response.Redirect("Ventas.aspx");
                return;
            }

            lblNumeroVenta.Text = venta.IDVenta.ToString();
            lblFecha.Text = venta.Fecha.ToString("dd/MM/yyyy HH:mm");
            lblEstado.Text = venta.Estado == "CONFIRMADA"
                                        ? "<span class='badge bg-success'>Confirmada</span>"
                                        : "<span class='badge bg-secondary'>Cancelada</span>";
            lblCliente.Text = venta.ClienteNombre;
            lblVendedor.Text = venta.VendedorNombre;
            lblMetodoPago.Text = venta.MetodoPago;
            lblTotalCabecera.Text = "$ " + venta.Total.ToString("N2");
            lblTotalPie.Text = venta.Total.ToString("N2");

            List<VentaDetalleDominio> detalle = negocio.listarDetalle(id);
            repDetalle.DataSource = detalle;
            repDetalle.DataBind();
        }
    }
}