using System;
using System.Collections.Generic;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarMarcas();
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