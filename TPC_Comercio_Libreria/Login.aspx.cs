using System;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                mostrarError("Completá usuario y contraseña.");
                return;
            }

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = negocio.validarLogin(
                    txtUsuario.Text.Trim(),
                    txtPassword.Text
                );

                Session["IDUsuario"] = usuario.IDUsuario;
                Session["NombreUsuario"] = usuario.NombreUsuario;
                Session["Rol"] = usuario.Rol;

                Response.Redirect("Inicio.aspx");
            }
            catch (Exception ex)
            {
                mostrarError(ex.Message);
            }
        }

        private void mostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
    }
}