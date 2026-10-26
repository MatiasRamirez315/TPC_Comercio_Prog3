using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Comercio_Libreria
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Por ahora solo mostramos un error de prueba.
            // Después acá va la validación real contra la base de datos.
            lblError.Visible = true;
            lblError.Text = "Usuario o contraseña incorrectos.";
        }
    }
}