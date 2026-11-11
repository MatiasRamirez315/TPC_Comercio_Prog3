using System;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class ProveedorForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;

                if (HayIdEnQueryString())
                {
                    lblTitulo.Text = "Editar proveedor";
                    lblSubtitulo.Text = "Modificá los datos del proveedor";
                    cargarProveedor();
                }
                else
                {
                    lblTitulo.Text = "Nuevo proveedor";
                    lblSubtitulo.Text = "Completá los datos para dar de alta un proveedor";
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
                ProveedorNegocio validacion = new ProveedorNegocio();

                if (!HayIdEnQueryString() && validacion.ExisteCuitProveedor(cuit))
                {
                    mostrarError("el cuit ingresado ya se encuentra en uso");
                    return;
                }

                if (HayIdEnQueryString())
                {
                    int id = int.Parse(Request.QueryString["id"]);

                    Proveedor proveedorExiste = validacion.listarPorId(id);

                    if (proveedorExiste != null && proveedorExiste.Cuit != cuit)
                    {
                        if (validacion.ExisteCuitProveedor(cuit))
                        {
                            mostrarError("El cuit ya pertenece a otro proveedor");
                            return;
                        }
                    }
                }
            }

            try
            {
                ProveedorNegocio negocio = new ProveedorNegocio();

                if (HayIdEnQueryString())
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    Proveedor proveedor = negocio.listarPorId(id);

                    if (proveedor == null)
                    {
                        Response.Redirect("Proveedores.aspx");
                        return;
                    }

                    proveedor.Nombre = txtNombre.Text.Trim();
                    proveedor.Descripcion = txtDescripcion.Text.Trim();
                    proveedor.Cuit = txtCuit.Text.Trim();
                    proveedor.Telefono = txtTelefono.Text.Trim();
                    proveedor.Email = email;

                    negocio.modificar(proveedor);
                    Session["MensajeExito"] = "Proveedor modificado correctamente.";
                }
                else
                {
                    Proveedor nuevo = new Proveedor();
                    nuevo.Nombre = txtNombre.Text.Trim();
                    nuevo.Descripcion = txtDescripcion.Text.Trim();
                    nuevo.Cuit = txtCuit.Text.Trim();
                    nuevo.Telefono = txtTelefono.Text.Trim();
                    nuevo.Email = email;
                    nuevo.Activo = true;

                    negocio.agregar(nuevo);
                    Session["MensajeExito"] = "Proveedor agregado correctamente.";
                }

                Response.Redirect("Proveedores.aspx");
            }
            catch (Exception ex)
            {
                mostrarError("Error al guardar: " + ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }

        private bool HayIdEnQueryString()
        {
            return !string.IsNullOrWhiteSpace(Request.QueryString["id"]);
        }

        private void cargarProveedor()
        {
            int id = int.Parse(Request.QueryString["id"]);
            ProveedorNegocio negocio = new ProveedorNegocio();
            Proveedor proveedor = negocio.listarPorId(id);

            if (proveedor == null)
            {
                Response.Redirect("Proveedores.aspx");
                return;
            }

            txtNombre.Text = proveedor.Nombre;
            txtDescripcion.Text = proveedor.Descripcion;
            txtCuit.Text = proveedor.Cuit;
            txtTelefono.Text = proveedor.Telefono;
            txtEmail.Text = proveedor.Email;
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