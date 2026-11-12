using System;
using Dominio;
using Negocio;

namespace TPC_Comercio_Libreria
{
    public partial class MarcaForm : PaginaSoloAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;

                if (HayIdEnQueryString())
                {
                    lblTitulo.Text = "Editar marca";
                    lblSubtitulo.Text = "Modificá los datos de la marca";
                    cargarMarca();
                }
                else
                {
                    lblTitulo.Text = "Nueva marca";
                    lblSubtitulo.Text = "Completá los datos para dar de alta una marca";
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
                MarcaNegocio negocio = new MarcaNegocio();

                if (HayIdEnQueryString())
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    Marca marca = negocio.listarPorId(id);

                    if (marca == null)
                    {
                        Response.Redirect("Marcas.aspx");
                        return;
                    }

                    marca.Descripcion = txtDescripcion.Text.Trim();
                    // marca.Activo se mantiene tal como vino de la base

                    negocio.modificar(marca);
                    Session["MensajeExito"] = "Marca modificada correctamente.";
                }
                else
                {
                    Marca nueva = new Marca();
                    nueva.Descripcion = txtDescripcion.Text.Trim();
                    nueva.Activo = true;

                    negocio.agregar(nueva);
                    Session["MensajeExito"] = "Marca agregada correctamente.";
                }

                Response.Redirect("Marcas.aspx");
            }
            catch (Exception ex)
            {
                mostrarError("Error al guardar: " + ex.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marcas.aspx");
        }

        private bool HayIdEnQueryString()
        {
            return !string.IsNullOrWhiteSpace(Request.QueryString["id"]);
        }

        private void cargarMarca()
        {
            int id = int.Parse(Request.QueryString["id"]);
            MarcaNegocio negocio = new MarcaNegocio();
            Marca marca = negocio.listarPorId(id);

            if (marca == null)
            {
                Response.Redirect("Marcas.aspx");
                return;
            }

            txtDescripcion.Text = marca.Descripcion;
        }

        private void mostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            lblError.Visible = true;
        }
    }
}