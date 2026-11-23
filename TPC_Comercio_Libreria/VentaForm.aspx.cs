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

                if (Session["CarritoVenta"] == null)
                {
                    Session["CarritoVenta"] = new List<VentaDetalleDominio>();
                }

                cargarClientes();
                cargarProductos();
                cargarCarrito();  
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

            int enCarrito = 0;
            var carrito = (List<VentaDetalleDominio>)Session["CarritoVenta"];
            if (carrito != null)
            {
                var lineaExistente = carrito.FirstOrDefault(l => l.IDProducto == idProducto);
                if (lineaExistente != null) enCarrito = lineaExistente.Cantidad;
            }

            int disponible = p.StockActual - enCarrito;

            lblInfoProducto.Text = "Precio unitario: $ " + precioUnitario.ToString("N2")
                                 + " &nbsp;·&nbsp; Stock disponible: " + p.StockActual
                                 + (enCarrito > 0 ? " (ya en carrito: " + enCarrito + ", restante: " + disponible + ")" : "");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

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

                var carrito = (List<VentaDetalleDominio>)Session["CarritoVenta"];

                var lineaExistente = carrito.FirstOrDefault(l => l.IDProducto == idProducto);
                int cantidadTotal = cantidad + (lineaExistente != null ? lineaExistente.Cantidad : 0);

                if (producto.StockActual < cantidadTotal)
                {
                    mostrarError("Stock insuficiente. Disponible: " + producto.StockActual
                               + " unidades. En el carrito ya tenés "
                               + (lineaExistente != null ? lineaExistente.Cantidad : 0) + ".");
                    return;
                }

                decimal precioUnitario = Math.Round(producto.PrecioCompraUltimo * (1 + producto.PorcentajeGanancia / 100), 2);

                if (lineaExistente != null)
                {
                    lineaExistente.Cantidad = cantidadTotal;
                    lineaExistente.Subtotal = precioUnitario * cantidadTotal;
                    lineaExistente.PrecioCompraAplicado = producto.PrecioCompraUltimo;
                    lineaExistente.PorcentajeGananciaAplicado = producto.PorcentajeGanancia;
                    lineaExistente.PrecioUnitario = precioUnitario;
                }
                else
                {
                    VentaDetalleDominio nuevaLinea = new VentaDetalleDominio();
                    nuevaLinea.IDProducto = idProducto;
                    nuevaLinea.CodigoProducto = producto.Codigo;
                    nuevaLinea.NombreProducto = producto.Nombre;
                    nuevaLinea.Cantidad = cantidad;
                    nuevaLinea.PrecioCompraAplicado = producto.PrecioCompraUltimo;
                    nuevaLinea.PorcentajeGananciaAplicado = producto.PorcentajeGanancia;
                    nuevaLinea.PrecioUnitario = precioUnitario;
                    nuevaLinea.Subtotal = precioUnitario * cantidad;
                    carrito.Add(nuevaLinea);
                }

                Session["CarritoVenta"] = carrito;

                ddlProducto.SelectedIndex = 0;
                txtCantidad.Text = "1";
                lblInfoProducto.Text = "Seleccioná un producto para ver el precio y el stock.";

                cargarCarrito();
            }
            catch (Exception ex)
            {
                mostrarError("Error al agregar al carrito: " + ex.Message);
            }
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                var boton = (System.Web.UI.WebControls.Button)sender;
                int idProducto = int.Parse(boton.CommandArgument);

                var carrito = (List<VentaDetalleDominio>)Session["CarritoVenta"];
                var linea = carrito.FirstOrDefault(l => l.IDProducto == idProducto);
                if (linea != null)
                {
                    carrito.Remove(linea);
                    Session["CarritoVenta"] = carrito;
                }

                cargarCarrito();
            }
            catch (Exception ex)
            {
                mostrarError("Error al quitar del carrito: " + ex.Message);
            }
        }

        private void cargarCarrito()
        {
            var carrito = (List<VentaDetalleDominio>)Session["CarritoVenta"];
            if (carrito == null) carrito = new List<VentaDetalleDominio>();

            repCarrito.DataSource = carrito;
            repCarrito.DataBind();

            decimal total = carrito.Sum(l => l.Subtotal);
            lblTotal.Text = "$ " + total.ToString("N2");

            lblCarritoVacio.Visible = carrito.Count == 0;
            btnConfirmar.Enabled = carrito.Count > 0;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            var carrito = (List<VentaDetalleDominio>)Session["CarritoVenta"];
            if (carrito == null || carrito.Count == 0)
            {
                mostrarError("El carrito está vacío. Agregá al menos un producto.");
                return;
            }

            if (string.IsNullOrEmpty(ddlCliente.SelectedValue))
            {
                mostrarError("Seleccioná un cliente.");
                return;
            }

            if (string.IsNullOrEmpty(ddlMetodoPago.SelectedValue))
            {
                mostrarError("Seleccioná un método de pago.");
                return;
            }

            try
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                foreach (var linea in carrito)
                {
                    Producto p = productoNegocio.ObtenerPorID(linea.IDProducto);
                    if (p == null)
                    {
                        mostrarError("El producto '" + linea.NombreProducto + "' ya no existe.");
                        return;
                    }
                    if (p.StockActual < linea.Cantidad)
                    {
                        mostrarError("Stock insuficiente para '" + linea.NombreProducto
                                   + "'. Disponible: " + p.StockActual
                                   + ", en carrito: " + linea.Cantidad
                                   + ". Ajustá la cantidad o quitá el producto.");
                        return;
                    }
                }

                Venta venta = new Venta();
                venta.IDCliente = int.Parse(ddlCliente.SelectedValue);
                venta.IDUsuario = (int)Session["IDUsuario"];
                venta.MetodoPago = ddlMetodoPago.SelectedValue;
                venta.Total = carrito.Sum(l => l.Subtotal);

                VentaNegocio ventaNegocio = new VentaNegocio();
                int idVenta = ventaNegocio.registrar(venta, carrito);

                Session["CarritoVenta"] = null;

                Response.Redirect("VentaDetalle.aspx?id=" + idVenta);
            }
            catch (Exception ex)
            {
                mostrarError("Error al registrar la venta: " + ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session["CarritoVenta"] = null;
            Response.Redirect("Ventas.aspx");
        }

        private void mostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
    }
}