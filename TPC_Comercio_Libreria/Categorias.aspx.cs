using System;
using System.Collections.Generic;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["eliminar"]))
                {
                    int id = int.Parse(Request.QueryString["eliminar"]);
                    CategoriaNegocio negocio = new CategoriaNegocio();
                    negocio.eliminar(id);

                    Session["MensajeExito"] = "Categoría dada de baja correctamente.";
                    Response.Redirect("Categorias.aspx");
                    return;
                }

                cargarCategorias();

                if (Session["MensajeExito"] != null)
                {
                    lblMensaje.Text = Session["MensajeExito"].ToString();
                    lblMensaje.Visible = true;
                    Session["MensajeExito"] = null;
                }
            }
        }

        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            List<Categoria> lista = negocio.listar();

            repCategorias.DataSource = lista;
            repCategorias.DataBind();

            msgVacio.Visible = lista.Count == 0;
        }
    }
}