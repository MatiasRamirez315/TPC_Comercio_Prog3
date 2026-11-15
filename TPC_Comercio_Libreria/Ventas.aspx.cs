using System;
using System.Collections.Generic;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class Ventas : System.Web.UI.Page
    {
        private bool EsAdmin
        {
            get
            {
                return Session["Rol"] != null && Session["Rol"].ToString() == "ADMIN";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cancelar venta (solo admin)
                if (!string.IsNullOrWhiteSpace(Request.QueryString["cancelar"]))
                {
                    if (EsAdmin)
                    {
                        try
                        {
                            int id = int.Parse(Request.QueryString["cancelar"]);
                            VentaNegocio negocio = new VentaNegocio();
                            negocio.cancelar(id);
                            Session["MensajeExito"] = "Venta cancelada correctamente. El stock fue restaurado.";
                        }
                        catch (Exception ex)
                        {
                            Session["MensajeExito"] = "Error al cancelar: " + ex.Message;
                        }
                    }
                    Response.Redirect("Ventas.aspx");
                    return;
                }

                cargarVentas();

                if (Session["MensajeExito"] != null)
                {
                    lblMensaje.Text = Session["MensajeExito"].ToString();
                    lblMensaje.Visible = true;
                    Session["MensajeExito"] = null;
                }
            }
        }

        private void cargarVentas()
        {
            VentaNegocio negocio = new VentaNegocio();
            List<Venta> lista = negocio.listar();

            repVentas.DataSource = lista;
            repVentas.DataBind();

            msgVacio.Visible = lista.Count == 0;
        }
    }
}