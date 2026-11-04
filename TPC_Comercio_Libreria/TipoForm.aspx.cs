using System;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class TipoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;

                if (HayIdEnQueryString())
                {
                    lblTitulo.Text = "Editar tipo";
                    lblSubtitulo.Text = "Modificá los datos del tipo";
                    cargarTipo();
                }
                else
                {
                    lblTitulo.Text = "Nuevo tipo";
                    lblSubtitulo.Text = "Completá los datos para dar de alta un tipo";
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                mostrarError("La descripción es obligatoria.");
                return;
            }

            try
            {
                TipoNegocio negocio = new TipoNegocio();

                if (HayIdEnQueryString())
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    Tipo tipo = negocio.listarPorId(id);

                    if (tipo == null)
                    {
                        Response.Redirect("Tipos.aspx");
                        return;
                    }

                    tipo.Descripcion = txtDescripcion.Text.Trim();

                    negocio.modificar(tipo);
                    Session["MensajeExito"] = "Tipo modificado correctamente.";
                }
                else
                {
                    Tipo nuevo = new Tipo();
                    nuevo.Descripcion = txtDescripcion.Text.Trim();
                    nuevo.Activo = true;

                    negocio.agregar(nuevo);
                    Session["MensajeExito"] = "Tipo agregado correctamente.";
                }

                Response.Redirect("Tipos.aspx");
            }
            catch (Exception ex)
            {
                mostrarError("Error al guardar: " + ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tipos.aspx");
        }

        private bool HayIdEnQueryString()
        {
            return !string.IsNullOrWhiteSpace(Request.QueryString["id"]);
        }

        private void cargarTipo()
        {
            int id = int.Parse(Request.QueryString["id"]);
            TipoNegocio negocio = new TipoNegocio();
            Tipo tipo = negocio.listarPorId(id);

            if (tipo == null)
            {
                Response.Redirect("Tipos.aspx");
                return;
            }

            txtDescripcion.Text = tipo.Descripcion;
        }

        private void mostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
    }
}