using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;
using Negocio;
using VentaDetalleDominio = Dominio.VentaDetalle; 

namespace TPC_Comercio_Libreria
{
    public partial class VentaForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;
                cargarClientes();
                cargarProductos();
            }
        }

        private void cargarClientes()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            var lista = negocio.listar()
                                .Where(c => c.Activo)
                                .OrderBy(c => c.Nombre)
                                .ToList();

            ddlCliente.Items.Clear();
            ddlCliente.Items.Add(new System.Web.UI.WebControls.ListItem("-- Seleccione un cliente --", ""));
            foreach (var c in lista)
            {
                ddlCliente.Items.Add(new System.Web.UI.WebControls.ListItem(c.Nombre, c.IDCliente.ToString()));
            }
        }

        private void cargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            var lista = negocio.Listar()
                                .Where(p => p.Activo && p.StockActual > 0)
                                .OrderBy(p => p.Nombre)
                                .ToList();

            ddlProducto.Items.Clear();
            ddlProducto.Items.Add(new System.Web.UI.WebControls.ListItem("-- Seleccione un producto --", ""));
            foreach (var p in lista)
            {
                ddlProducto.Items.Add(new System.Web.UI.WebControls.ListItem(
                    p.Codigo + " - " + p.Nombre,
                    p.IDProducto.ToString()));
            }
        }

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarPreview();
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            actualizarPreview();
        }

        private void actualizarPreview()
        {
            lblInfoProducto.Text = "";
            lblTotal.Text = "";

            if (string.IsNullOrEmpty(ddlProducto.SelectedValue))
            {
                lblInfoProducto.Text = "Seleccioná un producto para ver el precio y el stock.";
                return;
            }

            int idProducto = int.Parse(ddlProducto.SelectedValue);
            ProductoNegocio negocio = new ProductoNegocio();
            Producto p = negocio.ObtenerPorID(idProducto);

            if (p == null)
            {
                lblInfoProducto.Text = "El producto ya no existe.";
                return;
            }

            decimal precioUnitario = Math.Round(p.PrecioCompraUltimo * (1 + p.PorcentajeGanancia / 100), 2);

            lblInfoProducto.Text = "Precio unitario: $ " + precioUnitario.ToString("N2")
                                 + " &nbsp;·&nbsp; Stock disponible: " + p.StockActual;

            int cantidad;
            if (int.TryParse(txtCantidad.Text, out cantidad) && cantidad > 0)
            {
                decimal subtotal = precioUnitario * cantidad;
                lblTotal.Text = "Total: $ " + subtotal.ToString("N2");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (string.IsNullOrEmpty(ddlCliente.SelectedValue))
            {
                mostrarError("Seleccioná un cliente.");
                return;
            }

            if (string.IsNullOrEmpty(ddlProducto.SelectedValue))
            {
                mostrarError("Seleccioná un producto.");
                return;
            }

            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                mostrarError("La cantidad debe ser un número mayor a 0.");
                return;
            }

            if (string.IsNullOrEmpty(ddlMetodoPago.SelectedValue))
            {
                mostrarError("Seleccioná un método de pago.");
                return;
            }

            try
            {
                int idProducto = int.Parse(ddlProducto.SelectedValue);
                ProductoNegocio productoNegocio = new ProductoNegocio();
                Producto producto = productoNegocio.ObtenerPorID(idProducto);

                if (producto == null)
                {
                    mostrarError("El producto seleccionado ya no existe.");
                    return;
                }

                if (producto.StockActual < cantidad)
                {
                    mostrarError("Stock insuficiente. Disponible: " + producto.StockActual + " unidades.");
                    return;
                }

                decimal precioUnitario = Math.Round(producto.PrecioCompraUltimo * (1 + producto.PorcentajeGanancia / 100), 2);
                decimal subtotal = precioUnitario * cantidad;

                Venta venta = new Venta();
                venta.IDCliente = int.Parse(ddlCliente.SelectedValue);
                venta.IDUsuario = (int)Session["IDUsuario"];
                venta.MetodoPago = ddlMetodoPago.SelectedValue;
                venta.Total = subtotal;

                VentaDetalleDominio linea = new VentaDetalleDominio();
                linea.IDProducto = idProducto;
                linea.Cantidad = cantidad;
                linea.PrecioCompraAplicado = producto.PrecioCompraUltimo;
                linea.PorcentajeGananciaAplicado = producto.PorcentajeGanancia;
                linea.PrecioUnitario = precioUnitario;
                linea.Subtotal = subtotal;

                List<VentaDetalleDominio> detalles = new List<VentaDetalleDominio>();
                detalles.Add(linea);

                VentaNegocio ventaNegocio = new VentaNegocio();
                int idVenta = ventaNegocio.registrar(venta, detalles);

                Response.Redirect("VentaDetalle.aspx?id=" + idVenta);
            }
            catch (Exception ex)
            {
                mostrarError("Error al registrar la venta: " + ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx");
        }

        private void mostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
    }
}