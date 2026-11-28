using System;
using System.Collections.Generic;
using System.Data;
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
                cargarHistorial();
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

        private void cargarHistorial()
        {
            AccesoDatos.AccesoDatos datos = new AccesoDatos.AccesoDatos();
            var lista = new List<MovimientoStockManual>();

            try
            {
                datos.setearProcedimiento("SP_ListarMovimientosStockManuales");
                datos.setearParametro("@top", 50);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(new MovimientoStockManual
                    {
                        IDMovimiento = (int)datos.Lector["id_movimiento"],
                        Fecha = (DateTime)datos.Lector["fecha"],
                        CodigoProducto = datos.Lector["codigo_producto"].ToString(),
                        NombreProducto = datos.Lector["nombre_producto"].ToString(),
                        Usuario = datos.Lector["usuario"].ToString(),
                        StockActualAntes = (int)datos.Lector["stock_actual_antes"],
                        StockActualDespues = (int)datos.Lector["stock_actual_despues"],
                        StockMinimoAntes = (int)datos.Lector["stock_minimo_antes"],
                        StockMinimoDespues = (int)datos.Lector["stock_minimo_despues"],
                        Motivo = datos.Lector["motivo"].ToString()
                    });
                }
            }
            finally
            {
                datos.cerrarConexion();
            }

            repHistorial.DataSource = lista;
            repHistorial.DataBind();

            msgHistorialVacio.Visible = lista.Count == 0;
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
            lblError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtMotivo.Text))
            {
                lblError.Text = "Tenés que indicar un motivo para el ajuste de stock.";
                lblError.Visible = true;
                return;
            }

            if (txtMotivo.Text.Trim().Length < 5)
            {
                lblError.Text = "El motivo es demasiado corto. Describí brevemente por qué se modifica el stock.";
                lblError.Visible = true;
                return;
            }

            var cambios = (List<CambioStock>)Session["CambiosStockPendientes"];
            if (cambios == null || cambios.Count == 0)
            {
                Response.Redirect("ControlStock.aspx");
                return;
            }

            int idUsuario = (int)Session["IDUsuario"];
            string motivo = txtMotivo.Text.Trim();

            var datos = new AccesoDatos.AccesoDatos();
            try
            {
                datos.iniciarTransaccion();

                foreach (var cambio in cambios)
                {
                    // 1. Actualizar el stock
                    datos.setearProcedimiento("SP_ActualizarStock");
                    datos.setearParametro("@id_producto", cambio.IDProducto);
                    datos.setearParametro("@stock_actual", cambio.StockActualNuevo);
                    datos.setearParametro("@stock_minimo", cambio.StockMinimoNuevo);
                    datos.ejecutarAccionTransaccion();

                    // 2. Registrar el movimiento en la auditoría
                    datos.setearProcedimiento("SP_AltaMovimientoStockManual");
                    datos.setearParametro("@id_producto", cambio.IDProducto);
                    datos.setearParametro("@id_usuario", idUsuario);
                    datos.setearParametro("@stock_actual_antes", cambio.StockActualAnterior);
                    datos.setearParametro("@stock_actual_despues", cambio.StockActualNuevo);
                    datos.setearParametro("@stock_minimo_antes", cambio.StockMinimoAnterior);
                    datos.setearParametro("@stock_minimo_despues", cambio.StockMinimoNuevo);
                    datos.setearParametro("@motivo", motivo);
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
            txtMotivo.Text = "";
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

    public class MovimientoStockManual
    {
        public int IDMovimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Usuario { get; set; }
        public int StockActualAntes { get; set; }
        public int StockActualDespues { get; set; }
        public int StockMinimoAntes { get; set; }
        public int StockMinimoDespues { get; set; }
        public string Motivo { get; set; }
    }
}