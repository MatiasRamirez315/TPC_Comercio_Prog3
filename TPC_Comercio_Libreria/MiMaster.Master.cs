using System;

namespace TPC_Comercio_Libreria
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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