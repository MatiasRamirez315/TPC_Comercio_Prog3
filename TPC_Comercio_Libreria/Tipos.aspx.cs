using System;
using System.Collections.Generic;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class Tipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["eliminar"]))
                {
                    int id = int.Parse(Request.QueryString["eliminar"]);
                    TipoNegocio negocio = new TipoNegocio();
                    negocio.eliminar(id);

                    Session["MensajeExito"] = "Tipo dado de baja correctamente.";
                    Response.Redirect("Tipos.aspx");
                    return;
                }

                cargarTipos();

                if (Session["MensajeExito"] != null)
                {
                    lblMensaje.Text = Session["MensajeExito"].ToString();
                    lblMensaje.Visible = true;
                    Session["MensajeExito"] = null;
                }
            }
        }

        private void cargarTipos()
        {
            TipoNegocio negocio = new TipoNegocio();
            List<Tipo> lista = negocio.listar();

            repTipos.DataSource = lista;
            repTipos.DataBind();

            msgVacio.Visible = lista.Count == 0;
        }
    }
}