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
                cargarUsuarios();
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