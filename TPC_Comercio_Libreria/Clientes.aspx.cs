using System;
using System.Collections.Generic;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarClientes();
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