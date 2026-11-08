using System;

namespace TPC_Comercio_Libreria
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si estamos en la página de login, no chequeamos sesión
            // (aunque Login.aspx no usa master, esto es por si en el futuro lo hace)
            string pagina = System.IO.Path.GetFileName(Request.Url.AbsolutePath).ToLower();

            if (pagina != "login.aspx" && Session["IDUsuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}