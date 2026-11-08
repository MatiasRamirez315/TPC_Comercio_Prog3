using System;
using System.Collections.Generic;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["eliminar"]))
                {
                    int id = int.Parse(Request.QueryString["eliminar"]);
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    negocio.eliminar(id);

                    Session["MensajeExito"] = "Usuario dado de baja correctamente.";
                    Response.Redirect("Usuarios.aspx");
                    return;
                }

                cargarUsuarios();

                if (Session["MensajeExito"] != null)
                {
                    lblMensaje.Text = Session["MensajeExito"].ToString();
                    lblMensaje.Visible = true;
                    Session["MensajeExito"] = null;
                }
            }
        }

        private void cargarUsuarios()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            List<Usuario> lista = negocio.listar();

            repUsuarios.DataSource = lista;
            repUsuarios.DataBind();

            msgVacio.Visible = lista.Count == 0;
        }
    }
}