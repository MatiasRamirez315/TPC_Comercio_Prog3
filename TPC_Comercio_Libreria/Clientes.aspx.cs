using Negocio;
using System;

namespace TPC_Comercio_Libreria
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteNegocio negocio = new ClienteNegocio();
                RepClientes.DataSource = negocio.listar();
                RepClientes.DataBind();
            }
            

        }
    }
}