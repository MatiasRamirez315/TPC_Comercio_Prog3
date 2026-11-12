using System;
using System.Web.UI;

namespace TPC_Comercio_Libreria
{    
    /// Clase base para paginas que solo debe ver un administrador.
    /// Si un usuario con otro rol intenta acceder, lo redirige al inicio.
    public class PaginaSoloAdmin : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Session["Rol"] == null || Session["Rol"].ToString() != "ADMIN")
            {
                Response.Redirect("Inicio.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }
        }
    }
}