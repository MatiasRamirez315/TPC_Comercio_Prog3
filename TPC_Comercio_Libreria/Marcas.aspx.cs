using System;
using System.Collections.Generic;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class Marcas : PaginaSoloAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["eliminar"]))
                {
                    int id = int.Parse(Request.QueryString["eliminar"]);
                    MarcaNegocio negocio = new MarcaNegocio();
                    negocio.eliminar(id);

                    Session["MensajeExito"] = "Marca dada de baja correctamente.";
                    Response.Redirect("Marcas.aspx");
                    return;
                }

                cargarMarcas();

                if (Session["MensajeExito"] != null)
                {
                    lblMensaje.Text = Session["MensajeExito"].ToString();
                    lblMensaje.Visible = true;
                    Session["MensajeExito"] = null;
                }
            }
        }

        private void cargarMarcas()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            List<Marca> lista = negocio.listar();

            repMarcas.DataSource = lista;
            repMarcas.DataBind();

            msgVacio.Visible = lista.Count == 0;
        }
    }
}