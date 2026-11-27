using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_Comercio_Libreria
{
    public partial class CompraDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                Response.Redirect("Compras.aspx");
                return;
            }

            int id;
            if (!int.TryParse(Request.QueryString["id"], out id))
            {
                Response.Redirect("Compras.aspx");
                return;
            }

            CargarCompra(id);

        }

        public void CargarCompra(int id)
        {
            CompraNegocio negocio = new CompraNegocio();
            Compra compra = negocio.ObtenerCompra(id);

            if (compra == null)
            {
                Response.Redirect("Compras.aspx");
                return;
            }

            lblNumeroCompra.Text = compra.IDCompra.ToString();
            lblFecha.Text = compra.Fecha.ToString("dd/MM/yyyy HH:mm");
            lblEstado.Text = Convert.ToBoolean(compra.Estado) 
                                    ? "<span class='badge bg-success'>Recibido</span>"
                                    : "<span class='badge bg-danger'>Cancelado</span>";
            Proveedor aux = new Proveedor();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            aux = proveedorNegocio.listarPorId(compra.IDProveedor.IDProveedor);

            lblProveedor.Text = aux.Nombre; 
            lblCuit.Text = compra.IDProveedor.Cuit;
            lblNumeroFactura.Text = compra.NumeroFactura;
            lblTotal.Text = compra.Total.ToString("C");
            lblTotalProd.Text = compra.Total.ToString("");

            List<Dominio.CompraDetalle> detalles = negocio.ListarDetalles(id);
            repDetalle.DataSource = detalles;
            repDetalle.DataBind();       
        }
    }
}