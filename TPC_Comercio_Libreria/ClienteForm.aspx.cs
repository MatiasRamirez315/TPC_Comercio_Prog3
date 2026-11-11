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

                if (HayIdEnQueryString())
                {
                    lblTitulo.Text = "Editar cliente";
                    lblSubtitulo.Text = "Modificá los datos del cliente";
                    cargarCliente();
                }
                else
                {
                    lblTitulo.Text = "Nuevo cliente";
                    lblSubtitulo.Text = "Completá los datos para dar de alta un cliente";
                }
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
            
            string cuit = txtCuit.Text.Trim();
            if (!string.IsNullOrWhiteSpace(cuit))
            {
                ClienteNegocio validacion = new ClienteNegocio();

                if (!HayIdEnQueryString() && validacion.ExisteCuitCliente(cuit))
                {
                    mostrarError("el cuit ingresado ya se encuentra en uso");
                    return;
                }

                if (HayIdEnQueryString())
                {
                    int id = int.Parse(Request.QueryString["id"]);

                    Cliente clienteExiste = validacion.listarPorId(id);

                    if (clienteExiste != null && clienteExiste.Cuit != cuit)
                    {
                        if (validacion.ExisteCuitCliente(cuit))
                        {
                            mostrarError("El cuit ya pertenece a otro cliente");
                            return;
                        }
                    }
                }
            }

            try
            {
                ClienteNegocio negocio = new ClienteNegocio();

                if (HayIdEnQueryString())
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    Cliente cliente = negocio.listarPorId(id);

                    if (cliente == null)
                    {
                        Response.Redirect("Clientes.aspx");
                        return;
                    }

                    cliente.Nombre = txtNombre.Text.Trim();
                    cliente.Cuit = txtCuit.Text.Trim();
                    cliente.Telefono = txtTelefono.Text.Trim();
                    cliente.Email = email;
                    cliente.Direccion = txtDireccion.Text.Trim();

                    negocio.modificar(cliente);
                    Session["MensajeExito"] = "Cliente modificado correctamente.";
                }
                else
                {
                    Cliente nuevo = new Cliente();
                    nuevo.Nombre = txtNombre.Text.Trim();
                    nuevo.Cuit = txtCuit.Text.Trim();
                    nuevo.Telefono = txtTelefono.Text.Trim();
                    nuevo.Email = email;
                    nuevo.Direccion = txtDireccion.Text.Trim();
                    nuevo.Activo = true;

                    negocio.agregar(nuevo);
                    Session["MensajeExito"] = "Cliente agregado correctamente.";
                }

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

        private bool HayIdEnQueryString()
        {
            return !string.IsNullOrWhiteSpace(Request.QueryString["id"]);
        }

        private void cargarCliente()
        {
            int id = int.Parse(Request.QueryString["id"]);
            ClienteNegocio negocio = new ClienteNegocio();
            Cliente cliente = negocio.listarPorId(id);

            if (cliente == null)
            {
                Response.Redirect("Clientes.aspx");
                return;
            }

            txtNombre.Text = cliente.Nombre;
            txtCuit.Text = cliente.Cuit;
            txtTelefono.Text = cliente.Telefono;
            txtEmail.Text = cliente.Email;
            txtDireccion.Text = cliente.Direccion;
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