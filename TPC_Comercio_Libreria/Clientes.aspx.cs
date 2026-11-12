using System;
using System.Collections.Generic;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class Clientes : PaginaSoloAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(Request.QueryString["eliminar"]))
                {
                    int id = int.Parse(Request.QueryString["eliminar"]);
                    ClienteNegocio negocio = new ClienteNegocio();
                    negocio.eliminar(id);

                    Session["MensajeExito"] = "Cliente dado de baja correctamente.";
                    Response.Redirect("Clientes.aspx");
                    return;
                }

                cargarClientes();

                if (Session["MensajeExito"] != null)
                {
                    lblMensaje.Text = Session["MensajeExito"].ToString();
                    lblMensaje.Visible = true;
                    Session["MensajeExito"] = null;
                }
            }
        }

        private void cargarClientes()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> lista = negocio.listar();

            repClientes.DataSource = lista;
            repClientes.DataBind();

            msgVacio.Visible = lista.Count == 0;
        }
    }
}