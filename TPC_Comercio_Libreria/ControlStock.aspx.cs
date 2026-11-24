using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class ControlStock : PaginaSoloAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMensaje.Visible = false;
                lblError.Visible = false;

                if (Session["MensajeExito"] != null)
                {
                    lblMensaje.Text = Session["MensajeExito"].ToString();
                    lblMensaje.Visible = true;
                    Session["MensajeExito"] = null;
                }

                cargarProductos();
                pnlEdicion.Visible = true;
                pnlConfirmacion.Visible = false;
            }
        }

        private void cargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            var lista = negocio.Listar()
                                .Where(p => p.Activo)
                                .OrderBy(p => p.Nombre)
                                .ToList();

            repProductos.DataSource = lista;
            repProductos.DataBind();
        }

        protected void btnAplicar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            var cambios = new List<CambioStock>();

            foreach (RepeaterItem item in repProductos.Items)
            {
                var hdnID = (HiddenField)item.FindControl("hdnIDProducto");
                var hdnNombre = (HiddenField)item.FindControl("hdnNombre");
                var hdnStockA = (HiddenField)item.FindControl("hdnStockActualOriginal");
                var hdnStockM = (HiddenField)item.FindControl("hdnStockMinOriginal");
                var txtStockA = (TextBox)item.FindControl("txtStockActual");
                var txtStockM = (TextBox)item.FindControl("txtStockMinimo");

                string nombreProducto = hdnNombre.Value;

                int stockActualOriginal = int.Parse(hdnStockA.Value);
                int stockMinOriginal = int.Parse(hdnStockM.Value);

                int stockActualNuevo, stockMinNuevo;

                if (!int.TryParse(txtStockA.Text, out stockActualNuevo) || stockActualNuevo < 0)
                {
                    mostrarError("El stock actual de '" + nombreProducto + "' debe ser un número mayor o igual a 0.");
                    return;
                }

                if (!int.TryParse(txtStockM.Text, out stockMinNuevo) || stockMinNuevo < 0)
                {
                    mostrarError("El stock mínimo de '" + nombreProducto + "' debe ser un número mayor o igual a 0.");
                    return;
                }

                if (stockActualNuevo != stockActualOriginal || stockMinNuevo != stockMinOriginal)
                {
                    cambios.Add(new CambioStock
                    {
                        IDProducto = int.Parse(hdnID.Value),
                        NombreProducto = nombreProducto,
                        StockActualAnterior = stockActualOriginal,
                        StockActualNuevo = stockActualNuevo,
                        StockMinimoAnterior = stockMinOriginal,
                        StockMinimoNuevo = stockMinNuevo
                    });
                }
            }

            if (cambios.Count == 0)
            {
                mostrarError("No hay cambios para aplicar. Modificá al menos un valor de stock.");
                return;
            }

            Session["CambiosStockPendientes"] = cambios;

            repConfirmacion.DataSource = cambios;
            repConfirmacion.DataBind();

            pnlEdicion.Visible = false;
            pnlConfirmacion.Visible = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            var cambios = (List<CambioStock>)Session["CambiosStockPendientes"];
            if (cambios == null || cambios.Count == 0)
            {
                Response.Redirect("ControlStock.aspx");
                return;
            }

            var datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.iniciarTransaccion();

                foreach (var cambio in cambios)
                {
                    datos.setearProcedimiento("SP_ActualizarStock");
                    datos.setearParametro("@id_producto", cambio.IDProducto);
                    datos.setearParametro("@stock_actual", cambio.StockActualNuevo);
                    datos.setearParametro("@stock_minimo", cambio.StockMinimoNuevo);
                    datos.ejecutarAccionTransaccion();
                }

                datos.confirmarTransaccion();
            }
            catch (Exception ex)
            {
                datos.cancelarTransaccion();
                mostrarError("Error al actualizar el stock: " + ex.Message);
                return;
            }

            Session["CambiosStockPendientes"] = null;
            Session["MensajeExito"] = "Stock actualizado correctamente para "
                                    + cambios.Count
                                    + (cambios.Count == 1 ? " producto." : " productos.");

            Response.Redirect("ControlStock.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Session["CambiosStockPendientes"] = null;
            cargarProductos();
            pnlEdicion.Visible = true;
            pnlConfirmacion.Visible = false;
        }

        private void mostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
    }

    public class CambioStock
    {
        public int IDProducto { get; set; }
        public string NombreProducto { get; set; }
        public int StockActualAnterior { get; set; }
        public int StockActualNuevo { get; set; }
        public int StockMinimoAnterior { get; set; }
        public int StockMinimoNuevo { get; set; }
    }
}