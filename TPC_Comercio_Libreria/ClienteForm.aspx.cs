using System;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class ClienteForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                mostrarError("El nombre es obligatorio.");
                return;
            }

            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrWhiteSpace(email) && !EsEmailValido(email))
            {
                mostrarError("El email no tiene un formato válido.");
                return;
            }

            try
            {
                Cliente nuevo = new Cliente();
                nuevo.Nombre = txtNombre.Text.Trim();
                nuevo.Cuit = txtCuit.Text.Trim();
                nuevo.Telefono = txtTelefono.Text.Trim();
                nuevo.Email = email;
                nuevo.Direccion = txtDireccion.Text.Trim();
                nuevo.Activo = true;

                ClienteNegocio negocio = new ClienteNegocio();
                negocio.agregar(nuevo);

                Session["MensajeExito"] = "Cliente agregado correctamente.";
                Response.Redirect("Clientes.aspx");
            }
            catch (Exception ex)
            {
                mostrarError("Error al guardar: " + ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }

        private void mostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}