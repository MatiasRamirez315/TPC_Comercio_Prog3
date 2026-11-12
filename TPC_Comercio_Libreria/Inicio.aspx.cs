using System;

namespace TPC_Comercio_Libreria
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Rol"] == null || Session["Rol"].ToString() != "ADMIN")
            {
                cardCompras.Visible = false;
                cardMarcas.Visible = false;
                cardCategorias.Visible = false;
                cardTipos.Visible = false;
                seccionContactos.Visible = false;
                seccionAdministracion.Visible = false;
            }
        }
    }
}