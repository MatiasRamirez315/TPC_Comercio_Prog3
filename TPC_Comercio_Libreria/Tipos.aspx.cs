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
                cargarTipos();
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