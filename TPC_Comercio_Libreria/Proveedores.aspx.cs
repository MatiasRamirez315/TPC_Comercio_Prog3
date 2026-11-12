using System;
using System.Collections.Generic;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class Proveedores : PaginaSoloAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["eliminar"]))
                {
                    int id = int.Parse(Request.QueryString["eliminar"]);
                    ProveedorNegocio negocio = new ProveedorNegocio();
                    negocio.eliminar(id);

                    Session["MensajeExito"] = "Proveedor dado de baja correctamente.";
                    Response.Redirect("Proveedores.aspx");
                    return;
                }

                cargarProveedores();

                if (Session["MensajeExito"] != null)
                {
                    lblMensaje.Text = Session["MensajeExito"].ToString();
                    lblMensaje.Visible = true;
                    Session["MensajeExito"] = null;
                }
            }
        }

        private void cargarProveedores()
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            List<Proveedor> lista = negocio.listar();

            repProveedores.DataSource = lista;
            repProveedores.DataBind();

            msgVacio.Visible = lista.Count == 0;
        }
    }
}