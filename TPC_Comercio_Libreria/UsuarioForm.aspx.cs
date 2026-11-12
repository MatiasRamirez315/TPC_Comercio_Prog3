using System;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class UsuarioForm : PaginaSoloAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;

                if (HayIdEnQueryString())
                {
                    lblTitulo.Text = "Editar usuario";
                    lblSubtitulo.Text = "Modificá los datos del usuario";
                    lblObligatoriaPass.Visible = false;
                    pwdHelp.Visible = true;
                    cargarUsuario();
                }
                else
                {
                    lblTitulo.Text = "Nuevo usuario";
                    lblSubtitulo.Text = "Completá los datos para dar de alta un usuario";
                    lblObligatoriaPass.Visible = true;
                    pwdHelp.Visible = false;
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                mostrarError("El nombre de usuario es obligatorio.");
                return;
            }

            bool esAlta = !HayIdEnQueryString();
            string password = txtPassword.Text;

            // En alta, la contraseña es obligatoria
            if (esAlta && string.IsNullOrWhiteSpace(password))
            {
                mostrarError("La contraseña es obligatoria para un usuario nuevo.");
                return;
            }

            // Si el usuario tipeó algo (en alta o edición), validar longitud mínima
            if (!string.IsNullOrWhiteSpace(password) && password.Length < 6)
            {
                mostrarError("La contraseña debe tener al menos 6 caracteres.");
                return;
            }

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();

                if (esAlta)
                {
                    Usuario nuevo = new Usuario();
                    nuevo.NombreUsuario = txtUsuario.Text.Trim();
                    nuevo.Rol = ddlRol.SelectedValue;
                    nuevo.Activo = true;

                    negocio.agregar(nuevo, password);
                    Session["MensajeExito"] = "Usuario agregado correctamente.";
                }
                else
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    Usuario usuario = negocio.listarPorId(id);

                    if (usuario == null)
                    {
                        Response.Redirect("Usuarios.aspx");
                        return;
                    }

                    usuario.NombreUsuario = txtUsuario.Text.Trim();
                    usuario.Rol = ddlRol.SelectedValue;

                    negocio.modificar(usuario, password);
                    Session["MensajeExito"] = "Usuario modificado correctamente.";
                }

                Response.Redirect("Usuarios.aspx");
            }
            catch (Exception ex)
            {
                mostrarError("Error al guardar: " + ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

        private bool HayIdEnQueryString()
        {
            return !string.IsNullOrWhiteSpace(Request.QueryString["id"]);
        }

        private void cargarUsuario()
        {
            int id = int.Parse(Request.QueryString["id"]);
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = negocio.listarPorId(id);

            if (usuario == null)
            {
                Response.Redirect("Usuarios.aspx");
                return;
            }

            txtUsuario.Text = usuario.NombreUsuario;

            // El DropDownList tiene Value "VENDEDOR" o "ADMIN"
            if (ddlRol.Items.FindByValue(usuario.Rol) != null)
                ddlRol.SelectedValue = usuario.Rol;

            // txtPassword arranca vacío a propósito
        }

        private void mostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
    }
}