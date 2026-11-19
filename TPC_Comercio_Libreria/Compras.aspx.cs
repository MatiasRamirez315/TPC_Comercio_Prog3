using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_Comercio_Libreria
{
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarCompras();
        }

        public void CargarCompras()
        {
            CompraNegocio negocio = new CompraNegocio();
            List<Compra> lista = negocio.Listar();

            repCompras.DataSource = lista;
            repCompras.DataBind();

            msgVacio.Visible = lista.Count == 0;

        }
    }
}